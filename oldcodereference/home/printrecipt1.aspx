<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printrecipt1.aspx.cs" Inherits="new_form_printrecipt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>Reciept</title>
   <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
 
	<script type="text/javascript">
	    var windowObjectReference;


	    function openRequestedPopup() {
	        var s = document.getElementById('<%=Label7.ClientID%>').innerHTML;

	        windowObjectReference = window.open("http://sms.webguard.in/api/sendhttp.php?authkey=330026AlOBgB2Z85ec8e185P1&mobiles=9696446268&message=Your Update form Request OTP is " + s + "&sender=HEEDKP&route=4&country=91");


	    }
	   
		
</script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".txt1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            function ShowMessage() {
                alert("Valid");
            }
            function ShowMessage1() {
                alert("Not Valid");
            }

        });
    </script>
<style type="text/css">
    body
    {
        background-image:url("images/bg1.jpg");
        background-size:cover;
    }
#main
{
margin-left:50px;
height:100%;
width:90%;
position:absolute;
border:4px solid brown;
}
#m1
{
height:40%;
border-bottom:4px solid brown;
}
#m2
{
height:6%;
border-bottom:4px solid brown;
}
#m3
{
height:44%;
border-bottom:4px solid brown;
}
#m4
{
height:60px;

width:100%;
margin-left:-4px;
}
#m12
{
float:left;
height:100%;
width:50%;
}
#c
{
height:18%;
border-bottom:4px solid brown;
}
#c1
{
height:80%;
border-bottom:4px solid brown;
}
    .style4
    {
        width: 179px;
    }
    .style7
    {
        width: 227px;
    }
    .style8
    {
        width: 119px;
    }
    .style9
    {
        width: 132px;
    }
    .style10
    {
        width: 179px;
        font-weight: bold;
    }
    .style11
    {
        width: 132px;
        font-weight: bold;
    }
