<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RECIPTDELETE.aspx.cs" Inherits="dialer_advocatemenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height:600px
        }
        .auto-style2 {
            text-align: center;
            font-size: x-large;
            height: 42px;
            color: #FFFFFF;
        }
        .auto-style3 {
            text-align: center;
            color: #FFFFFF;
        }
        .auto-style4 {
            height: 9px;
        }
        .auto-style5 {
            height: 447px;
        }
        .auto-style8  {
            text-decoration: none;
         
          
        }
        #dr {
            width:100%;
            height:100%;
        }
        .rt td{
           
            height:50px;
            width:25%;
        }
            .rt td a {
                padding:10px 40px;
                width:100%;
                background-color:black;
                color:white;
            }
            .rt td a:hover {
                padding:10px 40px;
                width:100%;
                background-color:yellow;
                color:red;
            }
        
        .auto-style9 {
            text-align: center;
        }
        .style1
        {
            height: 40px;
        }
        .style2
        {
            height: 403px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color:bisque;width:60%;height:600px;margin-left:20%;box-shadow:0px 0px 10px black;">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" style="background-color: #800000"><strong>RECIPT DELETE</strong></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="PASSWORD"></asp:Label>
                    <strong>&nbsp;</strong>&nbsp;<asp:TextBox ID="TextBox1" runat="server" 
                        Height="28px" Width="124px"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        style="font-weight: 700" Text="CHECK" />
&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" style="font-weight: 700" 
                        Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" BackColor="#00CC00" Height="28px" 
                        onclick="Button3_Click" style="font-weight: 700" Text="VIEW DELETE ALL" 
                        Width="137px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Panel ID="Panel1" runat="server" Height="33px">
                        <strong>RECIPT NO</strong>&nbsp;&nbsp;
                        <asp:TextBox ID="TextBox2" runat="server" Height="28px" 
                            ontextchanged="TextBox2_TextChanged" Width="89px"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                            style="font-weight: 700" Text="VIEW" />
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" style="font-weight: 700" 
                            Text="Label"></asp:Label>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                            CellPadding="4" CellSpacing="2" DataKeyNames="RECIPT" ForeColor="Black" 
                            onrowdeleting="GridView1_RowDeleting" 
                            onrowdatabound="GridView1_RowDataBound">
                         <Columns>
                        <asp:BoundField DataField="RECIPT" HeaderText="RECIPT" />
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO" >
								 <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                             
                            <asp:BoundField DataField="DATE1" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}">
								 <ItemStyle Width="90px" />
                            </asp:BoundField>
                            
                           
                            
                             <asp:BoundField DataField="AMOUNTR" HeaderText="AMOUNT" >
								  <ItemStyle Width="90px" />
                            </asp:BoundField>
                            
                             <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                            
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                       
                        <br />
                    </asp:Panel>
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                            CellPadding="4" CellSpacing="2" DataKeyNames="RECIPT" ForeColor="Black">
                            <Columns>
                                <asp:BoundField DataField="RECIPT" HeaderText="RECIPT" />
                                <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREG.NO">
                                <ItemStyle Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NAME" HeaderText="NAME" />
                                <asp:BoundField DataField="DATE1" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="DATE">
                                <ItemStyle Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AMOUNTR" HeaderText="AMOUNT">
                                <ItemStyle Width="90px" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style2"></td>
            </tr>
            <tr>
                <td class="auto-style3" style="background-color: #333333">&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
