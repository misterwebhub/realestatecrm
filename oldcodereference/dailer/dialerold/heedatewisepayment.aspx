<%@ Page Language="C#" AutoEventWireup="true" CodeFile="heedatewisepayment.aspx.cs" Inherits="kishan_Bin_datewisepayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".d").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>

    <style type="text/css">
        .WrapText {  
            width: 100%;  
            word-break: break-all; 
        } 
        .style1
        {
        }
        .style2
        {
            height: 14px;
        }
        .style3
        {
            width: 256px;
        }
        .style4
        {
            height: 32px;
        }
        .style5
        {
            height: 30px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<table style="width:100%;height:100%;" BORDER="1" rules="rows">
<tr height="45px"><td colspan="3" style="font-size:20PT;text-align:center;">CHECK PAID INSTALLMENT </td></tr>
 <tr><td style="font-weight:bold;" bgcolor="#CCFF33" colspan="2" rowspan="2">&nbsp;User&nbsp;&nbsp;
     <asp:DropDownList ID="DropDownList5" runat="server" Height="19px" 
         style="font-weight: 700" Width="103px">
         <asp:ListItem>---SELECT---</asp:ListItem>
         <asp:ListItem>heedrealestate</asp:ListItem>
         <asp:ListItem>Ashok8396</asp:ListItem>
         <asp:ListItem>MACHHARIYAOFFICE</asp:ListItem>
     </asp:DropDownList>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
     <td style="font-weight:bold;" bgcolor="#F0F0F0" 
         class="style5">Total Back Call&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dailed Call -
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
     &nbsp;&nbsp; Pending Call -
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
	  &nbsp;&nbsp; PAID -
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
     </td></tr>
 <tr height="45px">
     <td style="font-weight:bold;" bgcolor="#FFCC99" 
         class="style4">Total Current Call -&nbsp; 
        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dailed Call -
        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
     &nbsp;&nbsp; Pending Call -
        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
	 &nbsp;&nbsp; PAID -
        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
     </td></tr>
 <tr height="45px"><td style="font-weight:bold;" bgcolor="#CCFF33" colspan="3">
     <asp:Panel ID="Panel1" runat="server">

 DATE FROM&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="TextBox2" runat="server" class="d" Height="24px" Width="105px">MM/DD/YY</asp:TextBox>&nbsp;&nbsp; DATE FROM&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="TextBox3" runat="server" class="d" Height="21px" Width="95px">MM/DD/YY</asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ARAZI NO&nbsp;&nbsp;<asp:DropDownList 
         ID="DropDownList3" runat="server" Height="23px" Width="126px">
         <asp:ListItem>-----SELECT-------</asp:ListItem>
     </asp:DropDownList>
     &nbsp;&nbsp;    <strong>STATUS&nbsp;    <asp:DropDownList ID="DropDownList4" 
         runat="server" Height="27px" 
            Width="118px">
        <asp:ListItem>-----SELECT------</asp:ListItem>
        
        <asp:ListItem>NON PAID</asp:ListItem>
        
        
        
         <asp:ListItem>ALL ARAZI NON PAID</asp:ListItem>
        
    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
     <asp:Button ID="Button1" runat="server" Height="26px" 
         style="font-weight: 700" Text="VIEW" Width="68px" />
     &nbsp;&nbsp; </asp:Panel>
     </td></tr>
 <tr height="45px"><td style="font-weight:bold;">DATE FROM</td><td class="style3"><asp:TextBox ID="TextBox1" runat="server" class="d" Height="22px" Width="183px">MM/DD/YY</asp:TextBox></td>
     <td style="font-weight:bold;" class="style1">&nbsp;&nbsp;
     <asp:DropDownList ID="DropDownList2" runat="server" Height="23px" Width="134px" 
             Visible="False">
         <asp:ListItem>-----SELECT-------</asp:ListItem>
     </asp:DropDownList>
         <strong>SELECT STATUS&nbsp;&nbsp;    <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" 
            Width="182px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True">
        <asp:ListItem>-----SELECT------</asp:ListItem>
        
        
        
         <asp:ListItem>ALL ARAZI NON PAID</asp:ListItem>
        
    </asp:DropDownList>&nbsp;
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></strong>
     </td></tr>
 <tr><td style="font-weight:bold;" colspan="3" class="style2">
     </td>
    
    </tr>
    <tr><td colspan="3">
        <strong>CURRENT CALL DETAILS-</strong>
        <asp:GridView ID="GridView2" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Visible="False" Width="100%" 
            AutoGenerateColumns="False"  
            class="WrapText" 
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
                            <ItemStyle Width="130px" />
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
                            
                 </Columns>
        </asp:GridView>
		
        <br />
        <strong>BACK CALL DETAILS -</strong><asp:GridView ID="GridView4" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Visible="False" Width="100%" 
            AutoGenerateColumns="False"  
           class="WrapText" 
            style="font-size:10.5pt;text-align:center;" onrowdatabound="GridView4_RowDataBound" ForeColor="Black" 
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
                            <ItemStyle Width="130px" />
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
                           
                            
                            
                 </Columns>
        </asp:GridView>
		
    
		
    </td></tr>
	<tr><td style="font-weight:bold;" colspan="3">CUSTOMER RECIPT DETAILS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
	<tr><td style="font-weight:bold;" colspan="3">
                    <asp:GridView ID="GridView3" runat="server" BackColor="LightGoldenrodYellow" 
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                        GridLines="None" Width="100%" AutoGenerateColumns="False">
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
                         <Columns>
                <asp:BoundField DataField="REGNO" HeaderText="CUSTREGNO" />
                            <asp:BoundField DataField="ADDRESS" HeaderText="NAME" />
                            <asp:BoundField DataField="PLAN" HeaderText="PLAN" />
                           <asp:BoundField DataField="VALUE" HeaderText="VALUE" />
                            <asp:BoundField DataField="RECIPT" HeaderText="RECIPT NO." />
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="INSTNO" HeaderText="INSTNO" />
                            <asp:BoundField DataField="AMOUNTR" HeaderText="AMOIUNT" />
                             <asp:BoundField DataField="APPNO" HeaderText="ARAZI NO." />
                 </Columns>
                    </asp:GridView>
                    
                    </td></tr>
</table>
    
    </div>
    </form>
</body>
</html>
