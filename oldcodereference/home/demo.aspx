<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="demo" %>

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
            height: 33px;
        }
        .style3
        {
            height: 53px;
        }
        .style4
        {
            color: #FF0000;
        }
        .style5
        {
            color: #000066;
        }
        .style6
        {
            color: #003300;
        }
        .style7
        {
            color: #800000;
        }
        .style8
        {
            color: #660066;
        }
        .style9
        {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#FF99FF" class="style2" style="text-align: center">
                    <strong>Kishan Pyament Details</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    Select Kishan&nbsp; id&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" style="font-weight: 700; height: 26px;" Text="view" 
                        Width="74px" onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="style4"><strong>Total Amt -</strong></span><strong>&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong><span class="style5"><strong> Paid Amt-</strong></span><strong><asp:Label 
                        ID="Label3" runat="server" 
                        Text="Label" CssClass="style5" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; </strong><span class="style6"><strong>&nbsp;Balance Amt- </strong></span>
                    <strong>
                    <asp:Label ID="Label4" runat="server" Text="Label" CssClass="style6"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; <span class="style7">Unpaid Balance- </span>
                    <asp:Label ID="Label5" runat="server" Text="Label" CssClass="style7"></asp:Label>
&nbsp;&nbsp; <span class="style8">Broker Paid- </span>
                    <asp:Label ID="Label6" runat="server" Text="Label" CssClass="style8"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    Enter Recipt Id
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="82px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Delete" />
&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    invester id&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                        style="font-weight: 700" Text="view" Width="69px" />
                    &nbsp;&nbsp;&nbsp;
                    Enter Recipt ivest Id
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="82px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Delete" />
&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                    <Columns>
                            <asp:BoundField DataField="invrecipt" HeaderText="Recipt ID" />
                            <asp:BoundField DataField="name" HeaderText="Name" />
                           
                           
                            <asp:BoundField DataField="date" HeaderText="date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="amount" HeaderText="Amount" />
                            <asp:BoundField DataField="type" HeaderText="Type" />
                            <asp:BoundField DataField="paymode" HeaderText="mode"/>
                            <asp:BoundField DataField="chekdate" HeaderText="cheque date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="chkno" HeaderText="Cheq. No" />
                            <asp:BoundField DataField="refby" HeaderText="Ref.No" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" Width="100%" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="reciptid" HeaderText="Recipt ID" />
                            <asp:BoundField DataField="kid" HeaderText="Kid" />
                            <asp:BoundField DataField="arazi" HeaderText="Arazi" />
                            <asp:BoundField DataField="date" HeaderText="date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="amount" HeaderText="Amount" />
                            <asp:BoundField DataField="paymode" HeaderText="Pay Mode" />
                            <asp:BoundField DataField="cheqdate" HeaderText="Cheque date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="cheqno" HeaderText="Cheq. No" />
                            <asp:BoundField DataField="refno" HeaderText="Ref.No" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:BoundField DataField="bpaid" HeaderText="Broker Paid" />
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
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
