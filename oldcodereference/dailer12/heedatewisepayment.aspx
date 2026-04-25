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
            width: 252px;
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
<body style="background-color:#fff;">
    <form id="form1" runat="server">
    <div>
    <h3 style="padding:5px;background-color:Black;color:White;">! Welcome - <asp:TextBox ID="TextBox4" runat="server" Height="26px" ReadOnly="True" BorderStyle=None BackColor=Black ForeColor=White Font-Bold=true></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CHECK PAID INSTALLMENT</h3>
        <table style="width:100%;height:100%;" BORDER="1" rules="rows">
<tr height="45px" style="text-align:right;">
     <td style="font-weight:bold;" bgcolor="#F0F0F0" 
         class="style5">Total Back Call&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;
        <asp:Label ID="Label2222" runat="server"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dailed Call -
        <asp:Label ID="Label3333" runat="server"></asp:Label>
     &nbsp;&nbsp; Pending Call -
        <asp:Label ID="Label4444" runat="server"></asp:Label>
	     &nbsp;</td></tr>
 <tr height="45px" style="text-align:right;">
     <td style="font-weight:bold;" bgcolor="#FFCC99" 
         class="style4">Total Current Call -&nbsp; 
        <asp:Label ID="Label5555" runat="server"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dailed Call -
        <asp:Label ID="Label6666" runat="server"></asp:Label>
     &nbsp;&nbsp; Pending Call -
        <asp:Label ID="Label7777" runat="server"></asp:Label>
	     &nbsp;</td></tr>
 <tr height="45px"><td style="font-weight:bold;" bgcolor="#CCFF33" colspan="2">USER
     <asp:DropDownList ID="DropDownList5" runat="server" Height="19px" 
         style="font-weight: 700" Width="103px">
         <asp:ListItem>---SELECT---</asp:ListItem>
         <asp:ListItem>heedrealestate</asp:ListItem>
         <asp:ListItem>Ashok8396</asp:ListItem>
         <asp:ListItem>MACHHARIYAOFFICE</asp:ListItem>
     </asp:DropDownList>
     &nbsp;&nbsp;&nbsp; FROM&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="TextBox2" runat="server" class="d" Height="24px" Width="97px">MM/DD/YY</asp:TextBox>&nbsp;&nbsp; 
     TO&nbsp;&nbsp;
     <asp:TextBox ID="TextBox3" runat="server" class="d" Height="21px" Width="85px">MM/DD/YY</asp:TextBox>&nbsp;&nbsp;ARAZI NO&nbsp;&nbsp;<asp:DropDownList 
         ID="DropDownList3" runat="server" Height="24px" Width="109px">
         <asp:ListItem>-----SELECT-------</asp:ListItem>
     </asp:DropDownList>
     &nbsp;&nbsp;    <strong>STATUS&nbsp;    
     <asp:DropDownList ID="DropDownList4" 
         runat="server" Height="31px" 
            Width="95px">
        <asp:ListItem>-----SELECT------</asp:ListItem>
        
        <asp:ListItem>NON PAID</asp:ListItem>
        
        
        
         <asp:ListItem>ALL ARAZI NON PAID</asp:ListItem>
        
    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
     <asp:Button ID="Button1" runat="server" Height="26px" onclick="Button1_Click" 
         style="font-weight: 700" Text="VIEW" Width="68px" />
     &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button2" runat="server" Text="Advance" 
         onclick="Button2_Click" Font-Bold="True" Height="25px" Width="74px" />
     &nbsp;<asp:Label ID="Label1111" runat="server"></asp:Label>
     </td></tr>
 <tr><td style="font-weight:bold;" colspan="2" class="style2">
     &nbsp;</td>
    
    </tr>
    <tr><td colspan="2">
        <strong>CURRENT CALL DETAILS-</strong>
        <asp:GridView ID="GridView2" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Visible="False" Width="100%" 
            AutoGenerateColumns="False" AutoGenerateSelectButton="False" 
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
				  <asp:TemplateField HeaderText="Play">
                           <ItemTemplate>
                                <audio controls>
                                    <source src="<%# Eval("recording") %>" type="audio/mp3">
                                </audio>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
                            
                             
                 </Columns>
        </asp:GridView>
		
        <br />
        <strong>BACK CALL DETAILS -</strong><asp:GridView ID="GridView4" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" Visible="False" Width="100%" 
            AutoGenerateColumns="False" AutoGenerateSelectButton="False" 
            onselectedindexchanged="GridView4_SelectedIndexChanged" class="WrapText" 
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
                          
                            
                             <asp:TemplateField HeaderText="Play">
                           <ItemTemplate>
                                <audio controls>
                                    <source src="<%# Eval("recording") %>" type="audio/mp3">
                                </audio>
                            </ItemTemplate>
                        </asp:TemplateField>
                 </Columns>
        </asp:GridView>
		
        <br />
		
    </td></tr>
	<tr><td style="font-weight:bold;" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
	<tr><td style="font-weight:bold;" colspan="2">
                    <asp:GridView ID="GridView3" runat="server" BackColor="LightGoldenrodYellow" 
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                        GridLines="None" Width="100%" AutoGenerateColumns="False" Visible="False">
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
    <asp:Panel ID="Panel1" runat="server" Visible="False">
     <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style2" style="text-align: center">
                    <strong>CUSTOMER EMI DETAILS</strong></td>
            </tr>
            <tr>
                <td bgcolor="#66FF99" class="style3">
                    <b>CUSTOMER REG.NO.&nbsp;&nbsp;&nbsp;
                    </b>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="style4" Height="27px" 
                        style="font-size: large" Width="141px" ReadOnly="True"></asp:TextBox>
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;
                    </b>
                    <asp:Label ID="Label1" runat="server" style="color: #FF0000; " 
                        Text="Label" CssClass="style4"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#FF99FF" class="style5">
                    <b>ARAZI -&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT.NO -&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT SIZE -
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BOOKING DATE -
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; END DATE&nbsp; -
                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </b></td>
            </tr>
            <tr>
                <td bgcolor="#FFFFCC" class="style6">
                    <strong>NAME  </strong>- <b>
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </b></td>
            </tr>
            <tr>
                <td bgcolor="#CCCCCC">
                    <table class="style1">
                        <tr>
                            <td class="style15">
                    <strong>TOTAL AMOUNT&nbsp;</strong></td>
                            <td class="style16">
                                <b><asp:Label 
                        ID="Label6" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>RECIEVE AMOUNT&nbsp;</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE AMOUNT</b></td>
                            <td class="style13">
                                <b> <asp:Label ID="Label8" runat="server" 
                        Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>DOWN PAYMENT</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label16" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>RECIEVE D.P&nbsp;</b></td>
                            <td class="style17">
                                <b> <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE D.P</b></td>
                            <td class="style13">
                                <b>
                    <asp:Label ID="Label18" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>TOTAL EMI</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label9" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>PAID EMI&nbsp;</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE EMI</b></td>
                            <td class="style13">
                                <b>
                    <asp:Label 
                        ID="Label11" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>TOTAL MONTH EMI</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label20" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>NO. OF PAID EMI</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label21" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
&nbsp;&nbsp; =&nbsp;
                    <asp:Label ID="Label24" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE EMI MONTH</b></td>
                            <td class="style13">
                                <b>
                    <asp:Label 
                        ID="Label22" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>LATE EMI</b></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label12" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>LATE EMI PAYMENT</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label13" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                &nbsp;</td>
                            <td class="style13">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <strong>FIXED EMI</strong></td>
                            <td class="style16">
                                <b>
                    <asp:Label ID="Label23" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                &nbsp;</td>
                            <td class="style17">
                                &nbsp;</td>
                            <td class="style11">
                                &nbsp;</td>
                            <td class="style13">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style15">
                                <b>ADVANCE AMOUNT</b></td>
                            <td class="style16">
                                <b> <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <strong>LAST PAID DATE </strong></td>
                            <td class="style17">
                                <asp:Label ID="Label25" 
            runat="server" Text="Label"></asp:Label></td>
                            <td class="style11">
                              <strong>AMOUNT </strong></td>
                            <td class="style13">
                                 <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </table>
                    <b>&nbsp;</b><br />
                </td>
            </tr>
        </table>
    
    </div>
    
    </asp:Panel>
    </form>
</body>
</html>