</style>
</head>
<body>
<div id="main">
<form id="Form1" runat=server>
		<div id="m1">
			<div id="m12">
				<table style="border-right:4px solid brown;">
					<tr>
						<td colspan="2">&nbsp;</td>
					</tr>
					<tr>
						<td style="font-size:39pt;text-shadow:2px 2px red;text-align:center;">
                        HEED REAL</td>
					</tr>
					<tr>
						<td style="font-size:18pt;text-align:center;">ESTATE PRIVATE LIMITED<asp:Label 
                                ID="Label29" runat="server" style="font-size: xx-small; color: #FFFFFF;" 
                                Text="Label"></asp:Label>
                        </td>
					</tr>
					<tr>
						<td colspan="2"><P style="background-color:#d63aa9;color:white;padding:5px;text-align:center;">300/5, PAC Road,PAC Lane, Gadiyana, Kanpur, Uttar Pradesh <asp:Label 
                                ID="Label4" runat="server" Visible="False"></asp:Label>
                            </P></td>
					</tr>
					<tr>
						<td colspan="2"><center>
						<h3 style="color:#d63aa9;margin-top:-18px;">RENEWAL SUBSCRIPTION RECEIPT</h3>
						<p style="font-size:8pt;margin-top:-10px;">Recieved with thanks the amount of installment towards the subscription payable according to the terms & conditions of joint Venture</P>
						<p style="font-size:8pt;">NB:1. The certificate No.& Address should be mentioned in every correspondence with the company.<br>
						 2. Only the official Receipt bearing the company satmp and the signature of the Authorised officer
						 will be deemed to be the valid evidence of company of subscription.</p>
						</center></td>
					</tr>
				</table>
			</div>
			<div id="m12">
				<div id="c">
				<table style="padding:2px;">
					<tr><td>RECEIPT. No.</td><td><asp:TextBox ID="TextBox1" runat="server"   style="height:20px;width:50%;margin-left:50px;"  ></asp:TextBox></td><td>
                        <asp:Button ID="Button2" runat="server" Text="Check Rec" BackColor="#000066" 
                            BorderColor="#660066" BorderStyle="Groove" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="#FFFFCC" onclick="Button2_Click" Width="98px" /> 
                        &nbsp;<asp:Button
                                ID="Button3" runat="server" Text="Print" BackColor="#00CC00" 
                            onclick="Button3_Click" style="font-weight: 700; margin-left: 3px;" 
                            Width="68px" /></td></tr>
				</table></div>
				<div id="c1">
				<table style="position:absolute;height:200px;">
					<tr>
						<td>ASC Name </td>
						<td><asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"  ></asp:TextBox></td>
						<td>Reg no No. </td>
						<td><asp:TextBox ID="TextBox3" runat="server"   ReadOnly="True" BackColor="#CCFF66" 
                                Font-Bold="True" Font-Size="Larger" Height="29px" Width="111px"></asp:TextBox></td>
					</tr>
					<tr>

						<td>ASC Code</td>
						<td><asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"  ></asp:TextBox></td>
						<td>Date</td>
						<td><asp:TextBox ID="TextBox19" runat="server" class="txt1" ReadOnly="True"  ></asp:TextBox></td>
					</tr>
					<tr>

						<td>Due Date</td>
						<td><asp:TextBox ID="TextBox20" runat="server" class="txt1" ReadOnly="True"  ></asp:TextBox></td>
					    <td>&nbsp;End Of Term</td>
						<td><asp:TextBox ID="TextBox8" runat="server" ReadOnly="True"   ></asp:TextBox></td>
					</tr>
					<tr>

						<td>Installment No. </td>
						<td><asp:TextBox ID="TextBox7" runat="server" ReadOnly="True"   ></asp:TextBox></td>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
					</tr>
                    <tr>
						<td>BOOK BY / REF. NO. </td>
						<td colspan="2"><asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox></td>
						
					</tr>
				</table>
				</div>
			</div>
		</div>
		<div id="m2">
			<table style="position:relative;width:100%;padding:8px;border-top:4px solid brown;">
				<tr>
					<td>SCHEDULE&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server"></asp:Label> 
						<asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
					<td style="width:100px;">ASC Address</td>
					<td><asp:TextBox ID="TextBox9" runat="server" TextMode="MultiLine" MaxLength="0" 
                            Width="60%" ReadOnly="True"   ></asp:TextBox></td>
				</tr>
			</table>
		</div>
		<div id="m3">
		<table style="width:100%;">
			<tr>
				<td style="width:70%;">
					<table style="width:100%;height:240px;">
                        <tr>
							<td class="style10">Total Land Value</td><td class="style8">
                            <asp:TextBox ID="TextBox14" runat="server" ReadOnly="True" Height="22px" 
                                Width="109px"  ></asp:TextBox></td>
                                 <td class="style9" ><strong>Mode of Payment :&nbsp;
                            </strong>
                            </td><td class="style7" >
                                
                                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                
                            </td>
						</tr>
						<tr>
							<td class="style10">Balance Amount Rs.</td><td class="style8">
                            <asp:TextBox ID="TextBox15" runat="server" ReadOnly="True" Height="23px" 
                                    Width="109px"   ></asp:TextBox>
                            </td>
							<td class="style11">Plan Name & Term</td><td class="style7">
                            <asp:TextBox ID="TextBox11" 
                                runat="server" ReadOnly="True" Height="22px" Width="111px" ></asp:TextBox></td>
						</tr>
						<tr>
							<td class="style10">Amount Received</td><td class="style8">
                            <asp:TextBox ID="TextBox13" runat="server" ReadOnly="True" Height="25px" Width="110px" 
                                 ></asp:TextBox></td>
                            <td class="style11">Mode of Payment</td><td class="style7">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>-----Select-----</asp:ListItem>
                                    <asp:ListItem>Monthly</asp:ListItem>
                                    <asp:ListItem>Yearly</asp:ListItem>
                                </asp:DropDownList>
                            </td>
						</tr>
						<tr>
							<td class="style10">2% Late Charges</td><td class="style8">
                            <asp:TextBox ID="TextBox16" runat="server" 
                                ReadOnly="True" Height="23px" Width="109px"  ></asp:TextBox></td>
                            <td class="style11">Installment</td><td class="style7">
                            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp; Paid&nbsp;
                            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp; Bal&nbsp;
                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                            </td>
						</tr>
						<tr>
							<td class="style4"><strong>Cheque Bounce Charge</strong></td><td class="style8">
                            <asp:Label ID="Label26" runat="server" Text="Label" CssClass="ui-priority-primary" 
                                    style="color: #000066"></asp:Label>
                            </td>
							<td class="style11">
								
							    Downpayment</td>
							<td class="style7">
                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp; Paid&nbsp;
                            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp; Bal&nbsp;
                            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                            </td>
						</tr>
						<tr><td class="style4"><strong>Balance Received Amount</strong></td>
                            <td class="style8">
                            <asp:Label ID="Label27" runat="server" 
                                style="color: #FF0000; font-weight: 700; font-size: large" Text="Label"></asp:Label>
                            </td><td class="style9"><strong>Cheque Bounce</strong></td><td class="style7">Cheque No.:&nbsp;
                            <asp:Label ID="Label28" runat="server" Text="Label" CssClass="ui-priority-primary" 
                                    style="color: #990000"></asp:Label>
                        &nbsp;&nbsp;</td></tr>
					</table>
				</td>
				<td  style="border-left:2px solid blue;">
					<table>
						<tr style="height:80px;font-size:large;"><td>Associates's Name & Address</td></tr>
						<tr><td>
                            <asp:TextBox ID="TextBox17" runat="server" 
                                TextMode="MultiLine" ReadOnly="True" Height="49px" Width="189px"  ></asp:TextBox>	</td></tr>
						<tr><td style="height:60px;">For : HEED REAL ESTATE PRIVATE LIMITED</td></tr>
						<tr><td><div style="height:45px;">
                            <asp:Label ID="Label7" runat="server" ForeColor="White"></asp:Label>
                            </div></td></tr>
					</table>
				</td>
			</tr>
		</table>
		

		</div>
		<div id="m4">
			<table style="position:absolute;width:100%;height:50px;padding:0px">
				<tr>
					<td style="width:150px;"><p style="padding:5px;background-color:#d63aa9;color:white;">Amount in word Rs.</p></td>
					<td><asp:TextBox ID="TextBox18" runat="server" style="width:500px;height:30px;" 
                            Font-Size="Large" ReadOnly="True"  ></asp:TextBox></td>
					<td><h3>Auth Signatory&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                        </h3></td>
				</tr>
               
			</table><br /><br />
            <br /><br />
		</div>
        </form>
</div>
</body>
</html>










