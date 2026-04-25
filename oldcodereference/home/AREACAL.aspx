<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AREACAL.aspx.cs" Inherits="_37jajmau_AREACAL" %>

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
            color: #FFFFFF;
            height: 47px;
        }
        .style3
        {
            text-align: center;
            font-weight: bold;
            height: 33px;
            color: #FFFFFF;
        }
        .style4
        {
            width: 148px;
        }
        .style6
        {
            width: 148px;
            font-size: large;
            font-weight: bold;
            height: 38px;
        }
        .style7
        {
            height: 38px;
        }
        .style8
        {
            height: 38px;
            width: 60px;
        }
        .style9
        {
            width: 60px;
        }
        .style10
        {
            font-weight: bold;
            font-size: medium;
        }
        .style11
        {
            height: 38px;
            font-weight: bold;
            font-size: medium;
            width: 332px;
        }
        .style14
        {
            height: 38px;
            width: 144px;
            font-size: large;
        }
        .style15
        {
            height: 38px;
            font-size: large;
        }
        .style16
        {
            width: 332px;
        }
        .style17
        {
            height: 38px;
            width: 170px;
        }
        .style18
        {
        }
        .style19
        {
            height: 38px;
            width: 144px;
        }
        .style20
        {
            width: 144px;
        }
        .style21
        {
            width: 144px;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#1A2626" class="style2" colspan="6" style="text-align: center">
                    <strong>AREA CALCULATOR FOR <a href="https://www.cityraja.com/lab/plot_area_calculator.php" target="_blank" style="color:White;Text-decoration:none;">4</a> SIDE PLOT</strong></td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Image ID="Image1" runat="server" Height="300px" Width="100%" 
                        ImageUrl="AREA.JPG" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#003300" class="style3" colspan="3" class="WIDTH:50%;">
                    ENTER LENGTH OF SIDES</td>
                <td bgcolor="#003300" class="style3" colspan="3" class="WIDTH:50%;">
                    ENTER LENGTH OF DIAGONAL</td>
            </tr>
            <tr>
                <td class="style6" class="WIDTH:12.5%;">
                    Length&nbsp;&nbsp;&nbsp;&nbsp; A&nbsp; to B</td>
                <td class="style8" class="WIDTH:12.5%;">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="style10" Height="35px" 
                        Width="144px"></asp:TextBox>
                </td>
                <td class="style11" class="WIDTH:12.5%;">
                    FEET</td>
                <td class="style7" colspan="3">
                    <strong>AT LEAST ONE DIAGONAL IS REQUIRED</strong></td>
            </tr>
            <tr>
                <td class="style6">
                    Length&nbsp;&nbsp;&nbsp;&nbsp; B&nbsp; to C</td>
                <td class="style8">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="style10" Height="35px" 
                        Width="144px"></asp:TextBox>
                </td>
                <td class="style11">
                    FEET</td>
                <td class="style14">
                    <strong>Length A to C</strong></td>
                <td class="style17">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="style10" Height="35px" 
                        Width="144px"></asp:TextBox>
                </td>
                <td class="style15">
                    <strong>FEET</strong></td>
            </tr>
            <tr>
                <td class="style6" class="WIDTH:12.5%;">
                    Length&nbsp;&nbsp;&nbsp;&nbsp; C&nbsp; to D</td>
                <td class="style8">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="style10" Height="35px" 
                        Width="144px"></asp:TextBox>
                </td>
                <td class="style11">
                    FEET</td>
                <td class="style19">
                    </td>
                <td class="style17">
                    </td>
                <td class="style7">
                    </td>
            </tr>
            <tr>
                <td class="style6" class="WIDTH:12.5%;">
                    Length&nbsp;&nbsp;&nbsp;&nbsp; D&nbsp; to A</td>
                <td class="style8">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="style10" Height="35px" 
                        Width="144px"></asp:TextBox>
                </td>
                <td class="style11">
                    FEET</td>
                <td class="style19">
                    </td>
                <td class="style17">
                    </td>
                <td class="style7">
                    
                    
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style16">
                    <asp:Button ID="Button1" runat="server" Height="40px" onclick="Button1_Click" 
                        style="font-size: x-large; font-weight: 700" Text=" CALCULATE" Width="314px" />
                </td>
                <td class="style21">
                    <strong>AREA</strong></td>
                <td class="style18" colspan="2">
                    <asp:Label ID="Label1" runat="server" 
                        style="font-size: x-large; font-weight: 700" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style18">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style9">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style18">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
