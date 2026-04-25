<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regcertificatedetails.aspx.cs" Inherits="regcertificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
<head><title>Registration Certificate</title>
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBox1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox6").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox8").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox9").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });

        });
    </script>
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<style>

.wrrper {
    width: 990px;
    margin: 0 auto;
    border: 15px solid navy;
}
table {
    border-collapse: collapse;
	width:100%;
}

table, td, th {
    border: 1px solid black;
	
	text-align:center;
}

th{
padding :5px;
}
td{
padding :10px;
}
th{
background:#00FFCC;
}
    .style1
    {
        height: 78px;
    }
    .style2
    {
        color: #FF0000;
    }
	
    .style3
    {
        width: 558px;
    }
    .style4
    {
        width: 552px;
    }
    .style5
    {
        width: 182px;
    }
	
    .style6
    {
        width: 702px;
    }
	
</style>
</head>
<body>
<form runat="server">
<div class="wrrper">
<table>
<tr><td>&nbsp;<strong><span class="style2"><asp:DropDownList ID="DropDownList7" 
        runat="server" Height="16px" Width="56px" Visible="False">
            <asp:ListItem>--select---</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
        </asp:DropDownList>
    </span></strong> </td>
    <td bgcolor="#00FFCC" class="style6"><strong><span class="style2">REG. NO</span>&nbsp;&nbsp;<asp:TextBox 
            ID="TextBox21" runat="server" Width="80px" Font-Size="Medium" 
            Height="28px"></asp:TextBox>
&nbsp;</strong>&nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            style="font-weight: 700" Text="Search" Width="61px" />
    &nbsp;
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            style="font-weight: 700" Text="Delete" Visible="False" />
&nbsp;&nbsp;&nbsp; <asp:Button ID="Button4" runat="server" style="font-weight: 700" Text="Update" 
            onclick="Button4_Click" />
        <strong>&nbsp;&nbsp;&nbsp; <asp:Button ID="Button12" runat="server" 
            style="font-weight: 700" Text="Confirm" 
            onclick="Button12_Click" />
        <asp:Label ID="Label2" 
            runat="server" ForeColor="Red"></asp:Label>
        </strong>
      
    </td><td style="text-align:right;font-weight:bold;">MOB. +91-9696446268, 9935142277</td></tr>
<tr><td colspan="3" class="style4">
    <p style="font-size:37pt;color:red;font-weight:bold;margin-top:1px; font-stretch:expanded; width: 961px;">HEED REAL</p>
    <p style="margin-top:-35px;font-size:21pt;font-stretch:expanded; width: 964px;">ESTATE PRIVATE LIMITED</p>
<p style="padding:3px;background-color:#000080;color:white;font-size:15pt;font-stretch:expanded;margin-top:-10px; width: 960px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
<p style="font-size:12pt;font-weight:bold;text-align:justify; width: 977px;">CERTIFIED that the associate described in Schedule here to Registered Joint Venture Of Consideration as shown in Schedule under Plan of Company subject to the regular payment of subscription (s) has mentioned in the said schedule and also subject to
 "general terms & conditions"printed over leaf and terms and conditions as per rules book, as may be amendment from time to time, and compay shall pay in indian currency at its associate service center through corp.Office, the amount due under certificate in accordance with 
terms of said schedule of the person whome the same in here in express to payable. It is hereby declared that schedule "general terms & condition" and other terms of rules book as amended from time to time, shall be deemed to be a part of this certificate.
</p>

