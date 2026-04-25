<%@ Page Language="C#" AutoEventWireup="true" CodeFile="latepaymentyearly.aspx.cs" Inherits="dialer_latepaymentyearly" %>

<!DOCTYPE html>

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
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            font-size: x-large;
            height: 47px;
        }
        .auto-style3 {
            height: 41px;
        }
.ui-priority-primary,
.ui-widget-content .ui-priority-primary,
.ui-widget-header .ui-priority-primary {
	font-weight: bold;
}
        .auto-style4 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" style="background-color: #C0C0C0"><strong>LATE PAYMENT DETAILS MONTHSWISE</strong></td>
            </tr>
            <tr>
                <td class="auto-style3"><strong>FROM&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="108px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; TO&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Height="26px" Width="108px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; USER</strong>&nbsp;
     <asp:DropDownList ID="DropDownList3" runat="server" Height="31px" Width="108px" 
                    CssClass="ui-priority-primary" 
                   >
     </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp; <strong>
                    <asp:Button ID="Button1" runat="server" BackColor="#000066" CssClass="ui-priority-primary" ForeColor="White" Height="30px" Text="VIEW" Width="71px" OnClick="Button1_Click" />
                    </strong>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>
                    <asp:GridView ID="GridView1" style="text-align:left;" runat="server" 
                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" GridLines="Vertical" Width="100%" AutoGenerateColumns="False" 
                        CssClass="auto-style4" onrowdatabound="GridView1_RowDataBound">
                      <Columns>
                            <asp:BoundField DataField="month" HeaderText="MONTH" />
                            <asp:BoundField DataField="startpmt" HeaderText="START EMI" >
                                <ItemStyle ForeColor="black" />
                            </asp:BoundField>
                            <asp:BoundField DataField="totallateemi" HeaderText="END EMI" >
                                <ItemStyle ForeColor="black" />
                            </asp:BoundField>
                           <asp:TemplateField HeaderText="Status">
        <ItemTemplate>
            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("BALEMI") %>' Width="20px" ForeColor = "BLACK" />
        </ItemTemplate>
    </asp:TemplateField>
                            
                                <asp:BoundField DataField="lateemimonth" HeaderText="MONTH EMI" >
                                 <ItemStyle ForeColor="Red" />
                            </asp:BoundField>
                                 <asp:BoundField DataField="totalpaidemi" HeaderText="PAID EMI" >
                            <ItemStyle ForeColor="#006600" />
                            </asp:BoundField>
                            <asp:BoundField DataField="totalbalemi" HeaderText="BALANCE EMI" >
                           
                            <ItemStyle ForeColor="Red" />
                            </asp:BoundField>
                           
                           </Columns>
                         <AlternatingRowStyle BackColor="#DCDCDC" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                    </strong>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
