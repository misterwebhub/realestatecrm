<%@ Page Language="C#" AutoEventWireup="true" CodeFile="remidercheque.aspx.cs" Inherits="home_remidercheque" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reminder CHeque</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
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
            $("#TextBox7").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox12").datepicker({
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
        .style4
        {
            width: 164px;
            height: 41px;
            color: #FF0000;
            text-align: center;
        }
        .style9
        {
            height: 41px;
            width: 326px;
            color: #FF0000;
            text-align: center;
        }
        .style10
        {
            height: 38px;
            }
        .style29
        {
            height: 60px;
        }
        .style30
        {
            height: 41px;
            color: #FF0000;
            width: 208px;
            text-align: center;
        }
        #view
        {
           
            height:50%;
            width:50%;
        }
       
        .sty
        {
            width: 756px;
             background-image:url('img/ki.jpg');
            height: 539px;
        }
        .arzno239
        {
            background-image:url('IMG/arazi239.jpg');
            width: 410px;
            height: 680px;
        }
        .AR100
        {
            background-image:url('IMG/arazi100.jpg');
            width: 827px;
            height: 330px;
        }
        .ar308
        {
            background-image:url('IMG/arazi308.jpg');
            width: 680px;
            height: 303px;
        }
        .ar2011
        {
            background-image:url('IMG/arazi2011.jpg');
            width: 557px;
            height: 574px;
        }
        .ar293a
        {
            background-image:url('IMG/arazi293AB.jpg');
            width: 981px;
            height: 327px;
        }
        .ar293a&b
        {
            width: 420px;
        }
        .ar293a&b
        {
            width: 382px;
        }
        .style32
        {
            height: 17px;
            width: 326px;
            color: #FF0000;
            text-align: center;
        }
        .style33
        {
            width: 164px;
            height: 17px;
            text-align: center;
        }
        .style34
        {
            height: 17px;
            color: #FF0000;
            text-align: center;
        }
        .style35
        {
            height: 41px;
            width: 205px;
            color: #FF0000;
            text-align: center;
        }
        .style36
        {
            height: 17px;
            width: 205px;
            color: #FF0000;
            text-align: center;
        }
        .style38
        {
            height: 17px;
            color: #FF0000;
            text-align: center;
        }
        .style39
        {
            height: 17px;
            color: #FF0000;
            text-align: center;
            width: 487px;
        }
        .style40
        {
            height: 41px;
            color: #FF0000;
            width: 487px;
            text-align: center;
        }
        .style41
        {
            height: 23px;
            color: #FF0000;
            text-align: right;
        }
        .style42
        {
            height: 23px;
            width: 326px;
            color: #FF0000;
            text-align: center;
        }
        .style43
        {
            height: 23px;
            width: 205px;
            color: #FF0000;
            text-align: center;
        }
        .style44
        {
            width: 164px;
            height: 23px;
            color: #FF0000;
            text-align: center;
        }
        .style45
        {
            height: 23px;
            color: #FF0000;
            width: 208px;
            text-align: center;
        }
        .style46
        {
            height: 23px;
            color: #FF0000;
            text-align: center;
        }
        .style47
        {
            height: 23px;
            color: #FF0000;
            text-align: center;
            width: 487px;
        }
        .style48
        {
            height: 41px;
            color: #FF0000;
            width: 227px;
            text-align: center;
        }
        .style49
        {
            height: 17px;
            color: #FF0000;
            text-align: center;
            width: 227px;
        }
        .style50
        {
            height: 23px;
            color: #FF0000;
            width: 227px;
            text-align: center;
        }
        .style51
        {
            color: #000066;
        }
        </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
