<%@ Page Language="C#" AutoEventWireup="true" CodeFile="arazipayment.aspx.cs" Inherits="arazipayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Arazi Payment</title>
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
            width: 84%;
        }
        .style2
        {
            font-size: x-large;
            color: #660066;
            height: 45px;
        }
        .style3
        {
            font-size: large;
        }
        .style4
        {
            width: 100%;
        }
        .style5
        {
            height: 33px;
        }
        .style6
        {
            height: 30px;
        }
        .style7
        {
            height: 32px;
        }
        .style8
        {
            height: 33px;
            font-weight: bold;
            width: 142px;
        }
        .style9
        {
            height: 32px;
            font-weight: bold;
            width: 142px;
        }
        .style10
        {
            height: 30px;
            font-weight: bold;
            width: 142px;
        }
        .style12
        {
            width: 142px;
            font-size: x-large;
        }
        .style13
        {
            height: 33px;
            font-weight: bold;
            text-align: left;
        }
        .style14
        {
            height: 33px;
            width: 130px;
        }
        .style15
        {
            height: 32px;
            font-size: large;
            font-weight: bold;
        }
        .style16
        {
            height: 33px;
            font-size: large;
            font-weight: bold;
        }
        .style17
        {
            height: 30px;
            font-size: large;
            font-weight: bold;
        }
        .style18
        {
            height: 33px;
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <table class="style1">
            <tr>
                <td class="style2" colspan="5" style="text-align: center">
                    <strong>Arazi Wise Payment Details</strong></td>
            </tr>
            <tr>
                <td class="style3" bgcolor="#66FF99">
                    <strong>Date From</strong></td>
                <td bgcolor="#66FF99">
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" 
                        style="font-size: large" Width="140px"></asp:TextBox>
                </td>
                <td class="style3" bgcolor="#66FF99">
                    <strong>Date To</strong></td>
                <td bgcolor="#66FF99">
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" 
                        style="font-size: large" Width="128px"></asp:TextBox>
                </td>
                <td bgcolor="#66FF99">
                    <asp:Button ID="Button1" runat="server" Text="Search" Font-Bold="True" 
                        Width="76px" onclick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <table align="right" border="3" class="style4">
                        <tr>
                            <td class="style8">
                                Arazi No 100</td>
                            <td class="style14" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            &nbsp;</td>
                            <td class="style13" bgcolor="#99FF66" colspan="21">
                                &nbsp;&nbsp;&nbsp; Month From&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox3" runat="server" Font-Size="Large" Height="27px" 
                                    Width="51px"></asp:TextBox>
&nbsp;&nbsp; Month To
                                <asp:TextBox ID="TextBox4" runat="server" Font-Size="Large" Height="27px" 
                                    Width="53px"></asp:TextBox>
&nbsp;&nbsp; Year
                                <asp:TextBox ID="TextBox5" runat="server" Font-Size="Large" Height="27px" 
                                    Width="82px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" BackColor="#660033" ForeColor="White" 
                                    onclick="Button2_Click" style="font-weight: 700" Text="View" Width="63px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                Arazi No 1204</td>
                            <td class="style6" style="text-align: left" colspan="6">
                                <asp:Label ID="Label2" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                                &nbsp;</td>
                            <td class="style17" style="text-align: left" bgcolor="#CCCC00">
                                Month Name</td>
                            <td class="style17" style="text-align: left" bgcolor="#CCCC00" colspan="9">
                                Total Amount</td>
                            <td class="style17" style="text-align: left" bgcolor="#CCCC00">
                                New Amount</td>
                            <td class="style17" style="text-align: left" bgcolor="#CCCC00" colspan="5">
                                EMI Amount</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 1412</td>
                            <td class="style5" style="text-align: left" colspan="2">
                                <asp:Label ID="Label3" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" bgcolor="#FFCCFF" colspan="6">
                                <strong>JANUARY</strong></td>
                            <td class="style5" style="text-align: left" colspan="7">
                                <asp:Label ID="Label23" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="6">
                                <asp:Label ID="Label24" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left">
                                <asp:Label ID="Label25" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 1414 surpal</td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label4" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" colspan="8" bgcolor="#FFCCFF">
                                <strong>FEBRUARY</strong></td>
                            <td class="style5" style="text-align: left">
                                <asp:Label ID="Label26" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="8">
                                <asp:Label ID="Label27" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="2">
                                <asp:Label ID="Label28" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 174MI</td>
                            <td class="style5" style="text-align: left" colspan="4">
                                <asp:Label ID="Label5" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                MARCH</td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label29" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label30" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label31" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 2011</td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label6" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                APRIL</td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label32" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label33" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="4">
                                <asp:Label ID="Label34" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Arazi No 239</td>
                            <td class="style7" style="text-align: left" colspan="5">
                                <asp:Label ID="Label7" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                MAY</td>
                            <td class="style7" style="text-align: left" colspan="3">
                                <asp:Label ID="Label35" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" colspan="5">
                                <asp:Label ID="Label36" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" colspan="4">
                                <asp:Label ID="Label37" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 254</td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label8" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                JUNE</td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label38" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label39" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="4">
                                <asp:Label ID="Label40" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Arazi No 293A</td>
                            <td class="style7" style="text-align: left" colspan="5">
                                <asp:Label ID="Label9" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                JULY</td>
                            <td class="style7" style="text-align: left" colspan="3">
                                <asp:Label ID="Label41" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" colspan="5">
                                <asp:Label ID="Label42" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" colspan="4">
                                <asp:Label ID="Label43" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 30</td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label10" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                AUGUST</td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label44" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label45" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="4">
                                <asp:Label ID="Label46" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Arazi No 343</td>
                            <td class="style7" style="text-align: left" colspan="5">
                                <asp:Label ID="Label11" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                SEPTEMBER</td>
                            <td class="style7" style="text-align: left" colspan="3">
                                <asp:Label ID="Label47" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" colspan="5">
                                <asp:Label ID="Label48" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style7" style="text-align: left" colspan="4">
                                <asp:Label ID="Label49" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 375KA</td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label12" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                OCTOBER</td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label50" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label51" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="4">
                                <asp:Label ID="Label52" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 432</td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label13" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                NOVEMBER</td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label53" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label54" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="4">
                                <asp:Label ID="Label55" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
						<tr>
                            <td class="style8">
                                Arazi No 436</td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label19" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style18" style="text-align: left" colspan="5" bgcolor="#FFCCFF">
                                <strong>DECEMBER</strong></td>
                            <td class="style5" style="text-align: left" colspan="3">
                                <asp:Label ID="Label56" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="5">
                                <asp:Label ID="Label57" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left" colspan="4">
                                <asp:Label ID="Label58" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                Total Amount
                            </td>
                            <td style="text-align: left" colspan="5">
                                <asp:Label ID="Label14" runat="server" ForeColor="Red" 
                                    style="font-weight: 700; font-size: x-large"></asp:Label>
                            </td>
                            <td style="text-align: left" colspan="5">
                                &nbsp;</td>
                            <td style="text-align: left" colspan="3">
                                &nbsp;</td>
                            <td style="text-align: left" colspan="5">
                                &nbsp;</td>
                            <td style="text-align: left" colspan="4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                New Amount</td>
                            <td colspan="5" style="text-align: left">
                                <asp:Label ID="Label21" runat="server" ForeColor="#000066" 
                                    style="font-size: x-large; font-weight: 700"></asp:Label>
                            </td>
                            <td colspan="5" style="text-align: left">
                                &nbsp;</td>
                            <td colspan="3" style="text-align: left">
                                &nbsp;</td>
                            <td colspan="5" style="text-align: left">
                                &nbsp;</td>
                            <td colspan="4" style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                EMI Amlount</td>
                            <td colspan="5" style="text-align: left">
                                <asp:Label ID="Label22" runat="server" ForeColor="#003300" 
                                    style="font-size: x-large; font-weight: 700"></asp:Label>
                            </td>
                            <td colspan="5" style="text-align: left">
                                &nbsp;</td>
                            <td colspan="3" style="text-align: left">
                                &nbsp;</td>
                            <td colspan="5" style="text-align: left">
                                &nbsp;</td>
                            <td colspan="4" style="text-align: left">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>
