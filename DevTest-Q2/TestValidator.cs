using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aiCorporation
{
    public class JsonValue
    {
        private string m_szJsonPath;
        private object m_oValue;
        private string m_szRawValue;
        private JSON_VALUE_TYPE m_jvtJsonValueType;

        public string JsonPath { get { return (m_szJsonPath); } }
        public object Value { get { return (m_oValue); } }
        public string RawValue
        {
            get
            {
                //string szValue = null;

                //switch(m_jvtJsonValueType)
                //{
                //    case JSON_VALUE_TYPE.BOOLEAN:
                //        szValue = m_szValue;// Convert.ToBoolean(m_szValue).ToString();
                //        break;
                //    case JSON_VALUE_TYPE.DATE_TIME:
                //        szValue = m_szValue;// Convert.ToDateTime(m_szValue).ToString("dd/MM/yyyy HH:mm:ss");
                //        break;
                //    case JSON_VALUE_TYPE.FLOAT:
                //    case JSON_VALUE_TYPE.INTEGER:
                //    case JSON_VALUE_TYPE.NULL:
                //    case JSON_VALUE_TYPE.STRING:
                //        szValue = m_szValue;
                //        break;
                //}

                //return (szValue);
                return (m_szRawValue);
            }
        }
        public JSON_VALUE_TYPE JsonValueType { get { return (m_jvtJsonValueType); } }

        public bool EqualTo(JsonObject joJsonObject)
        {
            bool boObjectsEqual;
            string szValue1;
            int nValue1;
            double lfValue1;
            DateTime dtValue1;
            bool boValue1;
            string szValue2;
            int nValue2;
            double lfValue2;
            DateTime dtValue2;
            bool boValue2;

            boObjectsEqual = false;

            switch (joJsonObject.JsonValueType)
            {
                case JSON_VALUE_TYPE.BOOLEAN:
                    boValue1 = (bool)m_oValue;
                    boValue2 = (bool)joJsonObject.Value;
                    boObjectsEqual = boValue1 == boValue2;
                    break;
                case JSON_VALUE_TYPE.DATE_TIME:
                    dtValue1 = (DateTime)m_oValue;
                    dtValue2 = (DateTime)joJsonObject.Value;
                    boObjectsEqual = dtValue1 == dtValue2;
                    break;
                case JSON_VALUE_TYPE.FLOAT:
                    lfValue1 = (double)m_oValue;
                    lfValue2 = (double)joJsonObject.Value;
                    boObjectsEqual = lfValue1 == lfValue2;
                    break;
                case JSON_VALUE_TYPE.INTEGER:
                    nValue1 = Convert.ToInt32(m_oValue);
                    nValue2 = Convert.ToInt32(joJsonObject.Value);
                    boObjectsEqual = nValue1 == nValue2;
                    break;
                case JSON_VALUE_TYPE.NULL:
                    if (m_oValue == null &&
                        joJsonObject.Value == null)
                    {
                        boObjectsEqual = true;
                    }
                    break;
                case JSON_VALUE_TYPE.STRING:
                    szValue1 = m_oValue as string;
                    szValue2 = joJsonObject.Value as string;
                    boObjectsEqual = szValue1 == szValue2;
                    break;
            }

            return (boObjectsEqual);
        }

        public JsonValue(string szJsonPath,
                         object oValue,
                         string szRawValue,
                         JSON_VALUE_TYPE jvtJsonValueType)
        {
            m_szJsonPath = szJsonPath;
            m_oValue = oValue;
            m_szRawValue = szRawValue;
            m_jvtJsonValueType = jvtJsonValueType;
        }
    }
    public class JsonValueList
    {
        private List<JsonValue> m_ljvJsonValueList;

        //private static string GetArrayNameAndIndex(string szName, out int nIndex)
        //{
        //    string szReturnString;
        //    int nCount = 0;
        //    string szSubString;
        //    bool boFound = false;
        //    bool boAbort = false;
        //    bool boAtLeastOneDigitFound = false;

        //    if (szName == "")
        //    {
        //        nIndex = 0;
        //        return (szName);
        //    }

        //    szReturnString = szName;
        //    nIndex = 0;

        //    if (szName[szName.Length - 1] == ']')
        //    {
        //        nCount = szName.Length - 2;

        //        while (!boFound &&
        //               !boAbort &&
        //               nCount >= 0)
        //        {
        //            // if we've found the closing array brace
        //            if (szName[nCount] == '[')
        //            {
        //                boFound = true;
        //            }
        //            else
        //            {
        //                if (!Char.IsDigit(szName[nCount]))
        //                {
        //                    boAbort = true;
        //                }
        //                else
        //                {
        //                    boAtLeastOneDigitFound = true;
        //                    nCount--;
        //                }
        //            }
        //        }

        //        // did we finish successfully?
        //        if (boFound &&
        //            boAtLeastOneDigitFound)
        //        {
        //            szSubString = szName.Substring(nCount + 1, szName.Length - nCount - 2);
        //            szReturnString = szName.Substring(0, nCount);
        //            nIndex = System.Convert.ToInt32(szSubString);
        //        }
        //    }

        //    return (szReturnString);
        //}

        //private static List<string> GetStringListFromCharSeparatedString(string szString, char cDelimiter)
        //{
        //    int nCount = 0;
        //    int nLastCount = -1;
        //    string szSubString;
        //    int nStringLength;
        //    List<string> lszStringList;

        //    if (szString == null ||
        //        szString == "" ||
        //        cDelimiter.ToString() == "")
        //    {
        //        return (new List<string>());
        //    }

        //    lszStringList = new List<string>();

        //    nStringLength = szString.Length;

        //    for (nCount = 0; nCount < nStringLength; nCount++)
        //    {
        //        if (szString[nCount] == cDelimiter)
        //        {
        //            szSubString = szString.Substring(nLastCount + 1, nCount - nLastCount - 1);
        //            nLastCount = nCount;
        //            lszStringList.Add(szSubString);

        //            if (nCount == nStringLength)
        //            {
        //                lszStringList.Add("");
        //            }
        //        }
        //        else
        //        {
        //            if (nCount == nStringLength - 1)
        //            {
        //                szSubString = szString.Substring(nLastCount + 1, nCount - nLastCount);
        //                lszStringList.Add(szSubString);
        //            }
        //        }
        //    }

        //    return (lszStringList);
        //}

        public int Count { get { return (m_ljvJsonValueList.Count); } }

        public JsonValue this[int nIndex]
        {
            get
            {
                if (nIndex < 0 ||
                    nIndex >= m_ljvJsonValueList.Count)
                {
                    throw new Exception("Array index out of bounds");
                }
                return (m_ljvJsonValueList[nIndex]);
            }
        }

        public JsonValue this[string szJsonPath]
        {
            get
            {
                int nCount = 0;
                bool boFound = false;
                JsonValue jvJsonValue = null;

                while (!boFound &&
                       nCount < m_ljvJsonValueList.Count)
                {
                    if (m_ljvJsonValueList[nCount].JsonPath == szJsonPath)
                    {
                        boFound = true;
                        jvJsonValue = m_ljvJsonValueList[nCount];
                    }
                    nCount++;
                }

                return (jvJsonValue);
            }
        }

        public JsonValueList(List<JsonValue> ljvJsonValueList)
        {
            int nCount = 0;

            m_ljvJsonValueList = new List<JsonValue>();

            if (ljvJsonValueList != null)
            {
                for (nCount = 0; nCount < ljvJsonValueList.Count; nCount++)
                {
                    m_ljvJsonValueList.Add(ljvJsonValueList[nCount]);
                }
            }
        }
        public List<JsonValue> GetListOfJsonValueObjects()
        {
            List<JsonValue> ljoReturnJsonValueList;
            int nCount = 0;

            ljoReturnJsonValueList = new List<JsonValue>();

            for (nCount = 0; nCount < m_ljvJsonValueList.Count; nCount++)
            {
                ljoReturnJsonValueList.Add(m_ljvJsonValueList[nCount]);
            }

            return (ljoReturnJsonValueList);
        }
    }

    public class TestValidator
    {
        private Random m_rRandom;
        private int m_nMaxObjectDepth;
        private int m_nMinNumberOfFieldsInObjects;
        private int m_nMaxNumberOfFieldsInObjects;
        private int m_nMinNumberOfArrayItems;
        private int m_nMaxNumberOfArrayItems;
        private int m_nMinFieldNameLength;
        private int m_nMaxFieldNameLength;
        private int m_nMinStringValueLength;
        private int m_nMaxStringValueLength;
        private int m_nMinIntegerValue;
        private int m_nMaxIntegerValue;
        private int m_nMinDateTimeRange;
        private int m_nMaxDateTimeRange;
        private int m_nMinFloatRange;
        private int m_nMaxFloatRange;
        private int m_nMinFloatDecimalPlaces;
        private int m_nMaxFloatDecimalPlaces;

        public TestValidator(int nMaxObjectDepth,
                             int nMinNumberOfFieldsInObjects,
                             int nMaxNumberOfFieldsInObjects,
                             int nMinNumberOfArrayItems,
                             int nMaxNumberOfArrayItems,
                             int nMinFieldNameLength,
                             int nMaxFieldNameLength,
                             int nMinStringValueLength,
                             int nMaxStringValueLength,
                             int nMinIntegerValue,
                             int nMaxIntegerValue,
                             int nMinDateTimeRange,
                             int nMaxDateTimeRange,
                             int nMinFloatRange,
                             int nMaxFloatRange,
                             int nMinFloatDecimalPlaces,
                             int nMaxFloatDecimalPlaces)
        {
            m_nMaxObjectDepth = nMaxObjectDepth;
            m_nMinNumberOfFieldsInObjects = nMinNumberOfFieldsInObjects;
            m_nMaxNumberOfFieldsInObjects = nMaxNumberOfFieldsInObjects;
            m_nMinNumberOfArrayItems = nMinNumberOfArrayItems;
            m_nMaxNumberOfArrayItems = nMaxNumberOfArrayItems;
            m_nMinFieldNameLength = nMinFieldNameLength;
            m_nMaxFieldNameLength = nMaxFieldNameLength;
            m_nMinStringValueLength = nMinStringValueLength;
            m_nMaxStringValueLength = nMaxStringValueLength;
            m_nMinIntegerValue = nMinIntegerValue;
            m_nMaxIntegerValue = nMaxIntegerValue;
            m_nMinDateTimeRange = nMinDateTimeRange;
            m_nMaxDateTimeRange = nMaxDateTimeRange;
            m_nMinFloatRange = nMinFloatRange;
            m_nMaxFloatRange = nMaxFloatRange;
            m_nMinFloatDecimalPlaces = nMinFloatDecimalPlaces;
            m_nMaxFloatDecimalPlaces = nMaxFloatDecimalPlaces;

            m_rRandom = new Random();
        }

        private string GetSimpleFieldValue(out object oValue, out string szRawValue, out JSON_VALUE_TYPE jvtSimpleValueType)
        {
            DateTime dtValue;
            string szValue;
            int nValue;
            bool boValue;
            double lfValue;
            string szReturnValue;
            StringBuilder sbFormatString;
            int nDecimalPlaceCount;
            int nNumberOfDecimalPlaces;

            szRawValue = null;
            oValue = null;

            // what kind of simple value?
            jvtSimpleValueType = (JSON_VALUE_TYPE)m_rRandom.Next(6);

            switch (jvtSimpleValueType)
            {
                // 0 - string
                case JSON_VALUE_TYPE.STRING:
                    // TODO - max and min length for string
                    // mixed case
                    szValue = GenerateRandomString(m_rRandom, m_rRandom.Next(m_nMinStringValueLength, m_nMaxStringValueLength), true);
                    oValue = szValue;
                    szRawValue = szValue;
                    szReturnValue = String.Format("\"{0}\"", szValue);
                    break;
                // 1 - int
                case JSON_VALUE_TYPE.INTEGER:
                    nValue = m_rRandom.Next(m_nMinIntegerValue, m_nMaxIntegerValue);
                    oValue = nValue;
                    szRawValue = String.Format("{0}", nValue);
                    szReturnValue = szRawValue;
                    break;
                // 2 - date/time
                case JSON_VALUE_TYPE.DATE_TIME:
                    dtValue = DateTime.Now.AddDays((m_rRandom.NextDouble() * m_nMaxDateTimeRange) + m_nMinDateTimeRange);
                    szRawValue = dtValue.ToString("s");
                    dtValue = Convert.ToDateTime(szRawValue);
                    oValue = dtValue;
                    szReturnValue = String.Format("\"{0}\"", szRawValue);
                    break;
                // 3 - boolean
                case JSON_VALUE_TYPE.BOOLEAN:
                    if (m_rRandom.Next() % 2 == 0)
                    {
                        boValue = true;
                    }
                    else
                    {
                        boValue = false;
                    }
                    oValue = boValue;
                    szRawValue = boValue.ToString().ToLower();
                    szReturnValue = szRawValue;
                    break;
                // 4 - float
                case JSON_VALUE_TYPE.FLOAT:
                    nNumberOfDecimalPlaces = m_rRandom.Next(m_nMinFloatDecimalPlaces, m_nMaxFloatDecimalPlaces);
                    sbFormatString = new StringBuilder();

                    sbFormatString.Append("{0:0.");

                    for (nDecimalPlaceCount = 0; nDecimalPlaceCount < nNumberOfDecimalPlaces; nDecimalPlaceCount++)
                    {
                        sbFormatString.Append("0");
                    }

                    sbFormatString.Append("}");

                    lfValue = (m_rRandom.NextDouble() * m_nMaxFloatRange) + m_nMinFloatRange;
                    
                    szRawValue = String.Format(sbFormatString.ToString(), lfValue);
                    lfValue = Convert.ToDouble(szRawValue);
                    oValue = lfValue;
                    szReturnValue = szRawValue;
                    break;
                // 5 - null
                case JSON_VALUE_TYPE.NULL:
                    oValue = null;
                    szRawValue = "null";
                    szReturnValue = szRawValue;
                    break;
                default:
                    throw new Exception("Unsupported Json simple value type: " + jvtSimpleValueType);
            }

            return (szReturnValue);
        }

        private string AddFieldToPath(string szPath, string szFieldName, int? nArrayIndex)
        {
            StringBuilder sbString;

            sbString = new StringBuilder();

            if (!String.IsNullOrEmpty(szPath))
            {
                sbString.AppendFormat("{0}.", szPath);
            }

            if (nArrayIndex == null)
            {
                sbString.Append(szFieldName);
            }
            else
            {
                sbString.AppendFormat("{0}[{1}]", szFieldName, nArrayIndex.Value);
            }

            return (sbString.ToString());
        }

        private string GenerateRandomJsonField(int nCurrentDepth, string szCurrentPath, out List<JsonValue> ljvJsonValueList)
        {
            StringBuilder sbJsonString;
            StringBuilder sbJsonArrayString;
            string szCurrentJsonFieldName;
            int nFieldType;
            string szValue;
            string szRawValue;
            string szField;
            int nNumberOfArrayItems;
            int nArrayItemCount;
            int nArrayItemType;
            List<JsonValue> ljvChildJsonValueList;
            JSON_VALUE_TYPE jvtSimpleValueType;
            object oValue;

            ljvJsonValueList = new List<JsonValue>();
            sbJsonString = new StringBuilder();

            // TODO - max and min length for string
            // mixed case
            szCurrentJsonFieldName = GenerateRandomString(m_rRandom, m_rRandom.Next(m_nMinFieldNameLength, m_nMaxFieldNameLength), false);

            sbJsonString.AppendFormat("\"{0}\":", szCurrentJsonFieldName);

            if (nCurrentDepth == m_nMaxObjectDepth)
            {
                nFieldType = 0;
            }
            else
            {
                // what kind of field is this?
                nFieldType = m_rRandom.Next(3);
            }

            switch (nFieldType)
            {
                // 0 - simple value
                case 0:
                    szValue = GetSimpleFieldValue(out oValue, out szRawValue, out jvtSimpleValueType);
                    ljvJsonValueList.Add(new JsonValue(AddFieldToPath(szCurrentPath, szCurrentJsonFieldName, null), oValue, szRawValue, jvtSimpleValueType));
                    break;
                // 1 - object
                case 1:
                    szValue = GenerateRandomJsonObject(nCurrentDepth + 1, AddFieldToPath(szCurrentPath, szCurrentJsonFieldName, null), out ljvChildJsonValueList);
                    ljvJsonValueList.AddRange(ljvChildJsonValueList);
                    break;
                // 2 - array
                case 2:
                    nNumberOfArrayItems = m_rRandom.Next(m_nMinNumberOfArrayItems, m_nMaxNumberOfArrayItems);

                    sbJsonArrayString = new StringBuilder();

                    sbJsonArrayString.Append("[\r\n");

                    for (nArrayItemCount = 0; nArrayItemCount < nNumberOfArrayItems; nArrayItemCount++)
                    {
                        nArrayItemType = m_rRandom.Next(2);

                        if (nArrayItemCount != 0)
                        {
                            sbJsonArrayString.Append(",");
                        }

                        switch (nArrayItemType)
                        {
                            // 0 - value only
                            case 0:
                                szField = GetSimpleFieldValue(out oValue, out szRawValue, out jvtSimpleValueType);
                                ljvJsonValueList.Add(new JsonValue(AddFieldToPath(szCurrentPath, szCurrentJsonFieldName, nArrayItemCount), oValue, szRawValue, jvtSimpleValueType));
                                break;
                            // 1 - object
                            case 1:
                                szField = GenerateRandomJsonField(nCurrentDepth + 1, AddFieldToPath(szCurrentPath, szCurrentJsonFieldName, nArrayItemCount), out ljvChildJsonValueList);
                                ljvJsonValueList.AddRange(ljvChildJsonValueList);

                                szField = String.Format("{{{0}}}", szField);
                                break;
                            default:
                                throw new Exception("Unsupported array item type:" + nArrayItemType);
                        }

                        sbJsonArrayString.Append(szField);
                    }

                    sbJsonArrayString.Append("\r\n]");

                    szValue = sbJsonArrayString.ToString();
                    break;
                default:
                    throw new Exception("Unsupported Json field type: " + nFieldType);
            }

            sbJsonString.AppendFormat("{0}", szValue);

            return (sbJsonString.ToString());
        }

        private string GenerateRandomJsonObject(int nCurrentDepth, string szCurrentPath, out List<JsonValue> ljvJsonValueList)
        {
            StringBuilder sbJsonString;
            string szField;
            int nNumberOfFields;
            int nFieldCount;
            List<JsonValue> ljvChildJsonValueList;

            ljvJsonValueList = new List<JsonValue>();
            sbJsonString = new StringBuilder();

            nNumberOfFields = m_rRandom.Next(m_nMinNumberOfFieldsInObjects, m_nMaxNumberOfFieldsInObjects);

            sbJsonString.Append("\r\n{\r\n");

            for (nFieldCount = 0; nFieldCount < nNumberOfFields; nFieldCount++)
            {
                szField = GenerateRandomJsonField(nCurrentDepth, szCurrentPath, out ljvChildJsonValueList);
                ljvJsonValueList.AddRange(ljvChildJsonValueList);

                if (nFieldCount == 0)
                {
                    sbJsonString.AppendFormat("{0}", szField);
                }
                else
                {
                    sbJsonString.AppendFormat(",\r\n{0}", szField);
                }
            }

            sbJsonString.Append("\r\n}\r\n");

            return (sbJsonString.ToString());
        }

        public string GenerateRandomJson(out List<JsonValue> ljvJsonValueList, out string szJsonFilename)
        {
            string szJsonString;

            szJsonString = GenerateRandomJsonObject(1, null, out ljvJsonValueList);
            szJsonFilename = String.Format("{0:yyyMMddHHmmss}-{1}.json", DateTime.Now, GenerateRandomString(m_rRandom, 5, true));

            return (szJsonString);
        }

        private string GenerateRandomString(Random nRandom, int nSize, bool boNumbers)
        {
            StringBuilder sbString = new StringBuilder();
            char cChar;
            int nNumberOrChar;
            int nCharCase;
            int nCount;
            string szReturnString;

            for (nCount = 0; nCount < nSize; nCount++)
            {
                if (!boNumbers)
                {
                    nCharCase = m_rRandom.Next(2);
                    cChar = Convert.ToChar(nRandom.Next(26) + 65 + (32 * nCharCase));
                }
                else
                {
                    nNumberOrChar = nRandom.Next(2);

                    if (nNumberOrChar == 0)
                    {
                        nCharCase = m_rRandom.Next(2);
                        cChar = Convert.ToChar(nRandom.Next(26) + 65 + (32 * nCharCase));
                    }
                    else
                    {
                        cChar = Convert.ToChar(nRandom.Next(10) + 48);
                    }
                }
                sbString.Append(cChar);
            }

            szReturnString = sbString.ToString();

            return (szReturnString);
        }
    }
}