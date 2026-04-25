﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recipt.aspx.cs" Inherits="Recipt" %>

<html>
<head>
<title>Reciept</title>
   <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	<script type="text/javascript">
	    var windowObjectReference;


	    function openRequestedPopup() {
                var s = document.getElementById('<%=Label3.ClientID%>').innerHTML;
         var s4 = document.getElementById('<%=TextBox1.ClientID%>').value;
                  var s2 = document.getElementById('<%=TextBox13.ClientID%>').value;
                  var s3 = document.getElementById('<%=Label17.ClientID%>').value;
            windowObjectReference = window.open("http://sms.webguard.in/api/sendhttp.php?authkey=330026A7runOjvu5f533531P1&mobiles=9696446268,"+s+"&message=THANK YOU FOR PAID INSTALLMENT- " + s2 + "Rs AND INSTALLMENT NO. " + s3 + " and Registration No is "+s4+" ON HEED REAL ESTATE PVT LTD.&sender=HEEDKP&route=4&DLT_TE_ID=1207161743797366419");
	       
	   
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
border-bottom:4px solid brown
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
width:49.5%;
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
    .style3
    {
        width: 126px;
    }
    .style4
    {
        width: 186px;
    }
    .style5
    {
        width: 76%;
    }
    .style6
    {
        width: 159px;
    }
    .style7
    {
        color: #FF0000;
    }
    .auto-style1 {
        width: 186px;
        height: 41px;
    }
    .auto-style2 {
        width: 159px;
        height: 41px;
    }
    .auto-style3 {
        width: 126px;
        height: 41px;
    }
    .auto-style4 {
        height: 41px;
    }
    .auto-style5 {
        width: 186px;
        height: 33px;
    }
    .auto-style6 {
        width: 159px;
        height: 33px;
    }
    .auto-style7 {
        width: 126px;
        height: 33px;
    }
    .auto-style8 {
        height: 33px;
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
						<td></td>
					</tr>
					<tr>
						<td style="font-size:39pt;">
                          &nbsp;
                            <asp:Label ID="Label15" runat="server" style="font-size: x-large" Text="Label" 
                                Font-Bold="True" ForeColor="Red"></asp:Label>
&nbsp; HEED REAL
                            <asp:Label ID="Label16" runat="server" style="font-size: x-large" Text="Label" 
                                Font-Bold="True" ForeColor="Red"></asp:Label>
                        &nbsp;<asp:Label ID="Label25" runat="server" style="font-size: xx-small" Text="" 
                                Font-Bold="True" ForeColor="white" ></asp:Label>
                        </td>
					</tr>
					<tr>
						<td style="font-size:18pt;text-align:center;">ESTATE PRIVATE LIMITED</td>
					</tr>
					<tr>
						<td><P style="background-color:#d63aa9;color:white;padding:5px;text-align:center;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</P></td>
					</tr>
					<tr>
						<td><center>
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
              
					<tr><td>Customer Reg. No..</td><td><asp:TextBox ID="TextBox1" runat="server"   style="height:20px;width:50%;margin-left:50px;"  ></asp:TextBox></td><td>
                        <asp:Button ID="Button2" runat="server" Text="Check Reg" BackColor="#FFCCFF" 
                            BorderColor="#660066" BorderStyle="Groove" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="#333300" onclick="Button2_Click" Width="98px" /> 
                        <asp:Button ID="Button1" runat="server" Text="OK PRINT" onclick="Button1_Click" BackColor="#00FF99" BorderColor="#000066" BorderStyle="Groove" Font-Bold="True" Font-Size="Medium" ForeColor="#660033" Width="110px"  OnClientClick="javascript:return openRequestedPopup();"/></td></tr>
				</table></div>
				<div id="c1">
				<table style="position:absolute;height:200px;">
					<tr>
						<td>ASC Name </td>
						<td><asp:TextBox ID="TextBox2" runat="server"   ReadOnly="True"  ></asp:TextBox></td>
						<td>Receipt No. </td>
						<td><asp:TextBox ID="TextBox3" runat="server"   ReadOnly="True" BackColor="#CCFF66" 
                                Font-Bold="True" Font-Size="Larger" Height="29px" Width="46px"></asp:TextBox></td>
					</tr>
					<tr>

						<td>ASC Code</td>
						<td><asp:TextBox ID="TextBox4" runat="server"   ReadOnly="True"  ></asp:TextBox></td>
						<td>Date</td>
						<td><asp:TextBox ID="TextBox19" runat="server" ReadOnly="True"   ></asp:TextBox></td>
					</tr>
					<tr>

						<td>Due Date</td>
						<td><asp:TextBox ID="TextBox20" runat="server" class="txt1" ></asp:TextBox></td>
					    <td>&nbsp;End Of Term</td>
						<td><asp:TextBox ID="TextBox8" runat="server"  ReadOnly="True"  ></asp:TextBox></td>
					</tr>
					<tr>

						<td>Installment No. </td>
						<td>
                            &nbsp;
                            <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                        </td>
						<td>Booking Date</td>
						<td>
                            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                        </td>
					</tr>
                    <tr>

						<td>BOOK BY / REF. NO. </td>
						<td><asp:TextBox ID="TextBox5" runat="server"   ReadOnly="True"></asp:TextBox></td>
                        <td>Plot No.</td>
                         <td>
                            <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                        </td>
						
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
					<td style="width:100px;">&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</div>
		<div id="m3">
		<table style="width:100%;">
			<tr>
				<td class="style5">
					<table style="width:100%;height:240px;">
                        <tr>
							<td class="auto-style5">Payment Type</td><td class="auto-style6" >
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="26px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="117px">
                                    <asp:ListItem>----SELECT----</asp:ListItem>
                                    <asp:ListItem>CASH</asp:ListItem>
                                    <asp:ListItem>CHEQUE</asp:ListItem>
                                </asp:DropDownList>
                            </td><td class="auto-style7" Mode of Payment :&nbsp;
                             </td><td class="auto-style8" >
                                <asp:Label ID="Label11" runat="server" Text="Monthly"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label21" runat="server" style="font-weight: 700; color: #FF0000" 
                                    Text="CHEQUE NO"></asp:Label>
                                <span class="style7"><strong>&nbsp; </strong>
                                <asp:TextBox ID="TextBox21" runat="server" Height="24px" Width="84px" AutoPostBack="True" OnTextChanged="TextBox21_TextChanged">0</asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button3" runat="server" BackColor="#000066" 
                                    onclick="Button3_Click" style="color: #FFFFFF; font-weight: 700" 
                                    Text="BOUNCE" />
                                <br />
                            <asp:Label ID="Label24" runat="server" 
                                style=" font-weight: 700; font-size: large" Text="Label"></asp:Label>
                                </span>
                            </td>
						</tr>
						<tr>
							<td class="style4">Total Land Value Rs..</td><td class="style6">
                                <asp:TextBox ID="TextBox14" runat="server" ReadOnly="True" Height="22px" 
                                    Width="115px"  ></asp:TextBox>
                            </td>
							<td class="style3">Arazi</td><td>
                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:Label ID="Label22" runat="server" style="font-weight: 700; color: #FF0000" 
                                    Text="USER"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" Width="132px">
                                <asp:ListItem>---SELECT---</asp:ListItem>
                            </asp:DropDownList>
                            </td>
						</tr>
						<tr>
							<td class="style4">Balance Payment Rs.</td><td class="style6">
                            <asp:TextBox ID="TextBox15" runat="server" Height="21px" ReadOnly="True" 
                                Width="115px" ></asp:TextBox>
                            </td>
                            <td class="style3">Plan & Term</td><td>
                            <asp:TextBox ID="TextBox11" runat="server"  ReadOnly="True" ></asp:TextBox>
                            </td>
						</tr>
						<tr>
							<td class="auto-style1">Amount Received</td>
                            <td class="auto-style2">
                            <asp:TextBox ID="TextBox13" runat="server" AutoPostBack="True" 
                                ontextchanged="TextBox13_TextChanged" Height="22px" Width="115px"></asp:TextBox></td>
                            <td class="auto-style3"Downpayment</td>Cheque Bounce Charge<td class="auto-style4">
                           &nbsp;&nbsp;<asp:Label ID="Label19" runat="server" Text="Label" CssClass="ui-priority-primary" 
                                    style="color: #000066"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Discount&nbsp;
                            <asp:DropDownList ID="DropDownList3" runat="server">
                                <asp:ListItem>NORMAL</asp:ListItem>
                                <asp:ListItem>DISCOUNT</asp:ListItem>
                            </asp:DropDownList>
                            </td>
						</tr>
						<tr>
							<td class="style4">2% Late Charges Rs..</td><td class="style6">
                            <asp:TextBox ID="TextBox16" runat="server" ReadOnly="True" Height="22px" 
                                    style="margin-left: 0px" Width="115px" 
                                ></asp:TextBox>
                            </td>
							<td class="style3">
								
							   Installment</td>
							<td>
                            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                            </td>
						</tr>
						<tr><td class="style4">Balance Received Amounttt</td><td class="style6">
                            <asp:Label ID="Label20" runat="server" 
                                style="color: #FF0000; font-weight: 700; font-size: large" Text="Label"></asp:Label>
                            </td>
                            <td class="style3">Cheque Bounce</td><td>Cheque No.:&nbsp;
                            <asp:Label ID="Label18" runat="server" Text="Label" CssClass="ui-priority-primary" 
                                    style="color: #990000"></asp:Label>
                        &nbsp;&nbsp;</td></tr>
					</table>
				</td>
				<td  style="border-left:2px solid brown;">
					<table>
						<tr style="height:80px;font-size:large;"><td>Associates's Name & Address</td></tr>
						<tr><td><asp:TextBox ID="TextBox17" runat="server" style="width:80%;height:50px;" TextMode="MultiLine" ReadOnly="True"  ></asp:TextBox>	</td></tr>
						<tr><td style="height:60px;">For : HEED REAL ESTATE PRIVATE LIMITED</td></tr>
						<tr><td><div style="height:45px;">
                            <asp:Label ID="Label4" runat="server" ForeColor="White"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Image ID="Image1" runat="server" Height="45px" 
                                ImageUrl="~/home/check.png" Visible="False" Width="107px" />
                            </div></td></tr>
					</table>
				</td>
			</tr>
		</table>
		</div>
		<div id="m4">
			<table style="position:absolute;width:100%;padding:0px; left: -4px;">
				<tr>
					<td style="width:150px;"><p style="padding:5px;background-color:#d63aa9;color:white;">Amount in word Rs.</p></td>
					<td><asp:TextBox ID="TextBox18" runat="server" style="width:500px;height:30px;" Font-Size="Large"  ></asp:TextBox></td>
					<td><h3>Auth Signatory&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                        </h3></td>
				</tr>
			</table>
		</div>
        </form>
</div>
</body>
</html>








