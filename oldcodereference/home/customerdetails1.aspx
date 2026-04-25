<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customerdetails1.aspx.cs" Inherits="customer_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
<head>
<title>Customer Details</title>
<link rel="shortcut icon" href="images/2.jpeg" type="image/jpeg" />
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<style type="text/css">
    body
    {
        background-image:url("images/gd.jpg");
        background-size:cover;
    }
.wrrper{
width:1172px;
margin:0 auto;
border:5px solid black;
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
background-color:Maroon;
color:White;
}
td
{
    padding:5px;
}


    .style1
    {
        width: 159px;
    }
    .style2
    {
        width: 464px
    }


</style>
</head>
<body>
<div class="wrrper">
<form runat="server">
<table>
<tr><td colspan="3" style="font-size:larger;FONT-WEIGHT:bold;color:White;" bgcolor="Black">CUSTOMER DETAIL</td></tr>
<tr>
<td class="style2">
    <asp:Label ID="Label1" runat="server" Text="Customer Registration ID"  
        style="font-size:larger;FONT-WEIGHT:bold;"></asp:Label>
</td>
<td class="style1">
    <asp:TextBox ID="TextBox1" runat="server" Height="22px" ReadOnly="True" 
        Width="143px"></asp:TextBox>
</td>
<td>
   <p align="left"> <asp:Label ID="Label12" runat="server" Text=" "  style="font-size:larger;FONT-WEIGHT:bold;"></asp:Label>&nbsp;  &nbsp; &nbsp;     </p>
</td>
</tr>
<tr><td colspan="3" style="font-size:larger;FONT-WEIGHT:bold;">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        Font-Size="11pt" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>

</td></tr>
<tr><th style="font-size:larger;FONT-WEIGHT:bold;" colspan="2">
    <asp:Label ID="Label2" runat="server" Text="Expected Amount"></asp:Label></th>
    <td style="font-size:larger;FONT-WEIGHT:bold;" colspan="2" bgcolor="White">
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label></td></tr>
<tr><th style="font-size:larger;FONT-WEIGHT:bold;" colspan="2">
    <asp:Label ID="Label3" runat="server" Text="Received Amount"></asp:Label></th>
<td style="font-size:larger;FONT-WEIGHT:bold;" bgcolor="White" >
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td></tr>
    <tr><th style="font-size:larger;FONT-WEIGHT:bold;" colspan="2">
    <asp:Label ID="Label6" runat="server" Text="Balance Amount"></asp:Label></th>
<td style="font-size:larger;FONT-WEIGHT:bold;" colspan="2" bgcolor="White">
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td></tr>
    <tr><td colspan="3" style="font-size:larger;FONT-WEIGHT:bold;">
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td></tr>
</table>
	</form>
</div>
</body>
</html>
