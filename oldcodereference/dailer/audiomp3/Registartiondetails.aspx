<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registartiondetails.aspx.cs" Inherits="Registartion_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
<head><title>Registarion Details</title>
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<style type="text/css">
 .WrapText {  
            width: 100%;  
            word-break: break-all; 
        } 
body
{
    background-image:url("images/regbak.jpg");
    background-size:cover;
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
padding :2px;
}
td{
padding :3px;
}
P
{
    font-size:x-large;
}
</style>
</head>
<body>
<div class="wrrper">
<form runat="server">
<table>
<tr><th><P>CUSTOMER REGISTARTION DETAILS</P></th></tr>
<tr><th><div class="WrapText">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Height="100%" Width="100%" 
        Font-Size="9pt">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" 
            CssClass="col-md-push-9" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
	</asp:GridView></div>
</th></tr><tr><th>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></th></tr>
</table>
</form>
	
</div>
</body>
</html>
