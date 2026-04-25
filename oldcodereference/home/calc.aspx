<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calc.aspx.cs" Inherits="_30neeghanew_calc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 184px;
            text-align: right;
        }
        .style2
        {
            width: 184px;
            font-weight: bold;
            font-size: medium;
            text-align: left;
        }
        .style3
        {
            font-weight: bold;
            font-size: medium;
            
        }
         .style15
        {
            font-weight: bold;
            font-size: medium;
            text-align:right;
            
        }
        .style4
        {
            font-size: x-large;
        }
        .style5
        {
            width: 346px;
        }
        .style6
        {
            width: 184px;
            text-align: left;
        }
        .style16
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:600px;width:90%;background-color:#F4F6F6;border:1px solid smoke;box-shadow:0px 0px 10px black;margin-left:5%;margin-top:30px;">
    <div style="TEXT-ALIGN:center;PADDING:10PX;BACKGROUND-COLOR:Maroon;FONT-SIZE:20PT;COLOR:White;FONT-WEIGHT:bolder;">PLOT RATE CALCULATOR &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="AREACAL.aspx" target="_blank" style="text-decoration:none;color:white;">PLOT AREA CALCULATOR</a></div>
    <br /><div style="height:520px;">
            <table style="height:100%;width:100%;">
                <tr>
                    <td class="style2">
                        Arazi </td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="128px" 
                           >
                        </asp:DropDownList>
                    </td>
                    <td>
                        <b>10% Commission</b></td>
                    <td>
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox14_TextChanged" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Purchase Land Value</td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox3_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <b>Final Land Value</b></td>
                    <td>
                        <asp:TextBox ID="TextBox15" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" ReadOnly=true></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Stamp Value</td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox4_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <b>Final+10% comm</b></td>
                    <td>
                        <asp:TextBox ID="TextBox16" runat="server" CssClass="style3" Height="25px" 
                            TextMode="Number" Width="92px" ReadOnly=true></asp:TextBox>
                    &nbsp;<span class="style4"><b>/
                        </b>
                        <asp:TextBox ID="TextBox17" runat="server" CssClass="style3" Height="27px" 
                            TextMode="Number" Width="91px" AutoPostBack="True" 
                            ontextchanged="TextBox17_TextChanged"></asp:TextBox>
                        <b>Gz</b></span></td>
                </tr>
                <tr>
                    <td class="style2">
                        Ragistry Fees</td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox5_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <b>Rate</b></td>
                    <td>
                        &nbsp;<asp:TextBox ID="TextBox18" runat="server" 
                            CssClass="style15" Height="23px" 
                            TextMode="Number" Width="210px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Ragistry Commission</td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox6_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <b>Input Rate</b></td>
                    <td>
                        <asp:TextBox ID="TextBox19" runat="server" AutoPostBack="True" Height="24px" 
                            ontextchanged="TextBox19_TextChanged" TextMode="Number" Width="78px" 
                            CssClass="style16"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Broker Commission</td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox7_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <b>Total Value</b></td>
                    <td>
                        <asp:TextBox ID="TextBox20" runat="server" Height="21px" ReadOnly="True" 
                            Width="161px" CssClass="style16"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Site Maintinance Value</td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox8_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <b>Profit Amt</b></td>
                    <td>
                        <asp:TextBox ID="TextBox21" runat="server" Height="21px" ReadOnly="True" 
                            Width="103px" CssClass="style16"></asp:TextBox>
                        <b>&nbsp;/
                        </b>
                        <asp:TextBox ID="TextBox22" runat="server" Height="26px" ReadOnly="True" 
                            Width="75px" CssClass="style16"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="style3" Height="22px" 
                            Width="182px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox9_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="style3" Height="22px" 
                            Width="182px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="style3" Height="24px" 
                            TextMode="Number" Width="129px" AutoPostBack="True" 
                            ontextchanged="TextBox10_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Clear" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Invest Value</td>
                    <td class="style5">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox11" runat="server" AutoPostBack="True" 
                            CssClass="style3" Height="24px" ontextchanged="TextBox11_TextChanged" 
                            TextMode="Number" Width="129px"></asp:TextBox>
&nbsp;<span class="style4">x 2</span> =
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="style3" Height="24px" 
                            ReadOnly="True" Width="115px" ></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
