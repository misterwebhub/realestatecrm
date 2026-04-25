<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customermention.aspx.cs" Inherits="customer_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
<head>
<title>Customer Details</title>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
 

    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBox1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
          

        });
    </script>
<link rel="shortcut icon" href="images/2.jpeg" type="image/jpeg" />
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<style type="text/css">
    body
    {
        background-image:url("images/gd.jpg");
        background-size:cover;
    }
.wrrper{
width:1172px;
margin:0 auto;
border:5px solid black;
}
table {
    border-collapse: collapse;
	width:100%;
}

table, td, th {
    border: 1px solid black;
	
	
}

th{
padding :5px;
background-color:Maroon;
color:White;
}
td
{
    padding:5px;
        text-align: left;
    }


    .style1
    {
        width: 159px;
        height: 34px;
    }
    .style2
    {
    }


    .style3
    {
        width: 100%;
		height:100%;
    }
    .style4
    {
        text-align: left;
    }
    .style5
    {
        font-weight: bold;
    }
    .style6
    {
        text-align: left;
    }
    .style7
    {
        text-align: left;
        width: 377px;
    }
    .style8
    {
        width: 605px;
        height: 34px;
    }
    .style9
    {
        height: 34px;
    }


    .style13
    {
        width: 97px;
        height: 32px;
    }
    

    .style15
    {
    }
    .style16
    {
        text-align: left;
        height: 32px;
    }
    .style17
    {
        height: 55px;
    }


    .style18
    {
        width: 103px;
        height: 32px;
    }
    .style19
    {
        height: 61px;
    }
    .style20
    {
        height: 23px;
        font-size:12PT;
    }
    .style21
    {
        width: 97px;
        height: 23px;
        font-size:12PT;
    }
    .style22
    {
        width: 103px;
        height: 23px;
        font-size:12PT;
    }
    .style23
    {
        height: 32px;
    }


</style>
</head>
<body>
<div class="wrrper">
<form runat="server">
	<table >
		<tr>
			<td style="font-size:larger;FONT-WEIGHT:bold;color:White; text-align: center;" 
        bgcolor="Black">CUSTOMER MENTION PAYMENT DETAILS</td></tr>
		<tr>
		<td style="font-size:14pt;">CUST.REG.NO  <asp:TextBox ID="TextBox2" runat="server" width="120px" style="font-size:14pt;"  AutoPostBack="True"  ontextchanged="TextBox2_TextChanged"></asp:TextBox> &nbsp;&nbsp;Arazi &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="#000066" Text="lbarazi" style="font-size:14pt;"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;Plot NO &nbsp;<asp:Label ID="Label2" runat="server" ForeColor="#000066" Text="lbplot" style="font-size:14pt;"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;Plot Size &nbsp;<asp:Label ID="Label3" runat="server" ForeColor="#000066" Text="lbsize" style="font-size:14pt;"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;ID &nbsp;<asp:TextBox ID="TextBox21" runat="server" width="50px" style="font-size:14pt;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="DELETE" style="width:70px;height:25px;font-weight:bold;" BackColor="Red" onclick="Button2_Click"  
                                /> </td>
		</tr>

		<tr>
			<td>
			DATE <asp:TextBox ID="TextBox1" runat="server" width="100px" style="font-size:14pt;"></asp:TextBox>  
				&nbsp;&nbsp;TYPE <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" 
                        Width="128px"
                     >
                        <asp:ListItem>-----SELECT-------</asp:ListItem>
				<asp:ListItem>CHEQUE</asp:ListItem>
				<asp:ListItem>UPI</asp:ListItem>
				<asp:ListItem>RTGS</asp:ListItem>
				<asp:ListItem>NEFT</asp:ListItem>
				<asp:ListItem>IMPS</asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp; NUMBER <asp:TextBox ID="TextBox3" runat="server" width="100px" style="font-size:14pt;"></asp:TextBox> 
				&nbsp;&nbsp;AMOUNT <asp:TextBox ID="TextBox4" runat="server" width="100px" style="font-size:14pt;"></asp:TextBox> 
				&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="Button1" runat="server" Text="ADD" style="width:100px;height:25px;font-weight:bold;"  
                                BackColor="Red" onclick="Button1_Click" 
                                />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" ForeColor="#000066" Text="lblmsg" style="font-size:13pt;"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align:right;">Search Number &nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server" width="100px" style="font-size:14pt;"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="SEARCH" style="width:100px;height:25px;font-weight:bold;color:white;"  
                                BackColor="black" onclick="Button3_Click" 
                                />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" ForeColor="red" Text="lblmsg" style="font-size:13pt;"></asp:Label></td>
		</tr>
		<TR>
			<TD>
			 <asp:GridView ID="GridView1" runat="server" 
                  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                  CellPadding="4" Width="100%" AutoGenerateColumns="False" style="font-weight:bold;font-size:14pt;">
                  <Columns>
					  <asp:BoundField DataField="id" HeaderText="ID" >
                      <ItemStyle Width="10px" />  </asp:BoundField>
					  <asp:BoundField DataField="custregno" HeaderText="REG.NO">
                      <ItemStyle Width="20px" />
                      </asp:BoundField>
					   <asp:BoundField DataField="arazi" HeaderText="ARAZI" >
                      <ItemStyle Width="30px" />  </asp:BoundField>
					     <asp:BoundField DataField="plotno" HeaderText="PLOTNO" >
                      <ItemStyle Width="100px" />  </asp:BoundField>
					  <asp:BoundField DataField="plotsize" HeaderText="SIZE" >
                      <ItemStyle Width="30px" />  </asp:BoundField>
                      <asp:BoundField DataField="date" HeaderText="REC. DATE" DataFormatString = "{0:dd/MM/yyyy}">
                      <ItemStyle Width="30px" />
                      </asp:BoundField>
                      
                      <asp:BoundField DataField="mode" HeaderText="MODE" >
                      <ItemStyle Width="30px" />  </asp:BoundField>
					  <asp:BoundField DataField="refno" HeaderText="REF.NO" >
                      <ItemStyle Width="30px" />  </asp:BoundField>
					  <asp:BoundField DataField="amount" HeaderText="AMOUNT" >
                      <ItemStyle Width="30px" />  </asp:BoundField>
                  </Columns>
                  <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                  <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                  <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                  <RowStyle BackColor="White" ForeColor="#330099" />
                  <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                  <SortedAscendingCellStyle BackColor="#FEFCEB" />
                  <SortedAscendingHeaderStyle BackColor="#AF0101" />
                  <SortedDescendingCellStyle BackColor="#F6F0C0" />
                  <SortedDescendingHeaderStyle BackColor="#7E0000" />
              </asp:GridView>
			</TD>
		</TR>
	</table>
	</form>
</div>
</body>
</html>
