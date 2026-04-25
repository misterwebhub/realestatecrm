<%@ Page Language="C#" AutoEventWireup="true" CodeFile="emical.aspx.cs" Inherits="arazi137ramipur_emical" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 213px;
        }
        .style2
        {
            color: #660033;
            height: 42px;
            font-size: x-large;
        }
        .style3
        {
            height: 53px;
        }
        .style4
        {
            font-weight: bold;
        }
        .style5
        {
            height: 37px;
        }
        .style6
        {
            height: 38px;
        }
        .style9
        {
            width: 160px;
        }
        .style11
        {
            width: 182px;
        }
        .style13
        {
            width: 134px;
        }
        .style15
        {
            width: 165px;
        }
        .style16
        {
            width: 167px;
        }
        .style17
        {
            width: 177px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" style="text-align: center">
                    <strong>CUSTOMER EMI DETAILS</strong></td>
            </tr>
            <tr>
                <td bgcolor="#66FF99" class="style3">
                    <b>CUSTOMER REG.NO.&nbsp;&nbsp;&nbsp;
                    </b>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="style4" Height="27px" 
                        style="font-size: large" Width="141px" ReadOnly="True"></asp:TextBox>
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;
                    </b>
                    <asp:Label ID="Label1" runat="server" style="color: #FF0000; " 
                        Text="Label" CssClass="style4"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#FF99FF" class="style5">
                    <b>ARAZI -&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT.NO -&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT SIZE -
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BOOKING DATE -
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; END DATE&nbsp; -
                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </b></td>
            </tr>
            <tr>
                <td bgcolor="#FFFFCC" class="style6">
                    <strong>NAME  </strong>- <b>
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </b></td>
            </tr>
            <tr>
                <td bgcolor="#CCCCCC">
                    <table class="style1">
                        <tr>
                            <td class="style15">
                    <strong>TOTAL AMOUNT&nbsp;</strong></td>
                            <td class="style16">
                                <b><asp:Label 
                        ID="Label6" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>RECIEVE AMOUNT&nbsp;</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE AMOUNT</b></td>
                            <td class="style13">
                                <b> <asp:Label ID="Label8" runat="server" 
                        Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>DOWN PAYMENT</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label16" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>RECIEVE D.P&nbsp;</b></td>
                            <td class="style17">
                                <b> <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE D.P</b></td>
                            <td class="style13">
                                <b>
                    <asp:Label ID="Label18" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>TOTAL EMI</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label9" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>PAID EMI&nbsp;</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE EMI</b></td>
                            <td class="style13">
                                <b>
                    <asp:Label 
                        ID="Label11" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>TOTAL MONTH EMI</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label20" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>NO. OF PAID EMI</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label21" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
&nbsp;&nbsp; =&nbsp;
                    <asp:Label ID="Label24" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE EMI MONTH</b></td>
                            <td class="style13">
                                <b>
                    <asp:Label 
                        ID="Label22" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>LATE EMI</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label12" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>LATE EMI PAYMENT</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label13" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                &nbsp;</td>
                            <td class="style13">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <strong>FIXED EMI</strong></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label23" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                &nbsp;</td>
                            <td class="style17">
                                &nbsp;</td>
                            <td class="style11">
                                &nbsp;</td>
                            <td class="style13">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>ADVANCE AMOUNT</b></td>
                            <td class="style16">
                                <b> <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <strong>LAST PAID DATE </strong></td>
                            <td class="style17">
                                <asp:Label ID="Label25" 
            runat="server" Text="Label"></asp:Label></td>
                            <td class="style11">
                              <strong>AMOUNT </strong></td>
                            <td class="style13">
                                 <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </table>
                    <b>&nbsp;</b><br />
                </td>
            </tr>
        </table>
    
    </div>
    
   
    </form>
</body>
</html>
