using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;

namespace aiCorporation
{
    public partial class CartCheckout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rRandom;
            List<string> lszCurrencyList;
            string szOrderID;

            rRandom = new Random();

            lszCurrencyList = new List<string>();
            lszCurrencyList.Add("GBP");
            lszCurrencyList.Add("USD");
            lszCurrencyList.Add("EUR");
            lszCurrencyList.Add("AUD");

            // populate the variables
            MerchantID.Value = GenerateRandomNumberString(rRandom, 8);
            Amount.Value = String.Format("{0:0.00}", Convert.ToDouble(rRandom.Next(1000, 99999)) / 100);
            Currency.Value = lszCurrencyList[rRandom.Next(lszCurrencyList.Count)];
            TransactionType.Value = "SALE";
            szOrderID = GenerateRandomNumberString(rRandom, 15);
            OrderID.Value = String.Format("Order-{0}", szOrderID);
            OrderDescription.Value = String.Format("Order from website #{0}", szOrderID);

            // set the labels for display purposes
            AmountLabel1.Text = Amount.Value;
            AmountLabel2.Text = Amount.Value;
            AmountLabel3.Text = Amount.Value;
            AmountLabel4.Text = Amount.Value;
            CurrencyLabel1.Text = Currency.Value;
            CurrencyLabel2.Text = Currency.Value;
            CurrencyLabel3.Text = Currency.Value;
            CurrencyLabel4.Text = Currency.Value;
            OrderIDLabel.Text = OrderID.Value;
            OrderDescriptionLabel.Text = OrderDescription.Value;

            // Add signature to validate against tampering
            using (var hashingAlgorithm = SHA256.Create())            
            {
                var rawBytes = Encoding.UTF8.GetBytes(
                      MerchantID.Value
                    + Amount.Value
                    + Currency.Value
                    + TransactionType.Value
                    + OrderID.Value
                    + OrderDescription.Value
                    + OrderSignature.Value);

                var hashedBytes = hashingAlgorithm.ComputeHash(rawBytes);                
                var signedBytes = MachineKey.Protect(hashedBytes);

                OrderSignature.Value = BitConverter.ToString(signedBytes);
            }
        }

        private int GenerateHash(params object[] items)
        {
            var hash = 17;
            foreach (var item in items)
            {
                hash *= 31;
                hash += item.GetHashCode();
            }
            return hash;
        }

        public string GenerateRandomNumberString(Random rRandom, int nSize)
        {
            StringBuilder builder = new StringBuilder();
            int nInt;
            int nCount;

            for (nCount = 0; nCount < nSize; nCount++)
            {
                nInt = rRandom.Next(10);
                builder.Append(nInt);
            }

            return builder.ToString();
        }
        public string GenerateRandomString(Random random, int size, bool lowerCase)
        {
            return (GenerateRandomString(random, size, lowerCase, false));
        }
        public string GenerateRandomString(Random random, int size, bool lowerCase, bool boNumbers)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            int nNumberOrChar;

            for (int i = 0; i < size; i++)
            {
                if (!boNumbers)
                {
                    ch = Convert.ToChar(random.Next(26) + 65);
                }
                else
                {
                    nNumberOrChar = random.Next(2);

                    if (nNumberOrChar == 0)
                    {
                        ch = Convert.ToChar(random.Next(26) + 65);
                    }
                    else
                    {
                        ch = Convert.ToChar(random.Next(10) + 48);
                    }
                }
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }
    }
}