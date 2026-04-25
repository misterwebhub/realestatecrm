<%@ Page  Language="C#" AutoEventWireup="true" CodeFile="userreciptdetails.aspx.cs" Inherits="userreciptdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
           $(".txt2").datepicker({
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
            font-size: x-large;
            color: #CC0000;
        }
        .style3
        {
        }
        .style4
        {
            width: 102px;
            font-size: large;
        }
        .style5
        {
            width: 102px;
        }
        .style6
        {
            font-size: large;
        }
        .style8
        {
            background-color: #99FFCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#99FF99" class="style2" colspan="2" style="text-align: center">
                    <strong>USER ACCOUNT RECIPT DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" bgcolor="#FF99FF">
                    <strong>GET USER</strong></td>
                <td bgcolor="#FF99FF">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" Width="120px">
                        <asp:ListItem>------Select-------</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;<strong>DATE FROM </strong>&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" class="txt1" 
                        ontextchanged="TextBox1_TextChanged"></asp:TextBox>
                    &nbsp;&nbsp;<strong>DATE TO</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" class="txt1"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" ForeColor="#000066" Height="28px" 
                        onclick="Button1_Click" style="font-weight: 700; margin-left: 0px" 
                        Text="GET DETAILS" Width="101px" />
                &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Height="26px" 
                        onclick="Button2_Click" style="font-weight: 700" Text="ALL DETAILS" 
                        Width="97px" />
                    &nbsp;<strong>DAYWISE</strong>&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="ui-priority-primary" 
                        Height="24px" onclick="Button3_Click" Text="&lt;" Width="27px" />
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" CssClass="ui-priority-primary" 
                        Height="24px" onclick="Button4_Click" Text="&gt;" Width="27px" />
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    &nbsp;<span class="style6"><strong>Total Amount - 
                    </strong></span>
                    &nbsp;<span class="style6"><strong><asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="Red"></asp:Label>
                    </strong></span>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label ID="Label5" runat="server" Text="RECIEVE AMOUNT" 
                        style="font-weight: 700"></asp:Label>
                    <strong>&nbsp; </strong>
                    <asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="98px"></asp:TextBox>
&nbsp;<asp:Label ID="Label7" runat="server" Text="RECIEVE DATE" 
                        style="font-weight: 700"></asp:Label>
                    &nbsp;<asp:TextBox ID="TextBox4" runat="server" Height="24px" class="txt1" 
                        ontextchanged="TextBox1_TextChanged" Width="104px"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" Height="25px" Text="SUBMIT" 
                        Width="65px" style="font-weight: 700" onclick="Button5_Click" />
                    &nbsp;&nbsp;&nbsp; 
                    <asp:Label ID="Label6" runat="server" Text="BALANCE AMOUNT" 
                        style="font-weight: 700"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" 
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        Width="100%" AutoGenerateColumns="False">

                        <Columns>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO" />
                            <asp:BoundField DataField="date3" HeaderText="BOOKING DATE" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="INSTNO" HeaderText="INSTALLEMENT" />
                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" />
                            <asp:BoundField DataField="RECIPT" HeaderText="RECIPT NO" />
                            <asp:BoundField DataField="ARAZI" HeaderText="ARAZI NO" />
                            <asp:BoundField DataField="PLOT" HeaderText="PLOT NO" />
                            <asp:BoundField DataField="SIZE" HeaderText="PLOT SIZE" />
                            <asp:BoundField DataField="CHECKBY" HeaderText="CHECKBY" />
                            <asp:BoundField DataField="USER" HeaderText="USER" />
                            <asp:BoundField DataField="userstatus" HeaderText="RECIPT STATUS" />
                            <asp:BoundField DataField="paidamount" HeaderText="PAID AMOUNT" />
                            <asp:BoundField DataField="deldate" HeaderText="DEL DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
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
                    <br />
                    <span class="style6"><strong><span class="style8">&nbsp;Total Cancel&nbsp; Amount&nbsp;&nbsp;&nbsp;&nbsp; 
                    :</span><asp:Label ID="Label8" runat="server" ForeColor="Red" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Cancel&nbsp; 
                    Back Amount&nbsp;:&nbsp;<asp:Label ID="Label9" runat="server" ForeColor="Red" 
                        Text="Label"></asp:Label>&nbsp; 
                    <br />
                    </strong></span>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        GridLines="Vertical" Width="100%" AutoGenerateColumns="False" 
                        ForeColor="Black" onrowdatabound="GridView1_RowDataBound"  onrowdatabound="GridView1_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO" />
                            <asp:BoundField DataField="date3" HeaderText="BOOKING DATE" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="INSTNO" HeaderText="INSTALLEMENT" />
                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" />
                            <asp:BoundField DataField="RECIPT" HeaderText="RECIPT NO" />
                            <asp:BoundField DataField="ARAZI" HeaderText="ARAZI NO" />
                            <asp:BoundField DataField="PLOT" HeaderText="PLOT NO" />
                            <asp:BoundField DataField="SIZE" HeaderText="PLOT SIZE" />
                            <asp:BoundField DataField="CHECKBY" HeaderText="CHECKBY" />
                            <asp:BoundField DataField="USER" HeaderText="USER" />
                            <asp:BoundField DataField="userstatus" HeaderText="RECIPT STATUS" />
                            <asp:BoundField DataField="paidamount" HeaderText="PAID AMOUNT" />
                            <asp:BoundField DataField="deldate" HeaderText="DEL DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                        </Columns>

                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#FFC300" Font-Bold="True" ForeColor="BLACK" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                     
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

