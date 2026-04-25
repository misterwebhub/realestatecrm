<%@ Page Language="C#" AutoEventWireup="true" CodeFile="brokarentry.aspx.cs" Inherits="kishan_brokarentry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
            font-size: x-large;
        }
        .style3
        {
            color: #FFFFFF;
        }
        .style4
        {
            height: 43px;
        }
        .style5
        {
            height: 42px;
        }
        .style6
        {
            height: 41px;
        }
        .style7
        {
            height: 42px;
            font-weight: bold;
        }
        .style8
        {
            height: 43px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="2" bgcolor="#660066">
                    <span class="style3"><strong>BROKAR ENTRY FORM</strong></span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    BROKAR NAME</td>
                <td class="style4">
                    <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="233px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    AADHAR NUMBER</td>
                <td class="style5">
                    <asp:TextBox ID="TextBox2" runat="server" Height="24px" Width="233px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    MOBILE NUMBER</td>
                <td class="style5">
                    <asp:TextBox ID="TextBox3" runat="server" Height="24px" Width="233px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    </td>
                <td class="style6">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        style="font-weight: 700" Text="SUBMIT" Width="90px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6" bgcolor="#00CC66">
                    <strong>ENTER BROKAR ID</strong></td>
                <td class="style6" bgcolor="#00CC66">
                    <asp:TextBox ID="TextBox4" runat="server" Height="28px" Width="74px"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Height="26px" style="font-weight: 700" 
                        Text="DELETE" Width="71px" onclick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" Width="80%">
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
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
