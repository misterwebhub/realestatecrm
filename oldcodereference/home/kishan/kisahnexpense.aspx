<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kisahnexpense.aspx.cs" Inherits="kishan_kisahnexpense" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kishan Expense Entry</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          $("#TextBox7").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          
      });
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
            margin-left:10px;
        }
        .style2
        {
            font-size: x-large;
            color: #FFFFFF;
        }
        *{padding:0px;
                    margin-left: 0;
                    margin-right: 0;
                    margin-bottom: 0;
                    text-align: left;
            font-weight: 700;
        }

                .style3
        {
            width: 206px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="3" style="text-align: center" bgcolor="#003300">
                    <strong>KISHAN EXPENSE ENTRY FORM</strong></td>
            </tr>
            <tr>
                <td colspan="3">
                    Arazi No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        Height="21px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="121px">
                        <asp:ListItem>----Select-----</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kishan Name&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList 
                        ID="DropDownList2" runat="server" 
                        AutoPostBack="True" Height="23px" 
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged" Width="121px">
                        <asp:ListItem>----Select-----</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    Location&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server" Height="24px" ReadOnly="True" 
                        Width="98px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="Yellow" class="style3">
                    <b>Item Type / Reason</b></td>
                <td bgcolor="Yellow">
                    <b>Amount</b></td>
                <td bgcolor="Yellow">
                    <b></b></td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:TextBox ID="TextBox8" runat="server" Height="26px" 
                        Width="241px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Height="25px" Width="90px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="SUBMIT" onclick="Button1_Click" 
                        Width="91px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" Width="100%" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                        <Columns>
                        
                  
                  <asp:TemplateField ItemStyle-Width="20px">
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                  </asp:TemplateField>
                  
                   <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="rate" runat="server" Text='<%#Eval("item")  %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30px">
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="rate" runat="server" Text='<%#Eval("amount")  %>'></asp:Label>
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
