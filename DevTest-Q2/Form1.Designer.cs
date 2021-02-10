namespace aiCorporation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btParse = new System.Windows.Forms.Button();
            this.btBrowse = new System.Windows.Forms.Button();
            this.tbJSONFilename = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.wbWebBrowser = new System.Windows.Forms.WebBrowser();
            this.tbSingleFileClear = new System.Windows.Forms.Button();
            this.tbSingleFileLog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbBulkTestRounds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaxObjectDepth = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbMaxFloatDecimalPlaces = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMaxDateTimeRange = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbMinDateTimeRange = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbMaxIntegerValue = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbMaxFieldNameLength = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbMinFieldNameLength = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbMaxNumberOfArrayItems = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbMinFloatDecimalPlaces = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMaxFloatRange = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMinFloatRange = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbMinIntegerValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMaxStringValueLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMinStringValueLength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMinNumberOfArrayItems = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMaxNumberOfFieldsInObjects = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMinNumberOfFieldsInObjects = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btRunBulkTest = new System.Windows.Forms.Button();
            this.btBulkTestClear = new System.Windows.Forms.Button();
            this.tbBulkTestLog = new System.Windows.Forms.TextBox();
            this.llHelpLink = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1222, 739);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.wbWebBrowser);
            this.tabPage1.Controls.Add(this.tbSingleFileClear);
            this.tabPage1.Controls.Add(this.tbSingleFileLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1214, 713);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parse Single File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btParse);
            this.groupBox2.Controls.Add(this.btBrowse);
            this.groupBox2.Controls.Add(this.tbJSONFilename);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(6, 649);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1202, 58);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parse Single File";
            // 
            // btParse
            // 
            this.btParse.Location = new System.Drawing.Point(1121, 21);
            this.btParse.Name = "btParse";
            this.btParse.Size = new System.Drawing.Size(75, 23);
            this.btParse.TabIndex = 22;
            this.btParse.Text = "Parse";
            this.btParse.UseVisualStyleBackColor = true;
            this.btParse.Click += new System.EventHandler(this.btParse_Click);
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(641, 21);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(27, 23);
            this.btBrowse.TabIndex = 21;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // tbJSONFilename
            // 
            this.tbJSONFilename.Location = new System.Drawing.Point(106, 23);
            this.tbJSONFilename.Name = "tbJSONFilename";
            this.tbJSONFilename.Size = new System.Drawing.Size(529, 20);
            this.tbJSONFilename.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "JSON File";
            // 
            // wbWebBrowser
            // 
            this.wbWebBrowser.Location = new System.Drawing.Point(6, 107);
            this.wbWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbWebBrowser.Name = "wbWebBrowser";
            this.wbWebBrowser.Size = new System.Drawing.Size(1202, 536);
            this.wbWebBrowser.TabIndex = 22;
            // 
            // tbSingleFileClear
            // 
            this.tbSingleFileClear.Location = new System.Drawing.Point(1133, 78);
            this.tbSingleFileClear.Name = "tbSingleFileClear";
            this.tbSingleFileClear.Size = new System.Drawing.Size(75, 23);
            this.tbSingleFileClear.TabIndex = 21;
            this.tbSingleFileClear.Text = "Clear";
            this.tbSingleFileClear.UseVisualStyleBackColor = true;
            this.tbSingleFileClear.Click += new System.EventHandler(this.tbSingleFileClear_Click);
            // 
            // tbSingleFileLog
            // 
            this.tbSingleFileLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbSingleFileLog.Location = new System.Drawing.Point(6, 6);
            this.tbSingleFileLog.Multiline = true;
            this.tbSingleFileLog.Name = "tbSingleFileLog";
            this.tbSingleFileLog.ReadOnly = true;
            this.tbSingleFileLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSingleFileLog.Size = new System.Drawing.Size(1202, 64);
            this.tbSingleFileLog.TabIndex = 20;
            this.tbSingleFileLog.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btBulkTestClear);
            this.tabPage2.Controls.Add(this.tbBulkTestLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1214, 713);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bulk Test";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llHelpLink);
            this.groupBox1.Controls.Add(this.tbBulkTestRounds);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbMaxObjectDepth);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tbMaxFloatDecimalPlaces);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbMaxDateTimeRange);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbMinDateTimeRange);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tbMaxIntegerValue);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.tbMaxFieldNameLength);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbMinFieldNameLength);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbMaxNumberOfArrayItems);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.tbMinFloatDecimalPlaces);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbMaxFloatRange);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbMinFloatRange);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbMinIntegerValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbMaxStringValueLength);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbMinStringValueLength);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbMinNumberOfArrayItems);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbMaxNumberOfFieldsInObjects);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbMinNumberOfFieldsInObjects);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btRunBulkTest);
            this.groupBox1.Location = new System.Drawing.Point(6, 522);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1202, 184);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bulk Test";
            // 
            // tbBulkTestRounds
            // 
            this.tbBulkTestRounds.Location = new System.Drawing.Point(1064, 149);
            this.tbBulkTestRounds.Name = "tbBulkTestRounds";
            this.tbBulkTestRounds.Size = new System.Drawing.Size(51, 20);
            this.tbBulkTestRounds.TabIndex = 58;
            this.tbBulkTestRounds.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(966, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Bulk Test Rounds";
            // 
            // tbMaxObjectDepth
            // 
            this.tbMaxObjectDepth.Location = new System.Drawing.Point(814, 127);
            this.tbMaxObjectDepth.Name = "tbMaxObjectDepth";
            this.tbMaxObjectDepth.Size = new System.Drawing.Size(51, 20);
            this.tbMaxObjectDepth.TabIndex = 56;
            this.tbMaxObjectDepth.Text = "5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(619, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "Max Object Depth";
            // 
            // tbMaxFloatDecimalPlaces
            // 
            this.tbMaxFloatDecimalPlaces.Location = new System.Drawing.Point(814, 101);
            this.tbMaxFloatDecimalPlaces.Name = "tbMaxFloatDecimalPlaces";
            this.tbMaxFloatDecimalPlaces.Size = new System.Drawing.Size(51, 20);
            this.tbMaxFloatDecimalPlaces.TabIndex = 54;
            this.tbMaxFloatDecimalPlaces.Text = "3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(619, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Max Float Decimal Places";
            // 
            // tbMaxDateTimeRange
            // 
            this.tbMaxDateTimeRange.Location = new System.Drawing.Point(509, 153);
            this.tbMaxDateTimeRange.Name = "tbMaxDateTimeRange";
            this.tbMaxDateTimeRange.Size = new System.Drawing.Size(51, 20);
            this.tbMaxDateTimeRange.TabIndex = 52;
            this.tbMaxDateTimeRange.Text = "100";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(313, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Max DateTime Range";
            // 
            // tbMinDateTimeRange
            // 
            this.tbMinDateTimeRange.Location = new System.Drawing.Point(509, 127);
            this.tbMinDateTimeRange.Name = "tbMinDateTimeRange";
            this.tbMinDateTimeRange.Size = new System.Drawing.Size(51, 20);
            this.tbMinDateTimeRange.TabIndex = 50;
            this.tbMinDateTimeRange.Text = "-100";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(313, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 49;
            this.label15.Text = "Min DateTime Range";
            // 
            // tbMaxIntegerValue
            // 
            this.tbMaxIntegerValue.Location = new System.Drawing.Point(509, 101);
            this.tbMaxIntegerValue.Name = "tbMaxIntegerValue";
            this.tbMaxIntegerValue.Size = new System.Drawing.Size(51, 20);
            this.tbMaxIntegerValue.TabIndex = 48;
            this.tbMaxIntegerValue.Text = "2000";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(313, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "Max Integer Value";
            // 
            // tbMaxFieldNameLength
            // 
            this.tbMaxFieldNameLength.Location = new System.Drawing.Point(205, 153);
            this.tbMaxFieldNameLength.Name = "tbMaxFieldNameLength";
            this.tbMaxFieldNameLength.Size = new System.Drawing.Size(51, 20);
            this.tbMaxFieldNameLength.TabIndex = 46;
            this.tbMaxFieldNameLength.Text = "15";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 156);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Max Field Name Length";
            // 
            // tbMinFieldNameLength
            // 
            this.tbMinFieldNameLength.Location = new System.Drawing.Point(205, 127);
            this.tbMinFieldNameLength.Name = "tbMinFieldNameLength";
            this.tbMinFieldNameLength.Size = new System.Drawing.Size(51, 20);
            this.tbMinFieldNameLength.TabIndex = 44;
            this.tbMinFieldNameLength.Text = "3";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "Min Field Name Length";
            // 
            // tbMaxNumberOfArrayItems
            // 
            this.tbMaxNumberOfArrayItems.Location = new System.Drawing.Point(205, 101);
            this.tbMaxNumberOfArrayItems.Name = "tbMaxNumberOfArrayItems";
            this.tbMaxNumberOfArrayItems.Size = new System.Drawing.Size(51, 20);
            this.tbMaxNumberOfArrayItems.TabIndex = 42;
            this.tbMaxNumberOfArrayItems.Text = "10";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(121, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "Max Num Of Array Items";
            // 
            // tbMinFloatDecimalPlaces
            // 
            this.tbMinFloatDecimalPlaces.Location = new System.Drawing.Point(814, 75);
            this.tbMinFloatDecimalPlaces.Name = "tbMinFloatDecimalPlaces";
            this.tbMinFloatDecimalPlaces.Size = new System.Drawing.Size(51, 20);
            this.tbMinFloatDecimalPlaces.TabIndex = 40;
            this.tbMinFloatDecimalPlaces.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(619, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Min Float Decimal Places";
            // 
            // tbMaxFloatRange
            // 
            this.tbMaxFloatRange.Location = new System.Drawing.Point(814, 49);
            this.tbMaxFloatRange.Name = "tbMaxFloatRange";
            this.tbMaxFloatRange.Size = new System.Drawing.Size(51, 20);
            this.tbMaxFloatRange.TabIndex = 38;
            this.tbMaxFloatRange.Text = "200";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(619, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Max Float Range";
            // 
            // tbMinFloatRange
            // 
            this.tbMinFloatRange.Location = new System.Drawing.Point(814, 23);
            this.tbMinFloatRange.Name = "tbMinFloatRange";
            this.tbMinFloatRange.Size = new System.Drawing.Size(51, 20);
            this.tbMinFloatRange.TabIndex = 36;
            this.tbMinFloatRange.Text = "-200";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(619, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Min Float Range";
            // 
            // tbMinIntegerValue
            // 
            this.tbMinIntegerValue.Location = new System.Drawing.Point(509, 75);
            this.tbMinIntegerValue.Name = "tbMinIntegerValue";
            this.tbMinIntegerValue.Size = new System.Drawing.Size(51, 20);
            this.tbMinIntegerValue.TabIndex = 34;
            this.tbMinIntegerValue.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Min Integer Value";
            // 
            // tbMaxStringValueLength
            // 
            this.tbMaxStringValueLength.Location = new System.Drawing.Point(509, 49);
            this.tbMaxStringValueLength.Name = "tbMaxStringValueLength";
            this.tbMaxStringValueLength.Size = new System.Drawing.Size(51, 20);
            this.tbMaxStringValueLength.TabIndex = 32;
            this.tbMaxStringValueLength.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Max String Value Length";
            // 
            // tbMinStringValueLength
            // 
            this.tbMinStringValueLength.Location = new System.Drawing.Point(509, 23);
            this.tbMinStringValueLength.Name = "tbMinStringValueLength";
            this.tbMinStringValueLength.Size = new System.Drawing.Size(51, 20);
            this.tbMinStringValueLength.TabIndex = 30;
            this.tbMinStringValueLength.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Min String Value Length";
            // 
            // tbMinNumberOfArrayItems
            // 
            this.tbMinNumberOfArrayItems.Location = new System.Drawing.Point(205, 75);
            this.tbMinNumberOfArrayItems.Name = "tbMinNumberOfArrayItems";
            this.tbMinNumberOfArrayItems.Size = new System.Drawing.Size(51, 20);
            this.tbMinNumberOfArrayItems.TabIndex = 28;
            this.tbMinNumberOfArrayItems.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Min Num Of Array Items";
            // 
            // tbMaxNumberOfFieldsInObjects
            // 
            this.tbMaxNumberOfFieldsInObjects.Location = new System.Drawing.Point(205, 49);
            this.tbMaxNumberOfFieldsInObjects.Name = "tbMaxNumberOfFieldsInObjects";
            this.tbMaxNumberOfFieldsInObjects.Size = new System.Drawing.Size(51, 20);
            this.tbMaxNumberOfFieldsInObjects.TabIndex = 26;
            this.tbMaxNumberOfFieldsInObjects.Text = "15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Max Num Of Fields In Objects";
            // 
            // tbMinNumberOfFieldsInObjects
            // 
            this.tbMinNumberOfFieldsInObjects.Location = new System.Drawing.Point(205, 23);
            this.tbMinNumberOfFieldsInObjects.Name = "tbMinNumberOfFieldsInObjects";
            this.tbMinNumberOfFieldsInObjects.Size = new System.Drawing.Size(51, 20);
            this.tbMinNumberOfFieldsInObjects.TabIndex = 24;
            this.tbMinNumberOfFieldsInObjects.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Min Num Of Fields In Objects";
            // 
            // btRunBulkTest
            // 
            this.btRunBulkTest.Location = new System.Drawing.Point(1121, 127);
            this.btRunBulkTest.Name = "btRunBulkTest";
            this.btRunBulkTest.Size = new System.Drawing.Size(75, 46);
            this.btRunBulkTest.TabIndex = 22;
            this.btRunBulkTest.Text = "Run Bulk Test";
            this.btRunBulkTest.UseVisualStyleBackColor = true;
            this.btRunBulkTest.Click += new System.EventHandler(this.btRunBulkTest_Click);
            // 
            // btBulkTestClear
            // 
            this.btBulkTestClear.Location = new System.Drawing.Point(1133, 493);
            this.btBulkTestClear.Name = "btBulkTestClear";
            this.btBulkTestClear.Size = new System.Drawing.Size(75, 23);
            this.btBulkTestClear.TabIndex = 23;
            this.btBulkTestClear.Text = "Clear";
            this.btBulkTestClear.UseVisualStyleBackColor = true;
            this.btBulkTestClear.Click += new System.EventHandler(this.btBulkTestClear_Click);
            // 
            // tbBulkTestLog
            // 
            this.tbBulkTestLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbBulkTestLog.Location = new System.Drawing.Point(6, 6);
            this.tbBulkTestLog.Multiline = true;
            this.tbBulkTestLog.Name = "tbBulkTestLog";
            this.tbBulkTestLog.ReadOnly = true;
            this.tbBulkTestLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbBulkTestLog.Size = new System.Drawing.Size(1202, 481);
            this.tbBulkTestLog.TabIndex = 22;
            this.tbBulkTestLog.WordWrap = false;
            // 
            // llHelpLink
            // 
            this.llHelpLink.AutoSize = true;
            this.llHelpLink.Location = new System.Drawing.Point(619, 156);
            this.llHelpLink.Name = "llHelpLink";
            this.llHelpLink.Size = new System.Drawing.Size(149, 13);
            this.llHelpLink.TabIndex = 60;
            this.llHelpLink.TabStop = true;
            this.llHelpLink.Text = "What Do These Fields Mean?";
            this.llHelpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llHelpLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 763);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSON Parsing";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btParse;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TextBox tbJSONFilename;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.WebBrowser wbWebBrowser;
        private System.Windows.Forms.Button tbSingleFileClear;
        private System.Windows.Forms.TextBox tbSingleFileLog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbBulkTestRounds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaxObjectDepth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbMaxFloatDecimalPlaces;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbMaxDateTimeRange;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbMinDateTimeRange;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbMaxIntegerValue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbMaxFieldNameLength;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbMinFieldNameLength;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbMaxNumberOfArrayItems;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbMinFloatDecimalPlaces;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMaxFloatRange;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbMinFloatRange;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbMinIntegerValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMaxStringValueLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMinStringValueLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMinNumberOfArrayItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMaxNumberOfFieldsInObjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMinNumberOfFieldsInObjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btRunBulkTest;
        private System.Windows.Forms.Button btBulkTestClear;
        private System.Windows.Forms.TextBox tbBulkTestLog;
        private System.Windows.Forms.LinkLabel llHelpLink;
    }
}

