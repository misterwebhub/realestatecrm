<%@ Page Language="C#" AutoEventWireup="true" CodeFile="partnerpaid.aspx.cs" Inherits="partnerpaid" %>

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
    .style4
    {
    }
    .style5
    {
        height: 44px;
    }
</style>
</head>
<body>
<div>
<form id="Form1" runat="server">
<div id="main" class="t">
<table style="width:100%;height:100%;" BORDER="1" rules="rows">
<tr><td colspan="4" style="font-size:20PT;text-align:center;" 
        bgcolor="#FF9900" class="style5">PARTNER PAID INSTALLMENT</td></tr>
 <tr><td style="font-weight:bold;" class="style2" colspan="2" bgcolor="White">SELECT&nbsp; 
     DATE ( TYPE ) FROM&nbsp;&nbsp; &nbsp;
     <asp:DropDownList ID="DropDownList1" runat="server" Height="29px" Width="191px">
         <asp:ListItem>----SELECT----</asp:ListItem>
         <asp:ListItem>FROM JUNE-DEC (2020)</asp:ListItem>
         <asp:ListItem>FROM JANUARY (2021)</asp:ListItem>
     </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; USER&nbsp;
     <asp:DropDownList ID="DropDownList2" runat="server" Height="29px" Width="121px">
         <asp:ListItem>---select---</asp:ListItem>
     </asp:DropDownList>
     </td><td style="font-weight:bold;" class="style1">&nbsp;</td>
     <td class="style1">    &nbsp;&nbsp; </td></tr>
 <tr height="45px"><td style="font-weight:bold;" class="style4">DATE FROMM</td>
     <td>
     <asp:TextBox ID="TextBox1" runat="server" class="d" Height="22px" Width="149px">DD/MM/YY</asp:TextBox>
     </td><td style="font-weight:bold;">DATE TO</td><td>    <asp:TextBox ID="TextBox2" runat="server" class="d" Height="22px" Width="183px">DD/MM/YY</asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button1" runat="server" BackColor="#000066" 
         onclick="Button1_Click" style="font-weight: 700; color: #FFFFFF" Text="VIEW" 
         Width="76px" />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="Label4" runat="server"></asp:Label>
     </td></tr>
 <tr><td style="font-weight:bold;" colspan="4">TOTAL RECIEVED AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
     PERC. (%)
     <asp:TextBox ID="TextBox3" runat="server" Height="27px" Width="57px" 
         AutoPostBack="True" ontextchanged="TextBox3_TextChanged"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="TextBox4" runat="server" Height="25px" ReadOnly="True" 
         Width="126px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; BALANCE AMT-&nbsp;
     <asp:Label ID="Label5" runat="server">0</asp:Label>
     &nbsp;&nbsp;&nbsp; </td>
    
    </tr>
    <tr><td colspan="4" bgcolor="Aqua">
		
        NAME&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Height="27px" Width="245px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DATE&nbsp;
        <asp:TextBox ID="TextBox6" runat="server" Height="26px" Width="128px" CLASS="d">DD/MM/YY</asp:TextBox>
&nbsp;&nbsp;&nbsp;PERSON(5 )&nbsp;
        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Height="20px" 
            oncheckedchanged="CheckBox1_CheckedChanged" />
&nbsp;AMOUNT&nbsp;
        <asp:TextBox ID="TextBox7" runat="server" Height="28px" Width="102px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" BackColor="#666633" 
            style="color: #FFFFFF; font-weight: 700" Text="PAID" Width="73px" 
            onclick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" BackColor="Yellow" 
            onclick="Button3_Click" style="font-weight: 700; margin-bottom: 0px" 
            Text="New Entry" Width="76px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server"></asp:Label>
		
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		
        <br />
		
    </td></tr>
	<tr><td style="font-weight:bold;" class="style4" colspan="4">
        <asp:GridView ID="GridView1" runat="server" BackColor="White"  
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            ForeColor="Black" GridLines="Vertical" 
            style="margin-top: 9px;text-align:center; margin-left: 32px;" Width="94%" 
            AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
              <Columns>
   
                    <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
        </asp:GridView>
        </td></tr>
</table>
</div>

</form>
</div>

</body>
</html>