</td></tr>	
		<table>
		  <tr>
			<th>Regd.No & Date of Commenement </th>
			<th>Plan Name / Term  </th> 
			<th>Mode of Payment</th>
			<th>Considerration Amount</th>
	<TH>Insatallment of subscribtion Pyament</TH>
		  </tr>
		  <tr>
			<td>
                <asp:TextBox ID="TextBox1" runat="server" name="" class="textboxmain"></asp:TextBox></td>
			<td>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="101px">
                    <asp:ListItem>-------select------</asp:ListItem>
                </asp:DropDownList>
				<asp:Label ID="Label11" runat="server" Text=""></asp:Label>
              </td>
			<td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                   
                    <asp:ListItem>MONTHLY</asp:ListItem>
                    <asp:ListItem>YEARLY</asp:ListItem>
                </asp:DropDownList>
                &nbsp;</td>
			<td>
                <asp:TextBox ID="TextBox4" runat="server" name="" class="textboxmain"></asp:TextBox></td>
			<td>
                <asp:TextBox ID="TextBox5" runat="server" name="" class="textboxmain"></asp:TextBox></td>
		  </tr>
		  </table>
	</tr>
	<tr>
		<table>
		  <tr>
			<th>Subscription Due Date </th>
			<th>Booking Amount</th> 
			<th>Date Of Last Payment</th>
			<th>Expiry Date</th>
			<th>Agency ID</th>
		  </tr>
		  <tr>
			<td>
                <asp:TextBox ID="TextBox6" runat="server" name="" class="textboxmain"></asp:TextBox></td>
			<td>
                <asp:TextBox ID="TextBox7" runat="server" name="" class="textboxmain" 
                    ></asp:TextBox></td>
			<td>
                <asp:TextBox ID="TextBox8" runat="server" name="" class="textboxmain"></asp:TextBox></td>
			<td>
                <asp:TextBox ID="TextBox9" runat="server" name="" class="textboxmain"></asp:TextBox></td>
			<td>
                <asp:TextBox ID="TextBox10" runat="server" name="" class="textboxmain" 
                    Font-Bold="True" Font-Size="8pt" ReadOnly="True" Width="147px">.</asp:TextBox></td>
		  </tr>
		  </table>
	</tr>
	<tr>
		<table>
		<tr>
			<th style="width: 209px;" rowspan="4">Name ,D.O.B and Address Of Associateociate</th>
			<td rowspan="4" class="style5">
                <asp:TextBox ID="TextBox11" runat="server" name="" class="textboxmain" 
                    Height="122px" TextMode="MultiLine" Width="356px"></asp:TextBox></td>
			<th style="    width: 195px;">Arazi No.</th>
		  </tr>
		  <tr>
			
			
			<td>
                <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="105px" 
                    AutoPostBack="True" onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                    <asp:ListItem>------select-------</asp:ListItem>
                </asp:DropDownList>
				<asp:Label ID="Label12" runat="server" Text=""></asp:Label>
              </td>
		  </tr>
		  <tr>
			
			
			<th>Plot No./Plot Size</th>
		  </tr>
		  <tr>
			
			
			<td>
                <asp:TextBox ID="TextBox20" runat="server" Height="30px" Width="62px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox13" runat="server" name="" class="textboxmain" 
                    Height="29px" Width="64px"></asp:TextBox></td>
		  </tr>
		  <tr>
			<th style="width: 209px;">Nominee's  Name D.O.B and Relationship</th>
			<td class="style5">
                <asp:TextBox ID="TextBox14" runat="server" name="" class="textboxmain" 
                    TextMode="MultiLine" Width="366px"></asp:TextBox></td>
			<td>
                <asp:Panel ID="Panel1" 
                        runat="server" BackColor="#99FF33" Height="93px" Width="388px">
                    <asp:Label ID="Label7" runat="server" Text="BLOCK"></asp:Label>
&nbsp;
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="16px" Width="62px">
                        <asp:ListItem>-select---</asp:ListItem>
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem>D</asp:ListItem>
						<asp:ListItem>E</asp:ListItem>
						<asp:ListItem>F</asp:ListItem>
                        <asp:ListItem>NONE</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp; PLOT NO. 
                    <asp:TextBox 
                            ID="TextBox24" runat="server" Height="26px" 
    Width="37px"></asp:TextBox>&nbsp;
                    <asp:Button ID="Button8" runat="server" Height="25px" Text="Book" 
                        Width="52px" onclick="Button8_Click" />
                    &nbsp;
                    <asp:Button ID="Button9" runat="server" Height="26px" Text="Search" 
                        Width="46px" onclick="Button9_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label 
                            ID="Label6" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Panel ID="Panel2" runat="server" Height="32px">
                        Plot No. Replace with&nbsp;
                        <asp:TextBox ID="TextBox23" runat="server" Height="24px" Width="43px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button10" runat="server" Text="Update" 
                            onclick="Button10_Click" />
                    </asp:Panel>
                </asp:Panel></tr>
		  <tr>
			<th style="width: 209px;">&nbsp;<strong>Aadhar/PAN<br />
                /Voter/D.L&nbsp; NO</strong>
			  </th>
			<td class="style5">
                
                <asp:TextBox ID="TextBox2" runat="server" Width="146px" 
                    style="text-align: left"></asp:TextBox>
                </td>
			<td>
                <asp:Panel ID="Panel3" 
                        runat="server" BackColor="#99FFCC" Height="77px" Width="388px">
                    <asp:Label ID="Label15" runat="server" Text="BLOCK"></asp:Label>
