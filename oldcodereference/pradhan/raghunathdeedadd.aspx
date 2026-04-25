<%@ Page Language="C#" AutoEventWireup="true" CodeFile="raghunathdeedadd.aspx.cs" Inherits="arazi385KA_raghunathdeedadd" %>

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
            height: 41px;
            color: #FFFFFF;
        }
        .style3
        {
            width: 218px;
            height: 56px;
        }
        .style5
        {
            width: 218px;
            height: 60px;
        }
        .style6
        {
            height: 60px;
        }
        .style7
        {
            height: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="4" 
                    style="text-align: center; font-weight: 700; font-size: large" 
                    bgcolor="#660066">
                    DEED NO ADD INTO PRADHANJI SOFTWARE</td>
            </tr>
            <tr>
                <td class="style6">
                    ARAZI
                </td>
                <td class="style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="95px" 
                        AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    DEED NO</td>
                <td class="style6">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="95px">
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="ADD" onclick="Button1_Click" 
                        style="font-weight: 700" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    Delete Id</td>
                <td class="style3">
                    <asp:TextBox ID="TextBox1" runat="server" Height="27px" Width="78px"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                        style="font-weight: 700" Text="Delete" />
                </td>
                <td class="style7">
                    </td>
                <td class="style7">
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" style="width:100%;" 
                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" GridLines="Vertical">
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
