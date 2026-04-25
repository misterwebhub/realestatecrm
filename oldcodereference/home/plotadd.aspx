<%@ Page Language="C#" AutoEventWireup="true" CodeFile="plotadd.aspx.cs" Inherits="plotadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            height: 41px;
        }
        .style4
        {
            width: 228px;
            height: 41px;
        }
        .style5
        {
            height: 38px;
        }
        .style6
        {
            width: 228px;
            height: 38px;
        }
        .style7
        {
            height: 36px;
            text-align: left;
        }
        .style8
        {
            width: 228px;
            height: 36px;
        }
        .style9
        {
            height: 41px;
            width: 280px;
            color: #FF0000;
        }
        .style11
        {
            height: 36px;
            text-align: left;
            width: 280px;
            color: #FF0000;
        }
        .style13
        {
            height: 41px;
            width: 261px;
        }
        .style14
        {
            height: 38px;
            width: 329px;
            color: #FF0000;
        }
        .style15
        {
            height: 36px;
            text-align: left;
            width: 329px;
            color: #FF0000;
        }
        .style17
        {
            height: 39px;
            width: 280px;
            color: #FF0000;
        }
        .style18
        {
            width: 228px;
            height: 39px;
        }
        .style19
        {
            height: 39px;
            width: 329px;
        }
        .style20
        {
            height: 39px;
        }
        .style21
        {
            height: 35px;
            color: #FF0000;
        }
        .style22
        {
            width: 228px;
            height: 35px;
        }
        .style23
        {
            width: 329px;
            height: 35px;
            color: #FF0000;
        }
        .style24
        {
            height: 35px;
        }
        .style29
        {
            height: 60px;
        }
        .style30
        {
            width: 216px;
            height: 41px;
            color: #FF0000;
        }
        .style31
        {
            color: #000000;
        }
        .style32
        {
            height: 38px;
            color: #FF0000;
        }
        </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   
</head>
<body bgcolor="White" style="font-weight: 700">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" border="2">
            <tr>
                <td colspan="4" style="text-align: center" class="style29">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="21pt" 
                        ForeColor="#660033" style="text-align: center" 
                        Text="Plot &amp; Arazi Add Form"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9" style="text-align: left">
                    ARAZI NUMBER</td>
                <td class="style4">
                    <asp:TextBox ID="TextBox1" runat="server"  Width="191px" 
                        CssClass="style31"></asp:TextBox>
                </td>
                <td class="style30">
                    &nbsp;</td>
                <td class="style13">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style32" style="text-align: left">
                    LOCATION</td>
                <td class="style6">
                    <asp:TextBox ID="TextBox3" runat="server" Width="191px" 
                        style="margin-left: 0px" CssClass="style31"></asp:TextBox>
                </td>
                <td class="style14" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    KISHAN NAME</td>
                <td class="style8">
                    <span class="style31">&nbsp;</span><asp:TextBox ID="TextBox5" runat="server"  Width="189px" 
                        style="margin-left: 0px"></asp:TextBox>
                </td>
                <td class="style15" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style17">
                    BROKER NAME</td>
                <td class="style18">
                    <asp:TextBox ID="TextBox6" runat="server" Width="188px"></asp:TextBox>
                </td>
                <td class="style19" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style21">
                    &nbsp;</td>
                <td class="style22">
                    <asp:Button ID="Button1" runat="server" Text="ADD DETAILS" Width="187px" 
                        onclick="Button1_Click" style="font-weight: 700" />
                </td>
                <td class="style23" colspan="2">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style21" colspan="4">
                    &nbsp;</td>
            </tr>
            
          
        </table>
    
    </div>
    </form>
</body>
</html>

