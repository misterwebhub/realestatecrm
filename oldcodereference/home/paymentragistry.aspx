<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paymentragistry.aspx.cs" Inherits="dialer_paymentragistry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
         $("#TextBox35").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
         

      });
    </script>
    <style type="text/css">
        .gvWidthHight {  
                overflow: scroll;  
                height: 480px;  
                width: 100%;  
            }  
        .auto-style1 {
            width: 100%;
        }
        .auto-style1 td {
            width: 9.09%;
        }
        .auto-style2 {
            height: 42px;
            text-align: center;
            font-size: x-large;
        }
        .auto-style3 {
            height: 60px;
        }
        .auto-style5 {
            height: 30px;
            text-align: left;
        }
        .auto-style6 {
            height: 37px;
        }
        .auto-style7 {
            height: 30px;
            text-align: right;
        }
        .style1
        {
            width: 7%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" style="background-color: #FFCCFF"><strong>RAGISTRY PAYMENT DETAILS ( 18/AUG/2022 )</strong></td>
            </tr>
            <tr>
                <td class="auto-style3" style="background-color: #FFFF99"><strong>FROM&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="24px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; TO&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Height="24px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="ui-priority-primary" Text="VIEW" Width="69px" OnClick="Button1_Click" Height="30px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" CssClass="ui-priority-primary" Text="ALL DETAILS" Width="99px" Height="30px" OnClick="Button2_Click" />
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="paymentdone.aspx" target="_blank">ADVOCATE PAYMENT</a>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style6" style="background-color: #99FFCC">DATE <asp:TextBox ID="TextBox35" runat="server" Height="19px" Width="90px"></asp:TextBox> &nbsp;&nbsp;&nbsp;REGNO.
                    <asp:TextBox ID="TextBox3" runat="server" Height="19px" Width="90px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; REC. AMT&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server" Height="19px" Width="69px"></asp:TextBox>
&nbsp; PAY AMT&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server" Height="19px" Width="69px"></asp:TextBox>
&nbsp;&nbsp; <strong>&nbsp;TYPE&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="81px">
                        <asp:ListItem>---SELECT--</asp:ListItem>
                        <asp:ListItem>FREE</asp:ListItem>
                        <asp:ListItem>PAID</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="ui-priority-primary" OnClick="Button3_Click" Text="SUBMIT" Width="77px" />
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID
                    <asp:TextBox ID="TextBox6" runat="server" Height="21px" Width="69px"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" BackColor="#33CC33" CssClass="ui-priority-primary" OnClick="Button4_Click" Text="DEL" />
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style7" style="background-color: #CCCCCC"><strong>FREE&nbsp;
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TOTAL RECIEVE&nbsp; <asp:Label ID="Label2" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; TOTAL PAY&nbsp;
                    <asp:Label ID="Label3" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; BALANCE&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style5" style="background-color: #000000">
                    <table class="auto-style1" style="width:100%;">
                        <tr>
                            <td style="color: #FFFFFF" ><strong>ID</strong></td>
                              <td style="color: #FFFFFF"><strong>ENTRY</strong></td>
                            <td style="color: #FFFFFF"><strong>REG.NO</strong></td>
                            <td style="color: #FFFFFF"><strong>DATE</strong></td>
                            <td style="color: #FFFFFF"><strong>ARAZI NO</strong></td>
                            <td style="color: #FFFFFF"><strong>PLOT NO</strong></td>
                            <td style="color: #FFFFFF"><strong>PLOT SIZE</strong></td>
                             <td style="color: #FFFFFF"><strong>TYPE</strong></td>
                             <td style="color: #FFFFFF"><strong>STATUS</strong></td>
                            <td style="color: #FFFFFF"><strong>REC.AMT</strong></td>
                            <td style="color: #FFFFFF"><strong>PAY AMT</strong></td>
                            <td style="color: #FFFFFF"><strong>BALANCE</strong></td>
                               <td style="color: #FFFFFF"><strong>REG.TYPE</strong></td>
                            <td style="color: #FFFFFF"><strong>BY</strong></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Class="gvWidthHight">
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                            ForeColor="Black" GridLines="Horizontal" Width="100%" 
                            AutoGenerateColumns="False" 
                            Style="text-align:left;font-size:11pt;font-weight:bold;" 
                            OnRowDataBound="GridView1_RowDataBound" 
                            onrowcancelingedit="GridView1_RowCancelingEdit" 
                            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" DataKeyNames="ID" >
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        ID
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id888" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="100">
                                    <HeaderTemplate>
                                        ENTRY
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="entrydate" runat="server" Text='<%# Eval("entrydate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        REG.NO
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id1" runat="server" Text='<%# Eval("CUSTREGNO") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100">
                                    <HeaderTemplate>
                                        DATE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="date1" runat="server" Text='<%# Eval("DATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="120">
                                    <HeaderTemplate>
                                        ARAZI NO
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount1" runat="server" Text='<%# Eval("ARAZINO") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="120">
                                    <HeaderTemplate>
                                        PLOT NO
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount2" runat="server" Text='<%# Eval("PLOTNO") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80">
                                    <HeaderTemplate>
                                        PLOT SIZE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount3" runat="server" Text='<%# Eval("PLOTSIZE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="80">
                                    <HeaderTemplate>
                                        TYPE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount4" runat="server" Text='<%# Eval("regtype") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="80">
                                    <HeaderTemplate>
                                       STATUS
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount5" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="120">
                                    <HeaderTemplate>
                                        REC.AMT
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount6" runat="server" Text='<%# Eval("REGAMOUNT") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                <asp:TextBox ID="regamt" runat="server" Text='<%# Eval("REGAMOUNT") %>' Width="100"></asp:TextBox>
            </EditItemTemplate>
                                    <ItemStyle Width="9.09%"  Font-Bold="True" ForeColor="Green"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="120">
                                    <HeaderTemplate>
                                        PAY AMT
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount7" runat="server" Text='<%# Eval("PAYAMOUNT") %>'></asp:Label>
                                    </ItemTemplate>
                                      <EditItemTemplate>
                <asp:TextBox ID="payamt" runat="server" Text='<%# Eval("PAYAMOUNT") %>' Width="100"></asp:TextBox>
            </EditItemTemplate>
                                    <ItemStyle Width="9.09%"  Font-Bold="True" ForeColor="Red"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="120">
                                    <HeaderTemplate>
                                        BALANCE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount8" runat="server" Text='<%# Eval("BALANCE") %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80">
                                    <HeaderTemplate>
                                       REG.TYPE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="gender" runat="server" Text='<%# Eval("GENDER") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server">
                                        <asp:ListItem>---select---</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
            </EditItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="120">
                                    <HeaderTemplate>
                                        BY
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="camount15" runat="server" Text='<%# Eval("regitryby") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9.09%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
