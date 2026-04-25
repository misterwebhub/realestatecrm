<%@ Page Language="C#" AutoEventWireup="true" CodeFile="expence recipt.aspx.cs" Inherits="home_expence_recipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .style2
        {
        }
        .style3
        {
            width: 109px;
            height: 25px;
        }
        .style4
        {
            width: 102px;
            height: 25px;
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
        {}
        .style8
        {
            width: 538px;
        }
        .style9
        {
            font-size: large;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:800px;width:90%;margin-left:5%;border:1px solid black;border-top-width:0px;">
    <div style="border-bottom: 1px solid Black; height:119px; width:100%">
    <br />
     <table style="WIDTH:100%; height: 91px;"><tr><td class="style8"><strong>BACK AMOUNT</strong>&nbsp;&nbsp;
         <asp:TextBox ID="TextBox1" runat="server" Height="24px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
         <strong>CURRENT AMOUNT</strong></td><td>
         <asp:TextBox ID="TextBox6" runat="server" AutoPostBack="True" 
                 ontextchanged="TextBox6_TextChanged"></asp:TextBox></td>
         <td style="font-weight: 700">DATE</td><td>
             <asp:TextBox ID="TextBox2" runat="server" Height="25px" AutoPostBack="True" 
                 ontextchanged="TextBox2_TextChanged"></asp:TextBox></td></tr><tr>
             <td class="style7" colspan="4"><strong>EXTRA AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" ForeColor="#009900" CssClass="style9" 
                     style="color: #000066"></asp:Label></strong></td></tr><tr>
             <td class="style7" colspan="4"><b>TOTAL AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                        <asp:Label ID="Label2" runat="server" ForeColor="#009900" CssClass="style9" 
                     style="color: #000066"></asp:Label><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 TOTAL EXPENCE AMOUNT&nbsp;&nbsp;&nbsp;&nbsp; </b>
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" CssClass="style9" 
                     style="color: #006600"></asp:Label><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 BALANCE AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                        <asp:Label ID="Label4" runat="server" ForeColor="#009900" CssClass="style9" 
                     style="color: #660066"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <a href="extrapayment.aspx" target="_blank">Extra Payment</a></td></tr></table>
    
    </div>
    <div style="width:100%;height:100%;">
    
        <table class="style1" border="1">
            <tr>
                <td class="style4">
                    DATE</td>
                <td class="style3">
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
                <td class="style4">
                    <asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="103px"></asp:TextBox>
                </td>
                <td class="style3">
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
    </div>
    </form>
</body>
</html>
