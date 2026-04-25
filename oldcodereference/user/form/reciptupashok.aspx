<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reciptupashok.aspx.cs" Inherits="kishan_Bin_map2_174mi_reciptupashok" %>

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
	        var s1 = document.getElementById('<%=Label4.ClientID%>').innerHTML;
	        var s2 = document.getElementById('TextBox1').value;
	        windowObjectReference = window.open("http://sms.webguard.in/api/sendhttp.php?authkey=330026A7runOjvu5f533531P1&mobiles=9696446268&message=Your Update form " + s1 + " on Request Recipt no " + s2 + " OTP is " + s + "&sender=HEEDKP&route=4");


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
    .style1
    {
        font-size: x-large;
    }
    .style2
    {
        width: 665px;
    }
    .style3
    {
        width: 277px;
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
						<td style="font-size:18pt;text-align:center;">ESTATE PRIVATE LIMITED</td>
					</tr>
					<tr>
						<td colspan="2"><P style="background-color:#d63aa9;color:white;padding:5px;text-align:center;">300/5, PAC Road,PAC Lane, Gadiyana, Kanpur, Uttar Pradesh</P></td>
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
                        <asp:Button ID="Button2" runat="server" Text="Check Rec" BackColor="#FFCCFF" 
                            BorderColor="#660066" BorderStyle="Groove" Font-Bold="True" Font-Size="Medium" 
                            ForeColor="#333300" onclick="Button2_Click" Width="98px" /> 
                        &nbsp;<asp:Button ID="Button1" runat="server" Text="DEL" 
                            onclick="Button1_Click" BackColor="#00FF99" BorderColor="#000066" 
                            BorderStyle="Groove" Font-Bold="True" Font-Size="Medium" ForeColor="#660033" 
                            Width="47px"/><asp:Button
                                ID="Button3" runat="server" Text="UPDATE" BackColor="#00CC00" 
                            onclick="Button3_Click" style="font-weight: 700" Width="68px" /></td></tr>
				</table></div>
				<div id="c1">
				<table style="position:absolute;height:200px;">
					<tr>
						<td>ASC Name </td>
						<td><asp:TextBox ID="TextBox2" runat="server"  ></asp:TextBox></td>
						<td>Reg no No. </td>
						<td><asp:TextBox ID="TextBox3" runat="server"   ReadOnly="True" BackColor="#CCFF66" 
                                Font-Bold="True" Font-Size="Larger" Height="29px" Width="111px"></asp:TextBox></td>
					</tr>
					<tr>

						<td>ASC Code</td>
						<td><asp:TextBox ID="TextBox4" runat="server"  ></asp:TextBox></td>
						<td>Date</td>
						<td><asp:TextBox ID="TextBox19" runat="server" class="txt1"  ></asp:TextBox></td>
					</tr>
					<tr>

						<td>Due Date</td>
						<td><asp:TextBox ID="TextBox20" runat="server" class="txt1"  ></asp:TextBox></td>
					    <td>&nbsp;End Of Term</td>
						<td><asp:TextBox ID="TextBox8" runat="server"   ></asp:TextBox></td>
					</tr>
					<tr>

						<td>Installment No. </td>
						<td><asp:TextBox ID="TextBox7" runat="server"   ></asp:TextBox></td>
						<td colspan="2" rowspan="2">
                            <asp:Panel ID="Panel1" runat="server" BackColor="Lime" Height="65px">
                                PAID AMOUNT
                                <asp:TextBox ID="TextBox21" runat="server" Height="31px" Width="59px"></asp:TextBox>
                                &nbsp;
                                <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="DELETE" 
                                    Width="62px" />
                            </asp:Panel>
                        </td>
					</tr>
                    <tr>
						<td>BOOK BY / REF. NO. </td>
						<td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
						
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
					<td><asp:TextBox ID="TextBox9" runat="server" TextMode="MultiLine" MaxLength="0" Width="60%"   ></asp:TextBox></td>
				</tr>
			</table>
		</div>
		<div id="m3">
		<table style="width:100%;">
			<tr>
				<td style="width:70%;">
					<table style="width:100%;height:240px;">
                        <tr>
							<td>Plan Name & Term</td><td colspan="3"><asp:TextBox ID="TextBox11" runat="server" ></asp:TextBox></td>
						</tr>
						<tr>
							<td>Mode of Payment</td><td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>-----Select-----</asp:ListItem>
                                    <asp:ListItem>Monthly</asp:ListItem>
                                    <asp:ListItem>Yearly</asp:ListItem>
                                </asp:DropDownList>
                            </td>
							<td></td><td></td>
						</tr>
						<tr>
							<td>Amount Received</td><td><asp:TextBox ID="TextBox13" runat="server" 
                                AutoPostBack="True" ontextchanged="TextBox13_TextChanged"  ></asp:TextBox></td><td></td><td></td>
						</tr>
						<tr>
							<td>Expected Land Value at the end of term Rs.</td><td><asp:TextBox ID="TextBox14" runat="server"  ></asp:TextBox></td><td></td><td></td>
						</tr>
						<tr>
							<td>Subscription amount in each installment(s) Rs.</td><td>
                            <asp:TextBox ID="TextBox15" runat="server"   ></asp:TextBox></td>
							<td>
								
							</td>
							<td></td>
						</tr>
						<tr><td>Late Charges Rs.</td><td><asp:TextBox ID="TextBox16" runat="server"  ></asp:TextBox></td><td></td><td></td></tr>
					</table>
				</td>
				<td  style="border-left:2px solid blue;">
					<table>
						<tr style="height:80px;font-size:large;"><td>Associates's Name & Address</td></tr>
						<tr><td><asp:TextBox ID="TextBox17" runat="server" style="width:80%;height:50px;" TextMode="MultiLine"  ></asp:TextBox>	</td></tr>
						<tr><td style="height:60px;">For : HEED REAL ESTATE PRIVATE LIMITED</td></tr>
						<tr><td><div style="height:45px;">
                            <asp:Label ID="Label7" runat="server" ForeColor="White"></asp:Label>
                            <asp:Label 
                                ID="Label4" runat="server" Visible="true" ForeColor="White"></asp:Label>
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
					<td><asp:TextBox ID="TextBox18" runat="server" style="width:500px;height:30px;" Font-Size="Large"  ></asp:TextBox></td>
					<td><h3>Auth Signatory&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                        </h3></td>
				</tr>
               
			</table><br /><br />
            <br /><br />
            <table table style="width:100%;height:50px;padding:0px;background-color:yellow;">
             <tr><td class="style2"><span class="style1">Click Here For Send OTP ON +917007XXXXX4</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 <asp:Button ID="Button4" runat="server" Text="Send OTP" BackColor="#000066" 
                     ForeColor="White" style="font-size: large; font-weight: 700" 
                     onclick="Button4_Click" OnClientClick="javascript:return openRequestedPopup();"/></td>
                 <td class="style3">
                     <asp:Label ID="Label5" runat="server" Text="Enter OTP Here"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox6" runat="server" Height="24px" 
                         Width="130px"></asp:TextBox>
                 </td><td>
                     <asp:Button ID="Button5" runat="server" Font-Bold="True" ForeColor="Maroon" 
                         Text="Verify OTP" Width="89px" onclick="Button5_Click" />
                    &nbsp;&nbsp;
                     <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                    </td></tr>
            </table>
		</div>
        </form>
</div>
</body>
</html>









