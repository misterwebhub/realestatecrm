<%@ Page Language="C#" AutoEventWireup="true" CodeFile="arazi100.aspx.cs" Inherits="_161GHA_arazi190" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Arazi 190 Map</title>
    <style type="text/css">
    #r
    {
        float:left;
        height:600px;
    }
    .r1
    
    {
        width:42%;
        
      
    }
    .r3
    
    {
        
        width:48%;
     
    }
    .r2
    
    {
          background-image:url('road1.jpg');
      background-size:100% 100%;
        width:4%;
       
    }
    .r4
    
    {
          background-image:url('al.png');
      background-size:100% 100%;
        width:6%;
       
    }
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 93px;
        }
        .style3
        {
            width: 94px;
        }
        .style4
        {
            width: 98px;
        }
        .style5
        {
            width: 78px;
        }
        .style6
        {
            width: 93px;
            height: 85px;
        }
        .style7
        {
            width: 94px;
            height: 85px;
        }
        .style8
        {
            width: 98px;
            height: 85px;
        }
        .style9
        {
            width: 78px;
            height: 85px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:100%;width:100%;">

    <div id="r" class="r1">
    <div style="height:250px;width:100%;">.</div>
    <div  style="height:250px;width:100%;">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>    
    </div>
     <div id="r" class="r4">     </div>
    <div id="r" class="r2">     </div>
    
    <div id="r" class="r3">
    
    <div style="height:200px;width:100%;text-align:center;font-size:larger;">
    
    <div style="height:75%;width:100%;"></div>
    <div style="height:25%;width:100%;background-image:url('road3.jpg');background-size:100% 100%;"></div>
    </div>
<div  style="height:200px;width:100%;">
    <table class="style1" style="width:100%;height:100%;">
        <tr>
            <td class="style6" style="border:1px solid black;">
                   <asp:Panel ID="p1" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          <br />
                          1</asp:Panel></td>
            <td class="style7">
                   <asp:Panel ID="p5" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          <br />
                          5</asp:Panel></td>
            <td rowspan="3" style="background-image:url('road1.jpg');background-size:100% 100%;">
                &nbsp;</td>
            <td class="style8">
                   <asp:Panel ID="p6" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          <br />
                          6</asp:Panel></td>
            <td class="style9">
                   <asp:Panel ID="p11" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          <br />
                          11</asp:Panel></td>
            <td rowspan="3" style="background-image:url('road1.jpg');background-size:100% 100%;">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="border:1px solid black;" rowspan="2">
                   <asp:Panel ID="p2" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                       2</asp:Panel></td>
            <td class="style3">
                   <asp:Panel ID="p4" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                       4</asp:Panel></td>
            <td class="style4">
                   <asp:Panel ID="p7" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          7</asp:Panel></td>
            <td class="style5">
                   <asp:Panel ID="p10" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          10</asp:Panel></td>
        </tr>
        <tr>
            <td class="style3">
                   <asp:Panel ID="p3" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                       3</asp:Panel></td>
            <td class="style4">
                   <asp:Panel ID="p8" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                          8</asp:Panel></td>
            <td class="style5">
                   <asp:Panel ID="p9" runat="server" 
                          
                    style="height:100%;width:100%;Text-align:center;border:1px solid black;">
                       9</asp:Panel></td>
        </tr>
    </table>
        </div>    
    <div  style="height:200px;width:100%;"></div>   
    </div>
    </div>
    </form>
</body>
</html>
