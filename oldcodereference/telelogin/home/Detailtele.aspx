<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detailtele.aspx.cs" Inherits="Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".d").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>

<style type="text/css">
  
body
{
background-image:url("im.jpg");
background-size:cover;
}
	.WrapText {  
            width: 100%;  
            word-break: break-all; 
        } 
#main
{
margin-top:50px;
background-color:#D6EAF8;
height:80%;
box-shadow:1px 1px 30px black;
float:left;

}
#s
{
height:35px;
width:100%;
font-size:16pt;
background-color:black;
color:white;
}
#s:hover
{
height:35px;
width:100%;
font-size:16pt;
background-color:orange;
color:black;
}

.t
{
    width:100%;
}
        .style1
        {
            width: 100%;
            height: 213px;
        }
        .style2
        {
            color: #660033;
            height: 42px;
            font-size: x-large;
        }
        .style3
        {
            height: 53px;
        }
        .style4
        {
            font-weight: bold;
        }
        .style5
        {
            height: 37px;
        }
        .style6
        {
            height: 38px;
        }
        .style15
        {
            width: 165px;
        }
        .style16
        {
            width: 167px;
        }
        .style9
        {
            width: 160px;
        }
        .style17
        {
            width: 177px;
        }
        .style11
        {
            width: 182px;
        }
        .style13
        {
            width: 134px;
        }
        </style>
