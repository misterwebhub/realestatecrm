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
            width: 89%;
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
            width: 122px;
        }
        .style9
        {
            height: 32px;
            font-weight: bold;
            width: 122px;
        }
        .style10
        {
            height: 30px;
            font-weight: bold;
            width: 122px;
        }
        .style12
        {
            width: 122px;
            font-size: large;
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
            width: 86px;
        }
        .style15
        {
            height: 32px;
            font-size: large;
            font-weight: bold;
            width: 120px;
        }
        .style16
        {
            height: 33px;
            font-size: large;
            font-weight: bold;
            width: 120px;
        }
        .style17
        {
            height: 30px;
            font-size: large;
            font-weight: bold;
        }
        .style18
        {
            width: 122px;
            font-size: x-large;
            height: 31px;
        }
        .style19
        {
            height: 31px;
        }
        .style20
        {
            width: 122px;
            font-size: x-large;
            height: 29px;
        }
        .style21
        {
            height: 29px;
        }
        .style22
        {
            width: 122px;
            font-size: x-large;
            height: 27px;
        }
        .style23
        {
            height: 27px;
        }
        .style24
        {
            height: 33px;
            font-weight: bold;
            width: 90px;
        }
        .style25
        {
            height: 30px;
            font-weight: bold;
            width: 90px;
        }
        .style26
        {
            height: 32px;
            font-weight: bold;
            width: 90px;
        }
        .style27
        {
            width: 90px;
            font-size: x-large;
            height: 29px;
        }
        .style28
        {
            width: 90px;
            font-size: x-large;
            height: 31px;
        }
        .style29
        {
            width: 90px;
            font-size: x-large;
            height: 27px;
        }
        .style30
        {
            width: 90px;
            font-size: x-large;
        }
        .style31
        {
            font-size: medium;
        }
        .style32
        {
            height: 33px;
            width: 86px;
            font-size: medium;
        }
        .style33
        {
            width: 122px;
            font-size: medium;
            height: 27px;
        }
        .style34
        {
            height: 27px;
            font-size: medium;
        }
        .style35
        {
            width: 90px;
            font-size: medium;
            height: 27px;
        }
        .style36
        {
            font-size: medium;
            color: #003399;
        }
        .style38
        {
            height: 33px;
            width: 114px;
        }
        .style39
        {
            height: 32px;
            width: 114px;
        }
        .style45
        {
            height: 30px;
            font-size: large;
            font-weight: bold;
            width: 120px;
        }
        .style46
        {
            height: 29px;
            width: 120px;
        }
        .style47
        {
            height: 31px;
            width: 120px;
        }
        .style48
        {
            height: 27px;
            width: 120px;
        }
        .style49
        {
            height: 27px;
            font-size: medium;
            width: 120px;
        }
        .style50
        {
            width: 120px;
        }
        .style51
        {
            height: 30px;
            font-size: large;
            font-weight: bold;
            width: 114px;
        }
        .style52
        {
            height: 29px;
            width: 114px;
        }
        .style53
        {
            height: 31px;
            width: 114px;
        }
        .style54
        {
            height: 27px;
            width: 114px;
        }
        .style55
        {
            height: 27px;
            font-size: medium;
            width: 114px;
        }
        .style56
        {
            width: 114px;
        }
        .style58
        {
            height: 33px;
            width: 109px;
        }
        .style59
        {
            height: 32px;
            width: 109px;
        }
        .style60
        {
            height: 30px;
            font-size: large;
            font-weight: bold;
            width: 109px;
        }
        .style61
        {
            height: 29px;
            width: 109px;
        }
        .style62
        {
            height: 31px;
            width: 109px;
        }
        .style63
        {
            height: 27px;
            width: 109px;
        }
        .style64
        {
            height: 27px;
            font-size: medium;
            width: 109px;
        }
        .style65
        {
            width: 109px;
        }
        .style66
        {
            height: 33px;
            width: 104px;
        }
        .style67
        {
            height: 32px;
            width: 104px;
        }
        .style68
        {
            height: 29px;
            width: 104px;
        }
        .style69
        {
            height: 31px;
            width: 104px;
        }
        .style70
        {
            height: 27px;
            width: 104px;
        }
        .style72
        {
            width: 104px;
        }
        .style73
        {
            width: 104px;
            font-size: medium;
            height: 27px;
        }
        .style74
        {
            width: 105px;
            height: 29px;
        }
        .style78
        {
            height: 28px;
        }
        .style79
        {
            height: 28px;
            width: 120px;
        }
        .style80
        {
            height: 28px;
            width: 114px;
        }
        .style81
        {
            height: 28px;
            width: 109px;
        }
        .style82
        {
            height: 28px;
            width: 104px;
        }
        .style83
        {
            height: 30px;
            font-size: large;
            font-weight: bold;
            text-align: center;
            color: #FFFFFF;
        }
        .style84
        {
            height: 33px;
            width: 13px;
            font-weight: bold;
        }
        .style85
        {
            height: 32px;
            width: 13px;
            font-weight: bold;
        }
        .style86
        {
            height: 29px;
            width: 13px;
            font-weight: bold;
        }
        .style87
        {
            height: 31px;
            width: 13px;
            font-weight: bold;
        }
        .style88
        {
            height: 27px;
            width: 13px;
            font-weight: bold;
        }
        .style89
        {
            height: 27px;
            font-size: medium;
            width: 13px;
            font-weight: bold;
        }
        .style90
        {
            height: 28px;
            width: 13px;
            font-weight: bold;
        }
        .style91
        {
            width: 13px;
            text-align: left;
        }
        .style92
        {
            width: 13px;
            text-align: left;
            font-weight: bold;
        }
        .style93
        {
            width: 105px;
            height: 29px;
            color: black;
            font-size: medium;
        }
        .style94
        {
            width: 122px;
            font-size: large;
            color: #FF0000;
        }
        .style95
        {
            width: 90px;
            font-size: large;
            color: #000099;
        }
        .style96
        {
            font-size: large;
            color: #800000;
        }
        .style97
        {
            font-size: medium;
            color: #800000;
        }
        .style98
        {
            width: 122px;
            font-size: large;
            font-weight: bold;
        }
        .style99
        {
            width: 105px;
            height: 29px;
            color: black;
            font-size: medium;
            font-weight: bold;
        }
        .style100
        {
            width: 90px;
            font-size: medium;
        }
        .style101
        {
            width: 122px;
            font-size: medium;
            font-weight: bold;
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
                                &nbsp;</td>
                            <td class="style24">
                                Till Dec 2020 </td>
                            <td class="style32" style="text-align: left">
                                <strong style="text-align: center">&nbsp; Jan - 2021</strong></td>
                            <td class="style13" bgcolor="#99FF66" colspan="7">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 100</td>
                            <td class="style24">
                                <asp:Label ID="Label1" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style14">
                                <asp:Label ID="Label63" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style13" bgcolor="#99FF66" colspan="7">
                                &nbsp;Month From&nbsp;<asp:TextBox ID="TextBox3" runat="server" Font-Size="Large" Height="27px" 
                                    Width="40px"></asp:TextBox>
&nbsp;Month To
                                <asp:TextBox ID="TextBox4" runat="server" Font-Size="Large" Height="27px" 
                                    Width="39px"></asp:TextBox>
&nbsp;Year
                                <asp:TextBox ID="TextBox5" runat="server" Font-Size="Large" Height="27px" 
                                    Width="64px"></asp:TextBox>
                                &nbsp;<asp:Button ID="Button2" runat="server" BackColor="#660033" ForeColor="White" 
                                    onclick="Button2_Click" style="font-weight: 700" Text="View" Width="63px" />
                                <asp:Label ID="Label59" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                Arazi No 1204</td>
                            <td class="style25">
                                <asp:Label ID="Label2" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                                </td>
                            <td class="style6" colspan="2">
                                <asp:Label ID="Label64" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style45" style="text-align: left" bgcolor="#CCCC00">
                                Month Name</td>
                            <td class="style51" style="text-align: left" bgcolor="#CCCC00">
                                Total Amount</td>
                            <td class="style60" style="text-align: left" bgcolor="#CCCC00">
                                New Amount</td>
                            <td class="style17" style="text-align: left" bgcolor="#CCCC00">
                                EMI Amount</td>
                            <td class="style83" bgcolor="#660033" colspan="2">
                                PER DAY PAYMENT</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 1412</td>
                            <td class="style24">
                                <asp:Label ID="Label3" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                &nbsp;&nbsp;
                                <asp:Label ID="Label65" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                                &nbsp;
                            </td>
                            <td class="style15" style="text-align: left" bgcolor="#FFCCFF">
                                JANUARY</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label23" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label24" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label25" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                1</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label101" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 1414</td>
                            <td class="style24">
                                <asp:Label ID="Label4" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label66" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: left" bgcolor="#FFCCFF">
                                FEBRUARY</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label26" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label27" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label28" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                2</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label102" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 174MI</td>
                            <td class="style24">
                                <asp:Label ID="Label5" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label67" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" bgcolor="#FFCCFF">
                                MARCH</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label29" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label30" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label31" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                3</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label103" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 2011</td>
                            <td class="style24">
                                <asp:Label ID="Label6" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label68" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" bgcolor="#FFCCFF">
                                APRIL</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label32" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label33" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label34" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                4</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label104" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Arazi No 239</td>
                            <td class="style26">
                                <asp:Label ID="Label7" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style7" colspan="2">
                                <asp:Label ID="Label69" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: left" bgcolor="#FFCCFF">
                                MAY</td>
                            <td class="style39" style="text-align: left">
                                <asp:Label ID="Label35" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style59" style="text-align: left">
                                <asp:Label ID="Label36" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style67" style="text-align: left">
                                <asp:Label ID="Label37" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style85" bgcolor="#CCFF99">
                                5</td>
                            <td class="style7" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label105" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 254</td>
                            <td class="style24">
                                <asp:Label ID="Label8" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label70" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" bgcolor="#FFCCFF">
                                JUNE</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label38" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label39" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label40" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                6</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label106" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Arazi No 293A</td>
                            <td class="style26">
                                <asp:Label ID="Label9" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style7" colspan="2">
                                <asp:Label ID="Label71" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: left" bgcolor="#FFCCFF">
                                JULY</td>
                            <td class="style39" style="text-align: left">
                                <asp:Label ID="Label41" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style59" style="text-align: left">
                                <asp:Label ID="Label42" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style67" style="text-align: left">
                                <asp:Label ID="Label43" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style85" bgcolor="#CCFF99">
                                7</td>
                            <td class="style7" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label107" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 30</td>
                            <td class="style24">
                                <asp:Label ID="Label10" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label72" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" bgcolor="#FFCCFF">
                                AUGUST</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label44" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label45" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label46" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                8</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label108" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                Arazi No 343</td>
                            <td class="style26">
                                <asp:Label ID="Label11" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style7" colspan="2">
                                <asp:Label ID="Label73" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style15" style="text-align: left" bgcolor="#FFCCFF">
                                SEPTEMBER</td>
                            <td class="style39" style="text-align: left">
                                <asp:Label ID="Label47" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style59" style="text-align: left">
                                <asp:Label ID="Label48" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style67" style="text-align: left">
                                <asp:Label ID="Label49" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style85" bgcolor="#CCFF99">
                                9</td>
                            <td class="style7" style="text-align: left" bgcolor="#CCFF99">
                                &nbsp;<asp:Label ID="Label109" runat="server" CssClass="ui-priority-primary"></asp:Label>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 375KA</td>
                            <td class="style24">
                                <asp:Label ID="Label12" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label74" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" bgcolor="#FFCCFF">
                                OCTOBER</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label50" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label51" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label52" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                10</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label110" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                Arazi No 432</td>
                            <td class="style24">
                                <asp:Label ID="Label13" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label75" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style16" style="text-align: left" bgcolor="#FFCCFF">
                                NOVEMBER</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label53" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label54" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label55" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                11</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label111" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
						<tr>
                            <td class="style8">
                                Arazi No 436</td>
                            <td class="style24">
                                <asp:Label ID="Label19" runat="server" CssClass="ui-priority-primary" 
                                    ForeColor="#000099"></asp:Label>
                            </td>
                            <td class="style5" colspan="2">
                                <asp:Label ID="Label76" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td class="style45" style="text-align: left" bgcolor="#FFCCFF">
                                DECEMBER</td>
                            <td class="style38" style="text-align: left">
                                <asp:Label ID="Label56" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style58" style="text-align: left">
                                <asp:Label ID="Label57" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style66" style="text-align: left">
                                <asp:Label ID="Label58" runat="server" Text="0"></asp:Label>
                            </td>
                            <td class="style84" bgcolor="#CCFF99">
                                12</td>
                            <td class="style5" style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label112" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20">
                                <strong style="font-size: medium">Arazi No 519</strong></td>
                            <td class="style27">
                                <asp:Label ID="Label60" runat="server" ForeColor="#000099" 
                                    style="font-weight: 700" CssClass="style31"></asp:Label>
                            </td>
                            <td colspan="2" class="style21">
                                <asp:Label ID="Label77" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style46">
                                TOTAL</td>
                            <td style="text-align: left" class="style52">
                               <asp:Label ID="Label777" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label> </td>
                            <td style="text-align: left" class="style61">
                                </td>
                            <td style="text-align: left" class="style68">
                                </td>
                            <td class="style86" bgcolor="#CCFF99">
                                13</td>
                            <td style="text-align: left" class="style21" bgcolor="#CCFF99">
                                <asp:Label ID="Label113" runat="server" CssClass="ui-priority-primary"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td class="style18">
                                <strong style="font-size: medium">Arazi No 152</strong></td>
                            <td class="style28">
                                <asp:Label ID="Label61" runat="server" ForeColor="#000099" 
                                    style="font-weight: 700" CssClass="style31"></asp:Label>
                            </td>
                            <td colspan="2" class="style19">
                                <asp:Label ID="Label79" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style47" bgcolor="Aqua">
                                <strong>&#39; D &#39; Block&nbsp; </strong>
                                </td>
                            <td style="text-align: left" class="style53" bgcolor="Aqua">
                                <asp:Label ID="Label92" runat="server" style="font-weight: 700; color: #FF3300"></asp:Label>
                                </td>
                            <td style="text-align: left" class="style62" bgcolor="#66FF99">
                                &nbsp;</td>
                            <td style="text-align: left" class="style69" bgcolor="#66FF99">
                                &nbsp;</td>
                            <td class="style87" bgcolor="#CCFF99">
                                14</td>
                            <td style="text-align: left" class="style19" bgcolor="#CCFF99">
                                <asp:Label ID="Label114" runat="server" CssClass="ui-priority-primary"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td class="style22">
                                <strong style="font-size: medium">Arazi No 506</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label62" runat="server" ForeColor="#000099" 
                                    style="font-weight: 700" CssClass="style31"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label78" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48" bgcolor="#CCFF33">
                                <strong>&#39; F &#39; Block</strong></td>
                            <td style="text-align: left" class="style54" bgcolor="#CCFF33">
                                <asp:Label ID="Label98" runat="server" style="font-weight: 700; color: #FF3300"></asp:Label>
                                </td>
                            <td style="text-align: left" class="style63">
                                </td>
                            <td style="text-align: left" class="style70">
                                </td>
                            <td class="style88" bgcolor="#CCFF99">
                                15</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label115" runat="server" CssClass="ui-priority-primary"></asp:Label>
                                </td>
                        </tr>
						<tr>
                            <td class="style22">
                                <strong style="font-size: medium">Arazi No 340</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label80" runat="server" ForeColor="#000099" 
                                    style="font-weight: 700" CssClass="style31"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label81" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48" bgcolor="#FFFF66">
                                <strong>&#39; E &#39; Block&nbsp; </strong>
                                </td>
                            <td style="text-align: left" class="style54" bgcolor="#FFFF66">
                                <asp:Label ID="Label93" runat="server" style="font-weight: 700; color: #FF3300"></asp:Label>
                                </td>
                            <td style="text-align: left" class="style63">
                                </td>
                            <td style="text-align: left" class="style70">
                                </td>
                            <td class="style88" bgcolor="#CCFF99">
                                16</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label116" runat="server" CssClass="ui-priority-primary"></asp:Label>
                                </td>
                        </tr>
						<tr>
                            <td class="style22">
                                <strong style="font-size: medium">Arazi No 161 GHA</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label82" runat="server" ForeColor="#000099" 
                                    style="font-weight: 700" CssClass="style31"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label83" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48">
                                </td>
                            <td style="text-align: left" class="style54">
                                </td>
                            <td style="text-align: left" class="style63">
                                </td>
                            <td style="text-align: left" class="style70">
                                </td>
                            <td class="style88" bgcolor="#CCFF99">
                                17</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label117" runat="server" CssClass="ui-priority-primary"></asp:Label>
                                </td>
                        </tr>
						<tr>
                            <td class="style33">
                                <strong>Arazi No. 372KA</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label84" runat="server" CssClass="style36" Font-Bold="True" 
                                    ForeColor="#003399"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label85" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48">
                                &nbsp;</td>
                            <td style="text-align: left" class="style54">
                                &nbsp;</td>
                            <td style="text-align: left" class="style63">
                                &nbsp;</td>
                            <td style="text-align: left" class="style70">
                                &nbsp;</td>
                            <td class="style88" bgcolor="#CCFF99">
                                18</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label118" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
						<tr>
                            <td class="style22">
                                <strong style="font-size: medium">Arazi No. 385KA</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label86" runat="server" CssClass="style36" Font-Bold="True" 
                                    ForeColor="#003399"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label87" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48">
                                &nbsp;</td>
                            <td style="text-align: left" class="style54">
                                &nbsp;</td>
                            <td style="text-align: left" class="style63">
                                &nbsp;</td>
                            <td style="text-align: left" class="style70">
                                &nbsp;</td>
                            <td class="style88" bgcolor="#CCFF99">
                                19</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label119" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
						<tr>
                            <td class="style22">
                                <strong class="style31">Arazi No. 186MI</strong></td>
                            <td class="style35">
                                <asp:Label ID="Label88" runat="server" CssClass="style36" Font-Bold="True" 
                                    ForeColor="#003399"></asp:Label>
                            </td>
                            <td colspan="2" class="style34">
                                <asp:Label ID="Label89" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style49">
                                &nbsp;</td>
                            <td style="text-align: left" class="style55">
                                &nbsp;</td>
                            <td style="text-align: left" class="style64">
                                &nbsp;</td>
                            <td style="text-align: left" class="style73">
                                &nbsp;</td>
                            <td class="style89" bgcolor="#CCFF99">
                                20</td>
                            <td style="text-align: left" class="style34" bgcolor="#CCFF99">
                                <asp:Label ID="Label120" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
						<tr>
                            <td class="style33">
                                <strong>Arazi No. 137 Ramaipur</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label90" runat="server" CssClass="style36" Font-Bold="True" 
                                    ForeColor="#003399"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label91" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48">
                                &nbsp;</td>
                            <td style="text-align: left" class="style54">
                                &nbsp;</td>
                            <td style="text-align: left" class="style63">
                                &nbsp;</td>
                            <td style="text-align: left" class="style70">
                                &nbsp;</td>
                            <td class="style88" bgcolor="#CCFF99">
                                21</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label121" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
						<tr>
                            <td class="style33">
                                <strong>Arazi No. 217</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label94" runat="server" CssClass="style36" Font-Bold="True" 
                                    ForeColor="#003399"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label96" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48">
                                &nbsp;</td>
                            <td style="text-align: left" class="style54">
                                &nbsp;</td>
                            <td style="text-align: left" class="style63">
                                &nbsp;</td>
                            <td style="text-align: left" class="style70">
                                &nbsp;</td>
                            <td class="style88" bgcolor="#CCFF99">
                                22</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label122" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
						<tr>
                            <td class="style33">
                                <strong>Arazi No. 357</strong></td>
                            <td class="style29">
                                <asp:Label ID="Label95" runat="server" CssClass="style36" Font-Bold="True" 
                                    ForeColor="#003399"></asp:Label>
                            </td>
                            <td colspan="2" class="style23">
                                <asp:Label ID="Label97" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style48">
                                &nbsp;</td>
                            <td style="text-align: left" class="style54">
                                &nbsp;</td>
                            <td style="text-align: left" class="style63">
                                &nbsp;</td>
                            <td style="text-align: left" class="style70">
                                &nbsp;</td>
                            <td class="style88" bgcolor="#CCFF99">
                                23</td>
                            <td style="text-align: left" class="style23" bgcolor="#CCFF99">
                                <asp:Label ID="Label123" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style93">
                                <strong>Arazi 2001G</strong></td>
                            <td style="text-align: left;font-size:large;color:blue;" class="style74">
                                <asp:Label ID="Label134" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="#0033CC"></asp:Label>
                            </td>
                            <td style="text-align: left;font-size:large;color:Maroon;" colspan="2" 
                                class="style74">
                                <asp:Label ID="Label133" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style46">
                                </td>
                            <td style="text-align: left" class="style52">
                                </td>
                            <td style="text-align: left" class="style61">
                                </td>
                            <td style="text-align: left" class="style68">
                                </td>
                            <td bgcolor="#CCFF99" class="style86">
                                24</td>
                            <td style="text-align: left" bgcolor="#CCFF99" class="style21">
                                <asp:Label ID="Label124" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;" class="style99">
                                Arazi 187-Kha</td>
                            <td style="text-align: left;font-size:large;color:blue;" class="style74">
                                <asp:Label ID="Label135" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="#0033CC"></asp:Label>
                            </td>
                            <td style="text-align: left;font-size:large;color:Maroon;" colspan="2" 
                                class="style74">
                                <asp:Label ID="Label136" runat="server" CssClass="style97" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style79">
                                </td>
                            <td style="text-align: left" class="style80">
                                </td>
                            <td style="text-align: left" class="style81">
                                </td>
                            <td style="text-align: left" class="style82">
                                </td>
                            <td bgcolor="#CCFF99" class="style90">
                                25</td>
                            <td style="text-align: left" bgcolor="#CCFF99" class="style78">
                                <asp:Label ID="Label125" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style98">
                                Arazi-320</td>
                            <td class="style30">
                                
                                <asp:Label ID="Label137" runat="server" CssClass="style31" Font-Bold="True" 
                                    ForeColor="#0033CC"></asp:Label>
                                
                            </td>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label138" runat="server" CssClass="style97" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                26</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label126" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style98">
                                Arazi-353</td>
                            <td class="style100">
                                
                                0</td>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label778" runat="server" CssClass="style97" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                27</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label127" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style98">
                                Arazi-356</td>
                            <td class="style100">
                                
                                0</td>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label779" runat="server" CssClass="style97" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                28</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label128" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style98">
                                Arazi-419</td>
                            <td class="style100">
                                
                                0</td>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label780" runat="server" CssClass="style97" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                29</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label129" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style98">
                                Arazi-1731</td>
                            <td class="style100">
                                
                                0</td>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label781" runat="server" CssClass="style97" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                30</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label130" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style101">
                                Arazi-246-12bigha</td>
                            <td class="style100">
                                
                                0</td>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label782" runat="server" CssClass="style97" Font-Bold="True" 
                                    ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                31</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label131" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style94">
                                Total Amount
                            </td>
                            <td class="style95">
                                
                                <strong>2020 Amount
                            </strong></td>
                            <td colspan="2" style="text-align: left" class="style96">
                                <strong>2021 Amount</strong></td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                Total</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                <asp:Label ID="Label132" runat="server" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                               <asp:Label ID="Label21" runat="server" ForeColor="red" 
                                    style="font-size:large; font-weight: 700"></asp:Label> 
                               </td>
                            <td class="style30">
                                
                                <asp:Label ID="Label14" runat="server" ForeColor="blue" 
                                    style="font-weight: 700; font-size:large"></asp:Label>
                                
                            </td>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="Label22" runat="server" ForeColor="Maroon" 
                                    style="font-size:large; font-weight: 700"></asp:Label></td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                &nbsp;</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td class="style30">
                                
                                &nbsp;</td>
                            <td colspan="2" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style92">
                                &nbsp;</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td class="style30">
                                
                                &nbsp;</td>
                            <td colspan="2" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left" class="style50">
                                &nbsp;</td>
                            <td style="text-align: left" class="style56">
                                &nbsp;</td>
                            <td style="text-align: left" class="style65">
                                &nbsp;</td>
                            <td style="text-align: left" class="style72">
                                &nbsp;</td>
                            <td bgcolor="#CCFF99" class="style91">
                                &nbsp;</td>
                            <td style="text-align: left" bgcolor="#CCFF99">
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
