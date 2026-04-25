<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dailerdetails.aspx.cs" Inherits="dialer_dailerfetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CALL DAILER</title>
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
            $("#TextBox4").datepicker({
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
            height: 54px;
        }
        .style2
        {
            font-size: x-large;
            color: #FFFFFF;
        }
        .style3
        {
            height: 34px;
        }
        .style4
        {
            height: 46px;
        }
        .style5
        {
            height: 58px;
            width:50%;
        }
        .style6
        {
            width: 64px;
        }
        .style7
        {
            width: 144px;
        }
        .style8
        {
            width: 36px;
        }
        .style9
        {
            width: 139px;
        }
        .style10
        {
            height: 23px;
        }
        .style11
        {
            width: 537px;
        }
        .style12
        {
            width: 145px;
        }
        .style13
        {
            width: 121px;
        }
        .style14
        {
            font-weight: bold;
        }
        .style15
        {
            height: 31px;
        }
        .style16
        {
            color: #C4004F;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style4" colspan="5" style="text-align: center" bgcolor="#000066">
                    <strong><span class="style2">CUSTOMER CALL DETAILS</span></strong>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="5" bgcolor="#CCCCCC">
                    <strong>AGENT&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" 
                        style="font-weight: 700" Width="103px">
                        <asp:ListItem>---SELECT---</asp:ListItem>
                        <asp:ListItem>heedrealestate</asp:ListItem>
                        <asp:ListItem>Ashok8396</asp:ListItem>
                        <asp:ListItem>MACHHARIYAOFFICE</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    <strong>
                    <asp:Panel ID="Panel1" runat="server" Height="57px" BackColor="#FFBF80">
                        <table class="style1">
                            <tr>
                                <td class="style10" colspan="5" style="text-align: center">
                                    DAILING DATE</td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    FROM</td>
                                <td class="style7">
                                    <asp:TextBox ID="TextBox1" runat="server" Height="20px"></asp:TextBox>
                                </td>
                                <td class="style8">
                                    TO</td>
                                <td class="style9">
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                                <td class="style11">
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" Height="27px" Text="SEARCH" 
                                        Width="96px" CssClass="style14" onclick="Button1_Click" />
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </strong>
                </td>
                <td class="style5" colspan="4">
                    <strong>
                    <asp:Panel ID="Panel2" runat="server" Height="57px" BackColor="#AAFFDD">
                        <table class="style1">
                            <tr>
                                <td colspan="5" style="text-align: center">
                                    TOTAL CALL RECORD&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    TOTALL CALL</td>
                                <td class="style12">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                                </td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    <span class="style16"><strong>NO OF CALL&nbsp;&nbsp; </strong></span><strong>
                    <asp:Label ID="Label1" runat="server" CssClass="style16" Text="Label"></asp:Label>
                    </strong></td>
                <td class="style15">
                    </td>
                <td class="style15">
                    </td>
                <td class="style15">
                    </td>
                <td class="style15">
                    </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                        CellSpacing="1" GridLines="None" Width="100%" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField HeaderText="REGNO" DataField="CUSTREGNO" />
                            <asp:BoundField HeaderText="NAME" DataField="NAME" />
                            <asp:BoundField HeaderText="ARAZI" DataField="APPNO"/>
                            <asp:BoundField HeaderText="PLOTNO" DataField="plotno"/>
                            <asp:BoundField HeaderText="SIZE" DataField="PLOTSIZE"/>
                            <asp:BoundField HeaderText="STATUS" DataField="status" />
                            <asp:BoundField HeaderText="DURATION" DataField="duration"/>
                            <asp:BoundField HeaderText="CALL DATE" DataField="date" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:BoundField HeaderText="FEEDBACK" DataField="reason"/>
                            <asp:BoundField HeaderText="GIVEN DATE" DataField="feeddate" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:BoundField HeaderText="RECORDING" DataField="recording"/>
							<asp:BoundField HeaderText="TIME" DataField="entrytime"/>
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
