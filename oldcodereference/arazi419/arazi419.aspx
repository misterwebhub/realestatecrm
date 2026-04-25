<%@ Page Language="C#" AutoEventWireup="true" CodeFile="arazi419.aspx.cs" Inherits="arazi353_arazi419" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    #u
    {
        float:left;
        height:100%;
    }
    .r1
    {
        width:60%;
  
    }
    .r2
    {
        width:13%;
        background-image:url('road1.jpg');
        background-size:100% 100%;
    }
    .r3
    
    {
        width:27%;
       
    }
        .style1
        {
            height: 52px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:610px;width:40%;margin-left:30%;">
    <div style="height:550px;width:100%;">
    <div id="u" class="r1">
        <table style="height:90%;width:100%;">
            <tr>
                <td rowspan="2">
                    <asp:Panel ID="p9" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                        <br />
                        9</asp:Panel></td>
                <td colspan="2">
                    <asp:Panel ID="p11" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                        <br />
                        11</asp:Panel></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="p10" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                        <br />
                        10</asp:Panel></td>
            </tr>
            <tr>
                <td colspan="3" class="style1" style="background-image:url('road2.jpg');background-size:100% 100%;">
                    </td>
            </tr>
            <tr>
                <td rowspan="2">
                    <asp:Panel ID="p8" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                       <br /> 8</asp:Panel></td>
                <td colspan="2">
                    <asp:Panel ID="p7" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                        <br />
                        7</asp:Panel></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="p6" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                        <br />
                        6</asp:Panel></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Panel ID="p5" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                        <br />
                        5</asp:Panel></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Panel ID="p4" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                        <br />
                        4</asp:Panel></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Panel ID="p3" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          
                         <br />
                          
                         3</asp:Panel></td>
            </tr>
            <tr style="height:60px;">
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Panel ID="p2" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          
                          <br />2</asp:Panel></td>
                <td>
                    <asp:Panel ID="p1" runat="server" 
                          style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          
                          <br />1</asp:Panel></td>
            </tr>
        </table>
        </div>
    <div  id="u" class="r2"></div>
    <div  id="u" class="r3"></div>
    </div>
    <div style="height:60px;width:100%;background-image:url('road2.jpg');background-size:100% 100%;"></div>
    </div>
    </form>
</body>
</html>
