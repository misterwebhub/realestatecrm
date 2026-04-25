<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customerdetailsheed.aspx.cs" Inherits="customer_details" %>

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
            $(".txt1").datepicker({
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


    .style26
    {
        width: 43px;
        height: 23px;
        font-size: 12PT;
    }
    .style27
    {
        width: 43px;
        height: 32px;
    }
    .style28
    {
        width: 42px;
        height: 23px;
        font-size: 12PT;
    }
    .style29
    {
        width: 42px;
        height: 32px;
    }


    .style30
    {
        color: #FF0000;
    }


</style>
</head>
<body>
<div class="wrrper">
<form runat="server">
<table>
<tr><td colspan="3" 
        style="font-size:larger;FONT-WEIGHT:bold;color:White; text-align: center;" 
        bgcolor="Black">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CUSTOMER DETAIL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
           style="font-size: large; color: #FFFFFF;">Paid Amount</asp:LinkButton>
    </td></tr>
<tr>
<td class="style8" bgcolor="#CCFFFF">
    <asp:Label ID="Label1" runat="server" Text="Enter Customer Registration ID (Example 'REG001') "  style="font-size:larger;FONT-WEIGHT:bold;"></asp:Label>
</td>
<td class="style1" bgcolor="#CCFFFF">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
<td bgcolor="#CCFFFF" class="style9">
   <p align="left"> <asp:Label ID="Label12" runat="server" Text=" "  style="font-size:larger;FONT-WEIGHT:bold;"></asp:Label>&nbsp;<asp:Button ID="Button1" runat="server" Text="GET DETAILS" BackColor="#00CCFF"   
        BorderColor="#660066" BorderStyle="Dotted" Font-Bold="True" ForeColor="Black" 
																																					 onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
           style="font-weight: 700">SHOW ME</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton 
           ID="LinkButton3" runat="server" style="font-weight: 700" 
           onclick="LinkButton3_Click">HIDE ME</asp:LinkButton>
&nbsp;</p>
</td>
</tr>
<tr>
<td class="style2" colspan="3">
    <table bgcolor="#FFFF99" class="style3">
        <tr>
            <td class="style6">
                <b>REG. NO-&nbsp;&nbsp;&nbsp; </b>
                <asp:Label ID="Label13" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
            <td class="style7">
                <b>ARAZI NO.-&nbsp;&nbsp;&nbsp; </b>
                <asp:Label ID="Label14" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>TOTAL AMT</strong>-&nbsp;
                <asp:Label ID="Label18" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
            <td class="style4">
                <b>PLAN -&nbsp;&nbsp; </b>
                <asp:Label ID="Label15" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image1" runat="server" Height="25px" Width="74px" ImageUrl="~/home/check.png" />
            </td>
            <td class="style4">
                <b>MOBILE NO-&nbsp; </b>
                <asp:Label ID="Label16" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="4">
                <strong>NAME -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                <asp:Label ID="Label17" runat="server" CssClass="style5" ForeColor="#000066"></asp:Label>
            </td>
        </tr>
    </table>
</td>
</tr>
<tr><td colspan="3" style="font-size:larger;FONT-WEIGHT:bold;text-align:left;">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        Font-Size="11pt" GridLines="Vertical"  
        onrowdatabound="GridView1_RowDataBound" style="text-align:left;" 
        AutoGenerateColumns="False">
        <Columns>
                            
                        <asp:BoundField DataField="RECIPT" HeaderText="RECIPT">
                             <ItemStyle Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DATE" HeaderText="DATE">
                             <ItemStyle Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INSTNO" HeaderText="INSTNO">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="AMOUNTR" HeaderText="AMOUNT">
								<ItemStyle Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMTWORD" HeaderText="AMT WORD">
								<ItemStyle Width="250px" />
                           
                            </asp:BoundField>
			 <asp:BoundField DataField="chequenopay" HeaderText="CHEQUE NO">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="STATUS" HeaderText="STATUS">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="RECTYPE" HeaderText="DISCOUNT">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="deldate" HeaderText="DEL DATE" DataFormatString = "{0:dd/MM/yyyy}">
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                           
                            
                           
                           
                        </Columns>
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>

</td></tr>
<tr><th style="font-size:larger;FONT-WEIGHT:bold;" colspan="2" rowspan="3">
    
    </th>
    <td style="font-size:larger;FONT-WEIGHT:bold; " 
        bgcolor="White" class="style4">
    <asp:Label ID="Label2" runat="server" Text="Expected Amount"></asp:Label>&nbsp;<asp:Label ID="Label5" runat="server" Text=""></asp:Label></td></tr>
<tr>
<td style="font-size:larger;FONT-WEIGHT:bold; " bgcolor="White" class="style4" >
    <asp:Label ID="Label3" runat="server" Text="Received Amount"></asp:Label>&nbsp;<asp:Label ID="Label4" runat="server" Text=""></asp:Label>&nbsp;
    <asp:Label ID="Label23" runat="server" Text="Return-" CssClass="style30"></asp:Label>
    <asp:Label ID="Label22" runat="server" Text="" CssClass="style30"></asp:Label></td></tr>
    <tr>
<td style="font-size:larger;FONT-WEIGHT:bold; " bgcolor="White" class="style16">
    <asp:Label ID="Label6" runat="server" Text="Balance Amount"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td></tr>
    <tr><td colspan="3" style="font-size:larger;FONT-WEIGHT:bold;" class="style17">
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td></tr>
</table>
	<asp:Panel ID="Panel3" runat="server" ><H3>CHEUQE DETAILS :</H3> <BR>
    <asp:GridView ID="GridView4" runat="server" style="width:100%;" 
        AutoGenerateColumns="False" onrowdatabound="GridView4_RowDataBound">
     <Columns>
                            
                        <asp:BoundField DataField="ID" HeaderText="ID">
                             <ItemStyle Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CDATE" HeaderText="C_DATE"  DataFormatString = "{0:dd/MM/yyyy}">
                             <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHEQUENO" HeaderText="CHEQUENO">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CAMOUNT" HeaderText="CAMOUNT">
								<ItemStyle Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHEQUETYPE" HeaderText="CHEQUETYPE">
								<ItemStyle Width="30px" />
                           
                            </asp:BoundField>
			 
                             <asp:BoundField DataField="STATUS" HeaderText="STATUS">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="paiddate" HeaderText="paiddate" DataFormatString = "{0:dd/MM/yyyy}">
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="deletevalue" HeaderText="DEL" >
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BSTATUS" HeaderText="BSTATUS" >
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BDATE" HeaderText="BDATE" >
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="finalstatus" HeaderText="finalstatus" >
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                            
                           
                           
                        </Columns>
    </asp:GridView>
</asp:Panel>
	<asp:Panel ID="Panel1" runat="server" style="background-color:#e0fffe">
        <table class="style3">
            <tr style="height:20px;">
                <td class="style20">
                    DATE</td>
                <td class="style20">
                    TOTAL</td>
                <td class="style21">
                    % PERC</td>
                <td class="style22">
                    PAID</td>
                <td class="style20">
                    REASON&nbsp;&nbsp;
                    <asp:Label ID="Label19" runat="server" style="color: #FFFF99" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:20px;">
                <td class="style23">
                    <asp:TextBox ID="TextBox3" runat="server" Height="22px" Width="104px" class="txt1"></asp:TextBox>
                </td>
                <td class="style23">
                    <asp:TextBox ID="TextBox4" runat="server" Height="22px" Width="96px" 
                        AutoPostBack="True" ontextchanged="TextBox4_TextChanged" TextMode="Number"></asp:TextBox>
                </td>
                <td class="style13">
                    <asp:TextBox ID="TextBox5" runat="server" Height="22px" Width="83px" 
                        AutoPostBack="True" ontextchanged="TextBox5_TextChanged" TextMode="Number"></asp:TextBox>
                </td>
                <td class="style18">
                    <asp:TextBox ID="TextBox6" runat="server" Height="22px" TextMode="Number" 
                        Width="91px"></asp:TextBox>
                </td>
                <td class="style23">
                    &nbsp;<asp:TextBox ID="TextBox7" runat="server" Height="28px" 
                        style="text-align: left" TextMode="MultiLine" Width="180px">,</asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" style="font-weight: 700" 
                        Text="SUBMIT" onclick="Button2_Click" />
                </td>
            </tr>
            <tr  style="height:123px;">
                <td class="style19" colspan="5">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  
                        Font-Size="11pt" DataKeyNames="ID" onrowdeleting="GridView2_RowDeleting">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID">
                             <ItemStyle Width="25px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="REG.NO">
                             <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHECKBY" HeaderText="CHECKBY">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}">
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PER" HeaderText="PER (%)">
								<ItemStyle Width="70px" />
                           
                            </asp:BoundField>
                            <asp:BoundField DataField="PAID" HeaderText="PAID">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REASON" HeaderText="REASON" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
	<br />
	<asp:Panel ID="Panel2" runat="server" style="background-color:#e0fffe;height:300PX;">
        <table style="height:500px;">
            <tr style="height:20px;">
                <td colspan="3" style="text-align:center;font-weight:bold;background-color:Black;color:White;">
                    CUSTOMER RECIPT RETURN AMOUNT DETAILS</td>
            </tr>
            <tr style="height:20px;">
                <td class="style26">
                    DATE</td>
                <td class="style28">
                    PAID</td>
                <td class="style20">
                    REASON&nbsp;&nbsp;
                    <asp:Label ID="Label20" runat="server" style="color: #FFFF99" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height:20px;">
                <td class="style27">
                    <asp:TextBox ID="TextBox8" runat="server" Height="22px" Width="104px" 
                        class="txt1"></asp:TextBox>
                </td>
                <td class="style29">
                    <asp:TextBox ID="TextBox11" runat="server" Height="22px" TextMode="Number" 
                        Width="91px"></asp:TextBox>
                </td>
                <td class="style23">
                    &nbsp;<asp:TextBox ID="TextBox12" runat="server" Height="28px" 
                        style="text-align: left" TextMode="MultiLine" Width="180px">,</asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" style="font-weight: 700" 
                        Text="SUBMIT" onclick="Button3_Click" />
                    &nbsp;&nbsp;
                    <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr  style="height:123px;">
                <td class="style19" colspan="3">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  
                        Font-Size="11pt" DataKeyNames="ID" onrowdeleting="GridView3_RowDeleting">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" >
                            <ItemStyle Width="100px" />
                            </asp:CommandField>
                        <asp:BoundField DataField="ID" HeaderText="ID">
                             <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}">
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMOUNT" HeaderText="PAID">
								<ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REASON" HeaderText="REASON" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
	</form>
</div>
</body>
</html>
