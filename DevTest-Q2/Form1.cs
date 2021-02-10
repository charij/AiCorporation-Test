using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace aiCorporation
{
    public partial class Form1 : Form
    {
        private string m_szPathToStoreFailedJsonFiles;

        public Form1()
        {
            string szPathToStoreFailedJsonFiles;

            InitializeComponent();

            szPathToStoreFailedJsonFiles = ConfigurationManager.AppSettings["PathToStoreFailedJsonFiles"];

            if (!String.IsNullOrEmpty(szPathToStoreFailedJsonFiles))
            {
                m_szPathToStoreFailedJsonFiles = szPathToStoreFailedJsonFiles.Replace("@@APPDIR@@", AppDomain.CurrentDomain.BaseDirectory);

                if (!Directory.Exists(m_szPathToStoreFailedJsonFiles))
                {
                    Directory.CreateDirectory(m_szPathToStoreFailedJsonFiles);
                }
            }
        }

        private void tbSingleFileClear_Click(object sender, EventArgs e)
        {
            tbSingleFileLog.Clear();
            wbWebBrowser.DocumentText = "";
        }

        private void btParse_Click(object sender, EventArgs e)
        {
            JsonParser jpJsonParser;
            string szHtmlString;

            jpJsonParser = new JsonParser();

            try
            {
                if (!jpJsonParser.ParseFile(tbJSONFilename.Text))
                {
                    tbSingleFileLog.AppendText("Couldn't parse Json file\r\n");
                }
                else
                {
                    tbSingleFileLog.AppendText("Successfully parsed Json file\r\n");
                    szHtmlString = jpJsonParser.ToHtmlString(true);
                    wbWebBrowser.DocumentText = szHtmlString;
                }
            }
            catch (Exception exc)
            {
                tbSingleFileLog.AppendText(exc.ToString() + "\r\n");
            }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            DialogResult drDialogResult;
            OpenFileDialog ofdOpenFileDialog;

            ofdOpenFileDialog = new OpenFileDialog();

            ofdOpenFileDialog.Multiselect = false;
            ofdOpenFileDialog.DefaultExt = "*.json";
            ofdOpenFileDialog.Filter = "JSON Files (*.json)|*.json;|All Files (*.*)|*.*";
            ofdOpenFileDialog.InitialDirectory = GetFilePath(tbJSONFilename.Text);

            drDialogResult = ofdOpenFileDialog.ShowDialog(this);

            if (drDialogResult == DialogResult.OK)
            {
                tbJSONFilename.Text = ofdOpenFileDialog.FileName;
            }
        }
        public static string GetFilePath(string szFullFilePath)
        {
            string szReturnValue = null;
            int nCount = 0;
            bool boFound = false;

            if (String.IsNullOrEmpty(szFullFilePath))
            {
                return (null);
            }

            nCount = szFullFilePath.Length - 1;

            while (!boFound &&
                   nCount >= 0)
            {
                if (szFullFilePath[nCount] == '\\' ||
                    szFullFilePath[nCount] == '/')
                {
                    szReturnValue = szFullFilePath.Substring(0, nCount + 1);
                    boFound = true;
                }
                else
                {
                    nCount--;
                }
            }

            return (szReturnValue);
        }

        private bool RunBulkTest(TestValidator tvTestValidator, out string szStatusMessage)
        {
            bool boReturnValue;
            string szJsonString;
            List<JsonValue> ljvJsonValueList;
            int nCount;
            JsonParser jpJsonParser;
            JsonObject joJsonObject;
            bool boObjectsEqual;
            int nErrors;
            string szJsonFilename;

            szStatusMessage = null;
            boReturnValue = false;

            szJsonString = tvTestValidator.GenerateRandomJson(out ljvJsonValueList, out szJsonFilename);

            jpJsonParser = new JsonParser();

            if (!jpJsonParser.ParseBuffer(szJsonString))
            {
                szStatusMessage = String.Format("Couldn't parse Json string:\r\n{0}", szJsonString);
                File.WriteAllText(String.Format("{0}\\{1}", m_szPathToStoreFailedJsonFiles, szJsonFilename), szJsonString);
            }
            else
            {
                nErrors = 0;

                for (nCount = 0; nCount < ljvJsonValueList.Count; nCount++)
                {
                    szStatusMessage = null;

                    joJsonObject = jpJsonParser.GetObject(ljvJsonValueList[nCount].JsonPath);

                    if (joJsonObject == null)
                    {
                        szStatusMessage = String.Format("COULDN'T READ VALUE. Expected value: {0}", ljvJsonValueList[nCount].RawValue);
                        nErrors++;
                    }
                    else
                    {
                        boObjectsEqual = ljvJsonValueList[nCount].EqualTo(joJsonObject);

                        if (!boObjectsEqual)
                        {
                            szStatusMessage = String.Format("read value [{0}] doesn't match expected value: {1}", joJsonObject.RawValue, ljvJsonValueList[nCount].RawValue);
                            nErrors++;
                        }
                    }
                }

                if (nErrors == 0)
                {
                    szStatusMessage = "SUCCESS";
                    boReturnValue = true;
                }
                else
                {
                    szStatusMessage = "FAILED";
                    boReturnValue = false;
                    File.WriteAllText(String.Format("{0}\\{1}", m_szPathToStoreFailedJsonFiles, szJsonFilename), szJsonString);
                }

                szStatusMessage = String.Format("{0}! Finished with {1} error(s)", szStatusMessage, nErrors);
            }

            return (boReturnValue);
        }

        private void btRunBulkTest_Click(object sender, EventArgs e)
        {
            TestValidator tvTestValidator;
            string szStatusMessage;
            bool boAtLeastOneFailed = false;
            int nBulkRounds;
            int nCount;

            try
            {
                tvTestValidator = new TestValidator(Convert.ToInt32(tbMaxObjectDepth.Text),
                    Convert.ToInt32(tbMinNumberOfFieldsInObjects.Text),
                    Convert.ToInt32(tbMaxNumberOfFieldsInObjects.Text),
                    Convert.ToInt32(tbMinNumberOfArrayItems.Text),
                    Convert.ToInt32(tbMaxNumberOfArrayItems.Text),
                    Convert.ToInt32(tbMinFieldNameLength.Text),
                    Convert.ToInt32(tbMaxFieldNameLength.Text),
                    Convert.ToInt32(tbMinStringValueLength.Text),
                    Convert.ToInt32(tbMaxStringValueLength.Text),
                    Convert.ToInt32(tbMinIntegerValue.Text),
                    Convert.ToInt32(tbMaxIntegerValue.Text),
                    Convert.ToInt32(tbMinDateTimeRange.Text),
                    Convert.ToInt32(tbMaxDateTimeRange.Text),
                    Convert.ToInt32(tbMinFloatRange.Text),
                    Convert.ToInt32(tbMaxFloatRange.Text),
                    Convert.ToInt32(tbMinFloatDecimalPlaces.Text),
                    Convert.ToInt32(tbMaxFloatDecimalPlaces.Text));

                nBulkRounds = Convert.ToInt32(tbBulkTestRounds.Text);

                for (nCount = 0; nCount < nBulkRounds; nCount++)
                {
                    if (!RunBulkTest(tvTestValidator, out szStatusMessage))
                    {
                        boAtLeastOneFailed = true;
                    }

                    if (!String.IsNullOrEmpty(szStatusMessage))
                    {
                        tbBulkTestLog.AppendText(String.Format("Test run {0}: {1}\r\n", nCount, szStatusMessage));
                    }
                }

                if (boAtLeastOneFailed)
                {
                    tbBulkTestLog.AppendText("Bulk test run failed!\r\n");
                }
                else
                {
                    tbBulkTestLog.AppendText("Bulk test run succeeded!\r\n");
                }
            }
            catch (Exception exc)
            {
                tbBulkTestLog.AppendText(exc.ToString() + "\r\n");
            }
        }

        private void btBulkTestClear_Click(object sender, EventArgs e)
        {
            tbBulkTestLog.Clear();
        }

        private void llHelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FileGenHelpForm fghfFileGenHelpForm;

            fghfFileGenHelpForm = new FileGenHelpForm();

            fghfFileGenHelpForm.ShowDialog();
        }
    }
}