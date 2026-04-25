<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userpayment.aspx.cs" Inherits="kishan_userpayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>USER PAYMENT DETAILS</title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   <script type="text/javascript">
       $(document).ready(function () {
           $(".txt1").datepicker({
               changeMonth: true,
               changeYear: true,
               dateFormat: 'dd/mm/yy'
           });
           $(".txt2").datepicker({
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
            height: 30px;
            font-size: large;
            color: #FFFFFF;
            text-align: center;
        }
        .style3
        {
            height: 9px;
        }
        .style4
        {
            height: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#000066" class="style2">
                    <strong style="text-align: center">USER PAYMENT RECIEVE DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style3">
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF66" class="style4">
                    GET USER&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="120px">
                        <asp:ListItem>------Select-------</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp; <strong>DATE FROM&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" class="txt1" 
                        ></asp:TextBox>
                    &nbsp;&nbsp; DATE TO&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" class="txt1"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" ForeColor="#000066" Height="28px" 
                        onclick="Button1_Click" style="font-weight: 700; margin-left: 0px" 
                        Text="GET DETAILS" Width="101px" />
                &nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    TOTAL AMOUNT -<asp:Label ID="Label3" runat="server" ForeColor="#660033" 
                        style="font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TOTAL RECIEVE AMOUNT-
                    </strong>
                    <asp:Label ID="Label2" runat="server" ForeColor="#660033" 
                        style="font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>BALANCE AMOUNT -</strong>
                    <asp:Label ID="Label4" runat="server" ForeColor="#660033" 
                        style="font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>CHEQUE PAYMENT</strong>&nbsp;&nbsp; <strong>
                    <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </strong>
                </td>
            </tr>
            <tr>
                <td bgcolor="#ECF8F2" style="text-align:right;">
                    <strong>
                    <asp:Label ID="Label6" runat="server" ForeColor="#000066" Font-Size="20pt" 
                        ></asp:Label>
                    &nbsp; ---&nbsp;&nbsp;
                    </strong>
                    <asp:Label ID="Label7" runat="server" Text="" style="font-weight: 700" Font-Size="20pt" ForeColor="#000066" ></asp:Label>
                    &nbsp; ==&gt;
                    <asp:Label ID="Label8" runat="server" Text="" style="font-weight: 700" Font-Size="20pt"  ForeColor="#000066"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                        CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" 
                        onrowdatabound="GridView1_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <Columns>
							<asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1756" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>USER NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id17" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>DATE FROM</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id18" runat="server" Text='<%# Eval("datefrom","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>DATE TO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id19" runat="server" Text='<%# Eval("dateto","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>RECIEVE DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id21" runat="server" Text='<%# Eval("recdate","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>RECIEVE AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id20" runat="server" Text='<%# Eval("recamount") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id30" runat="server" Text='<%# Eval("reason") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="15px"></ItemStyle>
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
