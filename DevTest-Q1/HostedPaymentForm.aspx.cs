using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace aiCorporation
{
    public partial class HostedPaymentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool boSimulateTampering = false;
            bool boVariablesValidated;

            MerchantIDLabel.Text = Request.Form["MerchantID"];
            AmountLabel.Text = Request.Form["Amount"];
            CurrencyLabel.Text = Request.Form["Currency"];
            TransactionTypeLabel.Text = Request.Form["TransactionType"];
            OrderIDLabel.Text = Request.Form["OrderID"];
            OrderDescriptionLabel.Text = Request.Form["OrderDescription"];

            // this request value should NOT be referenced *anywhere else* in the solution
            if (!String.IsNullOrEmpty(Request.Form["SimulateTampering"]))
            {
                boSimulateTampering = Request.Form["SimulateTampering"].ToLower() == "true" ||
                                      Request.Form["SimulateTampering"].ToLower() == "on" ||
                                      Request.Form["SimulateTampering"].ToLower() == "yes";
            }

            try
            {
                boVariablesValidated = ValidateIncomingVariables();

                if ((!boSimulateTampering && boVariablesValidated) ||
                    (boSimulateTampering && !boVariablesValidated))
                {
                    pnMessageBox.CssClass = "SuccessMessage";

                    if (boSimulateTampering)
                    {
                        lbMessage.Text = "Variable tampering successfully detected!";
                    }
                    else
                    {
                        lbMessage.Text = "Variables not tampered with!";
                    }
                }
                else
                {
                    pnMessageBox.CssClass = "ErrorMessage";
                    lbMessage.Text = "Variable tampering failed!";
                }
            }
            catch (NotImplementedException exc)
            {
                pnMessageBox.CssClass = "WarningMessage";
                lbMessage.Text = exc.Message;
            }
            catch (Exception exc)
            {
                pnMessageBox.CssClass = "ErrorMessage";
                lbMessage.Text = exc.Message;
            }
        }

        // this function should return true if the variables are valid (i.e. variable tampering has not been detected)
        // and return false if the variables are invalid (i.e. variable tampering has been detected)
        private bool ValidateIncomingVariables()
        {
            using (var hashingAlgorithm = SHA256.Create())
            {
                var rawBytes = Encoding.UTF8.GetBytes(
                      Request.Form["MerchantID"]
                    + Request.Form["Amount"]
                    + Request.Form["Currency"]
                    + Request.Form["TransactionType"]
                    + Request.Form["OrderID"]
                    + Request.Form["OrderDescription"]
                    + Request.Form["OrderSignature"]);

                var hashedBytes = hashingAlgorithm.ComputeHash(rawBytes);
                var signedBytes = MachineKey.Protect(hashedBytes);
                var signature = BitConverter.ToString(signedBytes);

                return signature == Request.Form["OrderSignature"];
            }
        }
    }
}