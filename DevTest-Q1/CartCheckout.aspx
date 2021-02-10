<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartCheckout.aspx.cs" Inherits="aiCorporation.CartCheckout" EnableEventValidation="false" EnableViewState="false" EnableViewStateMac="false" EnableSessionState="False" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="CSS/ShoppingCart.css" rel="stylesheet" />
    <script type="text/javascript">
        function GenerateRandomNumberString(length)
        {
            var result = "";
            var characters = "0123456789";
            var charactersLength = characters.length;
            var count;

            for (count = 0; count < length; count++)
            {
                result += characters.charAt(Math.floor(Math.random() * charactersLength));
            }

           return result;
        }

        function SubmitForm()
        {
            var simulateTampering;
            var merchantID;
            var amount;
            var currency;
            var transactionType;
            var orderID;
            var orderDescription;
            var form;
            var modifyMerchantID = false;
            var modifyAmount = false;
            var modifyCurrency = false;
            var modifyTransactionType = false;
            var modifyOrderID = false;
            var modifyOrderDescription = false;
            var atLeastOneFieldModified = false;
            var currencyArray = ["GBP","USD","EUR","AUD"];
            var transactionTypeArray = ["PREAUTH", "REFUND"];
            var shoppingCartForm;

            // get the elements from the document
            simulateTampering = document.getElementById("SimulateTampering");
            merchantID = document.getElementById("MerchantID");
            amount = document.getElementById("Amount");
            currency = document.getElementById("Currency");
            transactionType = document.getElementById("TransactionType");
            orderID = document.getElementById("OrderID");
            orderDescription = document.getElementById("OrderDescription");
            
            // do we mess with the form items?
            if (simulateTampering.checked)
            {
                // sometimes modify the merchant ID
                if (Math.floor(Math.random() * 6) == 1)
                {
                    modifyMerchantID = true;
                    atLeastOneFieldModified = true;
                }
                // sometimes modify the amount
                if (Math.floor(Math.random() * 6) == 1)
                {
                    modifyAmount = true;
                    atLeastOneFieldModified = true;
                }
                // sometimes modify the currency
                if (Math.floor(Math.random() * 6) == 1)
                {
                    modifyCurrency = true;
                    atLeastOneFieldModified = true;
                }
                // sometimes modify the transaction type
                if (Math.floor(Math.random() * 6) == 1)
                {
                    modifyTransactionType = true;
                    atLeastOneFieldModified = true;
                }
                // sometimes modify the order ID
                if (Math.floor(Math.random() * 6) == 1)
                {
                    modifyOrderID = true;
                    atLeastOneFieldModified = true;
                }
                // sometimes modify the order description
                if (Math.floor(Math.random() * 6) == 1)
                {
                    modifyOrderDescription = true;
                    atLeastOneFieldModified = true;
                }

                // if by chance none of the items are set to be modified, then
                // force the amount to be modified
                if (!Boolean(atLeastOneFieldModified))
                {
                    modifyAmount = true;
                }

                // tamper with the merchant ID
                if (Boolean(modifyMerchantID))
                {
                    merchantID.value = GenerateRandomNumberString(8);
                }
                // tamper with the amount
                if (Boolean(modifyAmount))
                {
                    amount.value = ((Math.floor(Math.random() * 99999) + 1000) / 100).toFixed(2);
                }
                // tamper with the currency
                if (Boolean(modifyCurrency))
                {
                    currency.value = currencyArray[Math.floor(Math.random() * currencyArray.length)];
                }
                // tamper with the transaction type
                if (Boolean(modifyTransactionType))
                {
                    transactionType.value = transactionTypeArray[0];//Math.floor(Math.random() * transactionTypeArray.length)];
                }
                // tamper with the order ID
                if (Boolean(modifyOrderID))
                {
                    orderID.value = orderID.value + "_tampered";
                }
                // tamper with the order description
                if (Boolean(modifyOrderDescription))
                {
                    orderDescription.value = orderDescription.value + "_tampered";
                }
            }
            shoppingCartForm = document.getElementById("ShoppingCartForm");
            shoppingCartForm.submit();
        }
    </script>
</head>
<body>
	<div id="SiteBanner">
		ACME Widgets Shop 
	</div>
	<div id="Content">
		<form id="ShoppingCartForm" action="HostedPaymentForm.aspx" runat="server">
			<div style="position: relative;height:50px;">

				<div style="float:left;bottom:0;position:absolute;font-size:18px;font-weight:bold;">
					<asp:Label ID="OrderIDLabel" runat="server" />
                    (<asp:Label ID="OrderDescriptionLabel" runat="server" />)
				</div>
			</div>
			<div>
				<table id="CartContents">
					<tr id="CartContentsHeader">
						<th colspan="2" >&nbsp;</th>
						<th style="text-align:left;">Product Name</th>
						<th style="width:100px;">Unit Price</th>
						<th style="width:70px;">Qty</th>
						<th style="width:100px;">Subtotal</th>
					</tr>
					<tr id="CartContentsBody">
						<td style="width:20px;">#1</td>
						<td style="width:150px;padding:7px;"><img src="Images/camera.png" width="120" height="100" /></td>
						<td>Snapmatic AI1000 Compact Camera - Black</td>
						<td>
                            <asp:Label ID="AmountLabel1" runat="server" />
                            <asp:Label ID="CurrencyLabel1" runat="server" />
						</td>
						<td>
							<input id="Quantity" readonly="true" value="1" style="width:70px;" />
						</td>
						<td>
                            <asp:Label ID="AmountLabel2" runat="server" />
                            <asp:Label ID="CurrencyLabel2" runat="server" />
						</td>
					</tr>
					<tr id="CartContentsFooter">
						<td colspan="2">
							<a href="#" class="CartButton">Continue Shopping</a>
						</td>
						<td colspan="4" style="text-align:right">
							<a href="#" class="CartButton">Update Shopping Cart</a>
						</td>
				</table>
			</div>
			<div id="Totals">
				<div class="TotalsLabel">
					Sub Total:
				</div>
				<div class="TotalsText">
                    <asp:Label ID="AmountLabel3" runat="server" />
                    <asp:Label ID="CurrencyLabel3" runat="server" />
				</div>
				<div class="TotalsLabel GrandTotal">
					Grand Total:
				</div>
				<div class="TotalsText GrandTotal">
                    <asp:Label ID="AmountLabel4" runat="server" />
                    <asp:Label ID="CurrencyLabel4" runat="server" />
				</div>
				<div id="BottomPayButton">
                    <a class="PayButton" href="#" onclick="SubmitForm()">Proceed To Payment</a>
				</div>			
                <div id="SimulateTamperingPanel">
                    <asp:CheckBox ID="SimulateTampering" runat="server" Text="Simulate Tampering" />
                </div>
			</div>
            <div id="HiddenFields">
                <asp:HiddenField ID="MerchantID" runat="server" />
                <asp:HiddenField ID="Amount" runat="server" />
                <asp:HiddenField ID="Currency" runat="server" />
                <asp:HiddenField ID="TransactionType" runat="server" />
                <asp:HiddenField ID="OrderID" runat="server" />
                <asp:HiddenField ID="OrderDescription" runat="server" />
                <asp:HiddenField ID="OrderSignature" runat="server" />
            </div>
		</form>
	</div>
</body>
</html>