<%@ Page Language="C#" AutoEventWireup="true" CodeFile="araziaddfordetails.aspx.cs" Inherits="sidebar_araziaddfordetails" %>

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
            font-size: large;
            color: #FFFFFF;
            height: 37px;
        }
        .style3
        {
        }
        .style5
        {
            width: 147px;
            height: 42px;
            font-weight: bold;
        }
        .style6
        {
            width: 182px;
            height: 42px;
        }
        .style7
        {
            height: 42px;
        }
        .style8
        {
            width: 147px;
            height: 40px;
            font-weight: bold;
        }
        .style9
        {
            width: 182px;
            height: 40px;
        }
        .style10
        {
            height: 40px;
        }
        .style11
        {
            width: 147px;
            height: 39px;
            font-weight: bold;
        }
        .style12
        {
            width: 182px;
            height: 39px;
        }
        .style13
        {
            height: 39px;
        }
        .style14
        {
            font-size: medium;
            font-weight: bold;
        }
        .style16
        {
            width: 105px;
            height: 42px;
        }
        .style17
        {
            width: 105px;
            height: 40px;
        }
        .style18
        {
            width: 105px;
            height: 39px;
        }
        .style19
        {
            font-weight: bold;
        }
        .style20
        {
            width: 105px;
            font-weight: bold;
        }
        .style21
        {
            width: 182px;
            font-weight: bold;
        }
        .style22
        {
            width: 147px;
            font-weight: bold;
        }
        .style23
        {
            height: 157px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#003300" class="style2" colspan="4" style="text-align: center">
                    <strong>LAND DETAILS FOR ARAZIWISE</strong></td>
            </tr>
            <tr>
                <td class="style22">
                    &nbsp;</td>
                <td class="style21">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td>
                    <b></b>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Arazi</td>
                <td class="style6">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="style19" 
                        Height="31px" Width="106px" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style16">
                    <strong>Arazi Selection</strong></td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="style19" 
                        Height="31px" Width="106px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Total Land ( MAP )</td>
                <td class="style9">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="style14" Height="32px" 
                        Width="148px" TextMode="Number"></asp:TextBox>
                </td>
                <td class="style17">
                    <strong>Rate</strong></td>
                <td class="style10">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="style14" Height="32px" 
                        Width="148px" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Road ( MAP )</td>
                <td class="style12">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="style14" Height="32px" 
                        Width="148px" TextMode="Number"></asp:TextBox>
                </td>
                <td class="style18">
                    <asp:Button ID="Button1" runat="server" CssClass="style19" Height="33px" 
                        style="font-size: large" Text="ADD" Width="62px" onclick="Button1_Click" />
                </td>
                <td class="style13">
                    <b>ENTER ID&nbsp; </b>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="style14" Height="32px" 
                        Width="72px"></asp:TextBox>
                    <b>&nbsp;&nbsp;&nbsp; </b>
                    <asp:Button ID="Button2" runat="server" CssClass="style19" Height="33px" 
                        style="font-size: large" Text="DEL" Width="62px" onclick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td class="style23" colspan="4">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Horizontal" style="width:100%;text-align:left;">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" style="width:100%;text-align:left;">
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
                    </asp:GridView>
&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
