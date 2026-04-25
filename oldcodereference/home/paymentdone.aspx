<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paymentdone.aspx.cs" Inherits="dialer_paymentdone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {

          $("#TextBox5").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox2").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox12").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox11").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox14").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox15").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox16").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
         

      });
    </script>
    <style type="text/css">
        #rt
        {
            float:left;
            width:50%;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style5 {
            text-align: left;
            height: 42px;
        }
        .auto-style6 {
            height: 45px;
        }
        .auto-style7 {
            height: 47px;
        }
        .auto-style8 {
            height: 6px;
        }
        .auto-style9 {
            height: 44px;
            text-align: right;
        }
        .auto-style10 {
            height: 22px;
        }
        .auto-style11 {
            width: 100%;
            height: 244px;
        }
        .auto-style12 {
            height: 56px;
        }
        .auto-style13 {
            text-align: center;
        }
        .auto-style14 {
            text-align: center;
            width: 149px;
        }
        .auto-style15 {
            width: 30%;
            height: 41px;
        }
        .auto-style16 {
            height: 33px;
            font-weight: 900;
            font-size: 15pt;
        }
        .auto-style17 {
            height: 100%;
            width: 100%;
        }
        .auto-style18 {
            height: 33px;
            font-weight: 900;
            font-size: 15pt;
            color: #FFFFFF;
        }
        .auto-style19 {
            height: 32px;
        }
        .style1
        {
            color: #FFFFFF;
            text-align: center;
            height: 23.5px;
        }
        .style2
        {
            height: 28px;
        }
        .style31
        {
            color: #000000;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="width:100%;"><table class="auto-style15"><tr><td class="auto-style14">
        <asp:Button ID="Button4" runat="server" BackColor="#66FF99" 
            BorderColor="#003300" BorderStyle="Ridge" Font-Bold="True" ForeColor="#660066" 
            OnClick="Button4_Click" Text="ADVOCATE" />
        </td><td class="auto-style13"><strong>
            <asp:Button ID="Button5" runat="server" BackColor="Aqua" BorderColor="#660066" BorderStyle="Ridge" CssClass="ui-priority-primary" OnClick="Button5_Click" Text="DAKHIL KHARIJ" />
            </strong></td></tr></table></div>
        <asp:Panel ID="Panel1" runat="server">
                   <div class="auto-style17">


                       <table class="auto-style2">
                           <tr>
                               <td style="text-align:center; background-color: #008080;" class="auto-style18" 
                                   colspan="2">ADVOCATE PAYMENT (21/Aug/2022)</td>
                           </tr>
                           <tr>
                               <td style="text-align: left" ><strong>Select Advocate</strong>&nbsp;&nbsp;
                                   <span class="style31">
                                   <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" 
                                       Height="25px" onselectedindexchanged="DropDownList7_SelectedIndexChanged" 
                                       style="font-weight: 700" Width="106px">
                                       <asp:ListItem>---Select---</asp:ListItem>
                                       <asp:ListItem>ADV. IQBAL</asp:ListItem>
                                       <asp:ListItem>ADV. SUNIL</asp:ListItem>
									   <asp:ListItem>ADV. AMIT SAINI</asp:ListItem>	
									    <asp:ListItem>YASEEN</asp:ListItem>
                                   </asp:DropDownList>
                                   &nbsp;&nbsp; </span></td>
                               <td class="auto-style9">
                                   Please select date before using monthwise payment option</td>
                           </tr>
                           <tr>
                               <td class="auto-style7"><strong>TOTAL AMT&nbsp;&nbsp;
                                   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PAID&nbsp;&nbsp;
                                   <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp; BALANCE&nbsp;
                                   <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;
                                   <asp:Label ID="Label12" runat="server" Text="ADVANCE PAID"></asp:Label>
                                   </strong></td>
                               <td bgcolor="#00FFCC" class="auto-style7">
                                   <asp:Button ID="Button16" runat="server" Height="31px" onclick="Button16_Click" 
                                       style="font-weight: 700; font-size: x-small;" Text="Monthwise Payment" 
                                       Width="137px" />
                                   <strong>&nbsp;&nbsp;&nbsp;TOTAL AMT&nbsp;
                                   <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                                   &nbsp; &nbsp;&nbsp;TOTAL WORK&nbsp;&nbsp;
                                   <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;PENDING WORK&nbsp;&nbsp;
                                   <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                                   </strong>
                               </td>
                           </tr>
                           <tr>
                               <td class="auto-style5" colspan="2">
                                   <asp:Panel ID="Panel3" runat="server">
                                   
                                   <strong>ADD NAME</strong>&nbsp;
                                   <asp:TextBox ID="TextBox8" runat="server" Width="110px" Height="25px"></asp:TextBox>
                                   &nbsp;&nbsp;
                                   <asp:Button ID="Button6" runat="server" BackColor="#000066" Font-Bold="True" ForeColor="White" OnClick="Button6_Click" Text="ADD" />
                                   &nbsp;&nbsp; <strong>
                                   <asp:Label ID="Label10" runat="server" ForeColor="Red"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DELETE ID
                                   <asp:TextBox ID="TextBox10" runat="server" Height="25px" Width="42px"></asp:TextBox>
                                   &nbsp;
                                   <asp:Button ID="Button7" runat="server" BackColor="#99FF33" BorderColor="#660066" CssClass="ui-priority-primary" OnClick="Button7_Click" Text="DEL" Width="40px" />
                                   </strong></asp:Panel></td>
                           </tr>
                           <tr>
                               <td class="auto-style12" colspan="2">
                                   <asp:Panel ID="Panel4" runat="server">
                                   <strong>NAME&nbsp;&nbsp;&nbsp;
                                   <asp:DropDownList ID="DropDownList3" runat="server" Height="25px">
                                   </asp:DropDownList>
                                   &nbsp;&nbsp;&nbsp; DATE&nbsp;
                                   <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="109px"></asp:TextBox>
                                   &nbsp; TYPE&nbsp;
                                   <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                       <asp:ListItem>--SELECT--</asp:ListItem>
                                       <asp:ListItem>CASH</asp:ListItem>
                                       <asp:ListItem>TRANSECTION</asp:ListItem>
                                   </asp:DropDownList>
                                   &nbsp;&nbsp;&nbsp; NO.&nbsp;
                                   <asp:TextBox ID="TextBox9" runat="server" Height="25px" Width="102px"></asp:TextBox>
                                   &nbsp;AMOUNT&nbsp;
                                   <asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="102px"></asp:TextBox>
                                   &nbsp; REAMRK</strong>&nbsp;&nbsp;
                                   <asp:TextBox ID="TextBox4" runat="server" Width="219px" Height="25px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                                   <asp:Button ID="Button2" runat="server" BackColor="#003300" Font-Bold="True" ForeColor="White" Text="PAID" Height="29px" OnClick="Button2_Click" />
                                   <strong>
                                   <asp:Label ID="Label8" runat="server" ForeColor="Red"></asp:Label>
                                   </strong></asp:Panel>
                               </td>
                           </tr>
                           <tr>
                               <td class="auto-style19" style="background-color: #FFCCFF" colspan="2"><strong>NAME
                                   <asp:DropDownList ID="DropDownList5" runat="server" Height="25px" Width="62px">
                                   </asp:DropDownList>
                                   &nbsp; FROM</strong> <strong>
                                   <asp:TextBox ID="TextBox11" runat="server" Height="24px" Width="93px"></asp:TextBox>
                                   &nbsp;&nbsp; TO&nbsp;
                                   <asp:TextBox ID="TextBox12" runat="server" Height="25px" Width="91px"></asp:TextBox>
                                   &nbsp;&nbsp;
                                   <asp:Button ID="Button8" runat="server" CssClass="ui-priority-primary" Text="VIEW" Width="55px" Height="26px" OnClick="Button8_Click" />
                                   </strong>&nbsp;&nbsp;&nbsp; <strong>
                                   <asp:Button ID="Button9" runat="server" CssClass="ui-priority-primary" Text="ALL DETAILS" Width="100px" OnClick="Button9_Click" />
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TOTAL AMT&nbsp;
                                   <asp:Label ID="Label15" runat="server" Text="Label" style="font-size: medium"></asp:Label>
                                   &nbsp;&nbsp; PAID AMOUNT&nbsp;
                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="15pt" 
                                       ForeColor="#003300" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp; BALANCE&nbsp;
                                   <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:Label ID="Label17" runat="server" Text="ADVANCE PAID"></asp:Label>
                                   </strong></td>
                           </tr>
                           <tr>
                               <td class="auto-style10" colspan="2">
                              <div id="rt">
                                   <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" Width="100%" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" style="text-align:left;">
                                      <Columns>
                                <asp:TemplateField ItemStyle-Width="20">
                                    <HeaderTemplate>
                                        ID
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id888" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        NAME
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100">
                                    <HeaderTemplate>
                                        DATE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="date1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="11%"></ItemStyle>
                                </asp:TemplateField>
                                          <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        MODE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id11" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                          <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        TRANS.No
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id11" runat="server" Text='<%# Eval("transno") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                               <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        AMOUNT
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id111" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                              <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        REMARK
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id1111" runat="server" Text='<%# Eval("remark") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="44%"></ItemStyle>
                                </asp:TemplateField>
                                          </Columns>
                                        <AlternatingRowStyle BackColor="white" />
                                       <FooterStyle BackColor="#CCCCCC" />
                                       <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                       <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                       <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                       <SortedAscendingHeaderStyle BackColor="#808080" />
                                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                       <SortedDescendingHeaderStyle BackColor="#383838" />
                                   </asp:GridView></div><div id="rt">
                                       <table class="auto-style2">
                                           <tr>
                                               <td bgcolor="Black" class="style1">
                                                   <strong>EXPENSES OF ADVANCE PAYMENT&nbsp; ID
                                                   <asp:TextBox ID="TextBox19" runat="server" Height="24px" Width="69px"></asp:TextBox>
                                                   &nbsp;&nbsp;
                                                   <asp:Button ID="Button14" runat="server" onclick="Button14_Click" Text="DEL" 
                                                       Width="47px" />
                                                   &nbsp;
                                                   <asp:Label ID="Label18" runat="server" style="color: #FF0000; font-weight: 700" 
                                                       Text="Label"></asp:Label>
                                                   </strong></td>
                                           </tr>
                                           <tr>
                                               <td class="style2" bgcolor="#3366FF">
                                                   DATE&nbsp;
                                                   <asp:TextBox ID="TextBox16" runat="server" Height="24px" Width="76px"></asp:TextBox>
                                                   &nbsp; AMOUNT&nbsp;
                                                   <asp:TextBox ID="TextBox17" runat="server" Height="24px" Width="69px"></asp:TextBox>
                                                   &nbsp; REASON
                                                   <asp:TextBox ID="TextBox18" runat="server" Height="27px" Width="179px"></asp:TextBox>
                                                   &nbsp;&nbsp;
                                                   <asp:Button ID="Button13" runat="server" Text="ADD" onclick="Button13_Click" />
                                                   &nbsp; </td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   <asp:GridView ID="GridView3" runat="server" BackColor="White"  style="text-align:left;" Width=100%
                                                       BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                                       ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                                                        <Columns>
                                <asp:TemplateField ItemStyle-Width="20">
                                    <HeaderTemplate>
                                        ID
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id8888" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%"></ItemStyle>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="100">
                                    <HeaderTemplate>
                                        DATE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="date11" runat="server" Text='<%# Eval("padate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        AMOUNT
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id1145" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        REMARK
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id1" runat="server" Text='<%# Eval("remark") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70%"></ItemStyle>
                                </asp:TemplateField>
                               
                                          
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
                                   </div>
                               </td>
                           </tr>
                       </table>


                   </div>
               </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
                   <div style="height:100%;width:100%;">
                       <table class="auto-style11">
                           <tr>
                                <td style="text-align:center; background-color: bisque;" class="auto-style16" 
                                    colspan="2">DAKHIL-KHARIJ PAYMENT</td>
                              
                           </tr>
                           <tr>
                               <td class="auto-style6" colspan="2"><strong>ADD NAME</strong>&nbsp;
                                   <asp:TextBox ID="TextBox1" runat="server" Width="110px"></asp:TextBox>
&nbsp;&nbsp;
                                   <asp:Button ID="Button1" runat="server" BackColor="#000066" Font-Bold="True" ForeColor="White" Text="ADD" OnClick="Button1_Click" />
&nbsp;&nbsp; <strong>
                                   <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp; DELETE ID
                                   <asp:TextBox ID="TextBox13" runat="server" Height="25px" Width="42px"></asp:TextBox>
                                   &nbsp;
                                   <asp:Button ID="Button10" runat="server" BackColor="#99FF33" BorderColor="#660066" CssClass="ui-priority-primary" OnClick="Button10_Click" Text="DEL" Width="40px" />
                                   </strong></td>
                           </tr>
                           <tr>
                               <td class="auto-style7"><strong>TOTAL AMT&nbsp;
                                   <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;PAID&nbsp;&nbsp;
                                   <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BALANCE&nbsp;
                                   <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:Label ID="Label13" runat="server" Text="ADVANCE PAID"></asp:Label>
                                   </strong></td>
                               <td bgcolor="#CCFF66" class="auto-style7">
                                   <strong>TOTAL AMT&nbsp;
                                   <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PAID&nbsp;&nbsp;
                                   <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BALANCE&nbsp;
                                   <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;
                                   <asp:Label ID="Label22" runat="server" Text="ADVANCE PAID"></asp:Label>
                                   </strong>
                               </td>
                           </tr>
                           <tr>
                               <td class="auto-style8" colspan="2">
                               </td>
                           </tr>
                           <tr>
                               <td class="auto-style12" colspan="2"><strong>NAME &nbsp;
                                   <asp:DropDownList ID="DropDownList2" runat="server" Height="25px">
                                   </asp:DropDownList>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DATE&nbsp;
                                   <asp:TextBox ID="TextBox5" runat="server" Height="25px" Width="81px"></asp:TextBox>
&nbsp; AMOUNT&nbsp;
                                   <asp:TextBox ID="TextBox6" runat="server" Height="25px" Width="113px"></asp:TextBox>
&nbsp; REAMRK</strong>&nbsp;&nbsp;
                                   <asp:TextBox ID="TextBox7" runat="server" Width="321px" Height="25px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                                   <asp:Button ID="Button3" runat="server" BackColor="#003300" Font-Bold="True" ForeColor="White" Text="PAID" OnClick="Button3_Click" />
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
                                   <asp:Label ID="Label9" runat="server" ForeColor="Red"></asp:Label>
                                   </strong></td>
                           </tr>
                           <tr>
                               <td class="auto-style9" style="background-color: #FFFF99" colspan="2"><strong>NAME
                                   <asp:DropDownList ID="DropDownList6" runat="server" Height="25px">
                                   </asp:DropDownList>
                                   &nbsp; FROM</strong> <strong>
                                   <asp:TextBox ID="TextBox14" runat="server" Height="25px" Width="109px"></asp:TextBox>
                                   &nbsp;&nbsp; TO&nbsp;
                                   <asp:TextBox ID="TextBox15" runat="server" Height="25px" Width="109px"></asp:TextBox>
                                   &nbsp;&nbsp;
                                   <asp:Button ID="Button11" runat="server" CssClass="ui-priority-primary" Height="26px" OnClick="Button11_Click" Text="VIEW" Width="55px" />
                                   </strong>&nbsp;&nbsp;&nbsp; <strong>
                                   <asp:Button ID="Button12" runat="server" CssClass="ui-priority-primary" OnClick="Button12_Click" Text="ALL DETAILS" Width="100px" />
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PAID AMOUNT&nbsp;
                                   <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="15pt" ForeColor="#003300" Text="Label"></asp:Label>
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   </strong>
                                   <asp:Button ID="Button15" runat="server" Height="27px" onclick="Button15_Click" 
                                       style="font-weight: 700" Text="Month Wise Payment" Width="147px" />
                               </td>
                           </tr>
                           <tr>
                               <td colspan="2">
                                   <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" Width="100%" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                                      <Columns>
                                <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        ID
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id888" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        NAME
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100">
                                    <HeaderTemplate>
                                        DATE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="date1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                          
                                               <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        AMOUNT
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id111" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%"></ItemStyle>
                                </asp:TemplateField>
                                              <asp:TemplateField ItemStyle-Width="30">
                                    <HeaderTemplate>
                                        REMARK
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="id1111" runat="server" Text='<%# Eval("remark") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="46%"></ItemStyle>
                                </asp:TemplateField>
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
                   </div>
                </asp:Panel>
    </div>
    </form>
</body>
</html>
