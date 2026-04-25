<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printreg.aspx.cs" Inherits="printreg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
   <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<style type="text/css">
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
background:#ececec;
}
    .style1
    {
        height: 78px;
    }
    .style2
    {
        color: #FF0000;
        font-size:15pt;
    }
    .wrrper {
    width: 990px;
    margin: 0 auto;
    border: 15px solid navy;
}
</style>
<body>
<form id="Form1" runat="server">
<div class="wrrper">
<table>
<tr style="height:50px;"><td style="font-weight:bold;">CIN-U45201UP2019PTC123734</td>
    <td bgcolor="#00FFCC"><strong><span class="style2">CUSTOMER REG. NO</span>&nbsp;&nbsp;
        </strong>&nbsp;<asp:Label ID="Label1" runat="server" 
            Font-Bold="True" ForeColor="Red" Font-Size="15pt"></asp:Label></td><td style="text-align:right;font-weight:bold;font-size:15pt;">
        MOB. +91-9696446268, 9935142277</td></tr>
<tr><td colspan="3">
    <p style="font-size:40pt;color:red;font-weight:bold;margin-top:0px; font-stretch:expanded;">HEED REAL</p><p style="margin-top:-35px;font-size:23pt;font-stretch:expanded;">ESTATE PRIVATE LIMITED</p>
<p style="padding:10px;background-color:#000080;color:white;font-size:15pt;font-stretch:expanded;margin-top:-10px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p>
<p style="font-size:12pt;font-weight:bold;text-align:justify;">CERTIFIED that the associate described in Schedule here to Registered Joint Venture Of Consideration as shown in Schedule under Plan of Company subject to the regular payment of subscription (s) has mentioned in the said schedule and also subject to
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
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
			<td>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
			<td>
                 <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                &nbsp;</td>
			<td>
                 <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
			<td>
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
		  </tr>
		  </table>
	</tr>
	<tr>
		<table>
		  <tr>
			<th>Installment Due Date </th>
			<th>Expected sum payable on Expiry of Term</th> 
			<th>Date Of Last Payment</th>
			<th>Expiry Date</th>
			<th>Agency ID</th>
		  </tr>
		  <tr>
			<td>
               <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
			<td>
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
			<td>
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
			<td>
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
			<td>
                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
		  </tr>
		  </table>
	</tr>
	<tr>
		<table>
		<tr>
			<th style="width: 209px;" rowspan="4">Name ,D.O.B and Address Of Associateociate</th>
			<td rowspan="4">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
			<th style="    width: 90px;" colspan="2">Arazi No.</th>
		  </tr>
		  <tr>
			
			
			<td colspan="2">
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
		  </tr>
		  <tr>
			
			
			<th colspan="2">Plot Size</th>
		  </tr>
		  <tr>
			
			
			<td colspan="2">
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></td>
		  </tr>
		  <tr>
			<th style="width: 209px;">Nominee's  Name D.O.B and Relationship </th>
			<td>
                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></td>
			<td style="    width: 90px;">
                <strong>Aadhar/PAN<br />
                /Voter/D.L&nbsp; NO</strong></td>
			<td style="    width: 90px;">
                <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
              </td>
		  </tr>
		  <tr>
				<td colspan="4" style="text-align:left;font-weight:bold;">The expected sum payable to associate or his/her successor/ Nominee or Legal representative.</td>
		  </tr>
		  
		</table>
	</tr>
	<tr>
		<table>
			 <tr>
				<th style="width:20%;">EXPECTED SUM PAYABLE RUPEES</th>
				<td style="width:80%;" colspan="4">
                    <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></td>
		  </tr>
			<tr>
				<td rowspan="3" style="width:25%;font-weight:bold;">Date</td>
				<td rowspan="2"style="width:12.5%;"></td>
				<td rowspan="2" style="width:12.5%;"></td>
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
				<td colspan="5	"></td>
		  </tr>
		</table>
	</tr>
</table>
<table>
<tr><td style="font-weight:bold;" colspan="2">&nbsp;</td><td style="text-align:right;font-weight:bold;" colspan="2">
    MOB. +91-9696446268, 9935142277</td></tr>
<tr><td colspan="4">
    <p style="font-size:40pt;color:red;text-shadow:5px 2px grey;font-weight:bold;margin-top:5px; font-stretch:expanded;">HEED REAL</p><p style="margin-top:-35px;font-size:23pt;font-stretch:expanded;">ESTATE PRIVATE LIMITED</p>
<p style="padding:10px;background-color:#000080;color:white;font-size:15pt;font-stretch:expanded;margin-top:-10px;">19A ,New PAC Line, Gadiyana, Kanpur, Uttar Pradesh</p></td></tr>
<tr><th>&nbsp;</th><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><th>Receipt No. :</th><td>
    <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label></td></tr>
<tr><th colspan="2">Name, D.o.B and Address of Associate :</th><td colspan="2" rowspan="2">
    <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label></td></tr>
<tr><td colspan="2"></td></tr>
<th>Amount in words Rs.</th><td colspan="3">
    <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
    </td></tr>
</table>
<table>
<tr><td class="style1"><strong>Seal with Stamp Stamp Stamp</strong></td><td class="style1">
    <strong>Authorised by</strong></td>
    <td class="style1"> <strong>Authorised Signatory<br />  <asp:Label ID="Label2" runat="server"></asp:Label>
        </strong>
      
    </td></tr>
</table>
</table>
	
</div>
</form>
</body>
</html>
