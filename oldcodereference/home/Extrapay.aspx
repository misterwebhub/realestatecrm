<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Extrapay.aspx.cs" Inherits="arazi3435_menu1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	 <script type="text/javascript">
        $(document).ready(function () {
            $(".txt1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            function ShowMessage() {
                alert("Valid");
            }
            function ShowMessage1() {
                alert("Not Valid");
            }

        });
    </script>
  
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 41px;
            font-size: large;
        }
        .style3
        {
        }
        .style4
        {
            width: 201px;
            height: 52px;
        }
        .style5
        {
            height: 52px;
        }
        .style6
        {
            width: 201px;
            height: 57px;
        }
        .style7
        {
            height: 57px;
        }
        .style8
        {
            height: 51px;
        }
        .style9
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main">
<form id="Form1" runat=server>
		
		
        <table class="style1">
            <tr>
                <td class="style2" colspan="4" style="text-align: center">
                    <strong>EXTRA PAYMENT ENTRY</strong></td>
            </tr>
			<tr>
                <td class="style4">
                    DATE</td>
                <td class="style5">
                    <asp:TextBox ID="TextBox11" runat="server" Height="34px" Width="427px" class="txt1"></asp:TextBox>
                </td>
                <td class="style5">
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style4">
                    NAME</td>
                <td class="style5">
                    <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="427px"></asp:TextBox>
                </td>
                <td class="style5">
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    AMOUNT</td>
                <td class="style7">
                    <asp:TextBox ID="TextBox2" runat="server" Height="34px" Width="427px" 
                        TextMode="Number"></asp:TextBox>
                </td>
                <td class="style7">
                </td>
                <td class="style7">
                </td>
            </tr>
            <tr>
                <td class="style6">
                    PAY MODE</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="180px">
                        <asp:ListItem>---SELECT----</asp:ListItem>
                        <asp:ListItem>CASH</asp:ListItem>
                        <asp:ListItem>ONLINE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    REMARK</td>
                <td class="style7">
                    <asp:TextBox ID="TextBox3" runat="server" Height="44px" Width="427px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style7">
                </td>
                <td class="style7">
                </td>
            </tr>
            <tr>
                <td class="style8">
                    </td>
                <td class="style8" colspan="3">
                    <asp:Button ID="Button1" runat="server" 
                        style="font-weight: 700; font-size: large" Text="SUBMIT" Width="206px" 
                        onclick="Button1_Click" />
                &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8" colspan="4">
                    <span class="style9"><strong>
                    TOTAL EXTRA PAYMENT OF CURRENT MONTH : -- &gt;&nbsp;&nbsp; </strong>&nbsp; </span>
                    <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="Label" 
                        CssClass="style9"></asp:Label>
                &nbsp;
                    </td>
            </tr>
            <tr>
                <td class="style3" colspan="4">
                    <asp:GridView ID="GridView1" runat="server" STYLE="WIDTH:100%;" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" ForeColor="Black" GridLines="Vertical" 
                        AutoGenerateColumns="False">
                         <Columns>
                          <asp:BoundField DataField="RECIPT" HeaderText="ID">
                             <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DATE1" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}">
								<ItemStyle Width="80px" />
                            </asp:BoundField>
                        <asp:BoundField DataField="ASCADDRESS" HeaderText="NAME">
                             <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMOUNTR" HeaderText="AMOUNT">
                             <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="payto" HeaderText="MODE">
								<ItemStyle Width="50px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ASCNAME" HeaderText="REMARK">
								<ItemStyle Width="30px" />
                            </asp:BoundField>
                            
                           
                            
                           
                           
                        </Columns>
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
		
		
        </form>
</div>
</asp:Content>

