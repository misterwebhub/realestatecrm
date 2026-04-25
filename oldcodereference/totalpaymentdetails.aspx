<%@ Page Language="C#" AutoEventWireup="true" CodeFile="totalpaymentdetails.aspx.cs" Inherits="totalpaymentdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: x-large;
            color: #CC0000;
        }
        .style31
        {
            color: #000000;
        }
        .style32
        {
            color: #FF0000;
        }
        .style33
        {
            width: 687px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#00CCFF" class="style2" style="text-align: center" colspan="2">
                    <strong>TOTAL CUSTOMER PAYMENT DETAILS </strong>
                </td>
            </tr>
            <tr>
                <td bgcolor="#66FF33" colspan="2">
&nbsp;<span class="style32"><strong>ARAZI NUMBER</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" 
                        style="margin-left: 0px" Width="128px" AutoPostBack="True" 
                        CssClass="style31">
                        <asp:ListItem>-----SELECT-------</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" BackColor="#660066" ForeColor="White" 
                        onclick="Button1_Click" style="font-weight: 700" Text="View" Width="90px" />
                </td>
            </tr>
            <tr>
                <td class="style33" style="width:93%;" >
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        style="text-align:center;" BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                </td>
                <td style="width:7%;">
                    <asp:GridView ID="GridView2" runat="server" 
                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" style="font-size:12pt;">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
