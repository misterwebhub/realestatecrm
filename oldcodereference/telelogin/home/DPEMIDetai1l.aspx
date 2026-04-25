<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DPEMIDetai1l.aspx.cs" Inherits="Detail" %>

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
        height: 143px;
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
        .style18
    {
        width: 298px;
    }
    .style19
    {
        width: 101px;
    }
    .style21
    {
        height: 148px;
    }
    .style22
    {
        font-size: small;
    }
    .style23
    {
        font-weight: bold;
        text-align: left;
        font-size: large;
    }
    .style24
    {
        text-align: left;
        width: 396px;
    }
    .style25
    {
        text-align: left;
        width: 115px;
    }
    .style26
    {
        width: 115px;
    }
    .style27
    {
        font-weight: bold;
        text-align: left;
        width: 67px;
    }
    .style28
    {
        width: 67px;
    }
    .style29
    {
        text-align: left;
        width: 124px;
    }
    .style30
    {
        width: 124px;
    }
    .style31
    {
        text-align: left;
        width: 166px;
    }
    .style32
    {
        font-weight: bold;
        text-align: left;
        width: 166px;
    }
    .style33
    {
        font-weight: bold;
        text-align: left;
        width: 86px;
    }
    .style34
    {
    }
    .style35
    {
        text-align: left;
        width: 80px;
    }
    .style36
    {
        font-weight: bold;
        text-align: left;
        width: 80px;
    }
    .style37
    {
        width: 80px;
    }
    .style38
    {
        width: 396px;
    }
        .style39
    {
        font-size: medium;
    }
        </style>
</head>
<body>
<div>
<form id="Form1" runat="server">
<div id="main" class="t">
<table style="width:100%;height:100%;" BORDER="1" rules="rows">
<tr height="45px"><td colspan="4" style="font-size:20PT;text-align:center;" 
        bgcolor="#99FF99">CHECK DP 
    &amp; EMI PAYMENT</td></tr>
