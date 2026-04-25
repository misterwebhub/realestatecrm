<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userdetails.aspx.cs" Inherits="userdetails" %>

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
            color: #CC0000;
        }
        .style3
        {
        }
        .style4
        {
            width: 269px;
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#99FF99" class="style2" colspan="2" style="text-align: center">
                    <strong>USER ACCOUNT DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <strong>GET ACCOUNT DEATILS</strong></td>
                <td>
                    <asp:Button ID="Button1" runat="server" ForeColor="#000066" Height="28px" 
                        onclick="Button1_Click" style="font-weight: 700; margin-left: 0px" 
                        Text="GET DETAILS" Width="137px" />
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                        GridLines="Horizontal" Width="100%" style="text-align:center;" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound"
    DataKeyNames="Id" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
    OnRowUpdating="OnRowUpdating"
    EmptyDataText="No records has been added.">




    <Columns>
        <asp:TemplateField HeaderText="ID" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="utype" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblCountry1" runat="server" Text='<%# Eval("utype") %>'></asp:Label>
            </ItemTemplate>
           
        </asp:TemplateField>
         <asp:TemplateField HeaderText="name" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblCountry2" runat="server" Text='<%# Eval("name") %>'></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
         <asp:TemplateField HeaderText="username" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblCountry3" runat="server" Text='<%# Eval("username") %>'></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="password" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:Label ID="lblCountry4" runat="server" Text='<%# Eval("password") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCountry4" runat="server" Text='<%# Eval("password") %>' Width="140"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ButtonType="Link" ShowEditButton="true" 
            ItemStyle-Width="150" />
    </Columns>
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
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
