<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bank.aspx.cs" Inherits="bank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank</title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {
          $("#TextBox5").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox10").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox15").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox14").datepicker({
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
            height: 22px;
        }
        .style2
        {
            color: #990000;
            font-size: x-large;
            text-align: center;
        }
        .style3
        {
            height: 9px;
        }
        .style4
        {
            height: 21px;
        }
        .style9
        {
        }
        .style10
        {
            width: 146px;
        }
        .style13
        {
            width: 26px;
        }
        .style19
        {
            width: 26px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style23
        {
            width: 107px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style24
        {
            width: 107px;
        }
        .style25
        {
            color: #FF0000;
            font-size: large;
        }
        .style33
        {
            width: 209px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style34
        {
            width: 209px;
        }
        .style44
        {
            width: 127px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style45
        {
            width: 127px;
        }
        .style48
        {
            width: 157px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style49
        {
            width: 157px;
        }
        .style52
        {
            width: 119px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style53
        {
            width: 119px;
        }
        .style54
        {
            width: 82px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style55
        {
            width: 82px;
        }
        .style56
        {
            width: 102px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style57
        {
            width: 102px;
        }
        .style58
        {
            width: 105px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style59
        {
            width: 105px;
        }
        .style60
        {
            width: 126px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style61
        {
            width: 126px;
        }
        .style62
        {
            width: 241px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style63
        {
            width: 241px;
        }
        .style64
        {
            width: 133px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style65
        {
            width: 133px;
        }
        .style66
        {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="border:5px solid gray;height:999px;width:auto;">
    
        <table class="style1">
            <tr>
                <td bgcolor="#66FFCC" class="style2" colspan="2">
                    <strong style="text-align: center">BANK TRANSECTION ENTRY OR&nbsp; DETAILS FORM</strong></td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#66FFCC">
                    &nbsp;<span class="style25"><strong>SELECT ACCOUNT NUMBER</strong></span>&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="195px" 
                        Font-Bold="True" Font-Size="Large" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>----------SELECT------------</asp:ListItem>
                        <asp:ListItem style="background-color:Red;">HEED ICICI (A/C- 417805000312 )</asp:ListItem>
                        <asp:ListItem style="background-color:green;">JAVED (A/C- 417801000378 )</asp:ListItem>
                        <asp:ListItem style="background-color:yellow;">FAHEEM (A/C- 417801501303 )</asp:ListItem>
                        <asp:ListItem style="background-color:Lime;">HEED AXIS (A/C- 921020050778070 )</asp:ListItem>
                        <asp:ListItem style="background-color:white;">HOAR HDFC (A/C-50200059169643)</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">ADD DETAILS</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">EDIT DETAILS</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">VIEW DATEWISE</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="style66"><strong>A/C Balance : </strong></span>
                    <asp:Label ID="Label5" runat="server" style="color: #FF0000; font-weight: 700" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" bgcolor="#66FFCC">
                    </td>
                <td class="style3" bgcolor="#66FFCC">
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server" BorderColor="#CCFF33" Height="85px">
                        <table class="style1" bgcolor="#FFCC00">
                            <tr>
                                <td bgcolor="#000066" class="style19">
                                    NAME</td>
                                <td bgcolor="#000066" class="style33">
                                    AMOUNT</td>
                                <td bgcolor="#000066" class="style58">
                                    DATE</td>
                                <td bgcolor="#000066" class="style56">
                                    CHEQ TYPE</td>
                                <td bgcolor="#000066" class="style54">
                                    PAY MOD&nbsp;</td>
                                <td bgcolor="#000066" class="style44">
                                    REF NO./CH. NO</td>
                                <td bgcolor="#000066" class="style23">
                                    REASON</td>
                                <td bgcolor="#000066" class="style10">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    <asp:TextBox ID="TextBox1" runat="server" Height="27px" Width="176px"></asp:TextBox>
                                </td>
                                <td class="style34">
                                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="91px"></asp:TextBox>
                                    &nbsp;
                                    <asp:DropDownList ID="DropDownList2" runat="server" Height="26px" Width="92px">
                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                        <asp:ListItem>DEBIT ( - )</asp:ListItem>
                                        <asp:ListItem Value="CREDIT ( + )">CREDIT ( + )</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style59">
                                    <asp:TextBox ID="TextBox5" runat="server" Height="26px" Width="94px"></asp:TextBox>
                                </td>
                                <td class="style57">
                                    <asp:DropDownList ID="DropDownList6" runat="server" Height="29px" Width="90px">
                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                        <asp:ListItem>MENTION</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style55">
                                    <asp:DropDownList ID="DropDownList4" runat="server" Height="28px" Width="89px">
                                        <asp:ListItem>---SELECT---</asp:ListItem>
                                        <asp:ListItem>CHEQUE</asp:ListItem>
                                        <asp:ListItem>IMPS</asp:ListItem>
                                        <asp:ListItem>RTGS</asp:ListItem>
                                        <asp:ListItem>NEFT</asp:ListItem>
                                        <asp:ListItem>UPI</asp:ListItem>
                                        <asp:ListItem>DD</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style45">
                                    <asp:TextBox ID="TextBox6" runat="server" Height="26px" Width="111px"></asp:TextBox>
                                </td>
                                <td class="style24">
                                    <asp:TextBox ID="TextBox7" runat="server" Height="27px" TextMode="MultiLine" 
                                        Width="262px"></asp:TextBox>
                                </td>
                                <td class="style10">
                                    <asp:Button ID="Button1" runat="server" Height="26px" style="font-weight: 700" 
                                        Text="SUBMIT" Width="67px" onclick="Button1_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" style="font-weight: 700" Text="NEW" 
                                        Width="63px" onclick="Button2_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style34">
                                    &nbsp;</td>
                                <td class="style59">
                                    &nbsp;</td>
                                <td class="style57">
                                    &nbsp;</td>
                                <td class="style55">
                                    &nbsp;</td>
                                <td class="style45">
                                    &nbsp;</td>
                                <td class="style9" colspan="2">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    <asp:Panel ID="Panel2" runat="server" Height="114px">
                        <table bgcolor="#FFCC00" class="style1">
                            <tr>
                                <td bgcolor="#333300" class="style19">
                                    &nbsp;ID</td>
                                <td bgcolor="#333300" class="style62">
                                    <asp:TextBox ID="TextBox13" runat="server" Height="26px" Width="99px"></asp:TextBox>
                                </td>
                                <td bgcolor="#333300" class="style52">
                                    <asp:Button ID="Button4" runat="server" style="font-weight: 700" Text="SEARCH" 
                                        Width="105px" onclick="Button4_Click" />
                                </td>
                                <td bgcolor="#333300" class="style64">
                                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                                        style="font-weight: 700" Text="DELETE" />
                                </td>
                                <td bgcolor="#333300" class="style60">
                                    &nbsp;&nbsp;&nbsp;
                                    </td>
                                <td bgcolor="#333300" class="style48">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                                <td bgcolor="#333300" class="style23">
                                    &nbsp;</td>
                                <td bgcolor="#333300" class="style10">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td bgcolor="#660066" class="style19">
                                    NAME</td>
                                <td bgcolor="#660066" class="style62">
                                    AMOUNT</td>
                                <td bgcolor="#660066" class="style52">
                                    DATE</td>
                                <td bgcolor="#660066" class="style64">
                                    CHEQ TYPE</td>
                                <td bgcolor="#660066" class="style60">
                                    PAY MOD</td>
                                <td bgcolor="#660066" class="style48">
                                    REF NO / CH. NO.</td>
                                <td bgcolor="#660066" class="style23">
                                    REASON</td>
                                <td bgcolor="#660066" class="style10">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    <asp:TextBox ID="TextBox8" runat="server" Height="27px" 
                Width="173px"></asp:TextBox>
                                </td>
                                <td class="style63">
                                    <asp:TextBox ID="TextBox9" runat="server" Height="26px" 
                Width="102px"></asp:TextBox>
                                    &nbsp;<asp:DropDownList ID="DropDownList3" runat="server" Height="26px" Width="92px">
                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                        <asp:ListItem>DEBIT ( - )</asp:ListItem>
                                        <asp:ListItem Value="CREDIT ( + )">CREDIT ( + )</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style53">
                                    <asp:TextBox ID="TextBox10" runat="server" Height="26px" 
                                        style="margin-right: 0px" Width="98px"></asp:TextBox>
                                </td>
                                <td class="style65">
                                    <asp:DropDownList ID="DropDownList7" runat="server" Height="29px" Width="90px">
                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                        <asp:ListItem>MENTION</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style61">
                                    <asp:DropDownList ID="DropDownList5" runat="server" Height="26px" Width="93px">
                                        <asp:ListItem>---SELECT---</asp:ListItem>
                                        <asp:ListItem>CHEQUE</asp:ListItem>
                                        <asp:ListItem>IMPS</asp:ListItem>
                                        <asp:ListItem>RTGS</asp:ListItem>
                                        <asp:ListItem>NEFT</asp:ListItem>
                                        <asp:ListItem>UPI</asp:ListItem>
                                        <asp:ListItem>DD</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style49">
                                    <asp:TextBox ID="TextBox11" runat="server" Height="26px" 
                Width="121px"></asp:TextBox>
                                </td>
                                <td class="style24">
                                    <asp:TextBox ID="TextBox12" runat="server" Height="26px" 
                TextMode="MultiLine" Width="243px"></asp:TextBox>
                                </td>
                                <td class="style10">
                                    <asp:Button ID="Button3" runat="server" Height="26px" 
                style="font-weight: 700" Text="SUBMIT" Width="67px" onclick="Button3_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style63">
                                    &nbsp;</td>
                                <td class="style53">
                                    &nbsp;</td>
                                <td class="style65">
                                    &nbsp;</td>
                                <td class="style61">
                                    &nbsp;</td>
                                <td class="style49">
                                    &nbsp;</td>
                                <td class="style9" colspan="2">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel3" runat="server" Height="202px">
                        <asp:Label ID="Label6" runat="server" Text="FROM"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="TextBox14" runat="server" Height="26px" 
                            style="margin-right: 0px" Width="98px"></asp:TextBox>
                        &nbsp;<asp:Label ID="Label7" runat="server" Text="TO"></asp:Label>
&nbsp;
                        <asp:TextBox ID="TextBox15" runat="server" Height="26px" 
                            style="margin-right: 0px" Width="98px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:Button ID="Button6" runat="server" Height="26px" style="font-weight: 700" 
                            Text="VIEW" Width="90px" onclick="Button6_Click" />
                        <br />
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                            ForeColor="Black" GridLines="Vertical" Width="100%" 
                            style="text-align:left;" AutoGenerateColumns="False" 
                            onrowdatabound="GridView1_RowDataBound">
                           
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                            <Columns>
                        <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="10px">
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("DATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="58px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="80px">
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="90px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="50px">
                  <HeaderTemplate>CHEQUE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cheq1" runat="server" Text='<%# Eval("chequetype") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="80px">
                  <HeaderTemplate>PAY MODE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="pay1" runat="server" Text='<%# Eval("paymod") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="50px">
                  <HeaderTemplate>REF. NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="ref1" runat="server" Text='<%# Eval("REFNO") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="status1" runat="server" Text='<%# Eval("STATUS") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>DEBIT AMT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="debit1" runat="server" Text='<%# Eval("DEBIT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="15px">
                  <HeaderTemplate>CREDIT AMT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="credit1" runat="server" Text='<%# Eval("CREDIT") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="15px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="reason1" runat="server" Text='<%# Eval("REASON") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                  </asp:TemplateField>
                  </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
