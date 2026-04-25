<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demoarazimap.aspx.cs" Inherits="arazi137ramipur_demoarazimap" %>

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
            height: 22px;
        }
        .style3
        {
            height: 22px;
            width: 184px;
        }
        .style4
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td colspan="2" 
                    style="text-align: center; font-weight: 700; font-size: x-large">
                    PLOT NOT FOR SALE REGISTRATION</td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    ARAZI&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="82px">
                    </asp:DropDownList>
&nbsp;&nbsp; CUSTREGNO&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Height="27px" onclick="Button1_Click" 
                        style="font-weight: 700" Text="ADD" Width="83px" />
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    ID&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Height="27px" onclick="Button2_Click" 
                        style="font-weight: 700" Text="DELETE" Width="83px" />
&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="526px">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="ARAZI" HeaderText="ARAZI NO" />
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUST. REG. NO." />
                        </Columns>
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
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
