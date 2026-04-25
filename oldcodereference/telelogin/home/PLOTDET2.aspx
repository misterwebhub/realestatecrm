<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PLOTDET2.aspx.cs" Inherits="PLOTDET" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
		 .WrapText {  
            width: 100%;  
            word-break: break-all; 
        } 
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 101px;
            height: 41px;
        }
        .style9
        {
            height: 41px;
            width: 280px;
            color: #FF0000;
        }
        .style10
        {
            height: 38px;
            }
        .style29
        {
            height: 60px;
        }
        .style30
        {
            height: 41px;
            color: #FF0000;
        }
        .style31
        {
            color: #000000;
        }
        #view
        {
           
            height:50%;
            width:50%;
        }
       
        .sty
        {
            width: 756px;
             background-image:url('img/ki.jpg');
            height: 539px;
        }
        .arzno239
        {
            background-image:url('IMG/arazi239.jpg');
            width: 410px;
            height: 680px;
        }
        .AR100
        {
            background-image:url('IMG/arazi100.jpg');
            width: 827px;
            height: 330px;
        }
        .ar308
        {
            background-image:url('IMG/arazi308.jpg');
            width: 680px;
            height: 303px;
        }
        .ar2011
        {
            background-image:url('IMG/arazi2011.jpg');
            width: 557px;
            height: 574px;
        }
        .ar293a
        {
            background-image:url('IMG/arazi293AB.jpg');
            width: 981px;
            height: 327px;
        }
        .ar293a&b
        {
            width: 420px;
        }
        .ar293a&b
        {
            width: 382px;
        }
        .style32
        {
            height: 17px;
            color: #FF0000;
        }
        .style34
        {
            height: 17px;
            color: #FF0000;
        }
        .style35
        {
            color: #FF0000;
        }
        </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
</head>
<body bgcolor="White" style="font-weight: 700">
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" border="2">
            <tr>
                <td colspan="3" style="text-align: center" class="style29">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="21pt" 
                        ForeColor="#660033" style="text-align: center" Text="Plote Details Form"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style9" style="text-align: right">
                    ARAZI NUMBER&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" 
                        style="margin-left: 0px" Width="128px" AutoPostBack="False" 
                        CssClass="style31">
                        <asp:ListItem>-----SELECT-------</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    <asp:Button ID="Button3" runat="server" Font-Bold="True" ForeColor="#003399" 
                        onclick="Button3_Click" Text="VIEW" Width="81px" CssClass="style31" 
                        style="text-align: left; margin-left: 13px;" />
                </td>
                <td class="style30" bgcolor="#00FF99">
                    <span class="style31">&nbsp;<asp:Panel ID="Panel1" runat="server">
                    
                        &nbsp;<asp:Label ID="Label4" runat="server" 
                        ForeColor="Red" Text="Reg No."></asp:Label>
                    &nbsp;&nbsp;
                    </span>
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="14pt" Height="23px" 
                        style="margin-top: 0px" Width="101px"></asp:TextBox>
&nbsp; Registry Status
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="22px" Width="86px">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>Registry</asp:ListItem>
                        <asp:ListItem>Cancel</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button4" runat="server" BackColor="Black" ForeColor="White" 
                        style="font-weight: 700; margin-left: 7px; height: 26px;" Text="OK" 
                        Width="43px" onclick="Button4_Click" /></asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style32" style="text-align: center" bgcolor="#FFFF66" colspan="2">
                    RAGISTRY FREE</td>
                <td class="style34" bgcolor="#00FF99">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style32" style="text-align: left" bgcolor="#FFFF66" colspan="2">
                    <asp:Panel ID="Panel3" runat="server">
                    
                    REG. No.&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Height="24px" Width="96px"></asp:TextBox>
&nbsp; AMT
                    <asp:TextBox ID="TextBox4" runat="server" Height="26px" Width="72px"></asp:TextBox>
