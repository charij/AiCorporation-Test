using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aiCorporation
{
    public partial class FileGenHelpForm : Form
    {
        public FileGenHelpForm()
        {
            InitializeComponent();

            webBrowser1.DocumentText = "<html><head></head><body style=\"font-family:Arial;\"><ul>\r\n" +
                    "<li><strong>Min Num Of Fields In Objects</strong>: when creating a Json object, this determines the minimum number of fields to create in that object</li>\r\n" +
                    "<li><strong>Max Num Of Fields In Objects</strong>: when creating a Json object, this determines the maximum number of fields to create in that object</li>\r\n" +
                    "<li><strong>Min Num Of Array Items</strong>: when creating an array, this determines the minimum number of items to create in that array</li>\r\n" +
                    "<li><strong>Max Num Of Array Items</strong>: when creating an array, this determines the maximum number of items to create in that array</li>\r\n" +
                    "<li><strong>Min Field Name Length</strong>: when creating a field (which will be created with a random field name), this determines the minimum character length of this field name</li>\r\n" +
                    "<li><strong>Max Field Name Length</strong>: when creating a field (which will be created with a random field name), this determines the maximum character length of this field name</li>\r\n" +
                    "<li><strong>Min String Value Length</strong>: when creating a field with a string value (which will be created with a random value) this determines the minimum character length of this field value</li>\r\n" +
                    "<li><strong>Max String Value Length</strong>: when creating a field with a string value (which will be created with a random value) this determines the maximum character length of this field value</li>\r\n" +
                    "<li><strong>Min Integer Value</strong>: when creating a field with an integer value (which will be created with a random value) this determines the field's minimum value</li>\r\n" +
                    "<li><strong>Max Integer Value</strong>: when creating a field with an integer value (which will be created with a random value) this determines the field's maximum value</li>\r\n" +
                    "<li><strong>Min Date Time Range</strong>: when creating a field with a date/time value (which will be created with a random value) this determines lower end of the range from which a random value will be selected (which can be a negative value). This value will be added to the current date/time to arrive at the value for the field</li>\r\n" +
                    "<li><strong>Max Date Time Range</strong>: when creating a field with a date/time value (which will be created with a random value) this determines upper end of the range from which a random value will be selected (which can be a negative value). This value will be added to the current date/time to arrive at the value for the field</li>\r\n" +
                    "<li><strong>Min Float Range</strong>: when creating a field with a float value (which will be created with a random value) this determines lower end of the range from which a random value will be selected (which can be a negative value)</li>\r\n" +
                    "<li><strong>Max Float Range</strong>: when creating a field with a float value (which will be created with a random value) this determines upper end of the range from which a random value will be selected (which can be a negative value)</li>\r\n" +
                    "<li><strong>Min Float Decimal Places</strong>: when creating a field with a float value, this determines the minimum number of decimal places that the float will be represented as having in the field</li>\r\n" +
                    "<li><strong>Max Float Decimal Places</strong>: when creating a field with a float value, this determines the maximum number of decimal places that the float will be represented as having in the field</li>\r\n" +
                    "<li><strong>Max Object Depth</strong>: this determines the maximum depth of nesting that the JSON objects will be created with</li>\r\n" +
                "</ul></body>";
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
