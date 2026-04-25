<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cheuesearch.aspx.cs" Inherits="kishan_totalcheque" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: x-large;
            text-align: center;
            color: #800000;
        }
        .style3
        {
            height: 8px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#FFFFCC" class="style2" colspan="3">
                    <strong>&nbsp;CHEQUE DETAILS</strong></td>
            </tr>
            <tr>
                <td bgcolor="#FFFFCC" class="style3">
                </td>
                <td bgcolor="#FFFFCC" class="style3">
                </td>
                <td bgcolor="#FFFFCC" class="style3">
                </td>
            </tr>
            <tr>
                <td bgcolor="#FFCCFF" colspan="3">
                    &nbsp;<strong>&nbsp;CHEQUE NO</strong>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" 
                        runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        style="font-weight: 700" Text="FIND" Width="72px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" style="color: #FF0000; font-weight: 700" 
                        Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <strong>&nbsp;</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" onrowdatabound="GridView1_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                     <Columns>
                     <asp:TemplateField>
                  <HeaderTemplate>ARAZI NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date11" runat="server" Text='<%# Eval("arazi")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>KISHAN</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date12" runat="server" Text='<%# Eval("kname")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
			  <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date4" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date2" runat="server" Text='<%# Eval("amount")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>CHEQUE NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date5" runat="server" Text='<%# Eval("chequeno")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date6" runat="server" Text='<%# Eval("status")%>'></asp:Label>
                  </ItemTemplate>
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
                    <strong><asp:GridView ID="GridView3" runat="server" Width="100%" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" onrowdatabound="GridView3_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                     <Columns>
                     <asp:TemplateField>
                  <HeaderTemplate>ARAZI NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date13" runat="server" Text='<%# Eval("arazi")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date14" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
			  <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date15" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                         <asp:TemplateField>
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date17" runat="server" Text='<%# Eval("amount")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>CHEQUE NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date18" runat="server" Text='<%# Eval("cheqno")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                     <asp:TemplateField>
                  <HeaderTemplate>REF.NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="refno" runat="server" Text='<%# Eval("refno")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date19" runat="server" Text='<%# Eval("status")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                 
                    <asp:TemplateField>
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date16" runat="server" Text='<%# Eval("reason")%>'></asp:Label>
                  </ItemTemplate>
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
                    </strong>
                    <asp:GridView ID="GridView2" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        onrowdatabound="GridView2_RowDataBound">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                        <Columns>
                        <asp:TemplateField>
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d1" runat="server" Text='<%# Eval("id")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                                   <asp:Label ID="d2" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d3" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>A/C CHEQUE BY</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d4" runat="server" Text='<%# Eval("reason")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>CHEQUE NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d5" runat="server" Text='<%# Eval("type")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>CREDIT (+)</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d6" runat="server" Text='<%# Eval("amount")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>DEBIT (-)</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d7" runat="server" Text='<%# Eval("damount")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d8" runat="server" Text='<%# Eval("status1")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GridView4" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        onrowdatabound="GridView4_RowDataBound">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                        <Columns>
                        <asp:TemplateField>
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d9" runat="server" Text='<%# Eval("id")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                                   <asp:Label ID="d10" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d11" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>A/C CHEQUE BY</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d12" runat="server" Text='<%# Eval("reason")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField>
                  <HeaderTemplate>TYPE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d13" runat="server" Text='<%# Eval("type")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d14" runat="server" Text='<%# Eval("amount")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>CHEQUE NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d15" runat="server" Text='<%# Eval("chkno")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>REF.NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="refno1" runat="server" Text='<%# Eval("refby")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="d16" runat="server" Text='<%# Eval("status")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>REASON</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="reason" runat="server" Text='<%# Eval("reason")%>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
