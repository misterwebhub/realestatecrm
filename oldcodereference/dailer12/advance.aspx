<%@ Page Language="C#" AutoEventWireup="true" CodeFile="advance.aspx.cs" Inherits="call_advance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .WrapText {  
            width: 100%;  
            word-break: break-all; 
        } 
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Current
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Width="100%" 
            AutoGenerateColumns="False" AutoGenerateSelectButton="false" 
            onselectedindexchanged="GridView2_SelectedIndexChanged" class="WrapText" 
            style="font-size:10.5pt;" onrowdatabound="GridView2_RowDataBound" 
           >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
             <Columns>
                <asp:BoundField DataField="CUSTREGNO" HeaderText="REGNO">
                 <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NAME" HeaderText="NAME" >
                             <ItemStyle Width="180px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="APPNO" HeaderText="ARAZI" >
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                           <asp:BoundField DataField="plotno" HeaderText="P.NO" >
                           <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="P.SIZE" >
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="date3" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" >
                             <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHECKBY" HeaderText="CHECKBY">
                            <ItemStyle Width="110px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="date" HeaderText="CALL DATE" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="80px" />
                               </asp:BoundField>
                            <asp:BoundField DataField="reason" HeaderText="FEEDBACK" >
                            <ItemStyle Width="200px" />
                               </asp:BoundField>
                               <asp:BoundField DataField="feeddate" HeaderText="Given Date" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="70px" />
                               </asp:BoundField>
				 <asp:TemplateField ItemStyle-Width="90">
                                    <HeaderTemplate>
                                        ENTRY TIME
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="date2" runat="server" Text='<%# Eval("entrytime") %>' ForeColor="Green" Font-Bold="True" style="text-align:center;"></asp:Label>-
										 <asp:Label ID="date3" runat="server" Text='<%# Eval("demo") %>'  ForeColor="Red" Font-Bold="True" style="text-align:center;"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="90"></ItemStyle>
                                </asp:TemplateField>
				 <asp:BoundField DataField="advance" HeaderText="Advance" >
                             <ItemStyle Width="60px" />
                            </asp:BoundField>
                          
                            
                             <asp:HyperLinkField Text="Call Now" DataNavigateUrlFields="CUSTREGNO,NAME,MOBILE" DataNavigateUrlFormatString="~/dailer/dialerhome.aspx?CUSTREGNO={0}&NAME={1}&MOBILE={2}" target="_blank"/>
                 </Columns>
        </asp:GridView>
		
        <br />
        <br />
        Back<br />
        <br />
        <asp:GridView ID="GridView4" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Width="100%" 
            AutoGenerateColumns="False" AutoGenerateSelectButton="false" 
            onselectedindexchanged="GridView4_SelectedIndexChanged" class="WrapText" 
            style="font-size:10.5pt;text-align:center;" 
            onrowdatabound="GridView4_RowDataBound" ForeColor="Black" 
           >
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
             <Columns>
                <asp:BoundField DataField="CUSTREGNO" HeaderText="REGNO">
                 <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NAME" HeaderText="NAME" >
                             <ItemStyle Width="180px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="APPNO" HeaderText="ARAZI" >
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                           <asp:BoundField DataField="plotno" HeaderText="P.NO" >
                           <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="P.SIZE" >
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="date3" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" >
                             <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHECKBY" HeaderText="CHECKBY">
                            <ItemStyle Width="110px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="date" HeaderText="CALL DATE" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="80px" />
                               </asp:BoundField>
                            <asp:BoundField DataField="reason" HeaderText="FEEDBACK" >
                            <ItemStyle Width="200px" />
                               </asp:BoundField>
                               <asp:BoundField DataField="feeddate" HeaderText="Given Date" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="70px" />
                               </asp:BoundField>
				  <asp:TemplateField ItemStyle-Width="90">
                                    <HeaderTemplate>
                                        ENTRY TIME
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                         <asp:Label ID="date4" runat="server" Text='<%# Eval("entrytime") %>' 
                                             ForeColor="Green" Font-Bold="True" style="text-align:center;"></asp:Label>-
										 <asp:Label ID="date5" runat="server" Text='<%# Eval("demo") %>'  
                                             ForeColor="Red" Font-Bold="True" style="text-align:center;"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="90"></ItemStyle>
                                </asp:TemplateField>
                           <asp:BoundField DataField="advance" HeaderText="Advance" >
                             <ItemStyle Width="60px" />
                            </asp:BoundField>
                            
                             <asp:HyperLinkField Text="Call Now" DataNavigateUrlFields="CUSTREGNO,NAME,MOBILE" DataNavigateUrlFormatString="~/dailer/dialerhome.aspx?CUSTREGNO={0}&NAME={1}&MOBILE={2}" target="_blank"/>
                 </Columns>
        </asp:GridView>
		
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
