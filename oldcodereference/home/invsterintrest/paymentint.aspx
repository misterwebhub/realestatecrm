<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paymentint.aspx.cs" Inherits="invsterintrest_paymentint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
     <link rel="stylesheet" href="/resources/demos/style.css"/>
  
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
    <script type="text/javascript">
       
        $(document).ready(function () {
          
            $("#TextBox15").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox17").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });


        });
    </script>
    <style type="text/css">

    #r
    {
        float:left;
        height:550px;
        border:3px solid blue;
    }
    .p
    {
        width:24%;
       
    
    }
    .p1
    {
         width:74%;
         margin-left:1%;
        
        
    }
        .style2
        {
            width: 139px;
            color: #FFFFFF;
            height: 46px;
        }
        .style116
        {
            width: 154px;
            height: 41px;
            font-weight: bold;
        }
        .style55
        {
            width: 112px;
            height: 41px;
        }
        .style82
        {
            height: 41px;
            font-weight: bold;
            text-align: center;
        }
        .style57
        {
            width: 96px;
            height: 41px;
        }
        .style115
        {
            height: 40px;
            font-weight: bold;
            width: 154px;
        }
        .style60
        {
            width: 112px;
            height: 40px;
        }
        .style121
        {
            width: 167px;
            height: 40px;
            font-weight: bold;
        }
        .style62
        {
            width: 95px;
            height: 40px;
        }
        .style64
        {
            width: 91px;
            height: 40px;
        }
        .style132
        {
            width: 120px;
            height: 40px;
        }
        .style63
        {
            height: 40px;
        }
        .style125
        {
            width: 154px;
            height: 39px;
            font-weight: bold;
        }
        .style28
        {
            width: 112px;
            height: 39px;
        }
        .style131
        {
            width: 167px;
            height: 39px;
        }
        .style32
        {
            width: 95px;
            height: 39px;
        }
        .style129
        {
            width: 111px;
            height: 39px;
        }
        .style67
        {
            width: 91px;
            height: 39px;
        }
        .style133
        {
            width: 120px;
            height: 39px;
        }
        .style69
        {
            height: 39px;
        }
        .style4
        {
            width: 96px;
        }
        .style36
        {
            width: 96px;
            height: 39px;
        }
        .style59
        {
            height: 40px;
            font-weight: bold;
        }
        .style84
        {
            width: 273%;
            height: 38px;
        }
        .style86
        {
            width: 129px;
        }
         .style126
        {
            width: 154px;
            font-weight: bold;
        }
        .style119
        {
            width: 154px;
            height: 36px;
            font-weight: bold;
        }
        .style76
        {
            height: 36px;
        }
        .style123
        {
            width: 167px;
            height: 36px;
            font-weight: bold;
        }
        .style78
        {
            width: 95px;
            height: 36px;
        }
        .style130
        {
            width: 111px;
            height: 36px;
        }
        .style79
        {
            width: 91px;
            height: 36px;
        }
        .style134
        {
            width: 120px;
            height: 36px;
        }
        .style124
        {
            width: 167px;
            font-weight: bold;
        }
        .style127
        {
            width: 154px;
        }
        .style9
        {
            width: 108px;
            height: 37px;
        }
        .style135
        {
            width: 120px;
        }
        #r0
    {
        float:left;
        height:550px;
        border:3px solid blue;
    }
        .style136
        {
            height: 40px;
            font-weight: bold;
            width: 111px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <asp:Panel ID="Panel3" runat="server">
            <div style="height:550px;width:100%;">
    <div id="r" class="p"><div style="width:100%;height:100%;overflow:scroll;">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="invid" Font-Size="10pt" GridLines="Vertical" 
            Width="100%" onrowcommand="GridView3_RowCommand" 
            >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="invid" HeaderText="ID" />
                <asp:BoundField DataField="ivname" HeaderText="NAME" />
                
                <asp:CommandField HeaderText="VIEW" ShowSelectButton="True" />
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
    
        <br />
        <asp:Label ID="Label18" runat="server"></asp:Label>
    </div>
    </div>
    <div id="r0" class="p1">
        <table height="80%" width="100%" style="font-size:12pt;">
            <tr>
                <td class="style2" colspan="8" style="text-align: center" bgcolor="#000066">
                    <strong>Intrest Invester Recipt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Recipt- </strong>
                    <asp:Label ID="Label19" runat="server" style="font-weight: 700" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style116" bgcolor="#FFCCFF">
                    INV. ID</td>
                <td class="style55" bgcolor="#FFCCFF">
                    <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style82" bgcolor="#FFCCFF" colspan="3">
                    NAME</td>
                <td class="style57" colspan="3" bgcolor="#FFCCFF">
                    <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style115" bgcolor="#FFCCFF">
                    TOTAL INV.&nbsp; AMT</td>
                <td class="style60" bgcolor="#FFCCFF">
                    <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style121" bgcolor="#FFCCFF">
                    TOTAL RETURN AMT</td>
                <td class="style62" bgcolor="#FFCCFF">
                    <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style136" bgcolor="#FFCCFF">
                    WALLET AMT</td>
                <td class="style64" bgcolor="#FFCCFF">
                    &nbsp;
                    <asp:Label ID="Label40" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style132" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style63" bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td bgcolor="#FFCCFF" class="style115">
                    RECV AMT.</td>
                <td bgcolor="#FFCCFF" class="style60">
                    <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>
                </td>
                <td bgcolor="#FFCCFF" class="style121">
                    <strong>RETURN AMT</strong></td>
                <td bgcolor="#FFCCFF" class="style62">
                    <asp:Label ID="Label39" runat="server" Text="Label"></asp:Label>
                </td>
                <td bgcolor="#FFCCFF" class="style136">
                    WALLET USE</td>
                <td bgcolor="#FFCCFF" class="style64">
                    <asp:Label ID="Label41" runat="server" Text="Label"></asp:Label>
                </td>
                <td bgcolor="#FFCCFF" class="style132">
                    &nbsp;</td>
                <td bgcolor="#FFCCFF" class="style63">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style125" bgcolor="#FFCCFF">
                    DATE</td>
                <td class="style28" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox15" runat="server" Height="23px" Width="107px"></asp:TextBox>
                    </td>
                <td class="style131" bgcolor="#FFCCFF">
                    <strong>AMOUNT</strong></td>
                <td class="style32" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox16" runat="server" Height="25px" Width="97px">0</asp:TextBox>
                    </td>
                <td class="style129" bgcolor="#FFCCFF">
                    <strong>TYPE </strong>
                    </td>
                <td class="style67" bgcolor="#FFCCFF">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="22px" Width="87px" 
                        AutoPostBack="True" onselectedindexchanged="DropDownList4_SelectedIndexChanged">
                        <asp:ListItem>--SELECT----</asp:ListItem>
                        <asp:ListItem style="color:green;">RECEIVE</asp:ListItem>
                        <asp:ListItem style="color:red;">RETURN</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="style133" bgcolor="#FFCCFF">
                    </td>
                <td class="style69" bgcolor="#FFCCFF">
                    </td>
            </tr>
            <tr>
                <td class="style125" bgcolor="#FFCCFF">
                    PAYMENT MODE</td>
                <td class="style28" bgcolor="#FFCCFF">
                    <asp:RadioButton ID="RadioButton5" runat="server" CssClass="style4" 
                        Text="CASH" GroupName="A" AutoPostBack="True" 
                        oncheckedchanged="RadioButton5_CheckedChanged" />
                </td>
                <td class="style131" bgcolor="#FFCCFF">
                    <asp:RadioButton ID="RadioButton6" runat="server" CssClass="style4" 
                        Text="CHEQUE" GroupName="A" AutoPostBack="True" 
                        oncheckedchanged="RadioButton6_CheckedChanged" />
                </td>
                <td class="style36" colspan="5" bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style59" bgcolor="#FFCCFF" colspan="8">
                    <asp:Panel ID="Panel7" runat="server" Height="37px" Width="327px">
                        <table class="style84">
                            <tr>
                                <td class="style86">
                                    CHEUQE DATE</td>
                                <td class="style86">
                                    <asp:TextBox ID="TextBox17" runat="server" Height="23px" Width="107px"></asp:TextBox>
                                </td>
                                <td class="style86">
                                    <strong>CHEQUE NO.</strong></td>
                                <td>
                                     <asp:TextBox ID="TextBox18" runat="server" Height="25px" Width="91px"></asp:TextBox></td>
                                <td>
                                    <strong>REF.BY</strong></td>
                                <td>
                                     <asp:TextBox ID="TextBox19" runat="server" Height="23px" Width="107px"></asp:TextBox></td>
                                <td>
                                    <strong>STATUS</strong></td>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="93px">
                                        <asp:ListItem>---SELECT---</asp:ListItem>
                                        <asp:ListItem >PAID</asp:ListItem>
                                        <asp:ListItem>UNPAID</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
            </tr>
            <tr>
                <td class="style126" bgcolor="#FFCCFF">
                    REASON</td>
                <td class="style3" bgcolor="#FFCCFF" colspan="7">
                    <asp:TextBox ID="TextBox20" runat="server" Height="63px" TextMode="MultiLine" 
                        Width="97%">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style119" bgcolor="#FFCCFF">
                    BROKER</td>
                <td class="style76" bgcolor="#FFCCFF">
                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                    </td>
                <td class="style123" bgcolor="#FFCCFF">
                    TOTAL</td>
                <td class="style78" bgcolor="#FFCCFF">
                    <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style130" bgcolor="#FFCCFF">
                    <strong>PAID AMT</strong></td>
                <td class="style79" bgcolor="#FFCCFF">
                    <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>
                    </td>
                <td class="style134" bgcolor="#FFCCFF">
                    <strong>BALANCE AMT</strong></td>
                <td bgcolor="#FFCCFF" class="style76">
                    <asp:Label ID="Label35" runat="server" Text="Label"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="style126" bgcolor="#FFCCFF">
                    PAID AMOUNT</td>
                <td class="style3" bgcolor="#FFCCFF">
                    <asp:TextBox ID="TextBox21" runat="server" Height="23px" Width="107px">0</asp:TextBox>
                    </td>
                <td class="style124" bgcolor="#FFCCFF">
                    REASON</td>
                <td class="style6" bgcolor="#FFCCFF" colspan="5">
                    <asp:TextBox ID="TextBox22" runat="server" Height="63px" TextMode="MultiLine" 
                        Width="97%">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style127" bgcolor="#FFCCFF">
                    &nbsp;</td>
                <td class="style3" bgcolor="#FFCCFF">
                    <asp:Button ID="Button3" runat="server" Text="SUBMIT" Width="118px" 
                        style="font-weight: 700" onclick="Button3_Click1"  />
                </td>
                <td class="style9" colspan="4" bgcolor="#FFCCFF">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label36" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="style135" bgcolor="#FFCCFF">
                    <asp:Button ID="Button4" runat="server"  Text="new" onclick="Button4_Click" />
                </td>
                <td bgcolor="#FFCCFF">
                    &nbsp;</td>
            </tr>
        </table>
        </div>
    </div>

            </asp:Panel>
    
    </div>
    </form>
</body>
</html>
