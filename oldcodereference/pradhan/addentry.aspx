<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addentry.aspx.cs" Inherits="pradhan_addentry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 100%;
        }
        .style2
        {
            font-size: x-large;
            height: 40px;
        }
        .style3
        {
        }
        .style4
        {
            height: 61px;
            width: 86px;
        }
        .style5
        {
        }
        .style6
        {
            height: 25px;
        }
        .style7
        {
            height: 26px;
            text-align: center;
            font-size: large;
        }
        .style8
        {
        }
        .style9
        {
            height: 35px;
            width: 87px;
            font-weight: 700;
        }
        .style10
        {
            width: 87px;
        }
        .style11
        {
            height: 35px;
            width: 136px;
        }
        .style12
        {
            width: 136px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#CC66FF" class="style2" colspan="3" style="text-align: center">
                    <strong>ADD ENTRY</strong></td>
            </tr>
            <tr>
                <td class="style4" bgcolor="#FFFFCC">
                    NAME</td>
                <td class="style3" bgcolor="#FFFFCC">
                    <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="141px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Height="25px" style="font-weight: 700" 
                        Text="ADD" onclick="Button1_Click" />
&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" style="color: #FF0000"></asp:Label>
                </td>
                <td class="style3" bgcolor="#FFCCFF" rowspan="3">
                    <asp:Panel ID="Panel1" runat="server" Height="295px" Width="100%">
                        <table class="style1">
                            <tr>
                                <td bgcolor="#99FFCC" class="style7" colspan="3">
                                    <strong>PLOT ADD</strong></td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    NAME</td>
                                <td class="style11">
                                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                                        Height="16px" onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                                        Width="92px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style8" rowspan="5"><div style="width:100%;height:100%;overflow:scroll;">
                                    <asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" 
                                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                                        GridLines="None" Height="178px" Width="304px">
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <FooterStyle BackColor="Tan" />
                                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                            HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
									</asp:GridView></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    ARAZI NO</td>
                                <td class="style11">
                                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" 
                                        Height="16px" onselectedindexchanged="DropDownList5_SelectedIndexChanged" 
                                        Width="106px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                </td>
                                <td class="style11">
                                    <asp:DropDownList ID="DropDownList6" runat="server" Height="16px" 
                                        onselectedindexchanged="DropDownList2_SelectedIndexChanged" Width="106px">
                                        <asp:ListItem>---SELECT----</asp:ListItem>
                                        <asp:ListItem>A</asp:ListItem>
                                        <asp:ListItem>B</asp:ListItem>
                                        <asp:ListItem>C</asp:ListItem>
                                        <asp:ListItem>D</asp:ListItem>
                                        <asp:ListItem>E</asp:ListItem>
                                        <asp:ListItem>F</asp:ListItem>
                                        <asp:ListItem>G</asp:ListItem>
                                        <asp:ListItem>H</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    <asp:Label ID="Label5" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style12">
                                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="76px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    &nbsp;</td>
                                <td class="style12">
                                    <asp:Button ID="Button3" runat="server" Height="25px" onclick="Button3_Click" 
                                        Text="ADD" Width="71px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style6" bgcolor="#FFFFCC">
                    NAME</td>
                <td bgcolor="#FFFFCC" class="style6">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="92px" 
                        AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp; ARAZI NO.
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="106px" 
                        AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList>
&nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>
&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="106px" 
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem>---SELECT----</asp:ListItem>
                        <asp:ListItem>YES</asp:ListItem>
                        <asp:ListItem>NO</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="ADD" onclick="Button2_Click" 
                        style="width: 41px" />
                &nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" style="color: #FF0000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2" bgcolor="#FFFFCC">
                    <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
                        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CellSpacing="2" Width="100%">
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
