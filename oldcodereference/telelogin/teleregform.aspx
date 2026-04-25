<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teleregform.aspx.cs" Inherits="telelogin_teleregform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 419px;
        }
        .style2
        {
            font-size: large;
            color: #FFFFFF;
        }
        .style3
        {
            width: 177px;
        }
        .style4
        {
            width: 177px;
            text-align: right;
        }
        .style11
        {
            width: 177px;
            text-align: right;
            height: 43px;
            font-weight: bold;
        }
        .style13
        {
            width: 177px;
            text-align: right;
            height: 44px;
            font-weight: bold;
        }
        .style15
        {
            width: 177px;
            text-align: right;
            height: 41px;
            font-weight: bold;
        }
        .style17
        {
            width: 352px;
        }
        .style18
        {
            height: 43px;
            width: 352px;
        }
        .style19
        {
            height: 44px;
            width: 352px;
        }
        .style20
        {
            height: 41px;
            width: 352px;
        }
        .style21
        {
            width: 177px;
            text-align: right;
            height: 37px;
        }
        .style22
        {
            height: 37px;
            width: 352px;
        }
        .style23
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#000066" class="style2" colspan="3" style="text-align: center">
                    <strong>Tele Caller Registration</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style17">
                    &nbsp;</td>
                <td rowspan="8">
                    <asp:Panel ID="Panel1" runat="server" Height="369px">
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            GridLines="Horizontal" Width="100%" style="text-align:left;">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Name</td>
                <td class="style18">
                    &nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="Large" Height="23px" 
                        Width="210px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    Mobile No</td>
                <td class="style18">
&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Font-Size="Large" Height="23px" 
                        Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    Office</td>
                <td class="style19">
&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="210px">
                        <asp:ListItem>---SELECT----</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    User Name</td>
                <td class="style18">
&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Font-Size="Large" Height="23px" 
                        Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    Password</td>
                <td class="style20">
&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server" Font-Size="Large" Height="23px" 
                        Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style21">
                    </td>
                <td class="style22">
&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                        Width="69px" CssClass="style23" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" CssClass="style23" 
                        onclick="Button2_Click" Text="Clear" />
                    </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