&nbsp;
                    <asp:DropDownList ID="DropDownList6" runat="server" Height="16px" Width="74px">
                        <asp:ListItem>-select---</asp:ListItem>
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
						 <asp:ListItem>D</asp:ListItem>
						 <asp:ListItem>E</asp:ListItem>
						 <asp:ListItem>F</asp:ListItem>
                        <asp:ListItem>NONE</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp; PLOT NO. 
                    <asp:TextBox 
                            ID="TextBox25" runat="server" Height="27px" 
    Width="45px"></asp:TextBox>&nbsp;
                    <asp:Button ID="Button11" runat="server" onclick="Button11_Click" 
                        style="font-weight: 700" Text="UPDATE PLOT" Width="114px" />
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label 
                            ID="Label14" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel></tr>
		  <tr>
				<td colspan="3" style="text-align:left;font-weight:bold;">The expected sum payable to associate or his/her successor/ Nominee or Legal representative.</td>
		  </tr>
		  
		  <tr>
				<td colspan="3" style="text-align:left;font-weight:bold;">&nbsp;</td>
		  </tr>
		  
		</table>
	</tr>
	<tr>
		<table>
			 <tr>
				<th style="width:20%;">EXPECTED SUM PAYABLE RUPEES</th>
				<td style="width:80%;" colspan="4">
                    <asp:TextBox ID="TextBox15" runat="server" name="" class="textboxmain" 
                        Width="407px" ReadOnly="True"></asp:TextBox></td>
		  </tr>
			<tr>
				<td rowspan="3" style="width:25%;font-weight:bold;">
                    &nbsp;</td>
				<td rowspan="2"style="width:12.5%;"></td>
				<td rowspan="2" style="width:12.5%;">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="18px" Width="187px">
                        <asp:ListItem>---Select----</asp:ListItem>
                    </asp:DropDownList>
                </td>
				<td  rowspan="2" style="width:12.5%;"></td>
				<td style="width:25%;text-align:left;">For</td>
			</tr>
				
				
				<td style="width:25%;"></td>
			</tr>
			<tr>
				<td style="width:12.5%;"></td>
				<td style="width:12.5%;">Checked By</td>
				<td style="width:12.5%;">Authorised By</td>
				<td style="width:25%;">Authorised Signatory</td>
			</tr>
			 <tr>
				<td colspan="5	">
                    <asp:Label ID="Label13" runat="server" ForeColor="White"></asp:Label>
                 </td>
		  </tr>
		</table>
	</tr>
</table>
<table>
<tr><td style="font-weight:bold;" colspan="2">&nbsp;</td><td style="text-align:right;font-weight:bold;" colspan="2">MOB. +91-9696446268, 9935142277</td></tr>
<tr><td colspan="4" class="style3">
    <p style="font-size:37pt;color:red;text-shadow:5px 2px grey;font-weight:bold;margin-top:5px; font-stretch:expanded; width: 964px; margin-bottom: 19px;">HEED REAL</p>
    <p style="margin-top:-35px;font-size:21pt;font-stretch:expanded; width: 963px;">ESTATE PRIVATE LIMITED</p>
<p style="padding:3px;background-color:#000080;color:white;font-size:15pt;font-stretch:expanded;margin-top:-10px; width: 958px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p></td></tr>
<tr><th>Mobile No</th><td>
    <asp:TextBox ID="TextBox3" runat="server" Width="140px"></asp:TextBox>&nbsp;&nbsp; 
    ,
    <asp:TextBox ID="TextBox22" runat="server">0</asp:TextBox>
    </td><th>Receipt No. :</th><td>
    <asp:TextBox ID="TextBox16" runat="server" ReadOnly="True"></asp:TextBox></td></tr>
<tr><th colspan="2">Name, D.o.B and Address of Associate :</th><td colspan="2" rowspan="2">
    <asp:TextBox ID="TextBox18" runat="server" name="" class="textboxmain" 
        Height="51px" TextMode="MultiLine" Width="268px" ReadOnly="True"></asp:TextBox></td></tr>
<tr><td colspan="2"></td></tr>
<th>Amount in words Rs.</th><td colspan="3">
    <asp:TextBox ID="TextBox17" runat="server" name="" class="textboxmain" 
        Width="455px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </td></tr>
</table>
<table>
<tr><td class="style1"><strong>Seal with Stamp Stamp Stamp</strong></td><td class="style1">
    <strong>Authorised by</strong></td>
    <td class="style1"> <strong>Authorised Signatory<br />  
        </strong>
      
    </td></tr>
</table>
</table>
	
</div>
</form>
</body>
</html>