</head>
<body>
<div>
<form id="Form1" runat="server">
<div id="main" class="t">
<table style="width:100%;height:100%;" BORDER="1" rules="rows">
<tr height="45px"><td colspan="4" style="font-size:20PT;text-align:center;">CHECK PAID INSTALLMENT</td></tr>
 <tr height="45px"><td style="font-weight:bold;">DATE FROM</td><td><asp:TextBox ID="TextBox1" runat="server" class="d" Height="22px" Width="183px">MM/DD/YY</asp:TextBox></td><td style="font-weight:bold;">DATE TO</td><td>    <asp:TextBox ID="TextBox2" runat="server" class="d" Height="22px" Width="183px">MM/DD/YY</asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <strong>USER BY</strong>&nbsp;&nbsp;
     <asp:DropDownList ID="DropDownList3" runat="server" Height="26px" Width="108px">
         <asp:ListItem>----SELECT----</asp:ListItem>
     </asp:DropDownList>
     </td></tr>
 <tr height="45px"><td style="font-weight:bold;">ARAZI NO</td><td>
     <asp:DropDownList ID="DropDownList2" runat="server" Height="23px" Width="134px" 
         AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
         <asp:ListItem>-----SELECT-------</asp:ListItem>
         <asp:ListItem>ALL ARAZI</asp:ListItem>
     </asp:DropDownList>
     &nbsp;
     <asp:Label ID="Label4" runat="server" Text="BLOCK" Visible="False"></asp:Label>
     &nbsp;
     <asp:DropDownList ID="DropDownList4" runat="server" Height="21px" 
         Visible="False" Width="93px">
         <asp:ListItem>---SELECT---</asp:ListItem>
         <asp:ListItem Value="152">A,B,C</asp:ListItem>
         <asp:ListItem>D</asp:ListItem>
         <asp:ListItem>E</asp:ListItem>
     </asp:DropDownList>
     </td><td style="font-weight:bold;">SELECT STATUS</td><td>    <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" 
            Width="182px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True">
        <asp:ListItem>-----SELECT------</asp:ListItem>
        <asp:ListItem>PAID</asp:ListItem>
        
        <asp:ListItem>NON PAID</asp:ListItem>
        
    </asp:DropDownList></td></tr>
 <tr><td style="font-weight:bold;" colspan="2">&nbsp;</td>
    
    <td><strong>BALANCE LATE EMI AMOUNT</strong></td><td>
        <asp:Label ID="Label29" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td></tr>
    <tr><td colspan="4">
        <asp:GridView ID="GridView1" runat="server" Width="100%" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Visible="False" class="WrapText" style="Text-align:left;">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                        <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>REG.NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("REGNO") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="60">
                  <HeaderTemplate>Address</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("ADDRESS") %>'></asp:Label>
                  </ItemTemplate>
                  <ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                  
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>Date</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("DATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>



<ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("AMOUNT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>Late EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("LATE_EMI") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px" Font-Bold="True" ForeColor="Red"></ItemStyle>
                  </asp:TemplateField>
                     <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>LATE AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("LATE_EMI_PAYMENT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px" Font-Bold="True" ForeColor="Red"></ItemStyle>
                  </asp:TemplateField>
				<asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>BROKER</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("BROKER") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("STATUS") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  
                        </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
		
        <br />
        <div class="WrapText">
        <asp:GridView ID="GridView2" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Visible="False" Width="100%" 
            AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="#DCDCDC" />
             <Columns>
                        <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>REG.NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("REGNO") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="60">
                  <HeaderTemplate>ARAZI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("ARAZI") %>'></asp:Label>
                  </ItemTemplate>
                  <ItemStyle Width="20px"></ItemStyle>
                  </asp:TemplateField>
                  
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                  </ItemTemplate>



<ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>DUE DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("DUE_DATE") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>Late EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("LATE_EMI") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px" Font-Bold="True" ForeColor="Red"></ItemStyle>
                  </asp:TemplateField>
                     <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>LATE AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("LATE_EMI_PAYMENT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px" Font-Bold="True" ForeColor="Red"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>PLOT NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("PLOTNO") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>MOBILE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("MOBILE") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
				<asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>BROKER</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("BROKER") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("STATUS") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  
                        </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
		</div>
    </td></tr>
	<tr><td style="font-weight:bold;"></td><td></td>
    
    <td></td><td>
		<asp:Label ID="Label3" runat="server" Text="TOTAL RECEIVED AMOUNT" 
            Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label></td></tr>
</table>
</div>

<asp:Panel ID="Panel1" runat="server" Height="599px" Visible="False">
    <table class="style1">
        <tr>
            <td class="style2" style="text-align: center">
                <strong>CUSTOMER EMI DETAILS</strong></td>
        </tr>
        <tr>
            <td bgcolor="#66FF99" class="style3">
                <b>CUSTOMER REG.NO.&nbsp;&nbsp;&nbsp; </b>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="style4" Height="27px" 
                        style="font-size: large" Width="115px"></asp:TextBox>
                <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <asp:Button ID="Button1" runat="server" Text="VIEW" CssClass="style4" 
                         />
                <b>&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <asp:Label ID="Label25" runat="server" style="color: #FF0000; " 
                        Text="Label" CssClass="style4"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FF99FF" class="style5">
                <b>ARAZI -&nbsp;&nbsp;
                <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT.NO -&nbsp;
                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT SIZE -
                <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BOOKING DATE -
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; END DATE&nbsp; -
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFFCC" class="style6">
                <strong>NAME </strong>- <b>
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td bgcolor="#CCCCCC">
                <table class="style1">
                    <tr>
                        <td class="style15">
                            <strong>TOTAL AMOUNT&nbsp;</strong></td>
                        <td class="style16">
                            <b>
                            <asp:Label 
                        ID="Label6" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                            </b>
                        </td>
                        <td class="style9">
                            <b>RECIEVE AMOUNT&nbsp;</b></td>
                        <td class="style17">
                            <b>
                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                            </b>
                        </td>
                        <td class="style11">
                            <b>BALANCE AMOUNT</b></td>
                        <td class="style13">
                            <b>
                            <asp:Label ID="Label8" runat="server" 
                        Text="Label" ForeColor="Red"></asp:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            <b>DOWN PAYMENT</b></td>
                        <td class="style16">
                            <b>
                            <asp:Label ID="Label16" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                            </b>
                        </td>
                        <td class="style9">
                            <b>RECIEVE D.P&nbsp;</b></td>
                        <td class="style17">
                            <b>
                            <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                            </b>
                        </td>
                        <td class="style11">
                            <b>BALANCE D.P</b></td>
                        <td class="style13">
                            <b>
                            <asp:Label ID="Label18" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            <b>TOTAL EMI</b></td>
                        <td class="style16">
                            <b>
                            <asp:Label ID="Label9" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                            </b>
                        </td>
                        <td class="style9">
                            <b>PAID EMI&nbsp;</b></td>
                        <td class="style17">
                            <b>
                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                            </b>
                        </td>
                        <td class="style11">
                            <b>BALANCE EMI</b></td>
                        <td class="style13">
                            <b>
                            <asp:Label 
                        ID="Label11" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            <b>TOTAL MONTH EMI</b></td>
                        <td class="style16">
                            <b>
                            <asp:Label ID="Label20" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                            </b>
                        </td>
                        <td class="style9">
                            <b>NO. OF PAID EMI</b></td>
                        <td class="style17">
                            <b>
                            <asp:Label ID="Label21" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                            &nbsp;&nbsp; =&nbsp;
                            <asp:Label ID="Label24" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                            </b>
                        </td>
                        <td class="style11">
                            <b>BALANCE EMI MONTH</b></td>
                        <td class="style13">
                            <b>
                            <asp:Label 
                        ID="Label22" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            <b>LATE EMI</b></td>
                        <td class="style16">
                            <b>
                            <asp:Label ID="Label12" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                            </b>
                        </td>
                        <td class="style9">
                            <b>LATE EMI PAYMENT</b></td>
                        <td class="style17">
                            <b>
                            <asp:Label ID="Label13" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                            </b>
                        </td>
                        <td class="style11">
                            &nbsp;</td>
                        <td class="style13">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style15">
                            <strong>FIXED EMI</strong></td>
                        <td class="style16">
                            <b>
                            <asp:Label ID="Label23" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                            </b>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td class="style17">
                            &nbsp;</td>
                        <td class="style11">
                            &nbsp;</td>
                        <td class="style13">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style15">
                            <b>ADVANCE AMOUNT</b></td>
                        <td class="style16">
                            <b>
                            <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                            </b>
                        </td>
                        <td class="style9">
                            &nbsp;</td>
                        <td class="style17">
                            &nbsp;</td>
                        <td class="style11">
                            &nbsp;</td>
                        <td class="style13">
                            &nbsp;</td>
                    </tr>
                </table>
                <b>&nbsp;</b><br />
            </td>
        </tr>
    </table>
</asp:Panel>

</form>
</div>

</body>
</html>
