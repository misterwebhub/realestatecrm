<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RECIPTUPDATE.aspx.cs" Inherits="RECIPTUPFATE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>KISHAN PAYMENT</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
    <script type="text/javascript">
        $(function () {
            $("#countrytabs").tabs();
        });
        $(document).ready(function () {
            $("#TextBox3").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox8").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox30").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox43").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox9").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox15").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox17").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });


        });
    </script>
    <style type="text/css">
    #r
    {
        float:left;
        height:455px;
        border:3px solid blue;
    }
    .p
    {
        width:24%;
       
    
    }
    .p1
    {
         width:74%;
         margin-left:1%;
        
        
    }
        body
        {
            font-size: 14pt;
        }
        .style1
        {
            width: 151px;
        }
        .style2
        {
            width: 139px;
            color: #FFFFFF;
            height: 46px;
        }
        .style3
        {
        }
        .style4
        {
            width: 96px;
        }
        .style5
        {
            width: 97px;
            font-weight: bold;
        }
        .style6
        {
        }
        .style9
        {
            width: 108px;
            height: 37px;
        }
        .style10
        {
            height: 41px;
        }
        .style16
        {
            width: 137px;
            }
        .style28
        {
            width: 112px;
            height: 39px;
        }
        .style30
        {
            width: 151px;
            height: 39px;
            font-weight: bold;
        }
        .style32
        {
            width: 95px;
            height: 39px;
        }
        .style36
        {
            width: 96px;
            height: 39px;
        }
        .style54
        {
            width: 151px;
            height: 41px;
            font-weight: bold;
        }
        .style55
        {
            width: 112px;
            height: 41px;
        }
        .style57
        {
            width: 96px;
            height: 41px;
        }
        .style59
        {
            height: 40px;
            font-weight: bold;
        }
        .style60
        {
            width: 112px;
            height: 40px;
        }
        .style62
        {
            width: 95px;
            height: 40px;
        }
        .style63
        {
            height: 40px;
        }
        .style64
        {
            width: 91px;
            height: 40px;
        }
        .style67
        {
            width: 91px;
            height: 39px;
        }
        .style68
        {
            width: 137px;
            height: 39px;
        }
        .style69
        {
            height: 39px;
        }
        .style70
        {
            width: 126px;
            height: 39px;
        }
        .style71
        {
            width: 151px;
            font-weight: bold;
        }
        .style73
        {
            width: 126px;
            height: 41px;
            font-weight: bold;
        }
        .style75
        {
            width: 151px;
            height: 36px;
            font-weight: bold;
        }
        .style76
        {
            height: 36px;
        }
        .style77
        {
            width: 126px;
            height: 36px;
        }
        .style78
        {
            width: 95px;
            height: 36px;
        }
        .style79
        {
            width: 91px;
            height: 36px;
        }
        .style80
        {
            width: 137px;
            height: 36px;
        }
        .style81
        {
            width: 97px;
            height: 36px;
            font-weight: bold;
        }
        .style82
        {
            height: 41px;
            font-weight: bold;
            text-align: center;
        }
        .style83
        {
            width: 97px;
            height: 39px;
        }
        .style84
        {
            width: 273%;
            height: 38px;
        }
        .style86
        {
            width: 129px;
        }
         ul
        {
        background-color:#e9e9e9;
        }
        ul li
        {
            list-style:none;
            display:inline-block;
            padding:15px 25px ;
            border-radius:5px;
            background-color:ActiveCaption;
        }
        .t
        {
            text-decoration:none;
            font-size:14pt;
            color:Black;
        }
       ul li:hover
       {
          background-color: #dddddd;
       }
        .style88
        {
            width: 139px;
            color: #FFFFFF;
            height: 27px;
        }
        .style89
        {
            width: 70px;
            height: 26px;
            font-weight: bold;
        }
        .style91
        {
            width: 127px;
            height: 26px;
            font-weight: bold;
        }
        .style92
        {
            width: 174px;
            height: 26px;
        }
        .style93
        {
            height: 26px;
        }
        .style94
        {
            width: 96px;
            height: 26px;
        }
        .style95
        {
            width: 127px;
            height: 41px;
            font-weight: bold;
        }
        .style97
        {
            width: 70px;
            height: 41px;
            font-weight: bold;
        }
        .style100
        {
            width: 126px;
            height: 37px;
            font-weight: bold;
        }
        .style103
        {
            width: 127px;
            height: 37px;
            font-weight: bold;
        }
        .style104
        {
            width: 174px;
            height: 37px;
        }
        .style105
        {
            width: 70px;
            height: 37px;
            font-weight: bold;
        }
        .style106
        {
            width: 96px;
            height: 37px;
        }
        .style107
        {
            width: 19px;
            height: 37px;
        }
        .style108
        {
            width: 174px;
            height: 41px;
        }
        .style110
        {
            width: 127px;
        }
        .style111
        {
            width: 174px;
        }
        .style112
        {
            height: 37px;
            text-align: left;
        }
        .style113
        {
            width: 100%;
            height: 119px;
        }
        .style114
        {
        }
        .style115
        {
            height: 40px;
            font-weight: bold;
            width: 154px;
        }
        .style116
        {
            width: 154px;
            height: 41px;
            font-weight: bold;
        }
        .style119
        {
            width: 154px;
            height: 36px;
            font-weight: bold;
        }
        .style121
        {
            width: 167px;
            height: 40px;
            font-weight: bold;
        }
        .style123
        {
            width: 167px;
            height: 36px;
            font-weight: bold;
        }
        .style124
        {
            width: 167px;
            font-weight: bold;
        }
        .style125
        {
            width: 154px;
            height: 39px;
            font-weight: bold;
        }
        .style126
        {
            width: 154px;
            font-weight: bold;
        }
        .style127
        {
            width: 154px;
        }
        .style128
        {
            height: 40px;
            font-weight: bold;
            width: 102px;
        }
        .style129
        {
            width: 102px;
            height: 39px;
        }
        .style130
        {
            width: 102px;
            height: 36px;
        }
        .style131
        {
            width: 167px;
            height: 39px;
        }
        .style132
        {
            width: 120px;
            height: 40px;
        }
        .style133
        {
            width: 120px;
            height: 39px;
        }
        .style134
        {
            width: 120px;
            height: 36px;
        }
        .style135
        {
            width: 120px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li><asp:LinkButton ID="LinkButton3" runat="server"
                    onclick="LinkButton3_Click" class="t">KISHAN</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton5" runat="server" 
                    onclick="LinkButton5_Click" class="t">INVESTER</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton6" runat="server" 
                    onclick="LinkButton6_Click" class="t">BROKER</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton7" runat="server" 
                    onclick="LinkButton7_Click" class="t">OTHER</asp:LinkButton></li>
         
        </ul>
        <div id="countrytabs-1">
            <asp:Panel ID="Panel2" runat="server">
           
   <div style="height:550px;width:100%;">
    
    
        
    <div id="r" class="p1">
        <table height="80%" width="100%" style="font-size:12pt;width:0100%; ">
            <tr>
                <td class="style2" colspan="8" style="text-align: center" bgcolor="#000066">
                    <strong>Kishan Recipt Update&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Recipt- </strong>
                    <asp:TextBox ID="TextBox23" runat="server" Height="21px" Width="92px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button8" runat="server" Text="SEARCH" 
                        style="font-weight: 700" onclick="Button8_Click" />
                </td>
            </tr>
            <tr>
                <td class="style54" bgcolor="#FFCCFF">
                    KID</td>
                <td class="style55" bgcolor="#FFCCFF">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style82" bgcolor="#FFCCFF">
                    ARAZI</td>
                <td class="style10" bgcolor="#FFCCFF">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style73" bgcolor="#FFCCFF">
                    NAME</td>
                <td class="style57" colspan="3" bgcolor="#FFCCFF">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style30" bgcolor="#FFCCFF">
                    DATE</td>
                <td class="style28" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox3" runat="server" Height="23px" Width="107px"></asp:TextBox>
                    </td>
                <td class="style83" bgcolor="#FFCCFF">
                    <strong>AMOUNT</strong></td>
                <td class="style32" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="97px">0</asp:TextBox>
                    </td>
                <td class="style70" bgcolor="#FFCCFF">
                    </td>
                <td class="style67" bgcolor="#FFCCFF">
                    </td>
                <td class="style68" bgcolor="#FFCCFF">
                    </td>
                <td class="style69" bgcolor="#FFCCFF">
                    </td>
            </tr>
            <tr>
                <td class="style30" bgcolor="#FFCCFF">
                    PAYMENT MODE</td>
                <td class="style28" bgcolor="#FFCCFF">
                    <asp:RadioButton ID="RadioButton1" runat="server" CssClass="style4" 
                        Text="CASH" GroupName="A" AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" 
                         />
                </td>
                <td class="style83" bgcolor="#FFCCFF">
                    <asp:RadioButton ID="RadioButton2" runat="server" CssClass="style4" 
                        Text="CHEQUE" GroupName="A" AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" 
                        />
                </td>
                <td class="style36" colspan="5" bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style59" bgcolor="#FFCCFF" colspan="8">
                    <asp:Panel ID="Panel1" runat="server" Height="37px" Width="327px">
                        <table class="style84">
                            <tr>
                                <td class="style86">
                                    CHEUQE DATE</td>
                                <td class="style86">
                                    <asp:TextBox ID="TextBox8" runat="server" Height="23px" Width="107px"></asp:TextBox>
                                </td>
                                <td class="style86">
                                    <strong>CHEQUE NO.</strong></td>
                                <td>
                                     <asp:TextBox ID="TextBox6" runat="server" Height="25px" Width="91px"></asp:TextBox></td>
                                <td>
                                    <strong>REF.BY</strong></td>
                                <td>
                                     <asp:TextBox ID="TextBox7" runat="server" Height="23px" Width="107px"></asp:TextBox></td>
                                <td>
                                    <strong>STATUS</strong></td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="93px">
                                        <asp:ListItem>---SELECT---</asp:ListItem>
                                        <asp:ListItem>PAID</asp:ListItem>
                                        <asp:ListItem>UNPAID</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
            </tr>
            <tr>
                <td class="style71" bgcolor="#FFCCFF">
                    REASON</td>
                <td class="style3" bgcolor="#FFCCFF" colspan="7">
                    <asp:TextBox ID="TextBox2" runat="server" Height="63px" TextMode="MultiLine" 
                        Width="97%">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style75" bgcolor="#FFCCFF">
                    BROKER</td>
                <td class="style76" bgcolor="#FFCCFF">
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </td>
                <td class="style81" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style78" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style77" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style79" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style80" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td bgcolor="#FFCCFF" class="style76">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style71" bgcolor="#FFCCFF">
                    PAID AMOUNT</td>
                <td class="style3" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox4" runat="server" Height="23px" Width="107px">0</asp:TextBox>
                    </td>
                <td class="style5" bgcolor="#FFCCFF">
                    REASON</td>
                <td class="style6" bgcolor="#FFCCFF" colspan="5">
                    <asp:TextBox ID="TextBox5" runat="server" Height="63px" TextMode="MultiLine" 
                        Width="97%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style3" bgcolor="#FFCCFF">
                    <asp:Button ID="Button1" runat="server" Text="UPDATE" Width="118px" 
                        style="font-weight: 700; height: 26px;" onclick="Button1_Click" />
                </td>
                <td class="style9" colspan="4" bgcolor="#FFCCFF">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="style16" bgcolor="#FFCCFF">
                    <asp:Button ID="Button9" runat="server" onclick="Button9_Click" 
                        style="font-weight: 700" Text="DELETE" />
                </td>
                <td bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
        </table>
        </div>
    </div>
     </asp:Panel>
        </div>
        <div id="countrytabs-2">
            
            <asp:Panel ID="Panel3" runat="server">
            <div style="height:550px;width:100%;">
   
    <div id="r" class="p1">
        <table height="80%" width="100%" style="font-size:12pt;">
            <tr>
                <td class="style2" colspan="8" style="text-align: center" bgcolor="#000066">
                    <strong>Invester Recipt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Recipt- 
                    <asp:TextBox ID="TextBox24" runat="server" Height="21px" Width="92px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button10" runat="server" onclick="Button10_Click" 
                        style="font-weight: 700" Text="SEARCH" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style116" bgcolor="#FFCCFF">
                    INV. ID</td>
                <td class="style55" bgcolor="#FFCCFF">
                    <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style82" bgcolor="#FFCCFF" colspan="3">
                    NAME</td>
                <td class="style57" colspan="3" bgcolor="#FFCCFF">
                    <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style125" bgcolor="#FFCCFF">
                    DATE</td>
                <td class="style28" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox15" runat="server" Height="23px" Width="107px"></asp:TextBox>
                    </td>
                <td class="style131" bgcolor="#FFCCFF">
                    <strong>AMOUNT</strong></td>
                <td class="style32" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox16" runat="server" Height="25px" Width="97px"></asp:TextBox>
                    </td>
                <td class="style129" bgcolor="#FFCCFF">
                    <strong>TYPE </strong>
                    </td>
                <td class="style67" bgcolor="#FFCCFF">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="22px" Width="87px">
                        <asp:ListItem>--SELECT----</asp:ListItem>
                        <asp:ListItem style="color:green;">RECEIVE</asp:ListItem>
                        <asp:ListItem style="color:red;">RETURN</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="style133" bgcolor="#FFCCFF">
                    </td>
                <td class="style69" bgcolor="#FFCCFF">
                    </td>
            </tr>
            <tr>
                <td class="style125" bgcolor="#FFCCFF">
                    PAYMENT MODE</td>
                <td class="style28" bgcolor="#FFCCFF">
                    <asp:RadioButton ID="RadioButton5" runat="server" CssClass="style4" 
                        Text="CASH" GroupName="A" AutoPostBack="True" oncheckedchanged="RadioButton5_CheckedChanged" 
                        />
                </td>
                <td class="style131" bgcolor="#FFCCFF">
                    <asp:RadioButton ID="RadioButton6" runat="server" CssClass="style4" 
                        Text="CHEQUE" GroupName="A" AutoPostBack="True" oncheckedchanged="RadioButton6_CheckedChanged" 
                       />
                </td>
                <td class="style36" colspan="5" bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style59" bgcolor="#FFCCFF" colspan="8">
                    <asp:Panel ID="Panel7" runat="server" Height="37px" Width="327px">
                        <table class="style84">
                            <tr>
                                <td class="style86">
                                    CHEUQE DATE</td>
                                <td class="style86">
                                    <asp:TextBox ID="TextBox17" runat="server" Height="23px" Width="107px"></asp:TextBox>
                                </td>
                                <td class="style86">
                                    <strong>CHEQUE NO.</strong></td>
                                <td>
                                     <asp:TextBox ID="TextBox18" runat="server" Height="25px" Width="91px"></asp:TextBox></td>
                                <td>
                                    <strong>REF.BY</strong></td>
                                <td>
                                     <asp:TextBox ID="TextBox19" runat="server" Height="23px" Width="107px"></asp:TextBox></td>
                                <td>
                                    <strong>STATUS</strong></td>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="93px">
                                        <asp:ListItem>---SELECT---</asp:ListItem>
                                        <asp:ListItem >PAID</asp:ListItem>
                                        <asp:ListItem>UNPAID</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
            </tr>
            <tr>
                <td class="style126" bgcolor="#FFCCFF">
                    REASON</td>
                <td class="style3" bgcolor="#FFCCFF" colspan="7">
                    <asp:TextBox ID="TextBox20" runat="server" Height="59px" TextMode="MultiLine" 
                        Width="97%">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style119" bgcolor="#FFCCFF">
                    BROKER</td>
                <td class="style76" bgcolor="#FFCCFF">
                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                    </td>
                <td class="style123" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style78" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style130" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style79" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style134" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td bgcolor="#FFCCFF" class="style76">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style126" bgcolor="#FFCCFF">
                    PAID AMOUNT</td>
                <td class="style3" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox21" runat="server" Height="23px" Width="107px">0</asp:TextBox>
                    </td>
                <td class="style124" bgcolor="#FFCCFF">
                    REASON</td>
                <td class="style6" bgcolor="#FFCCFF" colspan="5">
                    <asp:TextBox ID="TextBox22" runat="server" Height="48px" TextMode="MultiLine" 
                        Width="97%">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style127" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style3" bgcolor="#FFCCFF">
                    <asp:Button ID="Button3" runat="server" Text="SUBMIT" Width="118px" 
                        style="font-weight: 700" onclick="Button3_Click" />
                </td>
                <td class="style9" colspan="4" bgcolor="#FFCCFF">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label36" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="style135" bgcolor="#FFCCFF">
                    <asp:Button ID="Button4" runat="server" Text="DELETE" onclick="Button4_Click" 
                        style="font-weight: 700" />
                </td>
                <td bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
        </table>
        </div>
    </div>

            </asp:Panel>
        </div>
        <div id="countrytabs-3">
            
            <asp:Panel ID="Panel4" runat="server">
            broker
            </asp:Panel>
        </div>
        <div id="countrytabs-4">
           
            <asp:Panel ID="Panel5" runat="server">
             <div style="height:550px;width:100%;">
    
    <div id="r" class="p1">
        <table width="100%" style="font-size:12pt; height: 48%;">
            <tr>
                <td class="style88" colspan="7" style="text-align: center" bgcolor="#000066">
                    Employee&nbsp; Recipt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Recipt-
                    <asp:Label ID="Label16" runat="server" style="font-weight: 700" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style91" bgcolor="#FFCCFF">
                    Emp Reg. No.</td>
                <td class="style92" bgcolor="#FFCCFF">
                    <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style89" bgcolor="#FFCCFF">
                    Name</td>
                <td class="style93" bgcolor="#FFCCFF" colspan="2">
                    <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style94" colspan="2" bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="#FFCCFF" class="style103">
                    Total Paid</td>
                <td bgcolor="#FFCCFF" class="style104">
                    <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                </td>
                <td bgcolor="#FFCCFF" class="style105">
                    Date</td>
                <td bgcolor="#FFCCFF" class="style107">
                    <asp:TextBox ID="TextBox9" runat="server" Height="26px"></asp:TextBox>
                </td>
                <td bgcolor="#FFCCFF" class="style100">
                </td>
                <td bgcolor="#FFCCFF" class="style106" colspan="2">
                </td>
            </tr>
            <tr>
                <td bgcolor="#FFCCFF" class="style95">
                    Payment For</td>
                <td bgcolor="#FFCCFF" class="style108">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="22px" Width="91px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton8" runat="server" >New</asp:LinkButton>
                </td>
                <td bgcolor="#FFCCFF" class="style97">
                    <asp:TextBox ID="TextBox10" runat="server" Height="29px" Width="100px"></asp:TextBox>
                </td>
                <td bgcolor="#FFCCFF" class="style10" colspan="4">
                    <strong>Reason</strong>&nbsp;
                    <asp:TextBox ID="TextBox11" runat="server" Height="52px" TextMode="MultiLine" 
                        Width="358px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style110" bgcolor="#FFCCFF">
                    <strong>Payment Mode</strong></td>
                <td class="style111" bgcolor="#FFCCFF">
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="CASH" 
                        AutoPostBack="True" GroupName="P" 
                       />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton4" runat="server" Text="CHEQUE" 
                        AutoPostBack="True" GroupName="P" 
                        />
                </td>
                <td class="style112" colspan="4" bgcolor="#FFCCFF">
                    <asp:Label ID="Label31" runat="server" Text="Type"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </td>
                <td class="style16" bgcolor="#FFCCFF" rowspan="3">
                    <asp:Panel ID="Panel6" runat="server" Height="122px">
                        <table class="style113">
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    Add Payment For</td>
                            </tr>
                            <tr>
                                <td class="style114">
                                    Pay For</td>
                                <td>
                                    <asp:TextBox ID="TextBox14" runat="server" Height="28px" Width="75px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style114">
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="Button5" runat="server" Text="Add" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style114" colspan="2">
                                    <asp:Label ID="Label32" runat="server" ForeColor="Red" style="font-weight: 700" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td bgcolor="#FFCCFF" class="style110">
                    <strong>Amount</strong></td>
                <td bgcolor="#FFCCFF" class="style111">
                    <asp:TextBox ID="TextBox13" runat="server" Height="27px"></asp:TextBox>
                </td>
                <td bgcolor="#FFCCFF" class="style9" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="#FFCCFF" class="style110">
                    &nbsp;</td>
                <td bgcolor="#FFCCFF" class="style111">
                    <asp:Button ID="Button7" runat="server" 
                        style="font-weight: 700" Text="Submit" Width="86px" />
                </td>
                <td bgcolor="#FFCCFF" class="style9" colspan="4">
                    &nbsp;&nbsp;<asp:Button ID="Button6" runat="server" 
                        style="font-weight: 700" Text="New" Width="49px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label28" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        </div>
    </div>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
