<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Totaldetails.aspx.cs" Inherits="Total_Balance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>

<head><title>Balance Form</title>
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
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
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<style type="text/css">
    .wrrper{
width:995px;
height:885px;
margin:0 auto;
border:1px solid black;
box-shadow:0px 0px 50px grey;
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
    
	
	text-align:left;
}

th{
padding :2px;
}
td{
padding :3px;
}
P
{
    font-size:xx-large;
    text-align:center;
    color:Maroon;
}
.b
{
    font-size:large;
    text-align:center;
    background-color:#9999FF;
}
.b:hover
{
     font-size:large;
    background-color:Orange;
}
    
    .style2
    {
        height: 72px;
        font-size:xx-large;
        color:Maroon;
    }
    
    .style3
    {
        height: 48px;
        color: Blue;
        font-size: large;
    }
    .style4
    {
        height: 48px;
    }
    .style5
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
    }
    .style6
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
        width: 138px;
    }
    .style9
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
        width: 358px;
    }
    .style10
    {
        height: 36px;
        color: Blue;
        font-size: large;
        width: 148px;
    }
    .style11
    {
        height: 36px;
        color: Blue;
        font-size: large;
        width: 117px;
    }
    .style12
    {
        height: 48px;
        color: Blue;
        font-size: x-large;
        }
    .style14
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
        width: 117px;
    }
    .style15
    {
        height: 36px;
        color: Blue;
        font-size: large;
    }
    .style16
    {
        font-size: large;
    }
    
</style>
</head>
<body>
<div class="wrrper">
<form id="Form1" runat="server">
<table>
<tr><th colspan="5" style="text-align:center;" class="style2">MONTH WISE PAYMENT BALANCE</th></tr>
	<tr><th colspan="5" >NAME   <asp:DropDownList ID="DropDownList6" runat="server" Height="34px" 
        style="font-weight: 700" Width="110px" AutoPostBack="True"  onselectedindexchanged="DropDownList6_SelectedIndexChanged">
        <asp:ListItem>------SELECT------</asp:ListItem>
    </asp:DropDownList></th></tr>
<tr><th class="style9" colspan="5"><span class="style16">ARAZI NO.</span>&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" Height="34px" 
        style="font-weight: 700" Width="110px" AutoPostBack="True"  onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>------SELECT------</asp:ListItem>
    </asp:DropDownList>
	 &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="Label4" runat="server" Text="BLOCK" Visible="False" style="font-weight: 100"></asp:Label>
     &nbsp;&nbsp;&nbsp;
     <asp:DropDownList ID="DropDownList4" runat="server" Height="24px" 
         Visible="False" Width="93px">
         <asp:ListItem>---SELECT---</asp:ListItem>
         <asp:ListItem Value="152">A,B,C</asp:ListItem>
         <asp:ListItem>D</asp:ListItem>
         <asp:ListItem>E</asp:ListItem>
		  <asp:ListItem>F</asp:ListItem>
     </asp:DropDownList>
	</th></tr>
	<tr><th class="style10">DATE FROM</th><th class="style5">
    <asp:TextBox ID="TextBox1" runat="server" class="d" Height="28px" Width="110px"></asp:TextBox></th>
    <th class="style11" >DATE TILL</th><th class="style6">
        <asp:TextBox ID="TextBox2" runat="server" class="d" Height="27px" Width="110px"></asp:TextBox></th>
</tr>

<tr><th class="style3" colspan="2">TOTAL INCOME OF ARAZI</th><th class="style4">
    <asp:Button ID="Button1" runat="server" class="b" Text="INCOME" Width="148px" 
        onclick="Button1_Click" /></th><th class="style12" colspan="2">
        
        <asp:Button ID="Button2" runat="server" BackColor="#000066" Font-Bold="True" 
            Font-Size="Medium" ForeColor="White" Height="34px" onclick="Button2_Click" 
            Text="ALL ARAZI DETAILS" Width="180px" />
        
    </th></tr>
<tr><th class="style15" colspan="2">TOTAL INCOME </th><th class="style5">
    <asp:Label ID="Label1" runat="server" Text="" style="font-size: large"></asp:Label>
    </th>
    <th class="style14" ></th><th class="style6">
    </th>
</tr>
<tr><th colspan="5">
    <asp:GridView ID="GridView1" runat="server" CellPadding="3" Width="989px" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
        BorderWidth="1px" AutoGenerateColumns="False" 
      >
      <Columns>
                        <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>REG.NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("CUSTREGNO") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="200">
                  <HeaderTemplate>Address</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("ASCADDRESS") %>'></asp:Label>
                  </ItemTemplate>
                  <ItemStyle Width="300px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>Recipt</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="damount1" runat="server" Text='<%# Eval("RECIPT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>Date</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("DATE1","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>



<ItemStyle Width="80px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("AMOUNTR") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="40">
                  <HeaderTemplate>Check By</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cstatus1" runat="server" Text='<%# Eval("checkby") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>
                  </asp:TemplateField>
                  
                        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    </th></tr>
</table>
</form>	
</div>
</body>
</html>
