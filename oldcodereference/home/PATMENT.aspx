<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PATMENT.aspx.cs" Inherits="PATMENT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 33px;
        }
        .style3
        {
        }
        .style4
        {
            height: 10px;
        }
        .style8
        {
            width: 131px;
        }
        .style9
        {
            width: 99px;
        }
        .style10
        {
            width: 130px;
        }
        .style11
        {
            width: 71px;
        }
        .style12
        {
            width: 69px;
        }
        .style13
        {
            width: 125px;
        }
        .style14
        {
            width: 73px;
        }
        .style15
        {
            width: 123px;
        }
        .style16
        {
            height: 34px;
            color: #FFFFFF;
            font-size: large;
        }
        .style17
        {
            height: 35px;
        }
        .style18
        {
            width: 103px;
        }
        .style20
        {
            width: 87px;
        }
        .style21
        {
            width: 110px;
        }
        .style22
        {
            height: 35px;
            width: 141px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <table class="style1">
            <tr>
                <td colspan="2" style="text-align: center" bgcolor="#000066" class="style16">
                    <strong>ADD NAME FOR PAYMENT</strong></td>
            </tr>
            <tr>
                <td class="style22" style="text-align: center">
                    ADD</td>
                <td class="style17">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        Height="22px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="108px">
                        <asp:ListItem>---SELECT---</asp:ListItem>
                        <asp:ListItem>KISHAN NAME</asp:ListItem>
                        <asp:ListItem>INVESTER NAME</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DEL ID&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="21px" TextMode="Number" 
                        Width="74px"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                        style="font-weight: 700" Text="DELETE" />
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    <asp:Panel ID="Panel1" runat="server" BackColor="#FFCC99" Height="37px">
                        <table class="style1">
                            <tr>
                                <td class="style12">
                                    Arazi</td>
                                <td class="style8">
                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                        Height="22px" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                                        Width="104px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style9">
                                    Kishan Name</td>
                                <td class="style10">
                                    <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="104px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style11">
                                    Arazi</td>
                                <td class="style13">
                                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                                        Height="22px" onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                                        Width="104px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style14">
                                    Deed No</td>
                                <td class="style15">
                                    <asp:DropDownList ID="DropDownList5" runat="server" Height="22px" Width="104px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Add Name" Width="92px" 
                                        onclick="Button1_Click" style="height: 26px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" BackColor="#66FF99" Height="34px">
                        <table class="style1">
                            <tr>
                                <td class="style18">
                                    Invester Name</td>
                                <td class="style21">
                                    <asp:DropDownList ID="DropDownList6" runat="server" Height="22px" 
                                        onselectedindexchanged="DropDownList6_SelectedIndexChanged" Width="104px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style20">
                                    Invester ID</td>
                                <td class="style10">
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                                <td class="style11">
                                    Arazi</td>
                                <td class="style13">
                                    <asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True" 
                                        Height="22px" onselectedindexchanged="DropDownList8_SelectedIndexChanged" 
                                        Width="104px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style14">
                                    Deed No</td>
                                <td class="style15">
                                    <asp:DropDownList ID="DropDownList9" runat="server" Height="22px" Width="104px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="Add Name" Width="92px" 
                                        onclick="Button2_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                        CellPadding="4" GridLines="Horizontal" Width="100%" style="text-align:left;">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" />
                            <asp:BoundField DataField="pid" HeaderText="K-Arazi/Inv-ID" />
                            <asp:BoundField DataField="name" HeaderText="Name" />
                            <asp:BoundField DataField="arazi" HeaderText="Arazi" />
                            <asp:BoundField DataField="deedno" HeaderText="Deed No" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </ContentTemplate></asp:UpdatePanel>
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
