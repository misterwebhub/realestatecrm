<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kishandetails.aspx.cs" Inherits="kishandetails" %>

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
            height: 53px;
            font-size: x-large;
            color: #FFFFFF;
            text-align: center;
        }
        .style3
        {
            height: 57px;
        }
        .style4
        {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="Maroon" class="style2">
                    <strong style="text-align: center">TOTAL KISHAN PAYEMNT ARAZI WISE</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    <span class="style4"><strong>*Please click Here</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Get Kishan Details" Height="26px" style="font-weight: 700" 
                        Width="170px" />
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <span class="style4"><strong>&nbsp;TOTAL AMOUNT= </strong></span><strong>
                    <asp:Label ID="Label1" runat="server" CssClass="style4" ForeColor="#003300" 
                        Text="0"></asp:Label>
                    </strong><span class="style4"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    PAID AMOUNT = </strong></span><strong>
                    <asp:Label ID="Label2" runat="server" CssClass="style4" ForeColor="Red" 
                        Text="0"></asp:Label>
                    </strong><span class="style4"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    BALANCE AMOUNT = </strong></span><strong>
                    <asp:Label ID="Label3" runat="server" CssClass="style4" ForeColor="#000066" 
                        Text="0"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" 
                        style="width:92%;margin-left:4%;color:black;font-weight:bold;font-size:large;" 
                        AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound">
                        <AlternatingRowStyle />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <Columns>
                        <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>ARAZI NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("arazino") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>KISHAN NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id2" runat="server" Text='<%# Eval("kname") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>LOCATION</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id3" runat="server" Text='<%# Eval("location") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>TOTAL AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id4" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>PAID AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id5" runat="server" Text='<%# Eval("PAID") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>BALANCE AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id6" runat="server" Text='<%# Eval("BALANCE") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
