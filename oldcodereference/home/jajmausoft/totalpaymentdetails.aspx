<%@ Page Language="C#" AutoEventWireup="true" CodeFile="totalpaymentdetails.aspx.cs" Inherits="totalpaymentdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   <script type="text/javascript">
       $(document).ready(function () {

           $("#TextBox1").datepicker({
               changeMonth: true,
               changeYear: true,
               dateFormat: 'dd/mm/yy'
           });

           $("#TextBox2").datepicker({
               changeMonth: true,
               changeYear: true,
               dateFormat: 'dd/mm/yy'
           });

       });
    </script>
    <style type="text/css">
        .WordWrap {
            width: 100%;
            word-break: break-all;
        }
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: x-large;
            color: #CC0000;
        }
        .style31
        {
            color: #000000;
        }
        .style32
        {
            color: #FF0000;
        }
        .style33
        {
            width: 687px;
        }
        .style34
        {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#00CCFF" class="style2" style="text-align: center">
                    <strong>TOTAL CUSTOMER PAYMENT DETAILS </strong>
                </td>
            </tr>
            <tr>
                <td bgcolor="#66FF33">
&nbsp;<span class="style32"><strong>ARAZI NUMBER</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" 
                        style="margin-left: 0px" Width="128px" AutoPostBack="True" 
                        CssClass="style31" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>-----SELECT-------</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="Label4" runat="server" Text="BLOCK" Visible="False" style="font-weight: 700"></asp:Label>
     &nbsp;&nbsp;&nbsp;
     <asp:DropDownList ID="DropDownList4" runat="server" Height="24px" 
         Visible="False" Width="93px">
         <asp:ListItem>---SELECT---</asp:ListItem>
         <asp:ListItem Value="152">A,B,C</asp:ListItem>
         <asp:ListItem>D</asp:ListItem>
         <asp:ListItem>E</asp:ListItem>
		  <asp:ListItem>F</asp:ListItem>
     </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;<strong><span class="style34">Date&nbsp; From </span>
                    </strong>&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="90px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; <strong><span class="style34">To </span></strong>&nbsp;&nbsp; &nbsp;<asp:TextBox 
                        ID="TextBox2" runat="server" Height="21px" Width="90px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" BackColor="#660066" ForeColor="White" 
                        onclick="Button1_Click" style="font-weight: 700" Text="View" Width="76px" 
                        Height="26px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Height="26px" Text="All Details" 
                        Width="85px" BackColor="#000066" ForeColor="White" onclick="Button2_Click" 
                        style="font-weight: 700" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#66FF33">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    TOTAL AMOUNT&nbsp; </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>&nbsp;TOTAL 
                    PAID AMOUNT </strong>&nbsp;&nbsp;&nbsp; <strong>TOTAL</strong> <strong>BALANCE 
                    AMOUNT </strong>&nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="#66FF33">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#660033"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" style="width:100%;" >
                <div class="WordWrap">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                         BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="REGNO" HeaderText="REG NO" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DATE" HeaderText="DATE"  DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="TOTALAMOUNT" HeaderText="TOTAL AMT" />
                            <asp:BoundField DataField="PA" HeaderText="PAID" />
                            <asp:BoundField DataField="BALANCE" HeaderText="BALANCE" />
                            <asp:BoundField DataField="EMI" HeaderText="EMI" />
                            <asp:BoundField DataField="RATE" HeaderText="RATE" />
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="PLOT SIZE" />
                            <asp:BoundField DataField="PLOTNO" HeaderText="PLOT NO" >
                            <ItemStyle Width="130px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                            <asp:BoundField DataField="BROKAR" HeaderText="BROKAR" />
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
                    </asp:GridView></div>
                </td>
                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
