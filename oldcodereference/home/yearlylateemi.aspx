<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yearlylateemi.aspx.cs" Inherits="invsterintrest_yearlylateemi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
            width: 100%;
        }
        .style2
        {
            font-family: Aharoni;
            text-align: center;
            font-size: x-large;
            color: #000066;
        }
        .style6
        {
        }
        .style7
        {
            height: 8px;
        }
        .style8
        {
            height: 38px;
        }
        .style9
        {
            font-weight: bold;
        }
    .style21
    {
        height: 148px;
    }
    
.t
{
    width:100%;
        height: 143px;
    }
        .style22
    {
        font-size: small;
    }
    .style33
    {
        font-weight: bold;
        text-align: left;
        width: 86px;
    }
    .style25
    {
        text-align: left;
        width: 115px;
    }
    .style27
    {
        font-weight: bold;
        text-align: left;
        width: 67px;
    }
    .style29
    {
        text-align: left;
        width: 124px;
    }
    .style35
    {
        text-align: left;
        width: 80px;
    }
    .style24
    {
        text-align: left;
        width: 396px;
    }
    .ui-priority-primary,
.ui-widget-content .ui-priority-primary,
.ui-widget-header .ui-priority-primary {
	font-weight: bold;
}
    .style31
    {
        text-align: left;
        width: 166px;
    }
    .style23
    {
        font-weight: bold;
        text-align: left;
        font-size: large;
    }
    .style36
    {
        font-weight: bold;
        text-align: left;
        width: 80px;
    }
    .style32
    {
        font-weight: bold;
        text-align: left;
        width: 166px;
    }
    .style26
    {
        width: 115px;
    }
    .style28
    {
        width: 67px;
    }
    .style30
    {
        width: 124px;
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
        .WrapText {  
            width: 100%;  
            word-break: break-all; 
        } 
    .style19
    {
        width: 101px;
    }
        .style18
    {
        width: 298px;
    }
        .style3
        {
            height: 53px;
        }
        .style4
        {
            font-weight: bold;
        }
        .style15
        {
            width: 165px;
            font-size: small;
        }
        .style16
        {
            width: 167px;
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
        .style40
        {
            font-weight: bold;
            font-size: small;
        }
        .style41
        {
            width: 182px;
            font-size: small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    <strong>YEARLY LATE EMI DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
            </tr>
            <tr>
                <td class="style8">
                    <strong>USER&nbsp;
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="24px" Width="75px">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; YEAR</strong>&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        Height="21px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="80px">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" BorderStyle="Dashed" CssClass="style9" 
                        onclick="Button1_Click" Text="PREV" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" BorderStyle="Dashed" CssClass="style9" 
                        onclick="Button2_Click" Text="NEXT" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="Red" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" Width="100%" BackColor="White" 
                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        AutoGenerateColumns="False" style="text-align:left;">
                          <Columns>
                        <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>MONTH</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("MONTH") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="60">
                  <HeaderTemplate>LATE EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("LATE") %>'></asp:Label>
                  </ItemTemplate>
                  <ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="60">
                  <HeaderTemplate>DIFF EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("DIFFLATE") %>'></asp:Label>
                  </ItemTemplate>
                  <ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                  
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>TOTAL EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("TOTAL") %>'></asp:Label>
                  </ItemTemplate>



<ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>REC.EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("EMI") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>BAL.EMI</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("BAL") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                              
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style5">
                        <tr>
                            <td class="style6">
                                <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
&nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="Red" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="#003300" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="Red" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" colspan="6">
                                <asp:Panel ID="Panel1" runat="server" Visible="False">
                                    <table style="width:100%;height:100%;" BORDER="1" rules="rows">
                                        <tr height="45px">
                                            <td colspan="4" style="font-size:20PT;text-align:center;" 
        bgcolor="#99FF99">
                                                <asp:Panel ID="Panel2" runat="server" Height="599px" Visible="False">
                                                    <table class="style1">
                                                        <tr>
                                                            <td class="style2" style="text-align: center">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#66FF99" class="style3">
                                                                <b>&nbsp; </b><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b><b>&nbsp;&nbsp;&nbsp;&nbsp; </b>
                                                                <asp:Label ID="Label25" runat="server" CssClass="style4" Font-Size="12pt" 
                                                                    style="color: #FF0000; " Text="Label"></asp:Label>
                                                                <b>
                                                                <asp:Label ID="Label46" runat="server" Font-Size="12pt" 
                                                                    style="text-align: left"></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#FF99FF" class="style5">
                                                                <b>&nbsp;
                                                                <asp:Label ID="Label26" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;
                                                                <asp:Label ID="Label27" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -
                                                                <asp:Label ID="Label28" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-
                                                                <asp:Label ID="Label14" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;&nbsp; -
                                                                <asp:Label ID="Label15" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#FFFFCC" class="style6">
                                                                <strong>NAME </strong>- <b>
                                                                <asp:Label ID="Label51" runat="server" Text="Label"></asp:Label>
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
                                                                            <asp:Label ID="Label52" runat="server" Font-Size="12pt" ForeColor="#003300" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style40">
                                                                            <b>RECIEVE AMOUNT&nbsp;</b></td>
                                                                        <td class="style17">
                                                                            <b>
                                                                            <asp:Label ID="Label53" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style41">
                                                                            <b>BALANCE AMOUNT</b></td>
                                                                        <td class="style13">
                                                                            <b>
                                                                            <asp:Label ID="Label8" runat="server" Font-Size="12pt" ForeColor="Red" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style15">
                                                                            <b>DOWN PAYMENT</b></td>
                                                                        <td class="style16">
                                                                            <b>
                                                                            <asp:Label ID="Label16" runat="server" Font-Size="12pt" ForeColor="#003300" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style40">
                                                                            <b>RECIEVE D.P&nbsp;</b></td>
                                                                        <td class="style17">
                                                                            <b>
                                                                            <asp:Label ID="Label17" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style41">
                                                                            <b>BALANCE D.P</b></td>
                                                                        <td class="style13">
                                                                            <b>
                                                                            <asp:Label ID="Label18" runat="server" Font-Size="12pt" ForeColor="Red" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style15">
                                                                            <b>TOTAL EMI</b></td>
                                                                        <td class="style16">
                                                                            <b>
                                                                            <asp:Label ID="Label9" runat="server" Font-Size="12pt" ForeColor="#003300" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style40">
                                                                            <b>PAID EMI&nbsp;</b></td>
                                                                        <td class="style17">
                                                                            <b>
                                                                            <asp:Label ID="Label10" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style41">
                                                                            <b>BALANCE EMI</b></td>
                                                                        <td class="style13">
                                                                            <b>
                                                                            <asp:Label ID="Label11" runat="server" Font-Size="12pt" ForeColor="Red" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style15">
                                                                            <b>TOTAL MONTH EMI</b></td>
                                                                        <td class="style16">
                                                                            <b>
                                                                            <asp:Label ID="Label20" runat="server" Font-Size="12pt" ForeColor="#003300" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style40">
                                                                            <b>NO. OF PAID EMI</b></td>
                                                                        <td class="style17">
                                                                            <b>
                                                                            <asp:Label ID="Label21" runat="server" Font-Size="12pt" ForeColor="#003300" 
                                                                                Text="Label"></asp:Label>
                                                                            &nbsp;&nbsp; =&nbsp;
                                                                            <asp:Label ID="Label24" runat="server" Font-Size="12pt" ForeColor="#003300" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style41">
                                                                            <b>BALANCE EMI MONTH</b></td>
                                                                        <td class="style13">
                                                                            <b>
                                                                            <asp:Label ID="Label22" runat="server" Font-Size="12pt" ForeColor="Red" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style15">
                                                                            <b>LATE EMI</b></td>
                                                                        <td class="style16">
                                                                            <b>
                                                                            <asp:Label ID="Label12" runat="server" Font-Size="12pt" ForeColor="Red" 
                                                                                Text="Label"></asp:Label>
                                                                            </b>
                                                                        </td>
                                                                        <td class="style40">
                                                                            <b>LATE EMI PAYMENT</b></td>
                                                                        <td class="style17">
                                                                            <b>
                                                                            <asp:Label ID="Label13" runat="server" Font-Size="12pt" ForeColor="Red" 
                                                                                Text="Label"></asp:Label>
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
                                                                            <asp:Label ID="Label23" runat="server" Font-Size="12pt" ForeColor="#003300" 
                                                                                Text="Label"></asp:Label>
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
                                                                            <asp:Label ID="Label19" runat="server" Font-Size="12pt" Text="Label"></asp:Label>
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
                                                    <br />
                                                    <asp:Label ID="Label31" runat="server" style="color: #660066" Text=""></asp:Label>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" 
        style="font-size:20PT;text-align:center;" class="style21" 
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
                                                            <asp:DropDownList ID="DropDownList5" runat="server" Height="24px" Width="99px" 
         AutoPostBack="True" 
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
                                                            <asp:DropDownList ID="DropDownList6" runat="server" Height="24px" 
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
                                                            <asp:Label ID="Label48" runat="server" Text="" style="text-align: left"></asp:Label>
                                                            </b>
                                                        </td>
                                                        <td class="style32">
                                                            EMI REC.AMOUNT&nbsp;&nbsp;</td>
                                                        <td class="style23">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr class="style22">
                                                        <td class="style39" colspan="4">
                                                            <strong>TOTAL PAID EMI CUSTOMER</strong></td>
                                                        <td class="style37">
                                                            <b>
                                                            <asp:Label ID="Label47" runat="server" Text="" 
                    style="text-align: left; font-size: large;"></asp:Label>
                                                            </b>
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
                                                            <asp:Label ID="Label45" runat="server" style="text-align: left" 
                                                                ForeColor="#000066"></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" bgcolor="Silver">
                                                <asp:GridView ID="GridView10" runat="server" Width="100%" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" class="WrapText" style="Text-align:left;">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="30">
                                                            <HeaderTemplate>
                                                                REG.NO
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="id2" runat="server" Text='<%# Eval("REGNO") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="60">
                                                            <HeaderTemplate>
                                                                Address
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="name2" runat="server" Text='<%# Eval("ADDRESS") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100">
                                                            <HeaderTemplate>
                                                                Date
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="date2" runat="server" 
                                                                    Text='<%# Eval("DATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="50px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="120">
                                                            <HeaderTemplate>
                                                                DP Amount
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="camount2" runat="server" Text='<%# Eval("DPAMOUNT") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="120">
                                                            <HeaderTemplate>
                                                                EMI Amount
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="camount3" runat="server" Text='<%# Eval("EMIAMOUNT") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="120">
                                                            <HeaderTemplate>
                                                                FIXED EMI
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="camount4" runat="server" Text='<%# Eval("FIXEDEMI") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" Font-Bold="true" ForeColor="Green"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="120">
                                                            <HeaderTemplate>
                                                                Late EMI
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="camount5" runat="server" Text='<%# Eval("LATE_EMI") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" Font-Bold="True" ForeColor="Red"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="120">
                                                            <HeaderTemplate>
                                                                LATE AMOUNT
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="camount6" runat="server" Text='<%# Eval("LATE_EMI_PAYMENT") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" Font-Bold="True" ForeColor="Red"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="120">
                                                            <HeaderTemplate>
                                                                BROKER
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="camount7" runat="server" Text='<%# Eval("BROKER") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="120">
                                                            <HeaderTemplate>
                                                                STATUS
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="camount8" runat="server" Text='<%# Eval("STATUS") %>'></asp:Label>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight:bold;" class="style19" 
            bgcolor="Silver">
                                            </td>
                                            <td class="style18" bgcolor="Silver">
                                            </td>
                                            <td bgcolor="Silver">
                                            </td>
                                            <td bgcolor="Silver">
                                                <asp:Label ID="Label49" runat="server" Text="TOTAL RECEIVED AMOUNT" 
            Visible="False"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
            ID="Label50" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
