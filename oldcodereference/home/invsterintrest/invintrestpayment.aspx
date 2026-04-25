<%@ Page Language="C#" AutoEventWireup="true" CodeFile="invintrestpayment.aspx.cs" Inherits="invsterintrest_invintrestpayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
      <script>
       
             function doPrint1() {
              var prtContent = document.getElementById('<%= GridView1.ClientID %>');
              var prtContent1 = document.getElementById('<%= Panel3.ClientID %>');
              prtContent.border = 0; //set no border here
              var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
              WinPrint.document.write(prtContent1.outerHTML);
              // WinPrint.document.write(prtContent.outerHTML);
              WinPrint.document.close();
              WinPrint.focus();
              WinPrint.print();
              WinPrint.close();
          }
         
</script>
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
            $("#TextBox3").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <style type="text/css">

        .style1
        {
            width:100%;
            height:100%;
        }
        .style30
        {
            width: 312px;
            height: 35px;
        }
        .style3
        {
            width: 304px;
            height: 48px;
        }
        .style12
        {
            font-size: x-small;
        }
        .style22
        {
            width: 92px;
            font-size: small;
            font-weight: bold;
        }
        .style17
        {
            width: 130px;
            font-size: small;
        }
        .style13
        {
            width: 116px;
            font-size: small;
        }
        .style27
        {
            width: 150px;
            font-size: small;
            font-weight: bold;
        }
        .style21
        {
            font-size: small;
        }
        .style4
        {
            width: 92px;
            font-weight: bold;
        }
        .style11
        {
            width: 130px;
        }
        .style9
        {
            width: 116px;
        }
        .style20
        {
            width: 150px;
            font-weight: bold;
        }
        .style33
        {
            width: 92px;
            font-weight: bold;
            height: 24px;
        }
        .style34
        {
            width: 130px;
            height: 24px;
        }
        .style35
        {
            width: 162px;
            font-weight: bold;
            height: 24px;
        }
        .style36
        {
            width: 151px;
            height: 24px;
        }
        .style37
        {
            width: 144px;
            font-weight: bold;
            height: 24px;
        }
        .style38
        {
            width: 116px;
            height: 24px;
        }
        .style39
        {
            width: 150px;
            font-weight: bold;
            height: 24px;
        }
        .ui-priority-primary,
