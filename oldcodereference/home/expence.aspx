<%@ Page Language="C#" AutoEventWireup="true" CodeFile="expence.aspx.cs" Inherits="expence" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
     <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   
    <script type="text/javascript">
        $(document).ready(function () {
            $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: "expence.aspx/GetAutoCompleteData",
                        data: "{'username':'" + document.getElementById('TextBox1').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert(result);
                        }
                    });
                }
            });
            $(".autosuggest1").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: "expence.aspx/GetAutoCompleteData",
                        data: "{'username':'" + document.getElementById('TextBox5').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert(result);
                        }
                    });
                }
            });
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
            $(".t15").datepicker({
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
            height: 71px;
            margin-top: 0px;
            font-size: small;
            font-weight: 700;
        }
        .style2
        {
            font-weight: bold;
        }
        .style3
        {
            text-align: center;
        }
        .style4
        {
            height: 43px;
            font-size: x-large;
        }
        .style9
        {
            text-align: center;
            font-size: large;
        }
        .style12
        {
            width: 3%;
        }
        .style14
        {
            width: 5%;
        }
        .style15
        {
            width: 10%;
            text-align: left;
        }
        .style16
        {
            height: 43px;
            font-size: medium;
            color: #FFFFFF;
        }
        .style17
        {
            width: 46px;
            height: 25px;
        }
        .style18
        {
            text-align: center;
            height: 36px;
        }
        .style19
        {
            height: 25px;
        }
        .style20
        {
            height: 25px;
            width: 61px;
        }
        .style21
        {
            height: 25px;
            width: 62px;
        }
        .style22
        {
            width: 59px;
            height: 25px;
        }
        .style23
        {
            width: 615px;
        }
        .style24
        {
            width: 100%;
        }
        .style26
        {
            color: #FFFFFF;
            text-align: right;
            height: 47px;
        }
        .style27
        {
            text-align: right;
            height: 47px;
        }
        .style29
        {
            font-size: medium;
        }
        .style33
        {
            color: #FFFFFF;
        }
        .autosuggest
        {}
        .style38
        {
            width: 3%;
            height: 33px;
            text-align: left;
        }
        .style39
        {
            width: 9%;
            height: 33px;
            font-size: medium;
            text-align: left;
        }
        .style42
        {
            width: 10%;
            height: 33px;
            text-align: left;
        }
        .style51
        {
            width: 5%;
            height: 33px;
            font-size: medium;
            text-align: left;
        }
        .style52
        {
            width: 9%;
            height: 33px;
            text-align: left;
        }
        .style53
        {
            width: 9%;
            text-align: left;
        }
        .style55
        {
            width: 7%;
            height: 33px;
            text-align: left;
        }
        .style56
        {
            width: 7%;
            text-align: left;
        }
        .style57
        {
            width: 4%;
            height: 33px;
            text-align: left;
        }
        .style58
        {
            width: 4%;
        }
        .style61
        {
            width: 8%;
            height: 33px;
            font-size: medium;
            text-align: left;
        }
        .style62
        {
            width: 8%;
            text-align: left;
        }
        .style63
        {
            width: 2%;
            height: 33px;
            text-align: left;
        }
        .style64
        {
            width: 2%;
        }
        .style67
        {
            width: 3%;
            height: 33px;
            font-size: medium;
            text-align: left;
        }
        .style70
        {
            width: 80px;
        }
        .style73
        {
            width: 165px;
        }
        .style74
        {
            width: 118px;
        }
        .style75
        {
            width: 59px;
        }
        .style76
        {
            width: 179px;
        }
        .style77
        {
            width: 10%;
            height: 33px;
            font-size: medium;
            text-align: left;
        }
        .style78
        {
            height: 51px;
            font-size: medium;
            color: #FFFFFF;
        }
        .style79
        {
            height: 47px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;">

    
        <table class="style1">
            <tr>
                <td colspan="2" style="text-align: center" bgcolor="#660033" class="style16">
                    <strong>EXPENCE DETAILS</strong></td>
            </tr>
            <tr>
                <td bgcolor="Aqua" class="style23">
                    <asp:Button ID="Button1" runat="server" BackColor="Lime" 
                        BorderColor="#003300" BorderStyle="Dashed" CssClass="style2" ForeColor="Maroon" 
                        onclick="Button1_Click" style="margin-left: 96px" Text="CREDIT AMOUNT ( + )" 
                        Width="205px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button8" runat="server" BackColor="#6666FF" 
                        BorderStyle="Dashed" onclick="Button8_Click" style="font-weight: 700" 
                        Text="EDIT EXPENSE" Width="118px" />
                &nbsp;&nbsp;
                    <asp:Button ID="Button11" runat="server" BackColor="#333300" 
                        BorderStyle="Dashed" ForeColor="White" style="font-weight: 700" 
                        Text="DATE WISE SEARCH" Width="148px" onclick="Button11_Click1" />
                </td>
                <td bgcolor="Aqua">
                    <asp:Button ID="Button2" runat="server" BackColor="#FF3300" 
                        BorderColor="#003300" BorderStyle="Dashed" CssClass="style2" ForeColor="Maroon" 
                        onclick="Button2_Click" style="margin-left: 64px" Text="DEBIT AMOUNT ( - )" 
                        Width="163px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                        style="font-weight: 700" Text="Get all details" Width="100px" 
                        BackColor="#99FF66" BorderStyle="Dashed" />
                </td>
            </tr>
            <tr><td colspan="2" bgcolor="#99FF66">
            <strong style="text-align: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    Total Debit(-)&nbsp;&nbsp;
                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Credit (+)&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label5" runat="server" style="font-weight: 700"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    Total Balance Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" style="font-weight: 700"></asp:Label>
                    &nbsp;
                    </strong>
                </td>
           </tr>
            <tr>
                <td colspan="2" style="text-align: center"  class="style4">
                    <asp:Panel ID="Panel1" runat="server" BackColor="Lime" Height="117px" 
                        Visible="False" BorderStyle="Solid">
                        <table class="style1">
                            <tr>
                                <td class="style9" colspan="10">
                                    <strong>CREDIT AMOUNT</strong></td>
                                <td class="style9">
                                    &nbsp;</td>
                            </tr>
                            <tr style="font-size: small; font-weight: 700;">
                                <td class="style67">
                                    &nbsp;Type</td>
                                <td class="style55">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" Width="104px" 
                                        AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem>---Select---</asp:ListItem>
                                        <asp:ListItem>Customer Payment</asp:ListItem>
                                        <asp:ListItem>Invester Payment</asp:ListItem>
                                        <asp:ListItem>Other Payment</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            
                                <td class="style77">
                                    <span class="style29">
                                    <asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True" 
                                        Height="25px" onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                                        Width="99px">
                                        <asp:ListItem>---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                    </span>Reg. No.</td>
                                <td class="style52">
                                    <asp:TextBox ID="TextBox22" runat="server" Height="27px" Width="101px"></asp:TextBox>
                                </td>
                           
                                <td class="style57">
                                    <asp:Button ID="Button17" runat="server" Height="26px" style="font-weight: 700" 
                                        Text="Search" Width="63px" onclick="Button17_Click" />
                                    </td>
                                <td class="style39">
                                    Arazi No.&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                </td>
                            
                                <td class="style51">
                                    Name</td>
                                <td class="style42">
                                    <asp:Label ID="Label10" runat="server" style="font-size: medium" Text="Label"></asp:Label>
                                </td>
                            
                                <td class="style61">
                                   
                                    Plot. No&nbsp;
                                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                   
                                </td>
                                <td class="style63">
                                    CREDIT FROM</td>
                            
                                
                                <td class="style38">
                                    <asp:Label ID="Label13" runat="server" style="font-size: medium" Text="Label"></asp:Label>
                                </td>
                            
                                
                            </tr>
                            <tr style="font-size: small; font-weight: 700;">
                                <td class="style12">
                                    DATE</td>
                                <td class="style56">
                                    <asp:TextBox ID="TextBox2" runat="server" class="txt1" Height="23px" 
                                        Width="102px"></asp:TextBox>
                                </td>
                                <td class="style15">
                                    <span class="style29">Mode</span><br />
                                    <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" GroupName="O" oncheckedchanged="RadioButton1_CheckedChanged" 
                                        Text="CASH" />
                                    <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" GroupName="O" oncheckedchanged="RadioButton2_CheckedChanged" 
                                        Text="CHEQUE" />
                                </td>
                                <td class="style53">
                                    <asp:Label ID="Label14" runat="server" style="font-size: medium" Text="Label"></asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox23" runat="server" Height="28px" Width="82px"></asp:TextBox>
                                </td>
                                <td class="style58">
                                    AMOUNT</td>
                                <td class="style53">
                                    <asp:TextBox ID="TextBox3" runat="server" Height="27px" Width="117px" 
                                        style="text-align: left"></asp:TextBox>
                                </td>
                                <td class="style14">
                                    REASON</td>
                                <td class="style15">
                                    <asp:TextBox ID="TextBox4" runat="server" Height="41px" TextMode="MultiLine" 
                                        Width="162px"></asp:TextBox>
                                </td>
                                <td class="style62">
                                    <asp:Button ID="Button3" runat="server" Font-Size="Small" 
                                        onclick="Button3_Click" style="font-weight: 700" Text="SUBMIT" Width="83px" />
                                </td>
                                <td class="style64">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#003399" 
                                        style="font-weight: 700" Text="Label"></asp:Label>
                                </td>
                                <td class="style12">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                   </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel2" runat="server" BackColor="RED" Height="157px" 
                        Visible="False" BorderStyle="Solid">
                        <table class="style1" border="1">
                            <tr>
                                <td class="style3" colspan="11">
                                    <strong style="font-size: large">DEBIT AMOUNT</strong></td>
                            </tr>
                            <tr>
                                <td class="style29" colspan="6">
                                    <asp:Panel ID="Panel5" runat="server" BackColor="#99CCFF" Height="32px" 
                                        Width="348px">
                                        Type&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Button19" runat="server" Text="ADD" onclick="Button19_Click" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                                    </asp:Panel>
                                </td>
                            
                                <td colspan="3">
                                    <asp:Panel ID="Panel6" runat="server" BackColor="Lime" Height="32px">
                                        Name -
                                        <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button20" runat="server" onclick="Button20_Click" Text="ADD" />
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                                    </asp:Panel>
                                </td>
                                <td class="style75">
                                  
                                        &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style29">
                                    Type</td>
                                <td class="style70">
                                    <asp:DropDownList ID="DropDownList2" runat="server" Height="28px" Width="89px" style="Text-align:left;"
                                        AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                        <asp:ListItem>---SELECT---</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style76">
                                    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CssClass="style29" 
                                        onclick="LinkButton1_Click">New</asp:LinkButton>
                                    <span class="style29">&nbsp;Select<asp:DropDownList ID="DropDownList3" 
                                        runat="server" Height="23px" Width="87px" AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                                        <asp:ListItem>---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                    </span></td>
                                <td class="style73">
                                    &nbsp;<asp:Label ID="Label21" runat="server" style="font-size: medium" Text="Label"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox26" runat="server" Height="28px" Width="94px"></asp:TextBox>
                                    <asp:DropDownList ID="DropDownList4" runat="server" Height="16px">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">New</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Button ID="Button18" runat="server" Height="26px" onclick="Button18_Click" 
                                        style="font-weight: 700" Text="Search" Width="63px" />
                                </td>
                                <td>
                                    Arazi No.&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label15" runat="server" Text="Label" ForeColor="Yellow"></asp:Label>
                                </td>
                                <td>
                                    Name</td>
                                <td class="style73">
                                    <asp:Label ID="Label16" runat="server" style="font-size: medium" Text="Label" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style74">
                                    Plot. No&nbsp;&nbsp;
                                    <asp:Label ID="Label17" runat="server" Text="Label" ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style75">
                                    DEBIT TO</td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" style="font-size: medium" Text="Label" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    DATE</td>
                                <td class="style70">
                                    <asp:TextBox ID="TextBox6" runat="server" class="txt2" Height="21px" 
                                        Width="89px"></asp:TextBox>
                                </td>
                                <td class="style76">
                                    <span class="style29">Mode<br />
                                    <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" GroupName="O" oncheckedchanged="RadioButton3_CheckedChanged" 
                                        Text="CASH" />
                                    &nbsp;
                                    <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" GroupName="O" oncheckedchanged="RadioButton4_CheckedChanged" 
                                        Text="CHEQUE" />
                                    </span>
                                </td>
                                <td class="style73">
                                    <asp:Label ID="Label19" runat="server" style="font-size: medium" Text="Label"></asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox24" runat="server" Height="28px" Width="68px"></asp:TextBox>
                                </td>
                                <td>
                                    AMOUNT</td>
                                <td>
                                    <asp:TextBox ID="TextBox7" runat="server" Height="24px" Width="119px"></asp:TextBox>
                                </td>
                                <td>
                                    REASON</td>
                                <td class="style73">
                                    <asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine" Width="160px"></asp:TextBox>
                                </td>
                                <td class="style74">
                                    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                                        style="font-weight: 700" Text="DEBIT AMOUNT" Width="117px" />
                                </td>
                                <td class="style75">
                                    <asp:Label ID="Label3" runat="server" ForeColor="GREEN" 
                                        style="font-weight: 700" Text="Label"></asp:Label>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr><td colspan="2">
                    <asp:Panel ID="Panel3" runat="server" BackColor="#669900" Height="91px" 
                        Visible="False" BorderStyle="Solid">
                        <table class="style1">
                            <tr>
                                <td class="style18" colspan="13">
                                    <strong style="font-size: large">UPDATE/DELETE AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ENTER ID </strong>
                                    <asp:TextBox ID="TextBox13" runat="server" Width="86px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button9" runat="server" onclick="Button9_Click" 
                                        style="font-weight: 700" Text="SEARCH" Width="73px" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    NAME</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox9" runat="server" Height="20px" Width="156px"></asp:TextBox>
                                </td>
                            
                                <td class="style19">
                                    DATE</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox10" runat="server" Width="103px" class="txt2"></asp:TextBox>
                                </td>
                           
                                <td class="style20">
                                    DEBIT AMOUNT</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox11" runat="server" Width="107px"></asp:TextBox>
                                    &nbsp;
                                </td>
                            
                                <td class="style21">
                                    CREDIT AMOUNT
                                </td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox14" runat="server" Width="97px"></asp:TextBox>
                                </td>
                                <td class="style22">
                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                </td>
                            
                                <td class="style19">
                                    REASON</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox12" runat="server" TextMode="MultiLine" Width="191px"></asp:TextBox>
                                </td>
                            
                                <td class="style19">
                                      <asp:Button ID="Button14" runat="server" onclick="Button14_Click" 
                                          style="font-weight: 700" Text="Update" />
                                </td>
                                <td class="style19">
                                  
                                        <asp:Button ID="Button10" runat="server" Height="26px" onclick="Button10_Click" 
                                            style="font-weight: 700" Text="DELETE" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td></tr>
                <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel4" runat="server" BackColor="#000066" Visible="False" 
                        BorderStyle="Solid">
                        <table class="style24">
                            <tr>
                                <td class="style78" colspan="5" style="text-align: left" bgcolor="#660033">
                                    DATE FROM
                                    <asp:TextBox ID="TextBox28" runat="server" class="t15" 
                                        style="margin-left: 2px" Width="144px"></asp:TextBox>
                                    &nbsp; DATE TILL&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox29" runat="server" class="t15" 
                                        style="margin-left: 5px" Width="135px"></asp:TextBox>
                                    &nbsp; <span class="style33">&nbsp;&nbsp;&nbsp;&nbsp;TYPE</span>&nbsp;&nbsp;
                                    <asp:DropDownList ID="DropDownList9" runat="server" 
                                        Height="22px" onselectedindexchanged="DropDownList9_SelectedIndexChanged" 
                                        Width="112px" AutoPostBack="True">
                                    </asp:DropDownList>
                                    &nbsp; &nbsp;<asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" 
                                        Height="23px" onselectedindexchanged="DropDownList6_SelectedIndexChanged" 
                                        Width="80px">
                                    </asp:DropDownList>
&nbsp;
                                    <asp:Button ID="Button21" runat="server" onclick="Button21_Click" 
                                        style="font-weight: 700" Text="TYPE WISE" Width="86px" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Button22" runat="server" onclick="Button22_Click" 
                                        style="font-weight: 700" Text="ALL DETTAILS" Width="110px" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label23" runat="server" ForeColor="Yellow"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style27" style="color: #FFFFFF" bgcolor="#003300">
                                    DATE FROM</td>
                                <td style="color: #FFFFFF" bgcolor="#003300" class="style79">
                                    <asp:TextBox ID="TextBox15" runat="server" style="margin-left: 22px" 
                                        Width="144px" class="t15"></asp:TextBox>
                                </td>
                                <td class="style26" bgcolor="#003300">
                                    DATE TILL</td>
                                <td bgcolor="#003300" class="style79">
                                    <asp:TextBox ID="TextBox16" runat="server" style="margin-left: 23px" 
                                        Width="135px" class="t15"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style33">TYPE</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" 
                                        Height="22px" onselectedindexchanged="DropDownList5_SelectedIndexChanged" 
                                        Width="112px">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp; <span class="style33">Name </span>&nbsp;<asp:DropDownList ID="DropDownList6" 
                                        runat="server" Height="23px" Width="80px" AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList6_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style33">Value</span>&nbsp;
                                    <asp:DropDownList ID="DropDownList7" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button12" runat="server" onclick="Button12_Click" 
                                        style="font-weight: 700" Text="SEARCH" Width="86px" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label8" runat="server" ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style79">
                                    </td>
                            </tr>
                        </table>
                   
                   
                   
                    </asp:Panel>
                </td>
                </tr>
            <tr>

                <td colspan="2">
                    <br />
                     <asp:GridView ID="GridView2" runat="server" Width="100%" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Horizontal" 
                        style="font-size:12pt;border:1px solid black;text-align:left;" AutoGenerateColumns="False" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged1" onrowdatabound="GridView2_RowDataBound" 
                       >
                        <AlternatingRowStyle />
                        <Columns>
                        <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Type</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id8" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Reg.No</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id9" runat="server" Text='<%# Eval("regno") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Name</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id10" runat="server" Text='<%# Eval("upname") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
 <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Arai No.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id11" runat="server" Text='<%# Eval("arazino") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Plot No</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id12" runat="server" Text='<%# Eval("plotno") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Boker</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id13" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>




                  
                

                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>Date</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Mode</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id14" runat="server" Text='<%# Eval("mode") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>Cheque No</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id15" runat="server" Text='<%# Eval("chequeno") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>Debit Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="damount1" runat="server" Text='<%# Eval("damount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>Credit Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("camount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="120px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="40">
                  <HeaderTemplate>Status</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cstatus1" runat="server" Text='<%# Eval("cstatus") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>Reason</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("creson") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
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
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                                    
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>

    
    </div>
    
    </form>
</body>
</html>
