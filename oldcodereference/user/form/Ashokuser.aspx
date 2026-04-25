<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ashokuser.aspx.cs" Inherits="userreciptdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
   <link href="CSS1/CSS.css" rel="stylesheet" type="text/css" /> 
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
       function BlockUI(elementID) {
           var prm = Sys.WebForms.PageRequestManager.getInstance();
           prm.add_beginRequest(function () {
               $("#" + elementID).block({ message: '<table align = "center"><tr><td>' +
     '<img src="images/loadingAnim.gif"/></td></tr></table>',
                   css: {},
                   overlayCSS: { backgroundColor: '#000000', opacity: 0.6
                   }
               });
           });
           prm.add_endRequest(function () {
               $("#" + elementID).unblock();
           });
       }
       function Hidepopup() {
           $find("popup").hide();
           return false;
       }
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
                    &nbsp;</td>
                <td bgcolor="#FF99FF">
                    &nbsp;&nbsp;<strong>DATE FROM </strong>&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" class="txt1" 
                        ontextchanged="TextBox1_TextChanged"></asp:TextBox>
                    &nbsp;&nbsp;<strong>DATE TO</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" class="txt1"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" ForeColor="#000066" Height="28px" 
                        onclick="Button1_Click" style="font-weight: 700; margin-left: 0px" 
                        Text="GET DETAILS" Width="101px" />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
                        Font-Underline="True" ForeColor="#003300" 
                        NavigateUrl="https://www.heedrealestate.com/home/userpayment.aspx" 
                        Target="_blank">Company Receive Amountt</asp:HyperLink></td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    &nbsp;<span class="style6"><strong>Total Amount - 
                    </strong></span>
                    &nbsp;<span class="style6"><strong><asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="Red"></asp:Label>
                    </strong></span>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <strong>Total Charge</strong>&nbsp;
                    <asp:Label ID="Label10" runat="server" style="font-weight: 700; color: #000066"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" 
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        Width="100%" AutoGenerateColumns="False">

                        <Columns>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO" />
                            <asp:BoundField DataField="date3" HeaderText="BOOKING DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="INSTNO" HeaderText="EMI NO" />
                             <asp:BoundField DataField="che" HeaderText="CHEQUE NO" />
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
                        ForeColor="Black" onrowdatabound="GridView1_RowDataBound" OnRowCommand="OnRowCommand">

                        <Columns>
                         <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox55" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="Button2" runat="server" CommandName="Details"
                                        CommandArgument="<%# Container.DataItemIndex%>" Text="Details" />
                                </ItemTemplate>
                            </asp:TemplateField>
                       <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CommandName="Show"
                                        CommandArgument="<%# Container.DataItemIndex%>" Text="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO" />
                            <asp:BoundField DataField="date3" HeaderText="BOOKING DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}"/>
                             <asp:BoundField DataField="INSTNO" HeaderText="EMI NO" />
                            <asp:BoundField DataField="che" HeaderText="CHEUQE NO." />
                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" />
                             <asp:BoundField DataField="dppaidamount" HeaderText="DP" />
                              <asp:BoundField DataField="instamtpaid" HeaderText="EMI" />
                               <asp:BoundField DataField="LATECHARGE" HeaderText="FINE" />
                                <asp:BoundField DataField="chequebounce" HeaderText="CHEQUE BOUNCE" />
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

