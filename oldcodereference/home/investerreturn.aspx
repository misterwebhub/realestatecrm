<%@ Page Language="C#" AutoEventWireup="true" CodeFile="investerreturn.aspx.cs" Inherits="investerreturn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>

<head><title>INVESTER RETURN</title>
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".a18").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: "invester.aspx/GetAutoCompleteData",
                        data: "{'username':'" + document.getElementById('TextBox16').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert(result);
                        }
                    });
                }
            });
            $(".t").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<style type="text/css">
    .wrrper{
width:1164px;
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
        height: 50px;
        font-size:xx-large;
        color:Maroon;
    }
    
    .style3
    {
        height: 19px;
        color: Blue;
        font-size: large;
    }
    .style5
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
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
        width: 203px;
    }
    .style16
    {
        width: 100%;
        height: 113px;
    }
    .style17
    {
        width: 166px;
    }
    .style22
    {
        width: 197px;
    }
    
    .style27
    {
        width: 100%;
    }
    .style28
    {
        width: 126px;
    }
    
    .autosuggest
    {}
    
    .style29
    {
        width: 115px;
    }
    .style30
    {
        width: 110px;
    }
    
    .style31
    {
        width: 115px;
        height: 27px;
    }
    .style32
    {
        width: 166px;
        height: 27px;
    }
    .style33
    {
        width: 197px;
        height: 27px;
    }
    .style35
    {
        width: 110px;
        height: 27px;
    }
    .style36
    {
        height: 27px;
    }
    
    .a1
    {}
    
    .style37
    {
        font-size: x-large;
    }
    
    .style38
    {
        width: 80px;
        height: 27px;
    }
    .style39
    {
        width: 80px;
    }
    
</style>
</head>
<body>
<div class="wrrper">
<form id="Form1" runat="server">
<table>
<tr><th colspan="3" style="text-align:center;" class="style2" bgcolor="#FFCCFF">
    INVESTER RETURN AMOUNT DETAILS</th></tr>
<tr><th class="style9" bgcolor="#000066">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" BackColor="#FFFF66" Font-Bold="True" 
        Font-Size="Large" Height="30px" Text="NEW ENTRY" Width="124px" 
        onclick="Button1_Click" />
    </th><th class="style10" bgcolor="#000066">&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" Font-Bold="True" Font-Size="Large" 
            ForeColor="Maroon" Height="30px" Text="SEARCH" Width="121px" 
            onclick="Button8_Click" />
    </th><th class="style5" bgcolor="#000066">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </th>
</tr>

<tr><th class="style3" colspan="3">
    <asp:Panel ID="Panel1" runat="server" Height="92px" BackColor="#00FFCC" 
        Visible="False">
        <table class="style16">
            <tr>
                <td bgcolor="#FFFF66" class="style31">
                    Date</td>
                <td bgcolor="#FFFF66" class="style32">
                    Name
                </td>
                <td bgcolor="#FFFF66" class="style33">
                    Cheque No. / Cash</td>
                <td bgcolor="#FFFF66" class="style38">
                    Amount</td>
                <td bgcolor="#FFFF66" class="style35">
                    Cheque Date</td>
                <td bgcolor="#FFFF66" class="style36">
                    Arazi No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Status&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Reason </td>
            </tr>
            <tr>
                <td class="style29">
                    <asp:TextBox ID="TextBox1" runat="server" Width="98px" class="t" Height="23px"></asp:TextBox>
                </td>
                <td class="style17">
                    <asp:TextBox ID="TextBox2" runat="server" Width="157px" Height="23px"></asp:TextBox>
                </td>
                <td class="style22">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="85px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem>-----SELECT-----</asp:ListItem>
                        <asp:ListItem>CASH</asp:ListItem>
                        <asp:ListItem>CHEQUE</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="TextBox7" runat="server" Width="70px" Height="23px"></asp:TextBox>
                </td>
                <td class="style39">
                    <asp:TextBox ID="TextBox3" runat="server"  Width="76px" Height="23px"></asp:TextBox>
                </td>
                <td class="style30">
                    <asp:TextBox ID="TextBox4" runat="server" Width="99px" class="t" Height="23px"></asp:TextBox>
                </td>
                <td>
                   
                    &nbsp;
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="23px" Width="68px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="23px" Width="75px">
                        <asp:ListItem>PAID</asp:ListItem>
                        <asp:ListItem>---SELECT----</asp:ListItem>
                        <asp:ListItem>UNPAID</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="TextBox17" runat="server" TextMode="MultiLine" 
                        Width="103px" Height="24px"></asp:TextBox>
&nbsp;<asp:Button ID="Button4" runat="server" Text="SUBMIT" Width="75px" 
                        onclick="Button4_Click" />
                    &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </th></tr>
<tr><th colspan="3">
    <asp:Panel ID="Panel3" runat="server" BackColor="#99FF33" Height="38px" 
        Visible="False">
        <table class="style27">
            <tr>
                <td class="style28">
                    ENTER NAME</td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server" Width="136px" CssClass="a1" 
                        Height="30px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button9" runat="server" 
                        BackColor="#000066" Font-Bold="True" Font-Size="Medium" ForeColor="White" 
                        Height="30px" onclick="Button9_Click" Text="SEARCH" Width="80px" />
                    &nbsp;&nbsp;&nbsp; RECEIVE AMOUNT =<asp:Label ID="Label5" runat="server" Font-Size="Large" 
                        ForeColor="#000066"></asp:Label>
                    &nbsp;&nbsp;&nbsp; RETURN AMOUNT=<asp:Label ID="Label3" runat="server" Font-Bold="True" 
                        Font-Size="Large" ForeColor="#000066"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; NET BALANCE=&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Font-Size="Large" ForeColor="#000066"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    </th></tr>
	<tr><th colspan="3"><p align="center"><span class="style37">TOTAL CREDIT =&nbsp;&nbsp;
        </span>
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="24pt" 
				   ForeColor="Green" CssClass="style37"></asp:Label>
        <span class="style37">&nbsp;&nbsp; TOTAL DEBIT =
        <asp:Label ID="Label7" runat="server" Font-Size="24pt" ForeColor="Red"></asp:Label>
        </span></p>
        </th></tr>
<tr><th colspan="3">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" 
        onrowdatabound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
         <Columns>
			  <asp:TemplateField>
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("id")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
   
                    <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr61" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr71" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr981" runat="server" Text='<%# Eval("reason") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>TYPE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr81" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>DEBIT AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr41" runat="server" Text='<%# Eval("damount") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr31" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>CHEQUE DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr21" runat="server" Text='<%# Eval("cdate") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>ARAZI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="arazi1" runat="server" Text='<%# Eval("arazi") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="st1" runat="server" Text='<%# Eval("status1") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
    </asp:GridView>
    </th></tr>
    
</table>
</form>	
</div>
</body>
</html>
