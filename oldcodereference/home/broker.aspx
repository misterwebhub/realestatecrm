<%@ Page Language="C#" AutoEventWireup="true" CodeFile="broker.aspx.cs" Inherits="broker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
<head>
<title>Broker Details</title>
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<style type="text/css">
    body
    {
        background-image:url("images/gd.jpg");
        background-size:cover;
    }
.wrrper{
width:993px;
margin:0 auto;
border:5px solid black;
}
table {
    border-collapse: collapse;
	width:100%;
}

table, td, th {
    border: 1px solid black;	
	text-align:center;
}

th{
padding :5px;
background-color:Maroon;
color:White;
}
td
{
    padding:5px;
}


    .style1
    {
        width: 161px;
    }
    .style2
    {
        width: 413px
    }


    .style4
    {
        font-size: large;
        font-weight: bold;
    }


    .style6
    {
        width: 343px
    }


    .style7
    {
        width: 277px
    }


    </style>
</head>
<body>
	<form id="Form1" runat="server">
		<table style="height:100%;">
			<tr><td>
	            &nbsp;</td><td>
<div class="wrrper">


<table>
<tr><td colspan="5" style="font-size:larger;FONT-WEIGHT:bold;color:White;" bgcolor="Black">BROKER DETAIL</td></tr>
<tr>
<td class="style6"><asp:Label ID="Label2" runat="server" Text="PLEASE SELECT ARAZI"  style="font-size:medium;FONT-WEIGHT:bold;"></asp:Label></td>
    <td class="style7"> <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="158px">
        <asp:ListItem>-------SELECT-------</asp:ListItem>
    </asp:DropDownList></td>
<td class="style2">
    <asp:Label ID="Label1" runat="server" Text="PLEASE SELECT BROKER"  style="font-size:medium;FONT-WEIGHT:bold;"></asp:Label>
</td>
<td class="style1">
    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="158px">
        <asp:ListItem>-------SELECT-------</asp:ListItem>
    </asp:DropDownList>
    
</td>
<td>
    <asp:Button ID="Button1" runat="server" Text="GET DETAILS" BackColor="#00CCFF" 
        BorderColor="#660066" BorderStyle="Dotted" Font-Bold="True" 
        ForeColor="Black" onclick="Button1_Click" 
        />
&nbsp;<asp:Button ID="Button6" runat="server" BackColor="#003300" 
        BorderStyle="Dashed" Font-Bold="True" Font-Size="Medium" ForeColor="White" 
        onclick="Button6_Click" style="margin-top: 7px" Text="All Details" 
        Width="130px" />
    <br />
    *Please select broker before click all details</td>
</tr>
<tr><td colspan="5" style="font-size:larger;FONT-WEIGHT:bold;">
    <asp:GridView ID="GridView1" runat="server" 
       >
    </asp:GridView>
&nbsp;</td></tr>
	 <tr><td colspan="3" style="TEXT-ALIGN:right;">
                        <asp:Label ID="Label15" runat="server" Text=" " Font-Size="Large"></asp:Label></td></tr>
                 <asp:Label ID="Label5" runat="server" Text=" " Font-Size="Large"></asp:Label>
                            </table>
                        
                        </div>
                        
                        </fieldset></td></tr>

</table>

				</div></td></tr></table>
		</form>
</body>
</html>
