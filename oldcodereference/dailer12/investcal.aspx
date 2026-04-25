<%@ Page Language="C#" AutoEventWireup="true" CodeFile="investcal.aspx.cs" Inherits="arazi137ramipur_investcal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
           
            $("#TextBox2").datepicker({
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
        }
        .style2
        {
            width: 151px;
        }
        .style3
        {
        }
        .style4
        {
            width: 185px;
        }
        .style5
        {
            width: 185px;
            height: 34px;
        }
        .style6
        {
            width: 151px;
            height: 34px;
        }
        .style7
        {
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style5">
                    MONTH&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="97px"></asp:TextBox>
                </td>
                <td class="style6">
                    Investr ID
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="66px"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;
                    </td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3" colspan="3">
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                    <br />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    <br />
                    Total Intrest Of month&nbsp; 
                      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