&nbsp;
                    <asp:Button ID="Button6" runat="server" Height="27px" onclick="Button6_Click" 
                        style="font-weight: 700" Text="FREE" Width="49px" /></asp:Panel>
                </td>
                <td class="style34" bgcolor="#00FF99">
                    <span class="style31">
                        <asp:Panel ID="Panel2" runat="server">
                        <asp:Label ID="Label6" runat="server" 
                        ForeColor="Red" Text="Reg No."></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    </span>
                    <asp:TextBox ID="TextBox2" runat="server" Width="106px"></asp:TextBox>
&nbsp; Move Status&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="94px">
                        <asp:ListItem>-----Select-----</asp:ListItem>
                        <asp:ListItem>completed</asp:ListItem>
                    </asp:DropDownList>
&nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" BackColor="#CCFFFF" Font-Bold="True" 
                        Height="26px" onclick="Button5_Click1" Text="Move" Width="59px" /> </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style32" style="text-align: right" bgcolor="#FFFF66" colspan="2">
                    <asp:Label ID="Label7" runat="server" style="text-align: right"></asp:Label>
                </td>
                <td class="style34" bgcolor="#00FF99">
                    &nbsp;&nbsp; Search By Plot No
                    &nbsp;<asp:TextBox ID="TextBox5" runat="server" Width="74px" Height="23px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button7" runat="server" BackColor="Red" ForeColor="White" 
                        onclick="Button7_Click" style="font-weight: 700" Text="Search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search By Name
                    &nbsp;<asp:TextBox ID="TextBox6" runat="server" Width="74px" Height="23px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button8" runat="server" BackColor="Red" ForeColor="White" 
                        onclick="Button8_Click1" style="font-weight: 700" Text="By Name" />
                </td>
            </tr>
            <tr>
                <td class="style35" style="text-align: right" colspan="3">
                    <div style="height: 2px; text-align: left;">
                        
                    </div>&nbsp;</td>
            </tr>
            <tr>
                <td class="style10" colspan="3">
					 <div class="WrapText">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                        Height="66px" Visible="False" Width="100%" 
                        onrowdatabound="GridView1_RowDataBound" CellSpacing="1" GridLines="None" 
                        AutoGenerateColumns="False" style="text-align:left;" >

                        <Columns>
                            <asp:BoundField DataField="PLOTNO" HeaderText="PLOT NO" >
                            <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="CUSTREGNO">
                             <ItemStyle Width="110px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="PLOT SIZE" />
                            <asp:BoundField DataField="DATE" HeaderText="DATE" DataFormatString = "{0:dd/MM/yyyy}">
                             <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NAME" HeaderText="NAME" >
                            <ItemStyle Width="350px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BROKER" HeaderText="BROKER">
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" />
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                            <asp:BoundField DataField="RAGISTRY" HeaderText="FREE" />
                            <asp:BoundField DataField="RAGISTRYAMT" HeaderText="RAGISTRY AMT" />
                        </Columns>

                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black"  />
						 <AlternatingRowStyle Width="100px" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
					</div>
                    <br />
                </td>
            </tr>
             <tr>
                <td colspan="3">
                    <asp:Label ID="Label2" runat="server" Text="Total plot size"></asp:Label>
&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                 </td>
            </tr>
             <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                        GridLines="Horizontal" Height="143px" Width="100%" 
                        onrowdatabound="GridView2_RowDataBound" AutoGenerateColumns="False">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                        <Columns>
                         <asp:TemplateField>
                  <HeaderTemplate>PLOT NO.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("plotno") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>CUSTREG NO.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson2" runat="server" Text='<%# Eval("CUSTREGNO") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>PLOT SIZE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson3" runat="server" Text='<%# Eval("PLOTSIZE") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson4" runat="server" Text='<%# Eval("date3","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson5" runat="server" Text='<%# Eval("NAMEDOBADDRESS") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>CHECKBY</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson6" runat="server" Text='<%# Eval("CHECKBY") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>MOBILE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson7" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson8" runat="server" Text='<%# Eval("regstatus") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>RAGISTRY</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson9" runat="server" Text='<%# Eval("ragistry") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <HeaderTemplate>Reg.AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson10" runat="server" Text='<%# Eval("ragistryamt") %>'></asp:Label>
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