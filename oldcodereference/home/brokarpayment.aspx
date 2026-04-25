<%@ Page Language="C#" AutoEventWireup="true" CodeFile="brokarpayment.aspx.cs" Inherits="home_brokarpayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
<head>
<title>Broker Payment Details</title>
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
     <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".txt1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $(".txt2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox4").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
           


        });
    </script>
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
        width: 449px
    }


    .style6
    {
        width: 534px
    }


    .style7
    {
        width: 277px
    }


    .style8
    {
        width: 100%;
    }
    .style9
    {
        width: 90px;
        color: #000066;
    }
    .style10
    {
        width: 129px;
        color: #000066;
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
<tr><td colspan="5" style="font-size:larger;FONT-WEIGHT:bold;color:White;" 
        bgcolor="#003300">BROKER PAYMENT DETAIL</td></tr>
<tr><td colspan="5" style="font-size:larger;FONT-WEIGHT:bold;color:White;" 
        bgcolor="#00CC99">
    <table class="style8">
        <tr>
            <td class="style10">
                Date From</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Size="14pt" Width="180px" class="txt1"></asp:TextBox>
            </td>
            <td class="style9">
                Date To</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Size="14pt" Width="176px" class="txt2"></asp:TextBox>
            </td>
        </tr>
    </table>
    </td></tr>
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
         style="margin-top: 7px" Text="All Details" 
        Width="130px" onclick="Button6_Click" />
    <br />
    *Please select broker before click all details</td>
</tr>
<tr><td colspan="5" style="font-size:larger;FONT-WEIGHT:bold;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
     <asp:TemplateField>
                  <HeaderTemplate>BOOKING</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("BOOKING","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
     <asp:TemplateField>
                  <HeaderTemplate>CUSTOMER REG.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("CUSTREGNO") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                     <asp:TemplateField>
                  <HeaderTemplate>ARAZI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("ARAZI") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
		 <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  
                  <asp:TemplateField>
                  <HeaderTemplate>RECIPT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("RECIPT") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("AMOUNT") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("DATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  
    </Columns>
    </asp:GridView>
&nbsp;</td></tr>
	 <tr><td  style="TEXT-ALIGN:right;" class="style6">
                        Total Amount = <asp:Label ID="Label15" runat="server" Text="" Font-Size="Large"></asp:Label></td><td>
             <b>%&nbsp;&nbsp;
                             <asp:TextBox ID="TextBox5" runat="server" AutoPostBack="True" Font-Size="12pt" 
                                 Width="32%" ontextchanged="TextBox5_TextChanged" 
                 Height="27px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =</b></td>
         <td class="style2">
                             <asp:TextBox ID="TextBox6" runat="server" Font-Size="12pt" 
                 Width="73%"></asp:TextBox></td><td>Date
                            <asp:TextBox ID="TextBox4" runat="server" Font-Size="12pt" 
                 Width="71%"></asp:TextBox></td><td>
                               <asp:Button ID="Button2" runat="server" Text="Submit" Width="84px" 
                                   onclick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Button ID="Button7" runat="server" onclick="Button7_Click" 
                                   Text="View All" />
         </td></tr>
                                   <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:TextBox ID="TextBox7" runat="server" Font-Size="12pt" Height="30px" 
                                  TextMode="MultiLine" Width="64%"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                       </td></tr>
                                       
                                   <tr><td colspan="5">
                               <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                               <Columns>
     <asp:TemplateField>
                  <HeaderTemplate>Broker Name</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson2" runat="server" Text='<%# Eval("bname") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>Date</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson3" runat="server" 
                          Text='<%# Eval("pdate","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>Percentage %</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson4" runat="server" Text='<%# Eval("perc") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson5" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>Reason</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson6" runat="server" Text='<%# Eval("reason") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
                               </asp:GridView>
                                       </td></tr>
                                       
                            </table>
                       </td></tr>

</table>

				</div></td></tr></table>
		</form>
</body>
</html>
