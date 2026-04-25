<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paymentdpdetails.aspx.cs" Inherits="arazi137ramipur_paymentdpdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   <script type="text/javascript">
       $(document).ready(function () {
           $(".txt1").datepicker({
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
            height: 30px;
            font-size: large;
            color: #FFFFFF;
            text-align: center;
        }
        .style3
        {
            height: 9px;
        }
        .style4
        {
            height: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <table class="style1">
            <tr>
                <td bgcolor="#000066" class="style2">
                    <strong style="text-align: center">USER DOWNPAYMENT RECIEVE DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style3">
                </td>
            </tr>
            <tr>
                <td bgcolor="#FFCCFF" class="style4">
                    &nbsp;<strong>DATE FROM&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" class="txt1" 
                        ></asp:TextBox>
                    &nbsp;&nbsp; DATE TO&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" class="txt1"></asp:TextBox>
                    &nbsp;USER&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="120px">
                        <asp:ListItem>------Select-------</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp; 
                    <asp:Button ID="Button1" runat="server" ForeColor="#000066" Height="28px" 
                        style="font-weight: 700; margin-left: 0px" 
                        Text="GET DETAILS" Width="101px" onclick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                        style="font-weight: 700" Text="ALL DETAILS" Visible="False" 
                        Height="28px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
                    TOTAL AMOUNT-
                    <asp:Label ID="Label5" runat="server" ForeColor="#660033" 
                        style="font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    TOTAL DP AMOUNT -<asp:Label ID="Label3" runat="server" ForeColor="#660033" 
                        style="font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;TOTALDP RECIEVE AMOUNT-
                    </strong>
                    <asp:Label ID="Label2" runat="server" ForeColor="#660033" 
                        style="font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>BALANCE DP AMOUNT -</strong>
                    <asp:Label ID="Label4" runat="server" ForeColor="#660033" 
                        style="font-weight: 700; font-size: large"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </strong>
                </td>
            </tr>
            <tr>
                <td bgcolor="#ECF8F2" style="text-align:right;">
                </td>
            </tr>
            <tr>
                <td>
                   <div class="WordWrap">
                    <asp:GridView ID="GridView1" runat="server" style="width:100%;" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
                        AutoGenerateColumns="False">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                         <Columns>
         
                            <asp:BoundField DataField="date3" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}">
                            <ItemStyle Width=80px />
                             </asp:BoundField>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO">
                            <ItemStyle Width=110px />
                             </asp:BoundField>
                            <asp:BoundField DataField="NAMEDOBADDRESS" HeaderText="NAME">
                              <ItemStyle Width=200px />
                             </asp:BoundField>
                           
                            <asp:BoundField DataField="APPNO" HeaderText="ARAZI NO">
                              <ItemStyle Width=80px />
                             </asp:BoundField>
                            <asp:BoundField DataField="plotno" HeaderText="PLOT NO">
                              <ItemStyle Width=100px />
                             </asp:BoundField>
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="SIZE">
                             <ItemStyle Width=40px />
                             </asp:BoundField>
                             <asp:BoundField DataField="MONTH" HeaderText="EMI MONTH">
                           <ItemStyle Font-Bold=true Width=60px ForeColor="#000066" Font-Size=Large/>
                             </asp:BoundField>
                             <asp:BoundField DataField="CONSAMOUNT" HeaderText="TOTAL AMT" >
                             <ItemStyle Font-Bold="True" Width=60px />
                              
                           
                             </asp:BoundField>
                             <asp:BoundField DataField="downpay" HeaderText="TOTAL DP" >
                              <ItemStyle Font-Bold="True" width=60px />
                             </asp:BoundField>
                              <asp:BoundField DataField="PAID" HeaderText="DP PAID" >
                               <ItemStyle Font-Bold="True" ForeColor="#006600" Width=70/>
                             </asp:BoundField>
                               <asp:BoundField DataField="BALANCEDP" HeaderText="BALANCE DP" >
                             <ItemStyle Font-Bold="True" ForeColor="Red" Width=80 />
                             </asp:BoundField>
                            <asp:BoundField DataField="CHECKBY" HeaderText="BROKER NAME" />
                            <asp:BoundField DataField="regstatus" HeaderText="STATUS" />
                               <asp:BoundField DataField="mobile" HeaderText="MOBILE NO" >

                             <ItemStyle Width=80 Font-Size=Medium />
                        
     </asp:BoundField>
                   
                  
                  
                 
                 
			
                  </Columns>
                    </asp:GridView>
                   </div>
                </td>
            </tr>
        </table>
    
    <div>
    
    </div>
    </form>
</body>
</html>
