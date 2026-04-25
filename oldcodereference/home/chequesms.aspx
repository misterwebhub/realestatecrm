<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chequesms.aspx.cs" Inherits="chequesms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>cheque sms</title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {

          $("#TextBox2").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#CPAID").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
         

      });
    </script>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 282px;
        }
        .style2
        {
            text-align: center;
            height: 45px;
            font-size: large;
        }
        .style3
        {
            height: 20px;
        }
        .style4
        {
            width: 100%;
        }
        .style5
        {
            color: #FFFFFF;
        }
        .style7
        {
            color: #FFFFFF;
            width: 187px;
        }
        .style8
        {
        }
        .style9
        {
            color: #FFFFFF;
            width: 196px;
        }
        .style16
        {
            width: 150px;
            height: 19px;
        }
        .style17
        {
            width: 173px;
            height: 19px;
        }
        .style18
        {
            width: 150px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style19
        {
            color: #FFFFFF;
            width: 173px;
            font-weight: bold;
        }
        .style21
        {
            color: #FFFFFF;
            width: 187px;
            font-weight: bold;
        }
        .style22
        {
        }
        .style26
        {
            color: #FFFFFF;
            width: 55px;
        }
        .style29
        {
            color: #FFFFFF;
            width: 106px;
        }
        .style35
        {
            width: 142px;
        }
        .style38
        {
            width: 81px;
        }
        .style39
        {
            color: #FFFFFF;
            width: 94px;
        }
        .style41
        {
            width: 91px;
            color: #FFFFFF;
        }
        .style43
        {
            width: 163px;
        }
        .style44
        {
            width: 171px;
        }
        .style45
        {
            width: 88px;
        }
        .style46
        {
            color: #FFFFFF;
            width: 133px;
        }
        .style47
        {
            width: 105px;
        }
        .style48
        {
            color: #FFFFFF;
            width: 266px;
        }
        .style49
        {
            width: 187px;
            height: 19px;
        }
        .style50
        {
            color: #FFFFFF;
            width: 113px;
        }
        .style51
        {
            width: 113px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style52
        {
            width: 113px;
            height: 19px;
        }
        .style53
        {
            width: 150px;
            color: #FFFFFF;
        }
        .style57
        {
            height: 19px;
        }
        .style58
        {
            color: #FFFFFF;
        }
        .style59
        {
            width: 168px;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style60
        {
            width: 168px;
            height: 19px;
        }
        .style61
        {
            color: #FFFFFF;
            width: 143px;
        }
        .style62
        {
            height: 19px;
            width: 143px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:90%;height:980px;margin-left:5%;background-color:#D0F8FA;border-radius:10px;">
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="3" bgcolor="#CCFF33">
                    <strong>CUSTOMER CHEQUE PAYMENT DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Button ID="Button1" runat="server" BackColor="#000066" ForeColor="White" 
                        onclick="Button1_Click" style="font-weight: 700" Text="CHEQUE ENTRY" 
                        Width="158px" />
                </td>
                <td class="style3">
                    <asp:Button ID="Button2" runat="server" BackColor="Maroon" ForeColor="White" 
                        onclick="Button2_Click" style="font-weight: 700" Text="CHEQUE EDIT/UPDATE" 
                        Width="180px" />
                </td>
                <td class="style3">
                    <asp:Button ID="Button3" runat="server" BackColor="#003300" ForeColor="White" 
                        onclick="Button3_Click" style="font-weight: 700" Text="CHEQUE DETAILS" />
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink1" runat="server" BackColor="Lime" 
                        BorderColor="#000066" BorderStyle="Dashed" Height="21px" 
                        style="text-align: center; font-weight: 700;text-decoration:none;" 
                        Width="120px" Target="_blank" NavigateUrl="deletecheque.aspx">Delete Cheque</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel1" runat="server" BackColor="#000066" Height="250px" style="width:100%;">
                        <table class="style4">
                            <tr>
                                <td class="style7">
                                    <b>&nbsp;CUST. REG-
                                    <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="81px"></asp:TextBox>
                                    </b>
                                </td>
                                <td class="style50">
                                    <asp:Button ID="Button4" runat="server" Height="22px" onclick="Button4_Click" 
                                        style="font-weight: 700" Text="SEARCH" Width="74px" />
                                </td>
                                <td class="style53">
                                    <b>ARAZI-
                                    <asp:Label ID="Label4891" runat="server" ForeColor="Yellow" 
                                        style="font-weight: 700"></asp:Label>
                                    </b>
                                </td>
                                <td class="style58" colspan="2">
                                    <b>NAME- </b>
                                    <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style61">
                                    <b>PLOT NO- </b>
                                    <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style5">
                                    <b>PLOT SIZE- </b>
                                    <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style21">
                                    CHEQUE DATE</td>
                                <td class="style51">
                                    CHEQUE NO.</td>
                                <td class="style18">
                                    CHEQUE AMOUNT</td>
                                <td class="style59">
                                    STATUS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td class="style19">
                                    &nbsp;CHEUQE TYPE</td>
                                <td class="style61">
                                    <strong>TOTAL AMT</strong></td>
                                <td>
                                    <asp:Label ID="Label4890" runat="server" ForeColor="White"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style49">
                                    <asp:TextBox ID="TextBox2" runat="server" Height="19px" Width="103px"></asp:TextBox>
                                </td>
                                <td class="style52">
                                    <asp:TextBox ID="TextBox3" runat="server" Height="19px" Width="77px"></asp:TextBox>
                                </td>
                                <td class="style16">
                                    <asp:TextBox ID="TextBox4" runat="server" Height="19px" Width="92px"></asp:TextBox>
                                </td>
                                <td class="style60">
                                    <asp:TextBox ID="TextBox5" runat="server" Font-Bold="True" Height="20px" 
                                        ReadOnly="True" Width="101px">UNPAID</asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="style17">
                                    <asp:DropDownList ID="DropDownList2" runat="server" Height="24px" Width="90px">
                                        <asp:ListItem>MENTION</asp:ListItem>
                                        <asp:ListItem>---SELECT----</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style62">
                                    <asp:Button ID="Button7" runat="server" Font-Bold="True" 
                                        onclick="Button5_Click" Text="SUBMIT" Height="25px" />
                                </td>
                                <td class="style57">
                                    <asp:Label ID="Label10" runat="server" ForeColor="White"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8" colspan="7">
                                    <asp:Label ID="Label4892" runat="server" ForeColor="Yellow" 
                                        style="font-weight: 700; font-size: xx-large" Text="Label"></asp:Label>
                                    <br />
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" GridLines="Horizontal" style="text-align:left;width:100%;" 
                                       onrowdatabound="GridView2_RowDataBound">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                        <Columns>
                                         <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                   ID
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1279" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    CHEQUE DATE
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1280" runat="server" 
                                                        Text='<%# Eval("CDATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    CHEQUE NO.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1281" runat="server" Text='<%# Eval("CHEQUENO") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    AMOUNT
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1282" runat="server" Text='<%# Eval("CAMOUNT") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                              <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>CHEQUE TYPE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1283" runat="server" Text='<%# Eval("CHEQUETYPE") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="20px"></ItemStyle>
                  </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    STATUS
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1284" runat="server" Text='<%# Eval("STATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    PAID DATE
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1285" runat="server" 
                                                        Text='<%# Eval("paiddate","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    DELETE
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1286" runat="server" Text='<%# Eval("deletevalue") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Select Data">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chkSelect1" runat="server" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect1" runat="server" AutoPostBack="True" 
                                                        OnCheckedChanged="check" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="imgActive0" runat="server" style="height:30px;width:30px;" />
                                                </ItemTemplate>
                                                <ItemStyle Height="20px" Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    BOUNCE STATUS
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1287" runat="server" Text='<%# Eval("BSTATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                    BOUNCE DATE
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id1288" runat="server" 
                                                        Text='<%# Eval("BDATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel2" runat="server" BackColor="Maroon" Height="233px" style="width:100%;">
                    <table class="style4">
                            <tr>
                                
                                <td class="style9">
                                    <b>CUST. REG- </b>
                                    <asp:TextBox ID="TextBox7" runat="server" Height="21px" Width="87px"></asp:TextBox>
                                </td>
                                <td class="style47">
                                    <asp:Button ID="Button8" runat="server" onclick="Button8_Click" Text="SEARCH" 
                                        style="height: 26px" />
                                </td>
                                <td class="style48">
                                    <b>NAME- </b>
                                    <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                                
                                <td class="style46">
                                    <b>ARAZI - </b>
                                    <asp:Label ID="Label13" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style5">
                                    <b>PLOT NO- </b>
                                    <asp:Label ID="Label11" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style5">
                                    <b>PLOT SIZE- </b>
                                    <asp:Label ID="Label12" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8" colspan="6">
                                     <asp:Label ID="Label14" runat="server" style="font-weight: 700" 
                                        ForeColor="Yellow"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8" colspan="6">
                                    <asp:GridView ID="GridView3" runat="server" Width="100%" 
                                        AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" DataKeyNames="ID" 
                                        onrowcancelingedit="GridView3_RowCancelingEdit" 
                                        onrowdeleting="GridView3_RowDeleting" onrowediting="GridView3_RowEditing" 
                                        onrowupdating="GridView3_RowUpdating" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="4">
                                        <Columns>
                                         <asp:TemplateField HeaderText="ID">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="ID" runat="server" Text='<%# Bind("ID") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="CHEQUE NO.">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="CHEQUENO" runat="server" Text='<%# Bind("CHEQUENO") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="CHEQUENO" runat="server" Text='<%# Bind("CHEQUENO") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="AMOUNT">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="CAMOUNT" runat="server" Text='<%# Bind("CAMOUNT") %>'>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="CAMOUNT" runat="server" Text='<%# Bind("CAMOUNT") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="CHEQUE TYPE">  
                            <EditItemTemplate>  
                                <asp:DropDownList ID="CHEQUETYPE" runat="server"   
SelectedValue='<%# Bind("CHEQUETYPE") %>'>  
                                    <asp:ListItem>--Select--</asp:ListItem>  
                                    <asp:ListItem>MENTION</asp:ListItem>  
                                    <asp:ListItem>OTHER</asp:ListItem>  
                                </asp:DropDownList>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label488" runat="server" Text='<%# Bind("CHEQUETYPE") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="STATUS">  
                            <EditItemTemplate>  
                                <asp:DropDownList ID="STATUS" runat="server"   
SelectedValue='<%# Bind("STATUS") %>'>  
                                    <asp:ListItem>--Select--</asp:ListItem>  
                                    <asp:ListItem>PAID</asp:ListItem>  
                                    <asp:ListItem>UNPAID</asp:ListItem>  
                                </asp:DropDownList>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label4888" runat="server" Text='<%# Bind("STATUS") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="PAID DATE">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="CPAID" runat="server" Text='<%# Bind("paiddate") %>' TextMode=DATE>  
                                </asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="CPAID" runat="server" Text='<%# Bind("paiddate","{0:dd, MMM yyyy}") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField> 
                                        </Columns>
                                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" ForeColor="#330099" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel3" runat="server" BackColor="#003300" Height="70px" style="width:100%;">
                        <table class="nav-justified">
                            <tr>
                                <td class="style41">
                                    <strong>CUST.REG-</strong></td>
                                <td class="style45">
                                    <asp:TextBox ID="TextBox6" runat="server" Height="23px" Width="76px"></asp:TextBox>
                                </td>
                                <td class="style38">
                                    <asp:Button ID="Button6" runat="server" Text="SEARCH" Width="65px" 
                                        onclick="Button6_Click" Height="26px" BackColor="#CCCCCC" />
                                </td>
                                <td class="style26">
                                    <strong>NAME</strong></td>
                                <td class="style35">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style29">
                                    <strong>ARAZI NO.</strong></td>
                                <td class="style43">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style39">
                                    <strong>PLOT NO.</strong></td>
                                <td class="style44">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Yellow"></asp:Label>
                                </td>
                                <td class="style5">
                                    <strong>PLOT SIZE</strong></td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Yellow"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style22" colspan="11">
                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                        GridLines="Vertical" style="text-align:left;width:100%;" 
                                        AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
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
                                         <Columns><asp:TemplateField ItemStyle-Width="8px">
                                                <HeaderTemplate>
                                                   ID
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="id121" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="9%" />
                                            </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>CHEQUE DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id122" runat="server" Text='<%# Eval("CDATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>CHEQUE NO.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id123" runat="server" Text='<%# Eval("CHEQUENO") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id124" runat="server" Text='<%# Eval("CAMOUNT") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>CHEQUE TYPE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id125" runat="server" Text='<%# Eval("CHEQUETYPE") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id126" runat="server" Text='<%# Eval("STATUS") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>PAID DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id127" runat="server" Text='<%# Eval("paiddate","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="10%"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>DELETE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id128" runat="server" Text='<%# Eval("deletevalue") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                  
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="imgActive" runat="server" style="height:30px;width:30px;" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" Height="20px"></ItemStyle>
                </asp:TemplateField>
                                             <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>BOUNCE STATUS</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1268" runat="server" Text='<%# Eval("BSTATUS") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>BOUNCE DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1278" runat="server" Text='<%# Eval("BDATE","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
											 <asp:TemplateField ItemStyle-Width="8px">
                  <HeaderTemplate>FINAL ST.</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id127899" runat="server" Text='<%# Eval("finalstatus") %>'></asp:Label>
                  </ItemTemplate>
                    <ItemStyle Width="9%"></ItemStyle>
                  </asp:TemplateField>
                  </Columns>
                                    </asp:GridView></td>
                                    </tr>
                                    <tr>
                                    <td  colspan="11">
                                    
                                        &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Click Me</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button9" runat="server" onclick="Button9_Click" 
                                        style="font-weight: 700" Text="TRANSFER AMOUNT" Visible="False" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label4889" runat="server" Text="Label" 
                                            style="color: #FF0000; font-weight: 700;"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button10" runat="server" CssClass="ui-priority-primary" 
                                        Height="26px" onclick="Button10_Click" Text="LOCK" Width="80px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button11" runat="server" CssClass="ui-priority-primary" 
                                        Height="26px" onclick="Button11_Click" Text="UNLOCK" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="11">
                                    TOTAL AMOUNT&nbsp;&nbsp;
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    &nbsp;&nbsp;&nbsp; MENTION AMT&nbsp;
                                    <asp:Label ID="Label4893" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp; OTHER AMT&nbsp;&nbsp;
                                    <asp:Label ID="Label4894" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        
                    </asp:Panel>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
