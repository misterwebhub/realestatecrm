<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customerdetails.aspx.cs" Inherits="customer_details" %>

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
        height: 34px;
    }
    .style2
    {
    }


    .style3
    {
        width: 100%;
    }
    .style4
    {
        text-align: left;
    }
    .style5
    {
        font-weight: bold;
    }
    .style6
    {
        text-align: left;
    }
    .style7
    {
        text-align: left;
        width: 377px;
    }
    .style8
    {
        width: 605px;
        height: 34px;
    }
    .style9
    {
        height: 34px;
    }


</style>
</head>
<body>
<div class="wrrper">
<form runat="server">
<table>
<tr><td colspan="3" 
        style="font-size:larger;FONT-WEIGHT:bold;color:White; text-align: center;" 
        bgcolor="Black">CUSTOMER DETAIL</td></tr>
<tr>
<td class="style8" bgcolor="#CCFFFF">
    <asp:Label ID="Label1" runat="server" Text="Enter Customer Registration ID (Example 'REG001') "  style="font-size:larger;FONT-WEIGHT:bold;"></asp:Label>
</td>
<td class="style1" bgcolor="#CCFFFF">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
<td bgcolor="#CCFFFF" class="style9">
   <p align="left"> <asp:Label ID="Label12" runat="server" Text=" "  style="font-size:larger;FONT-WEIGHT:bold;"></asp:Label>&nbsp;  &nbsp; &nbsp;     <asp:Button ID="Button1" runat="server" Text="GET DETAILS" BackColor="#00CCFF" 
        BorderColor="#660066" BorderStyle="Dotted" Font-Bold="True" ForeColor="Black" 
																																					 onclick="Button1_Click" /></p>
</td>
</tr>
<tr>
<td class="style2" colspan="3">
    <table bgcolor="#FFFF99" class="style3">
        <tr>
            <td class="style6">
                <b>REG. NO-&nbsp;&nbsp;&nbsp; </b>
                <asp:Label ID="Label13" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
            <td class="style7">
                <b>ARAZI NO.-&nbsp;&nbsp;&nbsp; </b>
                <asp:Label ID="Label14" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>TOTAL AMT</strong>-&nbsp;
                <asp:Label ID="Label18" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
            <td class="style4">
                <b>PLAN -&nbsp;&nbsp; </b>
                <asp:Label ID="Label15" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
            <td class="style4">
                <b>MOBILE NO-&nbsp; </b>
                <asp:Label ID="Label16" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="4">
                <strong>NAME -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                <asp:Label ID="Label17" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
        </tr>
    </table>
</td>
</tr>
<tr><td colspan="3" style="font-size:larger;FONT-WEIGHT:bold;text-align:left;">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        Font-Size="11pt" GridLines="Vertical"  onrowdatabound="GridView1_RowDataBound" style="text-align:left;">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" />
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
    <td style="font-size:larger;FONT-WEIGHT:bold; text-align: center;" 
        bgcolor="White">
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label></td></tr>
<tr><th style="font-size:larger;FONT-WEIGHT:bold;" colspan="2">
    <asp:Label ID="Label3" runat="server" Text="Received Amount"></asp:Label></th>
<td style="font-size:larger;FONT-WEIGHT:bold; text-align: center;" bgcolor="White" >
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td></tr>
    <tr><th style="font-size:larger;FONT-WEIGHT:bold;" colspan="2">
    <asp:Label ID="Label6" runat="server" Text="Balance Amount"></asp:Label></th>
<td style="font-size:larger;FONT-WEIGHT:bold; text-align: center;" bgcolor="White">
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td></tr>
    <tr><td colspan="3" style="font-size:larger;FONT-WEIGHT:bold;">
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td></tr>
</table>
	</form>
</div>
</body>
</html>
