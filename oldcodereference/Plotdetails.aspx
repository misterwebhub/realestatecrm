<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Plotdetails.aspx.cs" Inherits="Plotdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 90%;
			margin-left:5%;
			text-align:Left;
        }
        .style4
        {
            width: 101px;
            height: 41px;
        }
        .style9
        {
            height: 41px;
            width: 280px;
            color: #FF0000;
        }
        .style10
        {
            height: 38px;
            }
        .style29
        {
            height: 60px;
        }
        .style30
        {
            height: 41px;
            color: #FF0000;
        }
        .style31
        {
            color: #000000;
        }
        #view
        {
           
            height:50%;
            width:50%;
        }
       
        .sty
        {
            width: 756px;
             background-image:url('img/ki.jpg');
            height: 539px;
        }
        .arzno239
        {
            background-image:url('IMG/arazi239.jpg');
            width: 410px;
            height: 680px;
        }
        .AR100
        {
            background-image:url('IMG/arazi100.jpg');
            width: 827px;
            height: 330px;
        }
        .ar308
        {
            background-image:url('IMG/arazi308.jpg');
            width: 680px;
            height: 303px;
        }
        .ar2011
        {
            background-image:url('IMG/arazi2011.jpg');
            width: 557px;
            height: 574px;
        }
        .ar293a
        {
            background-image:url('IMG/arazi293AB.jpg');
            width: 981px;
            height: 327px;
        }
        .ar293a&b
        {
            width: 420px;
        }
        .ar293a&b
        {
            width: 382px;
        }
        .style32
        {
            height: 17px;
            width: 280px;
            color: #FF0000;
        }
        .style33
        {
            width: 101px;
            height: 17px;
        }
        .style34
        {
            height: 17px;
            color: #FF0000;
        }
        .style35
        {
            width: 100%;
        }
        .style37
        {
            font-size: large;
            font-weight: normal;
            height: 32px;
            color: #FFFFFF;
        }
        .style39
        {
            width: 157px;
        }
        .style40
        {
        }
        .style42
        {
            width: 145px;
        }
        </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
</head>
<body bgcolor="#B9E2C0" style="font-weight: 700">
    <form id="form1" runat="server">
    <div>
        <table class="style35">
            <tr>
                <td bgcolor="#000066" class="style37" colspan="4" style="text-align: center">
                    <strong>ENTER ID OR PASSWORD FOR PLOT DETAILS</strong></td>
            </tr>
            <tr>
                
                
                <td bgcolor="#CCFFCC" class="style40">
                    PASSWORD</td>
                <td bgcolor="#CCFFCC" class="style39">
                    <asp:TextBox ID="TextBox2" runat="server" Height="22px" TextMode="Password" 
                        Width="136px"></asp:TextBox>
                </td>
                <td bgcolor="#CCFFCC" class="style42">
                    <asp:Button ID="Button4" runat="server" Font-Bold="True" 
                        onclick="Button4_Click1" Text="GET DETAILS" Width="103px" />
                </td>
                <td bgcolor="#CCFFCC">
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                
                
                <td bgcolor="#CCFFCC" class="style40" colspan="4">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="Panel1" runat="server">
       
        
    
        <table class="style1" border="2">
            <tr>
                <td colspan="3" style="text-align: center;background-color:black;color:white;" class="style29">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="21pt" 
                        ForeColor="white" style="text-align: center" Text="Plote Details Form"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9" style="text-align: right" bgcolor="#00FF99">
                    ARAZI NUMBER&nbsp;&nbsp;&nbsp;
                    
                </td>
                <td class="style4" bgcolor="#00FF99">
					<asp:DropDownList ID="DropDownList1" runat="server" Height="23px" 
                        style="margin-left: 0px" Width="128px" AutoPostBack="True" 
                        CssClass="style31">
                        <asp:ListItem>-----SELECT-------</asp:ListItem>
                    </asp:DropDownList>
                   
                </td>
                <td class="style30" bgcolor="#00FF99">
					 <asp:Button ID="Button3" runat="server" Font-Bold="True" ForeColor="#003399" 
                        onclick="Button3_Click" Text="VIEW" Width="81px" CssClass="style31" 
                        style="text-align: left; margin-left: 13px;" />
                    &nbsp;<asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style32" style="text-align: right">
                </td>
                <td class="style33">
                </td>
                <td class="style34" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10" colspan="3">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                        Height="66px" Visible="False" Width="100%" CellSpacing="1" GridLines="None" >

                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
             <tr>
                <td colspan="3">
                    <asp:Label ID="Label2" runat="server" Text="Total plot size"></asp:Label>
&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                 </td>
            </tr>
        </table>
     </asp:Panel>
    </div>
    </form>
</body>
</html>