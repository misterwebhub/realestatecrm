﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="expence.aspx.cs" Inherits="expence" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
     <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   
    <script type="text/javascript">
        $(document).ready(function () {
            $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: "expence.aspx/GetAutoCompleteData",
                        data: "{'username':'" + document.getElementById('TextBox1').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert(result);
                        }
                    });
                }
            });
            $(".autosuggest1").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;charset=utf-8",
                        url: "expence.aspx/GetAutoCompleteData",
                        data: "{'username':'" + document.getElementById('TextBox5').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert(result);
                        }
                    });
                }
            });
            $(".txt1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $(".txt2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $(".t15").datepicker({
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
            height: 71px;
            margin-top: 0px;
            font-size: small;
            font-weight: 700;
        }
        .style2
        {
            font-weight: bold;
        }
        .style3
        {
            text-align: center;
        }
        .style4
        {
            height: 43px;
            font-size: x-large;
        }
        .style8
        {
            width: 11%;
        }
        .style9
        {
            text-align: center;
            font-size: large;
        }
        .style10
        {
            width: 4%;
        }
        .style11
        {
            width: 15%;
        }
        .style12
        {
            width: 3%;
        }
        .style13
        {
            width: 14%;
        }
        .style14
        {
            width: 5%;
        }
        .style15
        {
            width: 19%;
        }
        .style16
        {
            height: 43px;
            font-size: x-large;
            color: #FFFFFF;
        }
        .style17
        {
            width: 46px;
            height: 25px;
        }
        .style18
        {
            text-align: center;
            height: 36px;
        }
        .style19
        {
            height: 25px;
        }
        .style20
        {
            height: 25px;
            width: 61px;
        }
        .style21
        {
            height: 25px;
            width: 62px;
        }
        .style22
        {
            width: 59px;
            height: 25px;
        }
        .style23
        {
            width: 615px;
        }
        .style24
        {
            width: 100%;
        }
        .style25
        {
            font-size: medium;
            color: #FFFFFF;
        }
        .style26
        {
            color: #FFFFFF;
            text-align: right;
        }
        .style27
        {
            text-align: right;
        }
        .style28
        {
            color: #FFFFFF;
        }
        .style29
        {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:90%;margin-left:5%;">

    
        <table class="style1">
            <tr>
                <td colspan="2" style="text-align: center" bgcolor="#660033" class="style16">
                    <strong>EXPENCE DETAILS</strong></td>
            </tr>
            <tr>
                <td bgcolor="Aqua" class="style23">
                    <asp:Button ID="Button1" runat="server" BackColor="Lime" 
                        BorderColor="#003300" BorderStyle="Dashed" CssClass="style2" ForeColor="Maroon" 
                        onclick="Button1_Click" style="margin-left: 96px" Text="CREDIT AMOUNT ( + )" 
                        Width="205px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button8" runat="server" BackColor="#6666FF" 
                        BorderStyle="Dashed" onclick="Button8_Click" style="font-weight: 700" 
                        Text="EDIT EXPENSE" Width="118px" />
                &nbsp;&nbsp;
                    <asp:Button ID="Button11" runat="server" BackColor="#333300" 
                        BorderStyle="Dashed" ForeColor="White" style="font-weight: 700" 
                        Text="DATE WISE SEARCH" Width="148px" onclick="Button11_Click1" />
                </td>
                <td bgcolor="Aqua">
                    <asp:Button ID="Button2" runat="server" BackColor="#FF3300" 
                        BorderColor="#003300" BorderStyle="Dashed" CssClass="style2" ForeColor="Maroon" 
                        onclick="Button2_Click" style="margin-left: 64px" Text="DEBIT AMOUNT ( - )" 
                        Width="163px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                        style="font-weight: 700" Text="Get all details" Width="100px" 
                        BackColor="#99FF66" BorderStyle="Dashed" />
                </td>
            </tr>
            <tr><td colspan="2" bgcolor="#99FF66">
            <strong style="text-align: right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    Total Debit(-)&nbsp;&nbsp;
                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Credit (+)&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label5" runat="server" style="font-weight: 700"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                    Total Balance Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" style="font-weight: 700"></asp:Label>
                    &nbsp;
                    </strong>
                </td>
           </tr>
            <tr>
                <td colspan="2" style="text-align: center"  class="style4">
                    <asp:Panel ID="Panel1" runat="server" BackColor="Lime" Height="80px" 
                        Visible="False" BorderStyle="Solid">
                        <table class="style1">
                            <tr>
                                <td class="style9" colspan="10">
                                    <strong>CREDIT AMOUNT</strong></td>
                            </tr>
                            <tr style="font-size: small; font-weight: 700;">
                                <td class="style10">
                                    CREDIT FROM</td>
                                <td class="style11">
                                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="160px" CssClass="autosuggest"></asp:TextBox>
                                </td>
                            
                                <td class="style12">
                                    DATE</td>
                                <td class="style13">
                                    <asp:TextBox ID="TextBox2" runat="server" Width="146px" class="txt1"></asp:TextBox>
                                </td>
                           
                                <td class="style14">
                                    AMOUNT</td>
                                <td class="style13">
                                    <asp:TextBox ID="TextBox3" runat="server" Width="142px"></asp:TextBox>
                                </td>
                            
                                <td class="style14">
                                    REASON</td>
                                <td class="style15">
                                    <asp:TextBox ID="TextBox4" runat="server" Height="41px" TextMode="MultiLine" 
                                        Width="196px"></asp:TextBox>
                                </td>
                            
                                <td class="style8">
                                   
                                         <asp:Button ID="Button3" runat="server" style="font-weight: 700" 
                                        Text="CREDIT AMOUNT" Width="132px" onclick="Button3_Click" Font-Size="Small" />
                                </td>
                                <td class="style12">
                                    <asp:Label ID="Label1" runat="server" ForeColor="#003399" style="font-weight: 700" 
                                        Text="Label"></asp:Label>
                                </td>
                            
                                
                            </tr>
                        </table>
                    </asp:Panel>
                   </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel2" runat="server" BackColor="RED" Height="75px" 
                        Visible="False" BorderStyle="Solid">
                        <table class="style1">
                            <tr>
                                <td class="style3" colspan="10">
                                    <strong style="font-size: large">DEBIT AMOUNT</strong></td>
                            </tr>
                            <tr>
                                <td>
                                    DEBIT TO</td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server" Height="26px" Width="156px"  CssClass="autosuggest1"></asp:TextBox>
                                </td>
                            
                                <td>
                                    DATE</td>
                                <td>
                                    <asp:TextBox ID="TextBox6" runat="server" Width="138px" class="txt2"></asp:TextBox>
                                </td>
                           
                                <td>
                                    AMOUNT</td>
                                <td>
                                    <asp:TextBox ID="TextBox7" runat="server" Width="149px"></asp:TextBox>
                                </td>
                            
                                <td>
                                    REASON</td>
                                <td>
                                    <asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine" Width="191px"></asp:TextBox>
                                </td>
                            
                                <td>
                                      <asp:Button ID="Button4" runat="server" style="font-weight: 700" 
                                        Text="DEBIT AMOUNT" Width="117px" onclick="Button4_Click" />
                                </td>
                                <td>
                                  
                                        <asp:Label ID="Label3" runat="server" ForeColor="GREEN" style="font-weight: 700" 
                                        Text="Label"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr><td colspan="2">
                    <asp:Panel ID="Panel3" runat="server" BackColor="#669900" Height="91px" 
                        Visible="False" BorderStyle="Solid">
                        <table class="style1">
                            <tr>
                                <td class="style18" colspan="13">
                                    <strong style="font-size: large">UPDATE/DELETE AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ENTER ID </strong>
                                    <asp:TextBox ID="TextBox13" runat="server" Width="86px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button9" runat="server" onclick="Button9_Click" 
                                        style="font-weight: 700" Text="SEARCH" Width="73px" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    NAME</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox9" runat="server" Height="20px" Width="156px"></asp:TextBox>
                                </td>
                            
                                <td class="style19">
                                    DATE</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox10" runat="server" Width="103px" class="txt2"></asp:TextBox>
                                </td>
                           
                                <td class="style20">
                                    DEBIT AMOUNT</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox11" runat="server" Width="107px"></asp:TextBox>
                                    &nbsp;
                                </td>
                            
                                <td class="style21">
                                    CREDIT AMOUNT
                                </td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox14" runat="server" Width="97px"></asp:TextBox>
                                </td>
                                <td class="style22">
                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                </td>
                            
                                <td class="style19">
                                    REASON</td>
                                <td class="style19">
                                    <asp:TextBox ID="TextBox12" runat="server" TextMode="MultiLine" Width="191px"></asp:TextBox>
                                </td>
                            
                                <td class="style19">
                                      <asp:Button ID="Button14" runat="server" onclick="Button14_Click" 
                                          style="font-weight: 700" Text="Update" />
                                </td>
                                <td class="style19">
                                  
                                        <asp:Button ID="Button10" runat="server" Height="26px" onclick="Button10_Click" 
                                            style="font-weight: 700" Text="DELETE" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td></tr>
                <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel4" runat="server" BackColor="#000066" Visible="False" 
                        BorderStyle="Solid">
                        <table class="style24">
                            <tr>
                                <td class="style25" colspan="5" style="text-align: center">
                                    DATE WISE SEARCH PAYENT</td>
                            </tr>
                            <tr>
                                <td class="style27" style="color: #FFFFFF">
                                    DATE FROM</td>
                                <td style="color: #FFFFFF">
                                    <asp:TextBox ID="TextBox15" runat="server" style="margin-left: 22px" 
                                        Width="144px" class="t15"></asp:TextBox>
                                </td>
                                <td class="style26">
                                    DATE TILL</td>
                                <td>
                                    <asp:TextBox ID="TextBox16" runat="server" style="margin-left: 23px" 
                                        Width="135px" class="t15"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button12" runat="server" style="font-weight: 700" Text="SEARCH" 
                                        Width="86px" onclick="Button12_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="color: #FFFFFF; text-align: right">
                                    BY NAME</td>
                                <td>
                                    <asp:TextBox ID="TextBox17" runat="server" Height="16px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button13" runat="server" onclick="Button13_Click" 
                                        style="font-weight: 700" Text="SEARCH" Width="75px" />
                                </td>
                                <td class="style28">
                                    B<span class="style29">y Resason</span></td>
                                <td>
                                    <asp:TextBox ID="TextBox18" runat="server" Width="122px"></asp:TextBox>
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Button15" runat="server" onclick="Button15_Click" 
                                        style="font-weight: 700" Text="Search" />
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                   
                   
                   
                    </asp:Panel>
                </td>
                </tr>
            <tr>

                <td colspan="2">
                    <br />
                     <asp:GridView ID="GridView2" runat="server" Width="100%" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Horizontal" 
                        style="text-align:center;font-size:12pt;border:1px solid black;" AutoGenerateColumns="False" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged1" onrowdatabound="GridView2_RowDataBound" 
                       >
                        <AlternatingRowStyle />
                        <Columns>
                        <asp:TemplateField ItemStyle-Width="30">
                  <HeaderTemplate>ID</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="id1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="200">
                  <HeaderTemplate>Name</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="200px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>Date</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="100">
                  <HeaderTemplate>Debit Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="damount1" runat="server" Text='<%# Eval("damount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="120">
                  <HeaderTemplate>Credit Amount</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="camount1" runat="server" Text='<%# Eval("camount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="120px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="40">
                  <HeaderTemplate>Status</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cstatus1" runat="server" Text='<%# Eval("cstatus") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="40px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField>
                  <HeaderTemplate>Reason</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="creson1" runat="server" Text='<%# Eval("creson") %>'></asp:Label>
                  </ItemTemplate>
                  </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                                    
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>

    
    </div>
    
    </form>
</body>
</html>
