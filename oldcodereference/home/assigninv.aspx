<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assigninv.aspx.cs" Inherits="arazi246_assigninv" %>

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
            font-size: x-large;
        }
        .style3
        {
        }
        .style4
        {
            width: 285px;
            height: 41px;
        }
        .style5
        {
            height: 41px;
        }
        .style6
        {
            width: 285px;
            height: 46px;
        }
        .style7
        {
            height: 46px;
        }
        .style8
        {
            height: 51px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="2" style="text-align: center">
                    <strong>ASSIGN INVESTER TYPE WITH ID</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" bgcolor="#00CC66">
                    INVESTER NAME</td>
                <td class="style5" bgcolor="#00CC66">
                    <asp:TextBox ID="TextBox1" runat="server" Height="28px" Width="128px"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" onclick="Button1_Click" 
                        style="font-weight: 700" Text="ADD" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID
                    <asp:TextBox ID="TextBox2" runat="server" Height="28px" Width="71px"></asp:TextBox>
                &nbsp;
                    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                        style="font-weight: 700" Text="DEL" />
                </td>
            </tr>
            <tr>
                <td class="style6" bgcolor="#FF99CC">
                    INVESTER NAME 
                    <asp:DropDownList ID="DropDownList4" runat="server" 
                         Height="29px" 
                        Width="126px">
                    </asp:DropDownList>
                    &nbsp;</td>
                <td class="style7" bgcolor="#FF99CC">
                   &nbsp;
                    INVESTER ID&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" 
                         Height="29px" 
                        Width="126px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                        style="font-weight: 700" Text="ADD" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID
                    <asp:TextBox ID="TextBox3" runat="server" Height="28px" Width="71px"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                        style="font-weight: 700" Text="DEL" />
                    </td>
            </tr>
            <tr>
                <td class="style8">
                    INVESTER NAMEEE<asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
                        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CellSpacing="2" Width="345px">
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
                <td class="style8">
                    INVESTER NAME &amp; ID<asp:GridView ID="GridView2" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        Width="345px">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    Z</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
