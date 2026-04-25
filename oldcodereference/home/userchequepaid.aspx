<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userchequepaid.aspx.cs" Inherits="Default2" %>

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
            font-size: x-large;
            height: 38px;
            color: #FFFFFF;
        }
        .style3
        {
            height: 50px;
        }
        .style4
        {
            font-size: large;
        }
        .style5
        {
            height: 29px;
            font-size: large;
            font-weight: bold;
        }
        .style6
        {
            height: 29px;
            width: 114px;
            font-size: large;
            font-weight: bold;
        }
        .style7
        {
        }
        .style8
        {
            height: 29px;
            font-size: large;
            font-weight: bold;
            width: 180px;
        }
        .style9
        {
            width: 180px;
            height: 49px;
        }
        .style10
        {
            height: 29px;
            font-size: large;
            font-weight: bold;
            width: 103px;
        }
        .style11
        {
            width: 103px;
            height: 49px;
        }
        .style12
        {
            height: 29px;
            font-size: large;
            font-weight: bold;
            width: 132px;
        }
        .style13
        {
            width: 132px;
            height: 49px;
        }
        .style16
        {
            height: 49px;
        }
        .style17
        {
            height: 29px;
            font-size: large;
            font-weight: bold;
            width: 108px;
        }
        .style18
        {
            width: 108px;
            height: 49px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 100%">
      
        <table class="style1">
            <tr>
                <td class="style2" colspan="6" style="text-align: center" bgcolor="#660066">
                    <strong>HOAR A/C PAYMENT DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style3" colspan="6">
                    <span class="style4"><strong>HOAR</strong></span><strong><span class="style4"> 
                    A/C OPENING BALANCE&nbsp;&nbsp;&nbsp; </span>
                    <asp:Label ID="Label1" runat="server" CssClass="style4" ForeColor="#006600"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </strong>ID&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server" Height="24px" Width="75px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" style="font-weight: 700" 
                        Text="DELETE" onclick="Button2_Click" />
&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Label" 
                        style="color: #FF0000; font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
            
                <td class="style10">
                    TYPE</td>
                <td class="style8">
                    NAME</td>
                <td class="style17">
                    CHEUQE NO</td>
                <td class="style12">
                    AMOUNT</td>
                <td class="style5">
                    REMARK</td>
            </tr>
            <tr>
               
                <td class="style11">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="32px" Width="91px">
                        <asp:ListItem>---SELECT---</asp:ListItem>
                        <asp:ListItem>SELF</asp:ListItem>
                        <asp:ListItem>A/C</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="171px"></asp:TextBox>
                </td>
                <td class="style18">
                    <asp:TextBox ID="TextBox3" runat="server" Height="26px" Width="95px"></asp:TextBox>
                </td>
                <td class="style13">
                    <asp:TextBox ID="TextBox4" runat="server" Height="26px" Width="95px"></asp:TextBox>
                </td>
                <td class="style16">
                    <asp:TextBox ID="TextBox5" runat="server" Height="26px" 
                        Width="221px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Height="27px" Text="ADD" 
                        Width="67px" style="font-weight: 700" onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Label" 
                        style="color: #FF0000; font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="6">
                    <b>TOTAL PAID - </b>
                    <asp:Label ID="Label5" runat="server" 
                        style="color: #FF0000; " CssClass="ui-priority-primary"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					BALANCE&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" CssClass="style4" ForeColor="#006600"></asp:Label>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Horizontal" STYLE="WIDTH:100%;text-align:left;" 
                        AutoGenerateColumns="False">

                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" >
                            <ItemStyle Width="2%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="date" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}">
                            <ItemStyle Width="6%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ptype" HeaderText="TYPE" >
                            <ItemStyle Width="3%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="name" HeaderText="NAME">
                            <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="chequeno" HeaderText="CHEUQE NO">
                            <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="AMOUNT" >
                            <ItemStyle Font-Bold="True" ForeColor="Red"  Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="remark" HeaderText="REMARK">
                            <ItemStyle Width="30%" />
                            </asp:BoundField>
                        </Columns>

                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
      
    </div>
    </form>
   
</body>
</html>
