<%@ Page Language="C#" AutoEventWireup="true" CodeFile="officehishab.aspx.cs" Inherits="home_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {

          $("#TextBox1").datepicker({
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
        }
        .style2
        {
        }
        .style3
        {
            width: 164px;
            text-align: left;
            font-weight: bold;
        }
        .style4
        {
            width: 388px;
            text-align: left;
        }
        .style5
        {
            width: 164px;
            text-align: left;
            font-weight: bold;
            height: 30px;
        }
        .style6
        {
            width: 388px;
            height: 30px;
        }
        .style7
        {
            height: 30px;
        }
        .style8
        {
            width: 164px;
            text-align: left;
            font-weight: bold;
            height: 29px;
        }
        .style9
        {
            width: 388px;
            height: 29px;
        }
        .style10
        {
            height: 29px;
        }
        .style11
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
    
        <table class="style1">
            <tr>
                <td bgcolor="#FF6600" class="style3">
                    BACK AMOUNT</td>
                <td bgcolor="#FF6600" class="style4">
                    <b>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="#000066"></asp:Label>
                    </b>
                </td>
                <td bgcolor="#FF6600" class="style11">
                    <strong>DATE </strong>&nbsp;<asp:TextBox ID="TextBox1" runat="server" 
                        AutoPostBack="True" Height="24px" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#FF6600" class="style5">
                    CURRENT AMOUNT</td>
                <td bgcolor="#FF6600" class="style6">
                    <b>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" ForeColor="#660066"></asp:Label>
                    </b>
                </td>
                <td bgcolor="#FF6600" class="style7">
                    <strong>EXTRA AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <b>
                    <asp:Label ID="Label7" runat="server" ForeColor="#660066"></asp:Label>
                    </b>
                    </strong>
                </td>
            </tr>
            <tr>
                <td bgcolor="#FF6600" class="style8">
                    TOTAL AMLOUNT</td>
                <td bgcolor="#FF6600" class="style9">
                    <b>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" ForeColor="#003300"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EXPENSE AMOUNT&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" ForeColor="#660033"></asp:Label>
                    </b>
                </td>
                <td bgcolor="#FF6600" class="style10">
                    <strong>BALANCE AMOUNT</strong>&nbsp;&nbsp; <b>
                    <asp:Label ID="Label5" runat="server" ForeColor="#333300"></asp:Label>
                    </b>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="3">
                    <asp:GridView ID="GridView1" runat="server" style="width:100%;height:100%;TEXT-ALIGN:left;" 
                        AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
                        CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id117" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="8px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="140px">
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id118" runat="server" Text='<%# Eval("RDATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="70px"></ItemStyle>
                  </asp:TemplateField>
							 <asp:TemplateField ItemStyle-Width="40px">
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id119" runat="server" Text='<%# Eval("RAMOUNT") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="40px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="350px">
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id120" runat="server" Text='<%# Eval("RREASON") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="310px"></ItemStyle>
                  </asp:TemplateField>
                   </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                   
                </td>
            </tr>
        </table>
    
        
    
    </div>
    </form>
</body>
</html>
