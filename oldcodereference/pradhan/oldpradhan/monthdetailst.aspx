<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthdetailst.aspx.cs" Inherits="pradhan_monthdetailst" %>

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
            height: 48px;
        }
        .style3
        {
        }
        .style4
        {
            width: 37px;
            height: 68px;
            font-weight: bold;
        }
        .style6
        {
            height: 68px;
            width: 124px;
        }
        .style8
        {
            height: 68px;
            width: 59px;
            font-weight: bold;
        }
        .style10
        {
            font-size: medium;
            font-weight: 700;
        }
        .style11
        {
            font-size: medium;
            font-weight: bold;
        }
        .style14
        {
            height: 68px;
            width: 112px;
        }
        .style17
        {
            width: 52px;
            height: 68px;
        }
        .style18
        {
            height: 68px;
        }
        .style19
        {
            width: 62px;
        }
        .style20
        {
            width: 90px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#FFCC00" class="style2" colspan="8" style="text-align: center">
                    <strong>MONTHWISE PAYMENT DEATILS</strong></td>
            </tr>
            <tr>
                <td class="style4">
                    NAME</td>
                <td class="style6">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="104px" 
                        AutoPostBack="True" CssClass="style11" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style8">
                    ARAZI</td>
                <td class="style14">
&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" CssClass="style10" Height="26px" 
                        Width="93px" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style19">
                    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="BLOCK"></asp:Label>
                </td>
                <td class="style20">
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="style10" Height="26px" 
                        Width="75px">
                    </asp:DropDownList>
                </td>
                <td class="style17">
&nbsp;<strong>YEAR&nbsp; </strong>
                </td>
                <td class="style18">
&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="style10" 
                        Height="26px" Width="93px">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Height="27px" onclick="Button1_Click" 
                        style="font-weight: 700; font-size: large" Text="VIEW" Width="82px" />
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="8">
                    <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black" Width="60%" style="text-align:left;">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="8">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                    &nbsp;<asp:Label ID="Label2" runat="server" style="font-weight: 700" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text=""></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
