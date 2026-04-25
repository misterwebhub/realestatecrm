<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chequedetails.aspx.cs" Inherits="_30neeghanew_chequedetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REMINDER CHEQUE DETAILS</title>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBox1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
            height: 34px;
        }
        .style3
        {
            height: 47px;
        }
        .style4
        {
            height: 47px;
            width: 134px;
        }
        .style6
        {
            height: 47px;
            width: 100px;
            font-weight: bold;
        }
        .style7
        {
        }
        .style8
        {
            height: 47px;
            width: 74px;
            font-weight: bold;
        }
        .style10
        {
            font-weight: bold;
        }
        .style11
        {
            height: 47px;
            width: 165px;
        }
        .style13
        {
            height: 47px;
            width: 357px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:100%;width:90%;margin-left:5%;box-shadow:0px 0px 20px black;">
    
        <table class="style1">
            <tr>
                <td bgcolor="#000066" class="style2" colspan="6">
                    <strong style="color: #FFFFFF; font-size: large">REMINDER CHEQUE DETAILS</strong></td>
            </tr>
            <tr>
                <td bgcolor="#FFCC99" class="style6">
                    DATE FROM
                </td>
                <td bgcolor="#FFCC99" class="style4">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="style10" Height="25px" 
                        CLASS="d" Width="100px"></asp:TextBox>
                </td>
                <td bgcolor="#FFCC99" class="style8">
                    DATE TO</td>
                <td bgcolor="#FFCC99" class="style11">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="style10" Height="25px" 
                        CLASS="d" Width="100px"></asp:TextBox>
                </td>
                <td bgcolor="#FFCC99" class="style13">
                    <asp:Button ID="Button1" runat="server" Height="27px" style="font-weight: 700" 
                        Text="ALL ARAZI" Width="110px" onclick="Button1_Click" />
                &nbsp;&nbsp; <strong>TOTAL AMT - </strong>&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" ForeColor="Red" 
                        style="font-weight: 700; font-size: large; color: #000066"></asp:Label>
                </td>
                <td bgcolor="#FFCC99" class="style3">
					ARAZI&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="23px" 
                        style="margin-left: 0px" Width="128px" AutoPostBack="False" 
                        CssClass="style31">
                        <asp:ListItem>-----SELECT-------</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" Height="27px" style="font-weight: 700" 
                        Text="SINGLE ARAZI" Width="110px" onclick="Button2_Click" /><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
					
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="6">
                    <asp:GridView ID="GridView1" runat="server" 
                         Width="100%" AutoGenerateColumns="False" AutoGenerateEditButton="False" 
                        BackColor="White" Font-Size="10pt" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" 
                        onrowdatabound="GridView1_RowDataBound" Font-Bold=True DataKeyNames="ID" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                        >
                       
                        <Columns>
							<asp:TemplateField HeaderText="ID">                               
                            <ItemTemplate>  
                                <asp:Label ID="ID" runat="server" Text='<%# Bind("ID") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CUSTREGNO">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="CUSTREGNO" runat="server" Text='<%# Bind("CUSTREGNO") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="NAME">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="NAME" runat="server" Text='<%# Bind("NAME") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ARAZI">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="ARAZI" runat="server" Text='<%# Bind("ARAZI") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PLOT NO">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="PLOTNO" runat="server" Text='<%# Bind("PLOTNO") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PLOT SIZE">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="PLOTSIZE" runat="server" Text='<%# Bind("PLOTSIZE") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CHEUQE DATE">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="CDATE" runat="server" Text='<%# Bind("CDATE","{0:dd, MMM yyyy}") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="CHEUQE NO">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="CHEQUENO" runat="server" Text='<%# Bind("CHEQUENO") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AMOUNT">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="CAMOUNT" runat="server" Text='<%# Bind("CAMOUNT") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CHEQUE TYPE">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="CHEQUETYPE" runat="server" Text='<%# Bind("CHEQUETYPE") %>'>  
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
                                <asp:Label ID="STATUS" runat="server" Text='<%# Bind("STATUS") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CHECKBY">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="CHECKBY" runat="server" Text='<%# Bind("CHECKBY") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PAID DATE">  
                             <EditItemTemplate>  
                                <asp:TextBox ID="paiddate" runat="server" Text='<%# Bind("paiddate") %>' TextMode=DATE>  
                                </asp:TextBox>  
                            </EditItemTemplate> 
                            <ItemTemplate>  
                                <asp:Label ID="paiddate" runat="server" Text='<%# Bind("paiddate","{0:dd, MMM yyyy}") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PENDING">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="PENDING" runat="server" Text='<%# Bind("PENDING") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <ItemStyle ForeColor="Red" />
                        </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
