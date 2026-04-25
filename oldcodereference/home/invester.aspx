 ﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="invester.aspx.cs" Inherits="invester" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>

<head><title>INVESTER</title>
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
    .style9
    {
        height: 36px;
        color: Blue;
        font-size: x-large;
        }
    .style15
    {
        height: 36px;
        color: Blue;
        font-size: large;
    }
    .style16
    {
        width: 100%;
        height: 113px;
    }
    .style17
    {
        width: 178px;
    }
    .style22
    {
        width: 249px;
    }
    
    .style23
    {
        width: 107px;
    }
    
    .style24
    {
    }
    .style25
    {
        width: 105px;
    }
    .style26
    {
        width: 113px;
    }
    
    .style27
    {
        width: 100%;
    }
        
    .autosuggest
    {}
    
    .style29
    {
        font-size: x-large;
    }
    
    .style30
    {
        width: 148px;
    }
    .style31
    {
        width: 56px;
    }
    .a1
    {}
    
</style>
</head>
<body>
<div class="wrrper">
<form id="Form1" runat="server">
<table>
<tr><th style="text-align:center;" class="style2" bgcolor="#FFFF66">
    INVESTER DETAILS</th></tr>
<tr><th class="style9" bgcolor="#003300">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" BackColor="Aqua" Font-Bold="True" 
        Font-Size="Large" Height="30px" Text="NEW ENTRY" Width="124px" 
        onclick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" BackColor="#FF66CC" Font-Bold="True" 
            Font-Size="Large" Height="30px" Text="EDIT / DELETE" Width="169px" 
            onclick="Button2_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" BackColor="#9999FF" Font-Bold="True" 
            Font-Size="Large" Height="30px" Text="DETAILS" Width="124px" 
            onclick="Button3_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" Font-Bold="True" Font-Size="Large" 
            ForeColor="Maroon" Height="30px" Text="SEARCH" Width="121px" 
            onclick="Button8_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<a href="investerreturn.aspx" target="_blank" style="color:white;">INVESTER RETURN</a>
    
</tr>

<tr><th class="style3">
    <asp:Panel ID="Panel1" runat="server" Height="114px" BackColor="#00FFCC" 
        Visible="False">
        <table class="style16">
            <tr>
                <td bgcolor="#FFFF66" class="style24">
                    Date</td>
                <td bgcolor="#FFFF66" class="style17">
                    Name
                </td>
                <td bgcolor="#FFFF66" class="style22">
                    Cheque No. / Cash</td>
                <td bgcolor="#FFFF66" class="style26">
                    Amount</td>
                <td bgcolor="#FFFF66" class="style25">
                    Cheque Date</td>
                <td bgcolor="#FFFF66" class="style23">
                    Arazi No</td>
                <td bgcolor="#FFFF66">
                   </td>
            </tr>
            <tr>
                <td class="style24">
                    <asp:TextBox ID="TextBox1" runat="server" Width="98px" class="t"></asp:TextBox>
                </td>
                <td class="style17">
                    <asp:TextBox ID="TextBox2" runat="server" Width="177px"></asp:TextBox>
                </td>
                <td class="style22">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="104px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem>-----SELECT-----</asp:ListItem>
                        <asp:ListItem>CASH</asp:ListItem>
                        <asp:ListItem>CHEQUE</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="TextBox7" runat="server" Width="113px"></asp:TextBox>
                </td>
                <td class="style26">
                    <asp:TextBox ID="TextBox3" runat="server"  Width="107px"></asp:TextBox>
                </td>
                <td class="style25">
                    <asp:TextBox ID="TextBox4" runat="server" Width="98px" class="t"></asp:TextBox>
                </td>
                <td class="style23">
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="18px" Width="85px">
                    </asp:DropDownList>
                </td>
                <td>
                   
                    &nbsp;
                    <asp:Button ID="Button4" runat="server" Text="SUBMIT" Width="75px" 
                        onclick="Button4_Click" />
                </td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style17">
                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
                <td class="style23">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </th></tr>