</head>
<body bgcolor="White" style="font-weight: 700">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" border="2">
            <tr>
                <td colspan="7" style="text-align: center" class="style29">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="21pt" 
                        ForeColor="#660033" style="text-align: center" 
                        Text="Reminder Cheque Details"></asp:Label>
                </td>
                <td style="text-align: center" class="style29">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style40" bgcolor="#FFCC00">
                    ARAZI NUMBER&nbsp;&nbsp;&nbsp;
                    </td>
                <td class="style9" bgcolor="#FFCC00">
                    NAME</td>
                <td class="style35" bgcolor="#FFCC00">
                    DATE</td>
                <td class="style4" bgcolor="#FFCC00">
                    CHEQUE</td>
                <td class="style48" bgcolor="#FFCC00">
                    &nbsp;AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style30" bgcolor="#FFCC00">
                    PLOT NO.</td>
                <td class="style30" bgcolor="#FFCC00">
                    &nbsp;</td>
                <td class="style30" bgcolor="#FFCC00">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style39" bgcolor="#FFCCFF">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="98px">
                    </asp:DropDownList>
                </td>
                <td class="style32" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox1" runat="server" Width="148px"></asp:TextBox>
                </td>
                <td class="style36" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td class="style33" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox3" runat="server" Height="21px" Width="92px"></asp:TextBox>
                </td>
                <td class="style49" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td class="style34" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox5" runat="server" Width="144px"></asp:TextBox>
                </td>
                <td class="style34" bgcolor="#FFCCFF">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                        Width="98px" />
                </td>
                <td class="style34" bgcolor="#FFCCFF">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style38" colspan="5">
                    Cheque Edit / Delete</td>
                <td class="style34" bgcolor="White" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style47" bgcolor="#FFCC00">
                    &nbsp;CHEQUE No.&nbsp;
                    </td>
                <td class="style42" bgcolor="#FFCC00">
                    ARAZI NUMBER&nbsp;</td>
                <td class="style43" bgcolor="#FFCC00">
                    NAME</td>
                <td class="style44" bgcolor="#FFCC00">
                    DATE</td>
                <td class="style50" bgcolor="#FFCC00">
                    &nbsp;AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style45" bgcolor="#FFCC00">
                    PLOT NO.</td>
                <td class="style45" bgcolor="#FFCC00">
                    STATUS</td>
                <td class="style45" bgcolor="#FFCC00">
                    STATUS DATE</td>
            </tr>
            <tr>
                <td class="style47" bgcolor="#00CCFF">
                    <asp:TextBox ID="TextBox11" runat="server" Width="69px"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Search" 
                        Width="61px" />
                </td>
                <td class="style42" bgcolor="#00CCFF">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="98px">
                    </asp:DropDownList>
                </td>
                <td class="style43" bgcolor="#00CCFF">
                    <asp:TextBox ID="TextBox6" runat="server" Width="148px"></asp:TextBox>
                </td>
                <td class="style44" bgcolor="#00CCFF">
                    <asp:TextBox ID="TextBox7" runat="server" Height="18px" Width="93px"></asp:TextBox>
                </td>
                <td class="style50" bgcolor="#00CCFF">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
                <td class="style45" bgcolor="#00CCFF">
                    <asp:TextBox ID="TextBox10" runat="server" Height="21px" Width="96px"></asp:TextBox>
                </td>
                <td class="style46" bgcolor="#00CCFF">
&nbsp;
                    &nbsp; 
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="113px">
                        <asp:ListItem>-----SELECT----</asp:ListItem>
                        <asp:ListItem>CHEQUE PAID</asp:ListItem>
                        <asp:ListItem>CANCEL</asp:ListItem>
                        <asp:ListItem>CASH</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style46" bgcolor="#00CCFF">
                    <asp:TextBox ID="TextBox12" runat="server" Height="23px" Width="111px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style41" bgcolor="Yellow" colspan="6">
                    <span class="style51">TOTAL AMOUNT -
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    PAID AMOUNT -&nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    BALANCE AMOUNT&nbsp; -&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
                <td class="style46" bgcolor="Yellow">
                    <asp:Button ID="Button2" runat="server" Text="Update" Width="63px" 
                        onclick="Button2_Click" />
&nbsp;
                    </td>
                <td class="style46" bgcolor="Yellow">
                    <asp:Button ID="Button3" runat="server" Text="Delete" Width="54px" 
                        onclick="Button3_Click" />
                </td>
            </tr>
            <tr>
                <td class="style10" colspan="8">
                    
                    <asp:GridView ID="GridView1" runat="server" 
                        onrowdatabound="GridView1_RowDataBound1" Width="100%" 
                        style="text-align:center;" BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        AutoGenerateColumns="False">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                        <Columns>
                        <asp:TemplateField>
                  <HeaderTemplate>ARAZI NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="arazi1" runat="server" Text='<%# Eval("arazi") %>'></asp:Label>
                  </ItemTemplate>
<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>CHEQUE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cheque1" runat="server" Text='<%# Eval("cheque") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="amount1" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>PLOT NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="plotno1" runat="server" Text='<%# Eval("plotno") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="status1" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>STATUS DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="status2" runat="server" Text='<%# Eval("statusdate","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle></ItemStyle>
                  </asp:TemplateField>
                  </Columns>
                    </asp:GridView>
                    
                    <br />
                </td>
            </tr>
             </table>
    
    </div>
    </form>
</body>
</html>