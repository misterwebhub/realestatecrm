<%@ Page Language="C#" AutoEventWireup="true" CodeFile="partner2.aspx.cs" Inherits="kishan_Bin_partner2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".d").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>

<style type="text/css">
body
{
background-image:url("im.jpg");
background-size:cover;
}
#main
{
margin-top:50px;
background-color:#D6EAF8;
height:80%;
box-shadow:1px 1px 30px black;
float:left;

}
#s
{
height:35px;
width:100%;
font-size:16pt;
background-color:black;
color:white;
}
#s:hover
{
height:35px;
width:100%;
font-size:16pt;
background-color:orange;
color:black;
}

.t
{
    width:100%;
}
    .style1
    {
        height: 17px;
    }
    .style2
    {
        height: 17px;
        color: #FF0000;
    }
    .style3
    {
        color: #003300;
        text-decoration: underline;
    }
    .style4
    {
        color: #990000;
    }
</style>
</head>
<body>
<div>
<form id="Form1" runat="server">
<div id="main" class="t">
<table style="width:100%;height:100%;" BORDER="1" rules="rows">
<tr height="45px"><td colspan="4" style="font-size:20PT;text-align:center;" 
        bgcolor="#99FF66">CHECK 
    PARTNER2 PAID INSTALLMENT( JANUARY 2021)</td></tr>
 <tr><td style="font-weight:bold;" bgcolor="Yellow" class="style2" colspan="2">
     SELECT&nbsp; DATE&nbsp;FROM&nbsp;&nbsp; 1/ JAN / 2021 </td>
     <td style="font-weight:bold;" class="style1" bgcolor="Yellow"></td>
     <td class="style1" bgcolor="Yellow">    &nbsp;&nbsp; </td></tr>
 <tr height="45px"><td style="font-weight:bold;">DATE FROM</td><td>
     <asp:TextBox ID="TextBox1" runat="server" class="d" Height="22px" Width="183px">MM/DD/YY</asp:TextBox>
     </td><td style="font-weight:bold;">DATE TO</td><td>    <asp:TextBox ID="TextBox2" runat="server" class="d" Height="22px" Width="183px">MM/DD/YY</asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <strong>ARAZI NO</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="119px">
         <asp:ListItem>----SELECT-----</asp:ListItem>
     </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button1" runat="server" BackColor="#000066" 
         onclick="Button1_Click" style="font-weight: 700; color: #FFFFFF" Text="VIEW" 
         Width="99px" />
     &nbsp;&nbsp;
     <asp:Button ID="Button2" runat="server" BackColor="#000066" 
         onclick="Button2_Click" style="font-weight: 700; color: #FFFFFF" 
         Text="ALL DETAILS" Width="102px" />
     </td></tr>
 <tr><td style="font-weight:bold;" colspan="2">&nbsp;</td>
    
    <td>&nbsp;</td><td>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td></tr>
    <tr><td colspan="4" style="text-align: left" bgcolor="Lime">
		
        <strong>DATE FROM </strong>&nbsp;&nbsp;
     <asp:TextBox ID="TextBox3" runat="server" class="d" Height="22px" Width="183px">MM/DD/YY</asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>DATE TO</strong>&nbsp;&nbsp;    
        <asp:TextBox ID="TextBox4" runat="server" class="d" Height="22px" Width="183px">MM/DD/YY</asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Height="28px" onclick="Button3_Click" 
            style="font-weight: 700" Text="Get Sanigawan Details" Width="207px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
		
    </td></tr>
    <tr><td colspan="4" style="text-align: right">
		
        <strong>TOTAL RECEIVE AMOUNT </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" ForeColor="Red" 
            style="text-align: right; font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		
    </td></tr>
    <tr><td colspan="4">
		
        <span class="style3"><strong>( OFFICE DETAILS )</strong></span><br />
        <asp:GridView ID="GridView2" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Width="100%" 
            AutoGenerateColumns="False">
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
             <Columns>
     <asp:TemplateField>
                  <HeaderTemplate>CUSTOMER REG.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("CUSTREGNO") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>FULL AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("AMOUNT") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>% AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("AMOUNT1") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("DATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>PLOT NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("plotno") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>PLOT SIZE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("PLOTSIZE") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>BROKAR</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson7" runat="server" Text='<%# Eval("CHECKBY") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
        </asp:GridView>
		
    </td></tr>
	<tr><td style="font-weight:bold; text-align: left;" colspan="4">
        <span class="style4">( BROKAR DETAILS )&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        </span>
		<asp:Label ID="Label5" runat="server" Text="TOTAL OFFICE RECEIVED AMOUNT"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td></tr>
	<tr><td style="font-weight:bold;" colspan="4">
        <asp:GridView ID="GridView3" runat="server" BackColor="White" 
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            Width="100%" 
            AutoGenerateColumns="False">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
             <Columns>
     <asp:TemplateField>
                  <HeaderTemplate>CUSTOMER REG.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson2" runat="server" Text='<%# Eval("CUSTREGNO") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson3" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>FULL AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson4" runat="server" Text='<%# Eval("AMOUNT") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>% AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson4" runat="server" Text='<%# Eval("AMOUNT1") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson5" runat="server" 
                          Text='<%# Eval("DATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>PLOT NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson6" runat="server" Text='<%# Eval("plotno") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>PLOT SIZE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson7" runat="server" Text='<%# Eval("PLOTSIZE") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>BROKAR</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson7" runat="server" Text='<%# Eval("CHECKBY") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
        </asp:GridView>
		
        </td></tr>
	<tr><td style="font-weight:bold; text-align: right;" colspan="4"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label3" runat="server" Text="TOTAL BROKAR  RECEIVED AMOUNT"></asp:Label>
        </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td></tr>
</table>
</div>

</form>
</div>

</body>
</html>