<tr><th class="style15">
    <asp:Panel ID="Panel2" runat="server" Height="124px" BackColor="#FF66FF" 
        Visible="False">
        <table class="style16">
            <tr>
                <td bgcolor="#FFFF66" class="style24" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter Id</td>
                <td bgcolor="#FFFF66" class="style22">
                    <asp:TextBox ID="TextBox15" runat="server" Width="143px"></asp:TextBox>
                </td>
                <td bgcolor="#FFFF66" class="style26">
                    <asp:Button ID="Button6" runat="server" Font-Bold="True" ForeColor="Maroon" 
                        onclick="Button6_Click" Text="SEARCH" Width="106px" />
                </td>
                <td bgcolor="#FFFF66" class="style25">
                    &nbsp;<asp:Button ID="Button7" runat="server" BackColor="#000066" Font-Bold="True" 
                        ForeColor="#FFFFCC" onclick="Button7_Click" Text="DELETE" Width="94px" />
                    &nbsp;</td>
                <td bgcolor="#FFFF66" class="style30">
                    &nbsp;</td>
                <td bgcolor="#FFFF66">
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="#FFFF66" class="style24">
                    Date</td>
                <td bgcolor="#FFFF66" class="style17">
                    Name
                </td>
                <td bgcolor="#FFFF66" class="style22">
                    Cheque No. / Cash</td>
                <td bgcolor="#FFFF66" class="style26">
                    Amount</td>
                <td bgcolor="#FFFF66" class="style25">
                    Cheque Date</td>
                <td bgcolor="#FFFF66" class="style30">
                    Status</td>
                <td bgcolor="#FFFF66">
                    </td>
            </tr>
            <tr>
                <td class="style24">
                    <asp:TextBox ID="TextBox8" runat="server" Width="98px" class="t"></asp:TextBox>
                </td>
                <td class="style17">
                    <asp:TextBox ID="TextBox9" runat="server" Width="177px"></asp:TextBox>
                </td>
                <td class="style22">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                        Height="17px" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                        Width="99px">
                        <asp:ListItem>---select-----</asp:ListItem>
                        <asp:ListItem>CASH</asp:ListItem>
                        <asp:ListItem>CHEQUE</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="TextBox10" runat="server" Width="113px"></asp:TextBox>
                </td>
                <td class="style26">
                    <asp:TextBox ID="TextBox11" runat="server"  Width="107px"></asp:TextBox>
                </td>
                <td class="style25">
                    <asp:TextBox ID="TextBox12" runat="server" Width="98px" class="t"></asp:TextBox>
                </td>
                <td class="style30">
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                    &nbsp;<asp:DropDownList ID="DropDownList4" runat="server" Height="17px" Width="74px">
                        <asp:ListItem>--select---</asp:ListItem>
                        <asp:ListItem>PAID</asp:ListItem>
                        <asp:ListItem>UNPAID</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    
                    &nbsp;
                    <asp:Button ID="Button5" runat="server" Text="UPDATE" Width="75px" 
                        Font-Bold="True" onclick="Button5_Click" />
                </td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style17">
                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
                <td class="style30">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </th>
</tr>
<tr><th>
    <asp:Panel ID="Panel3" runat="server" BackColor="#99FF33" Height="38px" 
        Visible="False">
        <table class="style27">
            <tr>
                <td class="style31">
                    &nbsp;NAME</td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server" Width="162px" CssClass="a1" 
                        Height="30px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button9" runat="server" 
                        BackColor="#000066" Font-Bold="True" Font-Size="Large" ForeColor="White" 
                        Height="30px" onclick="Button9_Click" Text="SEARCH" Width="90px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;TOTAL CR(+)=
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15pt" 
                        ForeColor="#000066"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;TOTAL DB(-) =
                    <asp:Label ID="Label5" runat="server" Font-Size="15pt" ForeColor="Red"></asp:Label>
					&nbsp;&nbsp;&nbsp; BALANCE = <asp:Label ID="Label51" runat="server" Font-Size="15pt"></asp:Label>
                    &nbsp;&nbsp; UNPAID =
                    <asp:Label ID="Label52" runat="server" ForeColor="#660066" 
                        style="font-size: large"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    </th></tr>
	<tr><th><p align="center"><span class="style29">TOTAL CREDIT =&nbsp;&nbsp; </span>
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="20pt" 
				   ForeColor="Green" CssClass="style29"></asp:Label>
        <span class="style29">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TOTAL DEBIT=
        <asp:Label ID="Label6" runat="server" Font-Size="20pt" ForeColor="#000066"></asp:Label>
        </span></p>
        </th></tr>
<tr><th>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" 
        onrowdatabound="GridView1_RowDataBound" width="100%">
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
                  <asp:Label ID="date" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>TYPE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="type" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>CREDIT AMOUNT( + )</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cr1" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>DEBIT AMOUNT ( - )</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="db1" runat="server" Text='<%# Eval("damount") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="st1" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>CHEQUE DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("cdate") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>ARAZI NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="ar1" runat="server" Text='<%# Eval("arazi") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="st51" runat="server" Text='<%# Eval("status1") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
			 <asp:TemplateField>
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate >
                  <asp:Label ID="rs14" runat="server" Text='<%# Eval("reason") %>'></asp:Label>
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
