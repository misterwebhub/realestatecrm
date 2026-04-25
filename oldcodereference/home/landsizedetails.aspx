<%@ Page Language="C#" AutoEventWireup="true" CodeFile="landsizedetails.aspx.cs" Inherits="kishan_landsizedetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 81px;
        }
        .style2
        {
            color: #FFFFCC;
            height: 40px;
        }
        .style3
        {
            height: 43px;
        }
        .style4
        {
            height: 84px;
        }
        .style7
        {
            height: 80px;
        }
        .style8
        {
            width: 100%;
            height: 55px;
        }
        .style9
        {
            height: 36px;
        }
        .style10
        {
            height: 27px;
        }
        .style11
        {
            height: 29px;
        }
        .style12
        {
            height: 28px;
        }
        .style13
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#003300" class="style2" 
                    style="font-size: x-large; font-weight: 700; text-align: center">
                    ARAZI WISE LAND DETAILS</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" BackColor="#FF9933" Height="30px" 
                        onclick="Button1_Click" style="font-weight: 700; font-size: medium" 
                        Text="NEW ENTRY" Width="167px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" BackColor="#FF66FF" Height="30px" 
                        onclick="Button2_Click" style="font-weight: 700; font-size: medium" 
                        Text="GET DETAILS" Width="147px" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Panel ID="Panel1" runat="server" BackColor="#FF9933" Height="86px">
                        <table class="style1">
                            <tr>
                                <td bgcolor="#99FF66">
                                    <b>ARAZI NO</b></td>
                                <td bgcolor="#99FF66">
                                    <b>KISHAN NAME</b></td>
                                <td bgcolor="#99FF66">
                                    <b>TOTAL LAND SIZE (BEEGHA)</b></td>
                                <td bgcolor="#99FF66">
                                    <b>SALE LAND</b></td>
                                <td bgcolor="#99FF66">
                                    <b>SALE RATE</b></td>
                                <td bgcolor="#99FF66">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="93px" 
                                        AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem>----SELECT----</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Height="28px" 
                                        Width="135px">
                                    </asp:DropDownList>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Height="29px" Width="126px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" Height="29px" Width="87px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server" Height="29px" Width="90px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Height="29px" onclick="Button3_Click" 
                                        style="font-weight: 700" Text="SUBMIT" Width="85px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Panel ID="Panel2" runat="server" BackColor="#CCFFCC" Height="126px" 
                        style="margin-top:0px;">
                        <table class="style8">
                            <tr>
                                <td class="style9">
                                    &nbsp;<strong>ARAZI NO&nbsp; </strong>&nbsp; &nbsp;<asp:DropDownList ID="DropDownList3" 
                                        runat="server" Height="26px" Width="100px" AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>KISHAN NAME </strong>&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="DropDownList4" runat="server" Height="26px" Width="97px">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button4" runat="server" BackColor="#FF99CC" 
                                        style="font-weight: 700" Text="VIEW" Width="99px" 
                                        onclick="Button4_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button5" runat="server" BackColor="#00FF99" Height="26px" 
                                        style="font-weight: 700" Text="ALL ARAZI  DETAILS " Width="160px" 
                                        onclick="Button5_Click1" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label5" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Panel ID="Panel3" runat="server" BackColor="#FF9933" Height="86px">
                                        <table class="style1">
                                            <tr>
                                                <td bgcolor="#99FF66">
                                                    <b>ARAZI NO</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>KISHAN NAME</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>TOTAL LAND SIZE(BEEGHA)</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>PURCHASE RATE</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SALE LAND</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SALE RATE</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SOLD LAND</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SOLD AMOUNT</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>BALANCE LAND</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>BALANCE LAND AMOUNT</b></td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    &nbsp;&nbsp;<asp:Label ID="Label8" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label9" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label10" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label11" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#660033"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label12" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#660033"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label13" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#006600"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label14" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#006600"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    <asp:Label ID="Label15" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                                <td bgcolor="White">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label16" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="Red"></asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                                    <asp:Panel ID="Panel4" runat="server" BackColor="#FF9933" 
                        Height="288px">
                                        <table class="style1">
                                            <tr>
                                                <td bgcolor="#99FF66">
                                                    <b>ARAZI NO</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>KISHAN NAME</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>TOTAL LAND SIZE(BEEGHA)</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>PURCHASE RATE</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SALE LAND</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SALE RATE</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SOLD LAND</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>SOLD AMOUNT</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>BALANCE LAND</b></td>
                                                <td bgcolor="#99FF66">
                                                    <b>BALANCE LAND AMOUNT</b></td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label18" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label19" runat="server" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label20" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label21" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label22" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#660033"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label23" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#660033"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label24" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#006600"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label25" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="#006600"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    <asp:Label ID="Label26" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style10">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label27" runat="server" style="font-weight: 700" Text="Label" 
                                                        ForeColor="Red"></asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label28" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label29" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label30" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label31" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label32" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label33" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label34" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label35" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label36" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label37" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label38" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label39" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label40" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label41" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label42" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label43" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label44" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label45" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label46" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label47" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label48" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label49" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label50" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label51" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label52" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label53" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label54" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label55" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label56" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label57" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label58" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label59" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label60" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label61" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label62" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label63" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label64" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label65" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label66" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label67" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label68" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label69" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label70" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label71" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label72" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label73" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label74" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label75" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    <asp:Label ID="Label76" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style12">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label77" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label78" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label79" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label80" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label81" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label82" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label83" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label84" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label85" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    <asp:Label ID="Label86" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style11">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label87" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label88" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label89" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label90" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label91" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label92" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label93" runat="server" ForeColor="#660033" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label94" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label95" runat="server" ForeColor="#006600" 
                                                        style="font-weight: 700" Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    <asp:Label ID="Label96" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                                <td bgcolor="White" class="style13">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label97" runat="server" ForeColor="Red" style="font-weight: 700" 
                                                        Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
