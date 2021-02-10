namespace aiCorporation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;

    public enum JSON_VALUE_TYPE
    {
        STRING,
        INTEGER,
        DATE_TIME,
        BOOLEAN,
        FLOAT,
        NULL
    }

    public class JsonObjectBuilder
    {
        private string m_szName;
        private object m_oValue;
        private JSON_VALUE_TYPE m_jvtJsonValueType;
        private string m_szRawValue;
        private bool m_boIsArrayObject;
        private JsonObjectListBuilder m_jolChildJsonObjectList;

        public string Name
        {
            get { return (m_szName); }
            set { m_szName = value; }
        }
        public object Value
        {
            get { return (m_oValue); }
            set { m_oValue = value; }
        }
        public JSON_VALUE_TYPE JsonValueType
        {
            get { return (m_jvtJsonValueType); }
            set { m_jvtJsonValueType = value; }
        }
        public string RawValue
        {
            get { return (m_szRawValue); }
            set { m_szRawValue = value; }
        }
        public bool IsArrayObject
        {
            get { return (m_boIsArrayObject); }
            set { m_boIsArrayObject = value; }
        }
        public JsonObjectListBuilder ChildJsonObjectList { get { return m_jolChildJsonObjectList; } }

        public JsonObject ToJsonObject()
        {
            JsonObject joJsonObject;

            joJsonObject = new JsonObject(m_szName, m_oValue, m_jvtJsonValueType, m_szRawValue, m_boIsArrayObject, m_jolChildJsonObjectList.IsArrayList, m_jolChildJsonObjectList.ToJsonObjectList());

            return (joJsonObject);
        }

        public JsonObjectBuilder()
        {
            m_jolChildJsonObjectList = new JsonObjectListBuilder();
        }
    }
    public class JsonObjectListBuilder
    {
        private List<JsonObjectBuilder> m_ljoJsonObjectList;
        private bool m_boIsArrayList;

        public int Count { get { return (m_ljoJsonObjectList.Count); } }

        public bool IsArrayList
        {
            get { return (m_boIsArrayList); }
            set
            {
                m_boIsArrayList = value;
            }
        }

        public JsonObjectBuilder this[int nIndex]
        {
            get
            {
                if (nIndex < 0 ||
                    nIndex >= m_ljoJsonObjectList.Count)
                {
                    throw new Exception("Array index out of bounds");
                }
                return (m_ljoJsonObjectList[nIndex]);
            }
        }

        public void Add(JsonObjectBuilder joJsonObject)
        {
            if (joJsonObject != null)
            {
                if (joJsonObject.IsArrayObject != this.IsArrayList)
                {
                    throw new Exception(String.Format("Mismatch between object's array status [{0}] and the list's array status: {1}", joJsonObject.IsArrayObject, this.IsArrayList));
                }
                m_ljoJsonObjectList.Add(joJsonObject);
            }
        }

        public List<JsonObject> ToJsonObjectList()
        {
            List<JsonObject> ljoJsonObjectList;
            int nCount;

            ljoJsonObjectList = new List<JsonObject>();

            for (nCount = 0; nCount < m_ljoJsonObjectList.Count; nCount++)
            {
                ljoJsonObjectList.Add(m_ljoJsonObjectList[nCount].ToJsonObject());
            }

            return (ljoJsonObjectList);
        }

        public JsonObjectListBuilder()
        {
            m_ljoJsonObjectList = new List<JsonObjectBuilder>();
        }

        public List<JsonObjectBuilder> GetListOfJsonObjectWorkingObjects()
        {
            List<JsonObjectBuilder> ljoReturnJsonObjectList;
            int nCount = 0;

            ljoReturnJsonObjectList = new List<JsonObjectBuilder>();

            for (nCount = 0; nCount < m_ljoJsonObjectList.Count; nCount++)
            {
                ljoReturnJsonObjectList.Add(m_ljoJsonObjectList[nCount]);
            }

            return (ljoReturnJsonObjectList);
        }
    }

    public class JsonObject
    {
        private string m_szName;
        private object m_oValue;
        private JSON_VALUE_TYPE m_jvtJsonValueType;
        private string m_szRawValue;
        private bool m_boIsArrayObject;
        private JsonObjectList m_jolChildJsonObjectList;

        public string Name { get { return (m_szName); } }
        public object Value { get { return (m_oValue); } }
        public JSON_VALUE_TYPE JsonValueType { get { return (m_jvtJsonValueType); } }
        public string RawValue { get { return (m_szRawValue); } }
        public bool IsArrayObject { get { return (m_boIsArrayObject); } }
        public JsonObjectList ChildJsonObjectList { get { return (m_jolChildJsonObjectList); } }

        public bool ObjectPresent(string szObjectName)
        {
            bool boReturnValue = false;

            if (m_szName == szObjectName)
            {
                boReturnValue = true;
            }
            else
            {
                boReturnValue = m_jolChildJsonObjectList.ObjectPresent(szObjectName);
            }

            return (boReturnValue);
        }

        public string ToHtmlString()
        {
            StringBuilder sbString;
            int nRowSpan = 0;
            bool boChildObjects = false;
            string szCssClass;

            sbString = new StringBuilder();

            // content
            if (!String.IsNullOrEmpty(m_szRawValue))
            {
                nRowSpan++;
            }

            if (m_jolChildJsonObjectList.Count > 0)
            {
                nRowSpan++;
            }

            if (m_boIsArrayObject)
            {
                szCssClass = "array";
            }
            else
            {
                szCssClass = "report";
            }

            sbString.Append("<tr>");

            // simple tag
            if (nRowSpan <= 1)
            {
                sbString.AppendFormat("<td class=\"{0}\">{1}</td>", szCssClass, m_szName);
                sbString.Append("<td>");
                if (!String.IsNullOrEmpty(m_szRawValue))
                {
                    if (m_jvtJsonValueType == JSON_VALUE_TYPE.NULL)
                    {
                        sbString.AppendFormat("<em>{0}</em>", m_szRawValue);
                    }
                    else
                    {
                        sbString.Append(m_szRawValue);
                    }
                }
                else
                {
                    sbString.Append(m_jolChildJsonObjectList.ToHtmlString());
                }
                sbString.Append("</td>");

            }
            else
            {
                sbString.AppendFormat("<td class=\"{0}\" rowspan=\"{1}\">{2}</td>", szCssClass, nRowSpan, m_szName);

                if (!String.IsNullOrEmpty(m_szRawValue))
                {
                    sbString.Append("<td>");
                    if (m_jvtJsonValueType == JSON_VALUE_TYPE.NULL)
                    {
                        sbString.AppendFormat("<em>{0}</em>", m_szRawValue);
                    }
                    else
                    {
                        sbString.Append(m_szRawValue);
                    }
                    sbString.Append("</td>");
                }
                else
                {
                    if (m_jolChildJsonObjectList.Count > 0)
                    {
                        sbString.Append("<td>");
                        sbString.Append(m_jolChildJsonObjectList.ToHtmlString());
                        sbString.Append("</td>");
                        boChildObjects = true;
                    }  
                }

                if (!boChildObjects &&
                    m_jolChildJsonObjectList.Count > 0)
                {
                    sbString.Append("<tr>");
                    sbString.Append("<td>");
                    sbString.Append(m_jolChildJsonObjectList.ToHtmlString());
                    sbString.Append("</td>");
                    sbString.Append("</tr>");
                }
            }

            sbString.Append("</tr>");

            return (sbString.ToString());
        }

        public JsonObject(string szName, object oValue, JSON_VALUE_TYPE jvtJsonValueType, string szRawValue, bool boIsArrayObject, bool boChildObjectListIsArrayList, List<JsonObject> ljoChldJsonObjectList)
        {
            m_szName = szName;
            m_oValue = oValue;
            m_jvtJsonValueType = jvtJsonValueType;
            m_szRawValue = szRawValue;
            m_boIsArrayObject = boIsArrayObject;
            m_jolChildJsonObjectList = new JsonObjectList(boChildObjectListIsArrayList, ljoChldJsonObjectList);
        }
    }

    public class JsonObjectList
    {
        private List<JsonObject> m_ljoJsonObjectList;
        private bool m_boIsArrayList;

        private static string GetArrayNameAndIndex(string szName, out int nIndex)
        {
            string szReturnString;
            int nCount = 0;
            string szSubString;
            bool boFound = false;
            bool boAbort = false;
            bool boAtLeastOneDigitFound = false;

            if (szName == "")
            {
                nIndex = 0;
                return (szName);
            }

            szReturnString = szName;
            nIndex = 0;

            if (szName[szName.Length - 1] == ']')
            {
                nCount = szName.Length - 2;

                while (!boFound &&
                       !boAbort &&
                       nCount >= 0)
                {
                    // if we've found the closing array brace
                    if (szName[nCount] == '[')
                    {
                        boFound = true;
                    }
                    else
                    {
                        if (!Char.IsDigit(szName[nCount]))
                        {
                            boAbort = true;
                        }
                        else
                        {
                            boAtLeastOneDigitFound = true;
                            nCount--;
                        }
                    }
                }

                // did we finish successfully?
                if (boFound &&
                    boAtLeastOneDigitFound)
                {
                    szSubString = szName.Substring(nCount + 1, szName.Length - nCount - 2);
                    szReturnString = szName.Substring(0, nCount);
                    nIndex = System.Convert.ToInt32(szSubString);
                }
            }

            return (szReturnString);
        }

        private static List<string> GetStringListFromCharSeparatedString(string szString, char cDelimiter)
        {
            int nCount = 0;
            int nLastCount = -1;
            string szSubString;
            int nStringLength;
            List<string> lszStringList;

            if (szString == null ||
                szString == "" ||
                cDelimiter.ToString() == "")
            {
                return (new List<string>());
            }

            lszStringList = new List<string>();

            nStringLength = szString.Length;

            for (nCount = 0; nCount < nStringLength; nCount++)
            {
                if (szString[nCount] == cDelimiter)
                {
                    szSubString = szString.Substring(nLastCount + 1, nCount - nLastCount - 1);
                    nLastCount = nCount;
                    lszStringList.Add(szSubString);

                    if (nCount == nStringLength)
                    {
                        lszStringList.Add("");
                    }
                }
                else
                {
                    if (nCount == nStringLength - 1)
                    {
                        szSubString = szString.Substring(nLastCount + 1, nCount - nLastCount);
                        lszStringList.Add(szSubString);
                    }
                }
            }

            return (lszStringList);
        }

        public int Count { get { return (m_ljoJsonObjectList.Count); } }

        public JsonObject this[int nIndex]
        {
            get
            {
                if (nIndex < 0 ||
                    nIndex >= m_ljoJsonObjectList.Count)
                {
                    throw new Exception("Array index out of bounds");
                }
                return (m_ljoJsonObjectList[nIndex]);
            }
        }

        public bool ObjectPresent(string szName)
        {
            JsonObject joJsonObject;
            bool boReturnValue = false;

            joJsonObject = GetNamedObjectInObjectList(szName);

            if (joJsonObject != null)
            {
                boReturnValue = true;
            }

            return (boReturnValue);
        }
        public JsonObject GetNamedObjectInObjectList(string szName)
        {
            List<string> lszHierarchicalNameList = null;
            int nCount = 0;
            bool boAbort = false;
            bool boFound = false;
            bool boLastNode = false;
            string szString;
            string szObjectNameToFind;
            int nCurrentIndex = 0;
            JsonObject joReturnObject = null;
            JsonObject joCurrentObject = null;
            int nTagCount = 0;
            JsonObjectList jolCurrentObjectList = null;
            bool boComponentHasIndex;

            if (m_ljoJsonObjectList.Count == 0)
            {
                return (null);
            }

            lszHierarchicalNameList = GetStringListFromCharSeparatedString(szName, '.');

            jolCurrentObjectList = this;

            // loop over the hierarchical list
            for (nCount = 0; nCount < lszHierarchicalNameList.Count && !boAbort; nCount++)
            {
                boComponentHasIndex = false;

                if (nCount == lszHierarchicalNameList.Count - 1)
                {
                    boLastNode = true;
                }

                szString = lszHierarchicalNameList[nCount];

                // look to see if this tag name has the special "[]" array chars
                if (szString.Contains("[") &&
                    szString.Contains("]"))
                {
                    boComponentHasIndex = true;
                    szObjectNameToFind = GetArrayNameAndIndex(szString, out nCurrentIndex);
                }
                else
                {
                    szObjectNameToFind = szString;
                }

                boFound = false;

                for (nTagCount = 0; nTagCount < jolCurrentObjectList.Count && !boFound; nTagCount++)
                {
                    joCurrentObject = jolCurrentObjectList[nTagCount];

                    // if this is the last node then check the attributes of the tag first

                    if (joCurrentObject.Name == szObjectNameToFind)
                    {
                        if (!boComponentHasIndex)
                        {
                            boFound = true;
                        }
                        else
                        {
                            if (nCurrentIndex < joCurrentObject.ChildJsonObjectList.Count)
                            {
                                joCurrentObject = joCurrentObject.ChildJsonObjectList[nCurrentIndex];
                                boFound = true;
                            }
                        }
                    }

                    if (boFound)
                    {
                        if (!boLastNode)
                        {
                            jolCurrentObjectList = joCurrentObject.ChildJsonObjectList;
                        }
                        else
                        {
                            // don't continue the search
                            joReturnObject = joCurrentObject;
                        }
                    }
                }
                if (!boFound)
                {
                    boAbort = true;
                }
            }

            return (joReturnObject);
        }

        public bool GetJsonObject(string szVariablePath, out JsonObject joJsonObject)
        {
            bool boReturnValue = false;
            List<string> lszHierarchicalNameList;
            string szJsonObjectName;
            string szLastJsonObjectName;
            int nCount = 0;
            JsonObject joCurrentJsonObject = null;
            StringBuilder sbJsonObjectName;

            lszHierarchicalNameList = new List<string>();
            joJsonObject = null;
            lszHierarchicalNameList = GetStringListFromCharSeparatedString(szVariablePath, '.');

            if (lszHierarchicalNameList.Count == 1)
            {
                szJsonObjectName = lszHierarchicalNameList[0];

                joCurrentJsonObject = GetNamedObjectInObjectList(szJsonObjectName);

                if (joCurrentJsonObject != null)
                {
                    joJsonObject = joCurrentJsonObject;
                    boReturnValue = true;
                }
            }
            else
            {
                if (lszHierarchicalNameList.Count > 1)
                {
                    sbJsonObjectName = new StringBuilder();
                    sbJsonObjectName.Append(lszHierarchicalNameList[0]);
                    szLastJsonObjectName = lszHierarchicalNameList[lszHierarchicalNameList.Count - 1];

                    // need to remove the last variable from the passed name
                    for (nCount = 1; nCount < lszHierarchicalNameList.Count - 1; nCount++)
                    {
                        sbJsonObjectName.AppendFormat(".{0}", lszHierarchicalNameList[nCount]);
                    }

                    joCurrentJsonObject = GetNamedObjectInObjectList(sbJsonObjectName.ToString());

                    // first check the attributes of this tag
                    if (joCurrentJsonObject != null)
                    {
                        // check to see if it's actually a tag
                        if (joCurrentJsonObject.ChildJsonObjectList == null)
                        {
                            joCurrentJsonObject = null;
                        }
                        else
                        {
                            joCurrentJsonObject = joCurrentJsonObject.ChildJsonObjectList.GetNamedObjectInObjectList(szLastJsonObjectName);
                        }

                        if (joCurrentJsonObject != null)
                        {
                            joJsonObject = joCurrentJsonObject;
                            boReturnValue = true;
                        }
                    }
                }
            }

            return (boReturnValue);
        }

        public string ToHtmlString()
        {
            StringBuilder sbString;
            int nCount;
            string szCssClass;

            sbString = new StringBuilder();

            if (m_boIsArrayList)
            {
                szCssClass = "dump_array";
            }
            else
            {
                szCssClass = "dump_report";
            }

            if (m_boIsArrayList &&
                m_ljoJsonObjectList.Count == 0)
            {
                sbString.AppendFormat("<em>empty array</em>");
            }
            else
            {
                sbString.AppendFormat("<table class=\"{0}\">", szCssClass);

                for (nCount = 0; nCount < m_ljoJsonObjectList.Count; nCount++)
                {
                    sbString.Append(m_ljoJsonObjectList[nCount].ToHtmlString());
                }

                sbString.AppendFormat("</table>");
            }
            return (sbString.ToString());
        }

        public JsonObjectList(bool boIsArrayList, List<JsonObject> ljoJsonObjectList)
        {
            int nCount = 0;

            m_ljoJsonObjectList = new List<JsonObject>();

            if (ljoJsonObjectList != null)
            {
                for (nCount = 0; nCount < ljoJsonObjectList.Count; nCount++)
                {
                    m_ljoJsonObjectList.Add(ljoJsonObjectList[nCount]);
                }
            }
            m_boIsArrayList = boIsArrayList;
        }
        public List<JsonObject> GetListOfJsonObjectObjects()
        {
            List<JsonObject> ljoReturnJsonObjectList;
            int nCount = 0;

            ljoReturnJsonObjectList = new List<JsonObject>();

            for (nCount = 0; nCount < m_ljoJsonObjectList.Count; nCount++)
            {
                ljoReturnJsonObjectList.Add(m_ljoJsonObjectList[nCount]);
            }

            return (ljoReturnJsonObjectList);
        }
    }

    public class JsonParser
    {
        private JsonObjectList m_jolJsonObjectList;

        #region HtmlStyle
        private static string m_szHTMLStyle = "<style>\r\n" +
            "body\r\n" +
            "{\r\n" +
            "	font-family: verdana, arial, helvetica, sans-serif;\r\n" +
            "}\r\n" +
            "table.dump_list,\r\n" +
            "table.dump_report,\r\n" +
            "table.dump_array\r\n" +
            "{\r\n" +
            "	font-size: xx-small;\r\n" +
            "	font-family: verdana, arial, helvetica, sans-serif;\r\n" +
            "	cell-spacing: 2px;\r\n" +
            "}\r\n" +
            "table.dump_list th,\r\n" +
            "table.dump_report th,\r\n" +
            "table.dump_array th\r\n" +
            "{\r\n" +
            "	text-align: left;\r\n" +
            "	color: #fff;\r\n" +
            "	padding: 5px;\r\n" +
            "}\r\n" +
            "table.dump_list td,\r\n" +
            "table.dump_report td,\r\n" +
            "table.dump_array td\r\n" +
            "{\r\n" +
            "	padding: 3px;\r\n" +
            "	background-color: #fff;\r\n" +
            "	vertical-align : top;\r\n" +
            "}\r\n" +
            "table.dump_list\r\n" +
            "{\r\n" +
            "	background-color: #00c;\r\n" +
            "}\r\n" +
            "table.dump_list th.list\r\n" +
            "{\r\n" +
            "	background-color: #44c;\r\n" +
            "}\r\n" +
            "table.dump_list td.list\r\n" +
            "{\r\n" +
            "	background-color: #cdf;\r\n" +
            "}\r\n" +
            "table.dump_array\r\n" +
            "{\r\n" +
            "	background-color: #060;\r\n" +
            "}\r\n" +
            "table.dump_array th.array\r\n" +
            "{\r\n" +
            "	background-color: #090;\r\n" +
            "}\r\n" +
            "table.dump_array td.array\r\n" +
            "{\r\n" +
            "	background-color: #cfc;\r\n" +
            "}\r\n" +
            "table.dump_report\r\n" +
            "{\r\n" +
            "	background-color: #888;\r\n" +
            "}\r\n" +
            "table.dump_report th.report\r\n" +
            "{\r\n" +
            "	background-color: #aaa;\r\n" +
            "}\r\n" +
            "table.dump_report td.report\r\n" +
            "{\r\n" +
            "	background-color: #ddd;\r\n" +
            "}\r\n" +
            "</style>";
        #endregion

        public bool ObjectPresent(string szObjectName)
        {
            return (m_jolJsonObjectList.ObjectPresent(szObjectName));
        }
        public JsonObject GetObject(string szObjectName)
        {
            JsonObject JsonReturnTag = null;

            if (m_jolJsonObjectList == null ||
                m_jolJsonObjectList.Count == 0)
            {
                return (null);
            }
            if (String.IsNullOrEmpty(szObjectName))
            {
                if (m_jolJsonObjectList.Count > 1)
                {
                    throw new Exception("Can return default object if there is only one object in object list");
                }
                if (m_jolJsonObjectList.Count == 1)
                {
                    JsonReturnTag = m_jolJsonObjectList[0];
                }
            }
            else
            {
                JsonReturnTag = m_jolJsonObjectList.GetNamedObjectInObjectList(szObjectName);
            }

            return (JsonReturnTag);
        }

        public bool ParseFile(string szFilename)
        {
            bool boReturnValue = false;
            FileStream fsFileStream;

            fsFileStream = new FileStream(szFilename, FileMode.Open, FileAccess.Read);

            if (fsFileStream != null)
            {
                boReturnValue = ParseStream(fsFileStream);
                fsFileStream.Close();
            }

            return (boReturnValue);
        }
        
        private JSON_VALUE_TYPE GetJsonValueTypeAndValue(Newtonsoft.Json.JsonToken jtJsonToken, object oInputValue, out string szRawValue, out object oOutputValue)
        {
            JSON_VALUE_TYPE jvtJsonValueType;

            switch (jtJsonToken)
            {
                case Newtonsoft.Json.JsonToken.Boolean:
                    jvtJsonValueType = JSON_VALUE_TYPE.BOOLEAN;
                    szRawValue = String.Format("{0}", oInputValue);
                    oOutputValue = oInputValue;
                    break;
                case Newtonsoft.Json.JsonToken.Date:
                    jvtJsonValueType = JSON_VALUE_TYPE.DATE_TIME;
                    szRawValue = String.Format("{0}", oInputValue);
                    oOutputValue = oInputValue;
                    break;
                case Newtonsoft.Json.JsonToken.Float:
                    jvtJsonValueType = JSON_VALUE_TYPE.FLOAT;
                    szRawValue = String.Format("{0}", oInputValue);
                    oOutputValue = oInputValue;
                    break;
                case Newtonsoft.Json.JsonToken.Integer:
                    jvtJsonValueType = JSON_VALUE_TYPE.INTEGER;
                    szRawValue = String.Format("{0}", oInputValue);
                    oOutputValue = oInputValue;
                    break;
                case Newtonsoft.Json.JsonToken.String:
                    jvtJsonValueType = JSON_VALUE_TYPE.STRING;
                    szRawValue = String.Format("{0}", oInputValue);
                    oOutputValue = oInputValue;
                    break;
                case Newtonsoft.Json.JsonToken.Null:
                    jvtJsonValueType = JSON_VALUE_TYPE.NULL;
                    szRawValue = "null";
                    oOutputValue = null;
                    break;
                default:
                    throw new Exception("This function cannot get value types and objects for non value type Json token: " + jtJsonToken);
            }

            return (jvtJsonValueType);
        }

        /************************************************************/
        /* THIS IS THE FUNCTION THAT WE WOULD LIKE YOU TO IMPLEMENT */
        /************************************************************/
        public bool ParseStream(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonObjectListBuilder jObjectBuilderRoots = new JsonObjectListBuilder();
                Stack<JsonObjectBuilder> jObjectBuilderStack = new Stack<JsonObjectBuilder>();

                reader.Read();

                JsonObjectBuilder jObjectRoot = new JsonObjectBuilder();
                JsonObjectBuilder jObjectParent = null;
                JsonObjectBuilder jObjectBuilder = null;

                jObjectBuilderStack.Push(jObjectRoot);

                while (reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.StartObject:
                            jObjectParent = jObjectBuilderStack.Peek();
                            if (jObjectParent.ChildJsonObjectList.IsArrayList)
                            {
                                jObjectBuilder = new JsonObjectBuilder();
                                jObjectBuilder.IsArrayObject = true;
                                jObjectBuilder.Name = $"Item{jObjectParent.ChildJsonObjectList.Count + 1}";
                                jObjectBuilderStack.Push(jObjectBuilder);
                                jObjectParent.ChildJsonObjectList.Add(jObjectBuilder);
                            }
                            break;

                        case JsonToken.EndObject:
                            if (jObjectBuilderStack.Count > 0)
                            {
                                jObjectBuilderStack.Pop();
                            }
                            break;

                        case JsonToken.StartArray:
                            jObjectBuilder = jObjectBuilderStack.Peek();
                            jObjectBuilder.ChildJsonObjectList.IsArrayList = true;
                            break;

                        case JsonToken.EndArray:
                            jObjectBuilder = jObjectBuilderStack.Pop();
                            break;

                        case JsonToken.PropertyName:
                            jObjectParent = jObjectBuilderStack.Peek();
                            jObjectBuilder = new JsonObjectBuilder();
                            jObjectBuilder.Name = String.Format("{0}", reader.Value);
                            jObjectBuilderStack.Push(jObjectBuilder);
                            jObjectParent.ChildJsonObjectList.Add(jObjectBuilder);
                            break;

                        case JsonToken.Boolean:
                        case JsonToken.Float:
                        case JsonToken.Date:
                        case JsonToken.Integer:
                        case JsonToken.Null:
                        case JsonToken.String:
                            jObjectParent = jObjectBuilderStack.Peek();
                            if (jObjectParent.ChildJsonObjectList.IsArrayList)
                            {
                                jObjectBuilder = new JsonObjectBuilder();
                                jObjectBuilder.IsArrayObject = true;
                                jObjectBuilder.Name = $"Item{jObjectParent.ChildJsonObjectList.Count + 1}";
                                jObjectParent.ChildJsonObjectList.Add(jObjectBuilder);
                            }
                            else
                            {
                                jObjectBuilder = jObjectBuilderStack.Pop();
                                jObjectParent = jObjectBuilderStack.Peek();
                            }

                            jObjectBuilder.JsonValueType = GetJsonValueTypeAndValue(reader.TokenType, reader.Value, out string szRawValue, out object oOutputValue);
                            jObjectBuilder.Value = oOutputValue;
                            jObjectBuilder.RawValue = szRawValue;
                            break;

                        case JsonToken.Bytes:
                        case JsonToken.Comment:
                        case JsonToken.None:
                        case JsonToken.Raw:
                        case JsonToken.Undefined:
                        default:
                            return false;
                    }
                }

                m_jolJsonObjectList = new JsonObjectList(false, jObjectRoot.ChildJsonObjectList.GetListOfJsonObjectWorkingObjects()
                    .Select(i => i.ToJsonObject())
                    .ToList());
            }
            
            return true;
        }
        public bool ParseBuffer(string szJsonString)
        {
            MemoryStream msStream;
            bool boReturnValue = false;
            System.Text.Encoding eEncoding;

            if (String.IsNullOrEmpty(szJsonString))
            {
                msStream = new MemoryStream();
            }
            else
            {
                eEncoding = new System.Text.UTF8Encoding();
                msStream = new MemoryStream(eEncoding.GetBytes(szJsonString));
            }

            if (msStream != null)
            {
                boReturnValue = ParseStream(msStream);
            }

            return (boReturnValue);
        }

        public string ToHtmlString(bool boCompleteHtml)
        {
            return ToHtmlString(boCompleteHtml, "Json Document");
        }
        public string ToHtmlString(bool boCompleteHtml, string szHeading)
        {
            StringBuilder sbString;

            sbString = new StringBuilder();

            if (boCompleteHtml)
            {
                sbString.AppendFormat("<html><head>{0}</head><body>", m_szHTMLStyle);
            }

            sbString.Append("<table class=\"dump_list\">");
            sbString.Append("<tr>");
            sbString.AppendFormat("<th class=\"list\">{0}</th>", szHeading);
            sbString.Append("</tr>");
            sbString.Append("<tr>");
            sbString.Append("<td>");

            if (m_jolJsonObjectList != null)
            {
                sbString.Append(m_jolJsonObjectList.ToHtmlString());
            }

            sbString.Append("</td>");
            sbString.Append("</tr>");
            sbString.Append("</table>");

            if (boCompleteHtml)
            {
                sbString.Append("</body></html>");
            }

            return (sbString.ToString());
        }
    }
}