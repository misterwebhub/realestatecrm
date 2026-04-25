<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sms.aspx.cs" Inherits="sms_sms" %>

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
<script type="text/javascript">
    
    var windowObjectReference;


    function openRequestedPopup() {
        var s = document.getElementById('TextBox3').value;

        var b = document.getElementById('msg').value;

        windowObjectReference = window.open("http://sms.webguard.in/api/sendhttp.php?authkey=330026A7runOjvu5f533531P1&mobiles="+s+"&message="+b+"&sender=HEEDKP&route=4");
    }


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
background-color:rgba(255,255,255,.5);
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
.r
{
    width:40%;
}
.t
{
    width:57%;
}
    .style1
    {
        color: #FFFFFF;
    }
</style>
</head>
<body>
<div>
<form runat=server>
<div id="main" class="t">
<table style="width:100%;height:100%;" BORDER="1" rules="rows">
<tr height="45px">
    <td colspan="4" style="font-size:20PT;text-align:center;" 
		bgcolor="#000066" class="style1">C<a href='https://heedrealestate.com/home/reciptupashoktemp.aspx' target="_blank" style="color:white;text-decoration:none;">H</a>ECK PAID INSTALLMENT</td></tr>
 <tr height="45px"><td style="font-weight:bold;" bgcolor="#66FFCC">DATE FROM</td>
     <td bgcolor="#66FFCC"><asp:TextBox ID="TextBox1" runat="server" class="d" Height="22px" Width="183px">DD/MM/YY</asp:TextBox></td>
     <td style="font-weight:bold;" bgcolor="#66FFCC">DATE TO</td>
     <td bgcolor="#66FFCC">    <asp:TextBox ID="TextBox2" runat="server" class="d" Height="22px" Width="183px">DD/MM/YY</asp:TextBox></td></tr>
 <tr><td style="font-weight:bold;" colspan="2" bgcolor="#66FFCC">Select Arazi No&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" Height="28px" 
         Width="118px">
        </asp:DropDownList>
     </td>
    
    <td bgcolor="#66FFCC">
        &nbsp;</td><td bgcolor="#66FFCC">
         SELECT STATUS&nbsp;
         <asp:DropDownList ID="DropDownList1" runat="server" Height="28px" 
            Width="141px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True">
        <asp:ListItem>-----SELECT------</asp:ListItem>
        <asp:ListItem>PAID</asp:ListItem>
        <asp:ListItem>NON PAID</asp:ListItem>
    </asp:DropDownList>&nbsp; </td></tr>
 <tr><td style="font-weight:bold;" colspan="2" bgcolor="#66FFCC">&nbsp;</td>
    
    <td bgcolor="#66FFCC">&nbsp;</td><td bgcolor="#66FFCC">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td></tr>
    <tr><td colspan="4">
        <asp:GridView ID="GridView1" runat="server" Width="100%" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </td></tr>
</table>
</div>
<div id="main" class="r">	
<table style="height:450px;" bgcolor="#FFCCFF">
<tr><td colspan="2" style="font-size:x-large;font-weight:bold;">WELCOME HEED REALPVT LTD. SMS PAGE</tr>

<tr><td style="font-weight:bold;font-size:13pt;">Mobile No.</td><td>
    <asp:TextBox ID="TextBox3" runat="server" style="font-size:15pt;height:30px;width:352px;"></asp:TextBox></td></tr>
<tr><td style="font-weight:bold;font-size:13pt;">Messege</td><td><textarea id="msg" rows="5" cols="5" style="width:352px;height:78px;">Dear Client,
kindly paid this month installment if you already paid please ignore it.
Thank You.</textarea></td></tr>
<tr><td></td><td><input id="s" type="submit" value="send" onclick="javascript:return openRequestedPopup();"/></td></tr>
</table>
</form>
</div>

</body>
</html>