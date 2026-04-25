<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chequebounce.aspx.cs" Inherits="chequebounce" %>

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

          

       });
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: x-large;
            height: 43px;
        }
        .style3
        {
            height: 39px;
        }
        .style4
        {
            height: 39px;
            width: 158px;
        }
        .style6
        {
            height: 39px;
            width: 141px;
        }
        .style7
        {
        }
        .style8
        {
            height: 39px;
            width: 132px;
        }
        .style10
        {
            height: 39px;
            width: 98px;
        }
        .style12
        {
            height: 39px;
            width: 100px;
        }
        .style14
        {
            width: 141px;
            height: 51px;
        }
        .style15
        {
            width: 158px;
            height: 51px;
        }
        .style16
        {
            width: 98px;
            height: 51px;
        }
        .style17
        {
            width: 100px;
            height: 51px;
        }
        .style18
        {
            height: 51px;
        }
        .style19
        {
            width: 132px;
            height: 51px;
        }
        .style20
        {
            width: 141px;
            height: 28px;
        }
        .style21
        {
            width: 158px;
            height: 28px;
        }
        .style22
        {
            width: 98px;
            height: 28px;
        }
        .style23
        {
            width: 100px;
            height: 28px;
        }
        .style24
        {
            height: 28px;
        }
        .style25
        {
            width: 132px;
            height: 28px;
        }
        .style26
        {
            font-size: xx-large;
        }
        .style27
        {
            height: 39px;
            width: 181px;
        }
        .style28
        {
            height: 28px;
            width: 181px;
        }
        .style29
        {
            height: 51px;
            width: 181px;
        }
        .style30
        {
            height: 39px;
            width: 127px;
        }
        .style31
        {
            width: 127px;
            height: 28px;
        }
        .style32
        {
            width: 127px;
            height: 51px;
        }
    </style>
</head>
<body style="font-weight: 700">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#CCFF66" class="style2" colspan="9" style="text-align: center">
                    <strong>Cheque Bounce Entry</strong></td>
            </tr>
            <tr>
                <td class="style6" bgcolor="#CCFFFF">
                    Customer Reg. No.</td>
                <td class="style4" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="92px"></asp:TextBox>
                </td>
                <td class="style10" bgcolor="#CCFFFF">
                    <asp:Button ID="Button1" runat="server" style="font-weight: 700" Text="Search" 
                        Width="74px" onclick="Button1_Click" />
                </td>
                <td class="style12" bgcolor="#CCFFFF">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                </td>
                <td class="style30" bgcolor="#CCFFFF">
                </td>
                <td class="style3" bgcolor="#CCFFFF">
                    <asp:Button ID="Button2" runat="server" Height="26px" onclick="Button2_Click" 
                        style="font-weight: 700" Text="Submit" Width="75px" />
                </td>
                <td class="style27" bgcolor="#CCFFFF">
                </td>
                <td class="style8" bgcolor="#CCFFFF">
                </td>
                <td class="style3" bgcolor="#CCFFFF">
                </td>
            </tr>
            <tr>
                <td class="style20" bgcolor="#FFCCFF">
                    Reg.No</td>
                <td class="style21" bgcolor="#FFCCFF">
                    Name</td>
                <td class="style22" bgcolor="#FFCCFF">
                    Arazi No.</td>
                <td class="style23" bgcolor="#FFCCFF">
                    Plot No.</td>
                <td bgcolor="#FFCCFF" class="style31">
                    Plot Size</td>
                <td bgcolor="#FFCCFF" class="style24">
                    Cheque Date</td>
                <td bgcolor="#FFCCFF" class="style28">
                    Cheque No. 
                    /&nbsp; Sr.No.</td>
                <td class="style25" bgcolor="#FFCCFF">
                    Cheque Amount</td>
                <td bgcolor="#FFCCFF" class="style24">
                    Status</td>
            </tr>
            <tr>
                <td class="style14">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style15">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style16">
                    &nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style17">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style32">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style18">
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="108px"></asp:TextBox>
                </td>
                <td class="style29">
                    <asp:TextBox ID="TextBox3" runat="server" Height="27px" Width="70px" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                &nbsp;<span class="style26">/</span>&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server" Height="27px" Width="70px"></asp:TextBox>
                </td>
                <td class="style19">
                    <asp:TextBox ID="TextBox4" runat="server" Height="26px" Width="108px"></asp:TextBox>
                </td>
                <td class="style18">
                    <asp:TextBox ID="TextBox5" runat="server" Height="26px" ReadOnly="True" 
                        Width="108px">UNPAID</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="9">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%" 
                        DataKeyNames="id">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID" />
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUST REGNO." />
                            <asp:BoundField DataField="name" HeaderText="NAME" />
                            <asp:BoundField DataField="arazi" HeaderText="ARAZI NO" />
                            <asp:BoundField DataField="plotno" HeaderText="PLOT NO." />
                            <asp:BoundField DataField="plotsize" HeaderText="PLOT SIZE" />
                            <asp:BoundField DataField="chequedate" HeaderText="CHEQUE DATE"  DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="chequeno" HeaderText="CHEQUE NO." />
                            <asp:BoundField DataField="srno" HeaderText="Sr. No." />
                            <asp:BoundField DataField="chequeamt" HeaderText="CHEQUE AMT" />
                            <asp:BoundField DataField="status" HeaderText="STATUS" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
