<%@ Page Language="C#" AutoEventWireup="true" CodeFile="extrapayment.aspx.cs" Inherits="extrapayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {

          $("#TextBox2").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox3").datepicker({
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
        .style5
        {
            height: 25px;
            width: 508px;
        }
        .style6
        {
            width: 98px;
        }
        .style7
        {
            height: 39px;
        }
        .style8
        {
            height: 25px;
            width: 115px;
        }
        .style9
        {
            height: 25px;
        }
        .style10
        {
            height: 25px;
            width: 112px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" border="1">
            <tr>
                <td class="style7" colspan="5" style="text-align: center;">
                    <strong >EXTRA PAYMENT RECIEVE BY COMPANY</strong></td>
            </tr>
            <tr>
                <td class="style10">
                    DATE</td>
                <td class="style8">
                    AMOUNT</td>
                <td class="style5">
                    REASON</td>
                <td class="style6">
                    ID&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox7" runat="server" Height="27px" Width="58px"></asp:TextBox>
                </td>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="DELETE" BackColor="#009933" 
                            Font-Bold="True" onclick="Button2_Click" />
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="103px"></asp:TextBox>
                </td>
                <td class="style8">
                    <asp:TextBox ID="TextBox4" runat="server" Height="25px" Width="110px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:TextBox ID="TextBox5" runat="server" Height="25px" Width="507px"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:Button ID="Button1" runat="server" Text="Submit" Width="63px" 
                        Height="26px" onclick="Button1_Click" /></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td class="style9" colspan="2">
                    TOTAL RECIEVE AMOUNT</td>
                <td class="style5">
                        <asp:Label ID="Label6" runat="server" ForeColor="Red" 
                        style="font-weight: 700"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;</td>
                    <td>
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" colspan="5">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" style="width:100%;height:100%;TEXT-ALIGN:left;" 
                        AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound">
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
                    </asp:GridView>
                   
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