.ui-widget-content .ui-priority-primary,
.ui-widget-header .ui-priority-primary {
	font-weight: bold;
}
        .style44
        {
            width: 144px;
            font-size: small;
            font-weight: bold;
        }
        .style45
        {
            width: 144px;
            font-weight: bold;
        }
        .style46
        {
            width: 162px;
            font-size: small;
            font-weight: bold;
        }
        .style47
        {
            width: 162px;
            font-weight: bold;
        }
        .style48
        {
            width: 151px;
            font-size: small;
        }
        .style49
        {
            width: 151px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <asp:Panel ID="Panel3" runat="server">
            
           <div id="Div1">
    
        <table class="style1">
            <tr>
                <td bgcolor="#FF99FF" class="style30" style="text-align: center" colspan="8">
                    <strong>Invester Pyament Details</strong></td>
            </tr>
            <tr>
                <td class="style3" colspan="8" bgcolor="#99FFCC">
                    Invester Name&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" 
                         Height="29px" 
                        Width="115px">
                    </asp:DropDownList>
                    &nbsp; Invester ID<asp:TextBox ID="TextBox1" runat="server" Height="27px" 
                        style="font-size: medium" Width="90px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" style="font-weight: 700; height: 26px;" 
                        Text="view" Width="74px" onclick="Button3_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button5" runat="server" Text="Print" OnClientClick="doPrint1()" /></td>
            </tr>
            <tr class="style12">
                <td class="style22" bgcolor="#99FFCC">
                    ID</td>
                <td class="style17" bgcolor="#99FFCC">
                    <asp:Label ID="Label15" runat="server" Text="0"></asp:Label>
                </td>
                <td class="style46" bgcolor="#99FFCC">
                    NAME</td>
                <td class="style48" bgcolor="#99FFCC">
                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style44" bgcolor="Lime">
                    TOTAL ONE AMT</td>
                <td class="style13" bgcolor="Lime">
                    <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style27" bgcolor="#FF6600">
                    TOTAL RETURN AMT</td>
                <td class="style13" bgcolor="#FF6600">
                    <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style12">
                <td class="style22" bgcolor="#99FFCC">
                    REG DATE</td>
                <td class="style17" bgcolor="#99FFCC">
                    <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style46" bgcolor="#99FFCC">
                    LAST DATE</td>
                <td class="style48" bgcolor="#99FFCC">
                    <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style44" bgcolor="Lime">
                    RECV&nbsp; AMT</td>
                <td class="style13" bgcolor="Lime">
                    <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style27" bgcolor="#FF6600">
                    RETURN AMT</td>
                <td class="style13" bgcolor="#FF6600">
                    <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style21">
                <td class="style4" bgcolor="#99FFCC">
                    INTREST (%)</td>
                <td class="style11" bgcolor="#99FFCC">
                    <asp:Label ID="Label34" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                </td>
                <td class="style47" bgcolor="#99FFCC">
                    UNPAID CHEQUE AMT</td>
                <td class="style49" bgcolor="#99FFCC">
                    <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style45" bgcolor="Lime">
                    BAL RECV AMT</td>
                <td class="style9" bgcolor="Lime">
                    <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style20" bgcolor="#FF6600">
                    BALANCE RETURN AMT</td>
                <td class="style9" bgcolor="#FF6600">
                    <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style21">
                <td class="style33" bgcolor="#66FFFF">
                    BROKER NAME</td>
                <td class="style34" bgcolor="#66FFFF">
                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style35" bgcolor="#66FFFF">
                    BROKER. TOTAL AMT</td>
                <td class="style36" bgcolor="#66FFFF">
                    <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style37" bgcolor="#66FFFF">
                    BROKER PAID AMT</td>
                <td class="style38" bgcolor="#66FFFF">
                    <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style39" bgcolor="#66FFFF">
                    BROKER BALANCE AMT</td>
                <td class="style38" bgcolor="#66FFFF">
                    <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style21">
                <td bgcolor="#66FFFF" class="style4">
                    DTAE FROM</td>
                <td bgcolor="#66FFFF" class="style11">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="ui-priority-primary" 
                        Height="25px" Width="97px"></asp:TextBox>
                </td>
                <td bgcolor="#66FFFF" class="style47">
                    DATE TO<asp:TextBox ID="TextBox3" runat="server" CssClass="ui-priority-primary" 
                        Height="25px" Width="97px"></asp:TextBox>
                </td>
                <td bgcolor="#66FFFF" class="style49">
                    &nbsp;&nbsp;TYPE
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        CssClass="ui-priority-primary" Height="18px" Width="100px">
                        <asp:ListItem>---SELECT---</asp:ListItem>
                        <asp:ListItem>DATEWISE</asp:ListItem>
                        <asp:ListItem Value="ALL DETAILS">ALL DETAILS</asp:ListItem>
                        <asp:ListItem>ALL DETAILS MONTHWISE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td bgcolor="#66FFFF" class="style45">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="ui-priority-primary" 
                        onclick="Button1_Click1" Text="DETAILS" />
                </td>
                <td bgcolor="#66FFFF" class="style9">
                    <asp:Label ID="Label31" runat="server" ForeColor="Red" 
                        style="font-weight: 700; font-size: medium" Text="Label"></asp:Label>
                </td>
                <td bgcolor="#66FFFF" class="style20">
                    WALLET AMOUNT</td>
                <td bgcolor="#66FFFF" class="style9">
                    <asp:Label ID="Label33" runat="server" ForeColor="Red" 
                        style="font-weight: 700; font-size: large" Text="Label"></asp:Label>
                </td>
            </tr>
           </table>
           </div>
           <div id="Div2">

       <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
   
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" Width="100%" AutoGenerateColumns="False" 
                        style="font-size:9pt;HEIGHT:100%;overflow:scroll;text-align:left;" Font-Bold="True" onrowdatabound="GridView1_RowDataBound" 
                        >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="invrecipt" HeaderText="Recipt ID" />
                            <asp:BoundField DataField="date" HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="type" HeaderText="Type" />
                                 <asp:BoundField DataField="bal" HeaderText="Balance" />
                            <asp:BoundField DataField="cramount" HeaderText="Amount (+)" />
                            <asp:BoundField DataField="dramount" HeaderText="Amount (-)" />
                                <asp:BoundField DataField="wallet" HeaderText="Wallet (-)" />
                                 <asp:BoundField DataField="total" HeaderText="Total (-)" />
                                 
                            <asp:BoundField DataField="paymod" HeaderText="Pay Mode" />
                            <asp:BoundField DataField="chequedate" HeaderText="Cheque date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="chequeno" HeaderText="Cheq. No" />
                          
                            <asp:BoundField DataField="status" HeaderText="Status" />
                              
                                  <asp:BoundField DataField="month" HeaderText="Month" />
                           
                            <asp:BoundField DataField="reason" HeaderText="Reson" />
							 <asp:BoundField DataField="days" HeaderText="Days" />
							 <asp:BoundField DataField="intrest" HeaderText="(%)AMT" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#cccccc" ForeColor="#333333" HorizontalAlign="left" />
                       
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
               </asp:GridView>
        
     </ContentTemplate>
</asp:UpdatePanel>
    </div>
            </asp:Panel>
    
    </div>
    
    <p>
                    <asp:Label ID="Label32" runat="server" ForeColor="Red" 
                        style="font-weight: 700; font-size: medium" Text="Label"></asp:Label>
                </p>
    
    </form>
</body>
</html>
