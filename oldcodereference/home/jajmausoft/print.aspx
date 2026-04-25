<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print.aspx.cs" Inherits="print" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>Reciept</title>
   <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".txt1").datepicker({
                changeMonth: true,
                changeYear: true
            });
            function ShowMessage() {
                alert("Valid");
            }
            function ShowMessage1() {
                alert("Not Valid");
            }

        });
    </script>

    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    

.wrrper{
width:990px;
margin:0 auto;
border:5px solid black;
}
table {
    border-collapse: collapse;
	width:101%;
}
    body
    {
        background-image:url("images/bg1.jpg");
        background-size:cover;
    }
#main
{
margin:10px;

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
height:275px;
width:48%;
        margin-top: 9px;
    }
#c
{
height:10%;
border-bottom:4px solid brown;
        width: 700px;
margin-left:2.5px;
    }
#c1
{
height:80%;

}
    .style1
    {
        width: 50%;
    }
    .style2
    {
        height: 84px;
    }
    .style3
    {
        height: 71px;
    }
    .style4
    {
        width: 230px;
        text-align: justify;
    }
    .style5
    {
        width: 109px;
        text-align: justify;
    }
    .style7
    {
        width: 170px;
        text-align: justify;
    }
    .style8
    {
        width: 155px;
        text-align: justify;
    }
    .style9
    {
        width: 241px;
    }
    .style10
    {
        width: 128px;
    }
    .style11
    {
        width: 163px;
    }
    .style12
    {
        width: 613px;
    }
    .style13
    {
       
    }
    .style16
    {
        width: 187px;
    }
    .style17
    {
        width: 260px;
        height: 37px;
    }
    .style18
    {
        width: 124px;
        height: 37px;
    }
    .style19
    {
        height: 37px;
    }
    .style20
    {
        width: 187px;
        height: 43px;
    }
    .style21
    {
        width: 124px;
        height: 43px;
    }
    .style22
    {
        height: 43px;
    }
    .style23
    {
        width: 187px;
        height: 38px;
    }
    .style24
    {
        height: 38px;
    }
    .style25
    {
    }
    .style26
    {
        height: 37px;
        width: 139px;
    }
    .style27
    {
        height: 43px;
        width: 139px;
        font-weight: bold;
    }
    .style28
    {
        width: 139px;
    }
    .style29
    {
        height: 38px;
        width: 124px;
    }
    .style30
    {
        width: 124px;
    }
    .style31
    {
        width: 139px;
        font-weight: bold;
    }
