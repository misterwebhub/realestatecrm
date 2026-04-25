<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regcount.aspx.cs" Inherits="regcount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

<head><title>Reg. Count Form</title>
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
width:90%;
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
        height: 121px;
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
    .style6
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
        width: 138px;
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
      
        width: 172px;
    }
    .style15
    {
        height: 36px;
        color: Blue;
        font-size: large;
    }
    .style16
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
        width: 113px;
    }
    
    .style17
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
        width: 172px;
    }
    
    .style18
    {
        color: red;
    }
    
</style>
</head>
<body>
<div class="wrrper">
<form id="Form1" runat="server">  
&nbsp;&nbsp;  
<table>
<tr><th colspan="5" style="text-align:center;" class="style2">MONTH WISE 
    REGISTRATION COUNT</th></tr>
<tr><th class="style10">DATE FROM</th><th class="style16">
    <asp:TextBox ID="TextBox1" runat="server" class="d" Height="28px" Width="142px"></asp:TextBox></th>
    <th class="style11" >DATE TILL</th><th class="style17">
        <asp:TextBox ID="TextBox2" runat="server" class="d" Height="27px" Width="180px"></asp:TextBox></th>
</tr>

<tr><th class="style3" colspan="2">USER&nbsp;&nbsp;
     <asp:DropDownList ID="DropDownList2" runat="server" Height="29px" Width="121px">
         <asp:ListItem>---select---</asp:ListItem>
     </asp:DropDownList>
     &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" BackColor="#FF99FF" Height="29px" 
        style="font-weight: 700" Text="USER WISE" Width="133px" 
        onclick="Button2_Click" />
    </th><th class="style4">
    <asp:Button ID="Button1" runat="server" class="b" Text="ALL USER WISE" Width="183px" 
        onclick="Button1_Click" Font-Bold="True" Height="28px" /></th><th class="style12" colspan="2">
        
        <asp:Label ID="Label11" runat="server" style="color: #FF3300" 
            Font-Size="Medium"></asp:Label>
        
    </th></tr>
<tr><th class="style15" colspan="2">Total Bond = 
    <asp:Label ID="Label1" runat="server" Text="" style="font-size: large"></asp:Label>
    &nbsp;---&nbsp; <span class="style18">Cancel = </span>
        <asp:Label ID="Label9" runat="server" style="color: #FF3300" Text=""></asp:Label>
    </th><th class="style15">
        &nbsp;Bal Bond=
        <asp:Label ID="Label10" runat="server" style="color: #006600" Text=""></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp; GAJ -<asp:Label ID="Label12" runat="server" 
            style="color: #006600" Text=""></asp:Label>
    </th>
    <th class="style14" >TOTAL RECEIVE DP AMOUNT -  </th><th class="style6"><asp:Label ID="Label8" runat="server" Text="" style="font-size: large"></asp:Label>
    </th>
</tr>
<tr><th class="style15" colspan="2">Total Land Payment&nbsp;&nbsp;
    <asp:Label ID="Label13" runat="server" Text="" style="font-size: large"></asp:Label>
    </th><th class="style15">
       Total Dowpayment&nbsp;&nbsp; <asp:Label ID="Label14" runat="server" Text="" 
            style="font-size: large"></asp:Label>
    </th>
    <th class="style14" >Balance Amt&nbsp; <asp:Label ID="Label15" runat="server" 
            Text="" style="font-size: large"></asp:Label>
    </th><th class="style6">&nbsp;</th>
</tr>
<tr><th colspan="5">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
        <Columns>
         
                            <asp:BoundField DataField="date3" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO" />
                            <asp:BoundField DataField="NAMEDOBADDRESS" HeaderText="NAME" />
                           
                            <asp:BoundField DataField="APPNO" HeaderText="ARAZI NO" />
                            <asp:BoundField DataField="plotno" HeaderText="PLOT NO" />
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="SIZE" />
                            <asp:BoundField DataField="CHECKBY" HeaderText="BROKER NAME" />
                            <asp:BoundField DataField="PAID" HeaderText="PAID AMOUNT" />
                            <asp:BoundField DataField="regstatus" HeaderText="STATUS" />
                        
     
                   
                  
                  
                 
                 
			
                  </Columns>
    </asp:GridView>
    </th></tr>
</table>
</form>	
</div>
</body>
</html>

