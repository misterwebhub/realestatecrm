<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cancel.aspx.cs" Inherits="cancel" %>

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
            text-align: center;
            font-size: x-large;
            color: #003366;
            height: 54px;
        }
        .style3
        {
            height: 33px;
        }
        .style4
        {
            height: 33px;
            width: 193px;
        }
        .style6
        {
            height: 33px;
            width: 95px;
            text-align: right;
        }
        .style7
        {
        }
        .style8
        {
            text-decoration: underline;
        }
        .style9
        {
            text-decoration: underline;
            height: 27px;
            color: #FFFFFF;
        }
        .style10
        {
            height: 27px;
        }
        .style11
        {
            color: #FFFFFF;
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td bgcolor="#FFFFCC" class="style2" colspan="4">
                    <strong>Registry Cancel Details Form</strong></td>
            </tr>
            <tr>
                <td bgcolor="#003300" class="style6">
                    <strong style="color: #FFFFFF">Arazi</strong></td>
                <td bgcolor="#003300" class="style4">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="24px" Width="111px">
                    </asp:DropDownList>
                </td>
                <td bgcolor="#003300" class="style3">
                    <asp:Button ID="Button1" runat="server" Height="26px" onclick="Button1_Click" 
                        style="font-weight: 700" Text="View " Width="89px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Height="26px" style="font-weight: 700" 
                        Text="All Details" Width="78px" onclick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;
                    </td>
                <td bgcolor="#003300" class="style3">
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="4">
                    <br />
                    <span class="style8">Cancel Bond Details :<br />
                    </span>
                    <asp:GridView ID="GridView2" runat="server" Width="100%" 
                        AutoGenerateColumns="False" AutoGenerateSelectButton="True" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" CellPadding="4" 
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREGNO" />
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="PLOT SIZE" />
                            <asp:BoundField DataField="plotno" HeaderText="PLOT NO" />
                            <asp:BoundField DataField="date3" HeaderText="DATE" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="CHECKBY" HeaderText="CHECK BY" />
                            <asp:BoundField DataField="mobile" HeaderText="MOBILE" />
                            <asp:BoundField DataField="regstatus" HeaderText="STATUS" />
                             <asp:BoundField DataField="deletedate" HeaderText="CANCEL DATE" 
                                DataFormatString="{0:dd/MM/yyyy}" />
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
            <tr>
                <td bgcolor="#660033" class="style9" colspan="2">
                    <strong>Cancel Reciept Details :</strong></td>
                <td bgcolor="#660033" class="style10">
                    <span class="style11"><strong>Total Paid Amount&nbsp; :- </strong></span>&nbsp;<asp:Label 
                        ID="Label1" runat="server" Text="Label" ForeColor="White" 
                        style="font-weight: 700; font-size: large;"></asp:Label>
                </td>
                <td bgcolor="#660033" class="style10">
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="4">
                    
                    <br />
                    <asp:GridView ID="GridView3" runat="server" BackColor="LightGoldenrodYellow" 
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                        GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>
                    
                    <br />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