</style>
</head>
<body>
<div id="main" class=".wrrper">
<form id="Form1" runat="server">
		<div id="m1">
			<div id="m12">
				<table style="border-right:4px solid brown; margin-top: 0px;height:100%;">
					<tr><td>CIN-U45201UP2019PTC123734</td>
						<td class="style13"><strong style="text-align:left;">MOB. +91-9696446268,     9935142277</strong></td>
					</tr>
					<tr>
						<td colspan="2" style="text-align:center;background-image:url('tyu.jpg');background-size:100% 100%; ">
                       <div"><p style="font-size:20pt;font-weight:bolder;color:#540202;">HEED REAL ESTATE PRIVATE LIMITED</p></div></td>
					</tr>
					<tr>
						<td colspan="2"><P style="background-color:#d63aa9;color:white;padding:5px;text-align:center;">
                            <strong>19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</strong></P></td>
					</tr>
					<tr>
						<td colspan="2"><center>
						<h3 style="color:#d63aa9;margin-top:-10px;"><strong>RENEWAL SUBSCRIPTION RECEIPT</strong></h3>
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
					<tr><td class="style4">&nbsp;&nbsp;&nbsp; <strong>Customer Reg. No.</strong></td>
                        <td class="text-justify">
                        <asp:Label ID="Label2" runat="server" Text="Label" style="font-weight:bold;"></asp:Label>
                        </td><td class="text-justify">
                            &nbsp;</td></tr>
				</table></div>
				<div id="c1">
				<table style="position:absolute;height:200px; top: 52px; margin-left: 18px;">
					<tr>
						<td class="style5"><strong>ASC Name </strong> </td>
						<td class="style8">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </td>
						<td class="style7"><strong>Receipt No. </strong> </td>
						<td class="text-justify">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
					</tr>
					<tr>

						<td class="style5"><strong>ASC Code</strong></td>
						<td class="style8">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </td>
						<td class="style7"><strong>Date</strong></td>
						<td class="text-justify">
                            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                        </td>
					</tr>
					<tr>

						<td class="style5"><strong>Due Date</strong></td>
						<td class="style8">
                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                        </td>
					    <td class="style7"><strong>End Of Term  </strong>  </td>
						<td class="text-justify">
                            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                        </td>
					</tr>
					<tr>

						<td class="style5"><strong>Installment No/Downpayment</strong>. </td>
						<td class="style8">
                            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                        </td>
						<td class="style7"><strong>Booking Date</strong></td>
						<td class="text-justify">
                            <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                            </td>
					</tr>
                    </table>
				</div>
			</div>
		</div>
		<div id="m2">
			<table style="position:relative;width:100%;padding:8px;border-top:4px solid brown;">
				<tr>
					<td class="style9">&nbsp;&nbsp;&nbsp;</td>
					<td class="style10">&nbsp;<td class="style10"></td>
					<td>
                        &nbsp;</td>
				</tr>
			</table>
		</div>
		<div id="m3">
		<table style="width:100%;">
			<tr>
				<td class="style1">
					<table style="width:100%; height:240px;">
                        <tr>
							<td class="style23"><strong>&nbsp;Total Land Value Rs.</strong></td>
                            <td class="style29">
                            <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="style25" colspan="2" rowspan="5" >
                                <asp:Panel ID="Panel1" runat="server">
                                
                                <strong>Mode of Payment :&nbsp;
                            </strong>
                                
                                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                
                                <strong>Plan Name &amp; Term</strong><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                Installment<asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Paid&nbsp;
                            <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Bal &nbsp;
                            <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                                Downpayment<asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Paid&nbsp;&nbsp;
                            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp; Bal&nbsp;&nbsp;
                            <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
								
							    Cheque BounceCheque No.:&nbsp;
                            <asp:Label ID="Label28" runat="server" Text="Label" CssClass="ui-priority-primary" 
                                    style="color: #990000"></asp:Label>
                        &nbsp;&nbsp;</asp:Panel></td>
						</tr>
						<tr>
							<td class="style17"><strong><span 
                                    style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Balance 
                                Amount Rs.</span></strong></td>
                            <td class="style18">
                            <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                            </td>
						</tr>
						<tr>
							<td class="style20"><strong>&nbsp;Amount Received</strong></td>
                            <td class="style21">
                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                            </td>
						</tr>
						<tr>
							<td class="style16"><strong>&nbsp;&nbsp;Late Charges ( 2%)</strong></td>
                            <td class="style30">
                            <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                            </td>
						</tr>
						<tr>
							<td class="style16"><strong>&nbsp;Cheque Bounce Charge</strong></td>
                            <td class="style30">
                            <asp:Label ID="Label26" runat="server" Text="Label" CssClass="ui-priority-primary" 
                                    style="color: #000066"></asp:Label>
                            </td>
						</tr>
						<tr><td class="style16"><strong>Balance Received Amount</strong></td>
                            <td class="style30">
                            <asp:Label ID="Label27" runat="server" 
                                style="color: #FF0000; font-weight: 700; font-size: large" Text="Label"></asp:Label>
                            </td><td class="style28"></td><td></td></tr>
					</table>
				</td>
				<td>
					<table>
						<tr style="font-size:large;"><td class="style2">&nbsp;&nbsp; <strong>Associates's Name & Address</strong></td></tr>
						<tr><td class="style3">
                            &nbsp;&nbsp;
                            <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                            </td></tr>
						<tr><td style="height:60px;">&nbsp;&nbsp; <strong>For : HEED REAL ESTATE PRIVATE LIMITED</strong></td></tr>
						<tr><td><div style="height:45px;"></div></td></tr>
					</table>
				</td>
			</tr>
		</table>
		

		</div>
		<div id="m4">
			<table style="position:absolute;width:100%;height:50px;padding:0px">
				<tr>
					<td class="style11">
                        <p style="padding:5px;background-color:#d63aa9;color:white;margin-left:6px;"><strong>Amount in word Rs.</strong></p></td>
					<td class="style12">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                    </td>
					<td><h3><strong>Auth Signatory</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h3></td>
				</tr>
			</table>
		</div>
        </form>
</div>
</body>
</html>
