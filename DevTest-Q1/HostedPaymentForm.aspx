<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HostedPaymentForm.aspx.cs" Inherits="aiCorporation.HostedPaymentForm" EnableEventValidation="false" EnableViewState="false" EnableViewStateMac="false" EnableSessionState="False" %>

<!DOCTYPE html>

<html lang="en">
	<head>
		<meta charset="UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<title>PayVector | Secure Payment Form | Internet Payment Gateway</title>
		<link href="CSS/HPFSystem.css" rel="stylesheet" type="text/css" />
		<link href="CSS/HPFCustom.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
		<div id="headerWrapper" class="box">
			<div id="siteHeader">
				<div id="logo">
					<img style="border-width:0px;" alt="PayVector" src="Images/logo.png">
				</div>
				<div class="clear"></div>
			</div>
			<div id="headerShadow"></div>
		</div>
		
		<div id="ContentWrapper">
            <asp:Panel ID="pnMessageBox" runat="server">
                <asp:Label ID="lbMessage" runat="server" />
            </asp:Panel>
			<div id="SecurePaymentMessage" class="box hidden-xs">
				<div class="hidden-md hidden-lg">
					<div class="col-xs-24">
						<h1>Secure Payment Form</h1>
					</div>
				</div>
				<div class="hidden-md hidden-lg" style="text-align:center;">
					<div class="col-xs-12 col-sm-8">
						<img src="Images/VerifiedByVisa50.jpg" />
					</div>
					<div class="hidden-xs col-sm-4">
						<img src="Images/Padlock-50.gif" />
					</div>
					<div class="hidden-xs col-sm-4">
						<img src="Images/Cards-50.gif" />
					</div>
					<div class="col-xs-12 col-sm-8">
						<img src="Images/MasterCardSecureCode50.jpg" />
					</div>
				</div>
				<div class="hidden-xs hidden-sm" style="text-align:center;">
					<div class="col-md-4 col-xs-6">
						<img src="Images/VerifiedByVisa50.jpg" />
					</div>
					<div class="col-md-3">
						<img src="Images/Padlock-50.gif" />
					</div>
					<div class="col-md-10 col-xs-12">
						<h1>Secure Payment Form</h1>
					</div>
					<div class="col-md-3">
						<img src="Images/Cards-50.gif" />
					</div>
					<div class="col-md-4 col-xs-6">
						<img src="Images/MasterCardSecureCode50.jpg" />
					</div>
				</div>
				<div class="col-md-24 hidden-xs">
					<p><strong>
						No personal information (including your card details) is ever passed over the internet or stored on our systems unencrypted.
					</strong></p>
				</div>
			</div>
			<div id="contentPane" class="box">
				<div>
					<form id="HostedPaymentForm" method="post" action="#" runat="server">
						<div id="PaymentFormContent">
							<div class="FormRequiredDescription">
								<span id="RequiredFieldsDescription">
									<img src='Images/req.gif' alt='*' />
									Required Entry
								</span>
							</div>

							<div class="ContentRight" id="OrderDetailsSection">
								<div class="ContentHeader" id="OrderDetailsHeader">Order Details</div>                            
								<div class="FormItem">
									<div id="MerchantIDFormLabel" class="FormLabel">Merchant ID:</div>
									<div class="FormInputTextOnly">
										<asp:Label ID="MerchantIDLabel" runat="server" />
									</div>
								</div>                            
								<div class="FormItem">
									<div id="AmountFormLabel" class="FormLabel">Amount:</div>                              
									<div class="FormInputTextOnly">
										<asp:Label ID="AmountLabel" runat="server" />
                                        <asp:Label ID="CurrencyLabel" runat="server" />
									</div>                                    
								</div>
								<div class="FormItem">
									<div id="TransactionTypeFormLabel" class="FormLabel">Transaction Type:</div>
									<div class="FormInputTextOnly">
										<asp:Label ID="TransactionTypeLabel" runat="server" />
									</div>
								</div>
                                <div class="FormItem">
									<div id="OrderIDFormLabel" class="FormLabel">Order ID:</div>
									<div class="FormInputTextOnly">
										<asp:Label ID="OrderIDLabel" runat="server" />
									</div>
								</div>
								<div id="OrderDescriptionPanel">
									<div id="OrderDescriptionFormLabel" class="FormItem">
										<div class="FormLabel">Order Description:</div>
										<div class="FormInputTextOnly">
											<asp:Label ID="OrderDescriptionLabel" runat="server" />
										</div>
									</div>                            
								</div>
							</div>
                        
							<div class="ContentRight" id="CardDetailsSection">
								<div class="ContentHeader" id="CardDetailsHeader">Payment Details</div>
                           
								<div class="FormItem">
									<div id="CardNameFormLabel" class="FormLabel">Name On Card:</div>                               
                                    <div class="FormInput">
                                        <input name="CardName" type="text" autocomplete="off" maxlength="50" id="CardName" class="InputTextField" />
                                    </div>
								</div>
								<div class="FormItem">
									<div id="CardNumberFormLabel" class="FormLabel">Card Number:</div>								
									<div class="FormInput">
										<input name="CardNumber" type="text" autocomplete="off" maxlength="20" id="CardNumber" class="InputTextField" />
									</div>
								</div>
								<div class="FormItem">
									<div id="ExpiryDateFormLabel" class="FormLabel">Expiry Date:</div>                                
									<div class="FormInput">
										<select name="ExpiryDateMonthList" id="ExpiryDateMonthList" class="InputDropDownListSmall">
											<option selected="selected" value="1">01</option>
											<option value="2">02</option>
											<option value="3">03</option>
											<option value="4">04</option>
											<option value="5">05</option>
											<option value="6">06</option>
											<option value="7">07</option>
											<option value="8">08</option>
											<option value="9">09</option>
											<option value="10">10</option>
											<option value="11">11</option>
											<option value="12">12</option>
										</select>
										<select name="ExpiryDateYearList" id="ExpiryDateYearList" class="InputDropDownListSmall">
											<option selected="selected" value="20">2020</option>
											<option value="21">2021</option>
											<option value="22">2022</option>
											<option value="23">2023</option>
											<option value="24">2024</option>
											<option value="25">2025</option>
											<option value="26">2026</option>
											<option value="27">2027</option>
											<option value="28">2028</option>
											<option value="29">2029</option>
										</select>
									</div>                                    
								</div>
								<div class="FormItem">			
									<div id="CV2FormLabel" class="FormLabel">Security Code (CV2):</div>
									<div class="FormInput">
										<input name="CV2" type="text" autocomplete="off" maxlength="4" id="CV2" class="InputTextFieldSmall" />
									</div>
								</div>
							</div>
							<div class="ContentRight" id="SubmitButtonSection">
								<div class="FormItem">
									<div class="FormSubmit">
										<input type="submit" name="SubmitButton" value="Submit For Processing" id="SubmitButton" disabled />   
									</div>
								</div>
							</div>                            
						</div>
					</form>
				</div>
			</div>
		</div>
		<div id="footerWrapper">
	        <div id="footer" class="box clearfix">
	            <div id="copyright"></div>
	            <span><p>Copyright &copy; PayVector</p></span>
	        </div>
	    </div>
	</body>
</html>