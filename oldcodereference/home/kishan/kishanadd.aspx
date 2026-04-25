<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kishanadd.aspx.cs" Inherits="kishan_kishanadd" %>

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
            width: 126px;
        }
        .style3
        {
            width: 101px;
        }
        .style4
        {
            width: 169px;
        }
        .style5
        {
        }
        #R
        {
            height:auto;
            border:2PX BLUE solid;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="R">
    <p align="center" style="font-size:x-large;color:Red; font-weight: 700;">KISHAN REGISTRATION FORM</p>
        <table class="style1">
            <tr>
                <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" BackColor="#660066" Font-Bold="True" 
                        Font-Size="12pt" ForeColor="#FFFFCC" Height="44px" Text="ADD KISHAN" 
                        Width="253px" onclick="Button2_Click" />
                </td>
                <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" BackColor="#660033" Font-Bold="True" 
                        Font-Size="12pt" ForeColor="#FFFFCC" Height="42px" Text="EDIT /  DELETE KISHAN" 
                        Width="253px" onclick="Button3_Click" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server">
        
        <table class="style1">
            <tr>
                <td bgcolor="#00CC66" class="style5">
                    &nbsp;
                    KISHAN REG. NO.<asp:TextBox ID="TextBox3" runat="server" Font-Size="13pt" 
                        Height="25px" ReadOnly="True" style="margin-top: 0px" Width="109px"></asp:TextBox>
                </td>
                <td bgcolor="#00CC66" class="style3">
                    &nbsp;
                    ARAZI NO.</td>
                <td bgcolor="#00CC66" class="style2">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="114px">
                        <asp:ListItem>----SELECT------</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td bgcolor="#00CC66">
                    &nbsp;&nbsp;
                    KISHAN NAME</td>
                <td bgcolor="#00CC66" class="style4">
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="13pt" Height="25px" 
                        Width="180px"></asp:TextBox>
                </td>
                <td bgcolor="#00CC66">
                    &nbsp;
                    AADHAR NO.</td>
                <td bgcolor="#00CC66">
                    <asp:TextBox ID="TextBox2" runat="server" Font-Size="13pt" Height="25px" 
                        Width="176px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="ADD RECORD" 
                        Width="115px" onclick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#00CC66" class="style5">
                    &nbsp;</td>
                <td bgcolor="#00CC66" class="style3">
                    &nbsp;</td>
                <td bgcolor="#00CC66" class="style2">
                    &nbsp;</td>
                <td bgcolor="#00CC66">
                    &nbsp;</td>
                <td bgcolor="#00CC66" class="style4">
                    &nbsp;</td>
                <td bgcolor="#00CC66">
                    &nbsp;</td>
                <td bgcolor="#00CC66">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
           <table class="style1">
            <tr>
                <td bgcolor="#00CC66" class="style5">
                    &nbsp; ADHAR / REG. NO.<asp:TextBox ID="TextBox4" runat="server" Font-Size="13pt" 
                        Height="25px" style="margin-top: 0px" Width="94px"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="Button5" runat="server" Font-Bold="True" Text="FIND" 
                        Width="50px" onclick="Button5_Click" />
                </td>
                <td bgcolor="#00CC66" class="style3">
                    &nbsp;
                    ARAZI NO.</td>
                <td bgcolor="#00CC66" class="style2">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="23px" Width="114px">
                        <asp:ListItem>----SELECT------</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td bgcolor="#00CC66">
                    &nbsp;&nbsp;
                    KISHAN NAME</td>
                <td bgcolor="#00CC66" class="style4">
                    <asp:TextBox ID="TextBox5" runat="server" Font-Size="13pt" Height="25px" 
                        Width="180px"></asp:TextBox>
                </td>
                <td bgcolor="#00CC66">
                    &nbsp;
                    AADHAR NO.</td>
                <td bgcolor="#00CC66">
                    <asp:TextBox ID="TextBox6" runat="server" Font-Size="13pt" Height="25px" 
                        Width="176px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" 
                        Font-Bold="True" Text="UPDATE " 
                        Width="72px" onclick="Button4_Click" />
                    &nbsp;<asp:Button ID="Button6" runat="server" Font-Bold="True" Text="DELETE" 
                        Width="74px" onclick="Button6_Click" />
                </td>
            </tr>
               <tr>
                   <td bgcolor="#00CC66" class="style5">
                       &nbsp;</td>
                   <td bgcolor="#00CC66" class="style3">
                       &nbsp;</td>
                   <td bgcolor="#00CC66" class="style2">
                       &nbsp;</td>
                   <td bgcolor="#00CC66">
                       &nbsp;</td>
                   <td bgcolor="#00CC66" class="style4">
                       &nbsp;</td>
                   <td bgcolor="#00CC66">
                       &nbsp;</td>
                   <td bgcolor="#00CC66">
                       <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                   </td>
               </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" style="width:100%;">

        </asp:Panel>
        <asp:GridView ID="GridView1" runat="server" style="width:100%;text-align:center;" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="kid" HeaderText="KISHAN ID">
                <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="arazino" HeaderText="ARAZI NO">
                <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="kname" HeaderText="NAME">
                <ItemStyle Width="45%" />
                </asp:BoundField>
                <asp:BoundField DataField="adharno" HeaderText="AADHAR NO">
                <ItemStyle Width="20%" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
