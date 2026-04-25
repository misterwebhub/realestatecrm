<%@ Page Language="C#" AutoEventWireup="true" CodeFile="partnerpaidbal.aspx.cs" Inherits="kishan_partnerpaidbal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: x-large;
            text-align: center;
            color: #FFFFFF;
            height: 44px;
        }
        .style3
        {
            height: 52px;
        }
        .style4
        {
            font-size: large;
        }
        .style5
        {
            height: 28px;
            font-weight: bold;
            font-size: large;
        }
        .style6
        {
            height: 32px;
        }
        .style7
        {
            height: 33px;
        }
        .style8
        {
            height: 32px;
            font-weight: bold;
        }
        .style9
        {
            height: 33px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="4" bgcolor="Maroon">
                    <strong>Partner Paid Balance Amount</strong></td>
            </tr>
            <tr>
                <td bgcolor="#CC99FF" class="style3" colspan="4">
                    <strong><span class="style4">Month From -&nbsp;&nbsp; </span>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="style4" Height="31px" 
                        Width="45px"></asp:TextBox>
                    <span class="style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Month To - </span>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="style4" Height="31px" 
                        Width="45px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Year&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Height="31px" Width="75px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                    <asp:Button ID="Button1" runat="server" Height="28px" onclick="Button1_Click" 
                        style="font-weight: 700; font-size: large" Text="View" Width="86px" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF33" class="style5">
                    Month Name</td>
                <td bgcolor="#CCFF33" class="style5">
                    Total Amount</td>
                <td bgcolor="#CCFF33" class="style5">
                    Paid Amount</td>
                <td bgcolor="#CCFF33" class="style5">
                    Balance Amount</td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    JANUARY</td>
                <td class="style6">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    FEBRUARY</td>
                <td class="style6">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    MARCH</td>
                <td class="style6">
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label8" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    APRIL</td>
                <td class="style6">
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label11" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label12" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    MAY</td>
                <td class="style6">
                    <asp:Label ID="Label13" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label14" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label15" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style9">
                    JUNE</td>
                <td class="style7">
                    <asp:Label ID="Label16" runat="server"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="Label17" runat="server"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="Label18" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    JULY</td>
                <td class="style6">
                    <asp:Label ID="Label19" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label20" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label21" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    AUGUST</td>
                <td class="style6">
                    <asp:Label ID="Label22" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label23" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label24" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    SEPTEMBER</td>
                <td class="style6">
                    <asp:Label ID="Label25" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label26" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label27" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    OCTOBER</td>
                <td class="style6">
                    <asp:Label ID="Label28" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label29" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label30" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    NOVEMBER</td>
                <td class="style6">
                    <asp:Label ID="Label31" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label32" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label33" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CCFF99" class="style8">
                    DECEMBER</td>
                <td class="style6">
                    <asp:Label ID="Label34" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label35" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label36" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