<tr><td colspan="4" style="font-size:20PT;text-align:center;" class="style21" 
        bgcolor="Silver">
    <table class="t">
        <tr class="style22">
            <td class="style33">
                DATE FROM</td>
            <td class="style25">
                <asp:TextBox ID="TextBox1" runat="server" class="d" Height="24px" Width="97px" 
                    >MM/DD/YY</asp:TextBox>
            </td>
            <td class="style27">
                DATE TO&nbsp;
            </td>
            <td class="style29">
                <asp:TextBox ID="TextBox2" runat="server" class="d" Height="24px" Width="105px" 
                   >MM/DD/YY</asp:TextBox>
            </td>
            <td class="style35">
     <strong>USER BY</strong></td>
            <td class="style24">
     <asp:DropDownList ID="DropDownList3" runat="server" Height="24px" Width="108px" 
                    CssClass="ui-priority-primary">
         <asp:ListItem>----SELECT----</asp:ListItem>
     </asp:DropDownList>
            </td>
            <td class="style31">
                <strong>LATE EMI AMOUNT</strong></td>
            <td class="style23">
        <asp:Label ID="Label29" runat="server" Text="" style="color: #FF0066"></asp:Label>
            </td>
        </tr>
        <tr class="style22">
            <td class="style33">
                ARAZI NO</td>
            <td class="style25">
     <asp:DropDownList ID="DropDownList2" runat="server" Height="24px" Width="99px" 
         AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                    CssClass="ui-priority-primary">
         <asp:ListItem>-----SELECT-------</asp:ListItem>
         <asp:ListItem>ALL ARAZI</asp:ListItem>
     </asp:DropDownList>
            </td>
            <td class="style27">
     <asp:Label ID="Label44" runat="server" Text="BLOCK" Visible="False"></asp:Label>
            </td>
            <td class="style29">
     <asp:DropDownList ID="DropDownList4" runat="server" Height="24px" 
         Visible="False" Width="93px" CssClass="ui-priority-primary">
         <asp:ListItem>---SELECT---</asp:ListItem>
         <asp:ListItem Value="152">A,B,C</asp:ListItem>
         <asp:ListItem>D</asp:ListItem>
         <asp:ListItem>E</asp:ListItem>
     </asp:DropDownList>
            </td>
            <td class="style36">
                STATUS</td>
            <td class="style24">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" 
            Width="103px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True" CssClass="ui-priority-primary">
        <asp:ListItem>-----SELECT------</asp:ListItem>
        <asp:ListItem>PAID</asp:ListItem>
        
    </asp:DropDownList>
            </td>
            <td class="style32">
                TOTAL EMI &nbsp;</td>
            <td class="style23">
        <asp:Label ID="Label32" runat="server" Text="" style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr class="style22">
            <td class="style33">
                &nbsp;</td>
            <td class="style26">
                &nbsp;</td>
            <td class="style28">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style37">
                &nbsp;</td>
            <td class="style38" style="text-align: left">
                <b>
        <asp:Label ID="Label1" runat="server" Text="" style="text-align: left"></asp:Label></b>
            </td>
            <td class="style32">
                EMI REC.AMOUNT&nbsp;&nbsp;</td>
            <td class="style23">
        <asp:Label ID="Label31" runat="server" Text="" style="color: #660066"></asp:Label>
            </td>
        </tr>
        <tr class="style22">
            <td class="style39" colspan="4">
                <strong>TOTAL PAID EMI CUSTOMER</strong></td>
            <td class="style37">
                <b>
        <asp:Label ID="Label47" runat="server" Text="" 
                    style="text-align: left; font-size: large;"></asp:Label></b>
            </td>
            <td class="style38">
                &nbsp;</td>
            <td class="style32">
                DP REC. AMOUNT&nbsp;&nbsp;</td>
            <td class="style23">
        <asp:Label ID="Label30" runat="server" Text="" style="color: #336600"></asp:Label>
            </td>
        </tr>
        <tr class="style22">
            <td class="style34" colspan="4">
                <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Size="14pt" 
                    Text="TOTAL REC. AMOUNT"></asp:Label>
            </td>
            <td class="style37">
                <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Size="14pt"></asp:Label>
            </td>
            <td class="style38">
                &nbsp;</td>
            <td class="style32">
                BAL. EMI
            </td>
            <td class="style23">
        <asp:Label ID="Label33" runat="server" Text="" style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr class="style22">
            <td class="style34">
                &nbsp;</td>
            <td class="style26">
                &nbsp;</td>
            <td class="style28">
                &nbsp;</td>
            <td class="style30">
                &nbsp;</td>
            <td class="style37">
                &nbsp;</td>
            <td class="style38">
                &nbsp;</td>
            <td class="style32">
                EXTRA AMOUNT</td>
            <td class="style23">
                <b>
        <asp:Label ID="Label45" runat="server" style="text-align: left" ForeColor="#000066"></asp:Label></b>
            </td>
        </tr>
    </table>
    </td></tr>
    <tr><td colspan="4" bgcolor="Silver">
        <asp:GridView ID="GridView1" runat="server" Width="100%" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" class="WrapText" style="Text-align:left;">
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
                  <HeaderTemplate>DP Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("DPAMOUNT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>EMI Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("EMIAMOUNT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>FIXED EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("FIXEDEMI") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px" Font-Bold="true" ForeColor="Green"></ItemStyle>
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
		</div>
    </td></tr>
	<tr><td style="font-weight:bold;" class="style19" bgcolor="Silver"></td>
        <td class="style18" bgcolor="Silver"></td>
    
    <td bgcolor="Silver"></td><td bgcolor="Silver">
		<asp:Label ID="Label3" runat="server" Text="TOTAL RECEIVED AMOUNT" 
            Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label></td></tr>
</table>
</div>

<asp:Panel ID="Panel1" runat="server" Height="599px" Visible="False">
    <table class="style1">
        <tr>
            <td class="style2" style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td bgcolor="#66FF99" class="style3">
                <b>&nbsp; </b>
                <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <b>&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <asp:Label ID="Label25" runat="server" style="color: #FF0000; " 
                        Text="Label" CssClass="style4"></asp:Label>
                <b>
                <asp:Label ID="Label46" runat="server" style="text-align: left"></asp:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FF99FF" class="style5">
                <b>&nbsp;
                <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;
                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -
                <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; -
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
                            <strong>TOTAL AMOUN</strong></td>
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
