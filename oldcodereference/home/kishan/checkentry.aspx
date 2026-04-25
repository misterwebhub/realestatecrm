<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkentry.aspx.cs" Inherits="checkentry" %>

<!DOCTYPE html>
    <html>
        <head>
            <title>CHEQUE TRANSECTION</title>
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
          $("#TextBox7").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox12").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
      });
    </script>
            

            <style>
                *{padding:0px;
                    margin-left: 0;
                    margin-right: 0;
                    margin-bottom: 0;
                    text-align: left;
                }

                .header{
                    width: 100%;
                    background-color: #0d77b6 !important;
                    height: 45px;
                }

                .showLeft{
                    background-color: #0d77b6 !important;
                    border:1px solid #0d77b6 !important;
                    text-shadow: none !important;
                    color:#fff !important;
                    padding:10px;
                }

                .icons li {
                    background: none repeat scroll 0 0 #fff;
                    height: 3px;
                    width: 3px;
                    line-height: 0;
                    list-style: none outside none;
                    margin-right: 15px;
                    margin-top: 3px;
                    vertical-align: top;
                    border-radius:50%;
                    pointer-events: none;
                }

                .btn-left {
                    left: 0.4em;
                }

                .btn-right {
                    right: 0.4em;
                }

                .btn-left, .btn-right {
                    position: absolute;
                    top: 0.24em;
                }

                .dropbtn {
                    background-color: #4CAF50;
                    position: fixed;
                    color: white;
                    font-size: 16px;
                    border: none;
                    cursor: pointer;
                }
                #r1
                {
                    float:left;
                    height:auto;
                    
                }
                .p1
                {
                    width:80%;
                }
                .p21
                {
                    width:18%;
                    marginleft:1%;
                }
                .dropbtn:hover, .dropbtn:focus {
                    background-color: #3e8e41;
                }

                .dropdown {
                    position: absolute;
                    display: inline-block;
                    right: 0.4em;
                }

                .dropdown-content {
                    display: none;
                    position: relative;
                    margin-top: 5px;
                    background-color: #f9f9f9;
                    min-width: 160px;
                    overflow: auto;
                    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
                    z-index: 1;
                }

                .dropdown-content a {
                    color: black;
                    padding: 12px 16px;
                    text-decoration: none;
                    display: block;
                }

                .dropdown a:hover {background-color: #f1f1f1}

                .show {display:block;}

                .style1
                {
                    height: 33px;
                }

                .style2
                {
                    width: 100%;
                }

                .style3
                {
                    text-align: center;
                }

            </style>
            <script>
                function changeLanguage(language) {
                    var element = document.getElementById("url");
                    element.value = language;
                    element.innerHTML = language;
                }

                function showDropdown() {
                    document.getElementById("myDropdown").classList.toggle("show");
                }

                // Close the dropdown if the user clicks outside of it
                window.onclick = function (event) {
                    if (!event.target.matches('.dropbtn')) {
                        var dropdowns = document.getElementsByClassName("dropdown-content");
                        var i;
                        for (i = 0; i < dropdowns.length; i++) {
                            var openDropdown = dropdowns[i];
                            if (openDropdown.classList.contains('show')) {
                                openDropdown.classList.remove('show');
                            }
                        }
                    }
                }
            </script>
        </head>
        <body>
            <form id="form1" runat="server">
            <div class="header">
           <center> <h1 class="style3">CHEQUE TRANSECTION DETAILS</h1></center>
                <!-- three dot menu -->
                <div class="dropdown">
                    <!-- three dots -->
                    <ul class="dropbtn icons btn-right showLeft" onclick="showDropdown()">
                        <li></li>
                        <li></li>
                        <li></li>
                    </ul>
                    <!-- menu -->
                    <div id="myDropdown" class="dropdown-content">
                        <a href="#">
                             <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Cheque Entry</asp:LinkButton></a>
                       <a> <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Paid Cash/Cheque Entry</asp:LinkButton></a>
                      <a> <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">DETAILS</asp:LinkButton></a>
                     <a href="kisahnexpense.aspx" target="_blank"">Kishan Expense Entry</a>
                    </div>
                </div>

            </div>
            <div>
    <asp:Panel ID="Panel2" runat="server" Height="22px">
        <br />
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        

    </asp:Panel>

                <br />
    <asp:Panel ID="Panel1" runat="server" Height="126px" Width="100%" style="margin-left:0px;">
        <table class="style2" width="100%">
            <tr>
                <td class="style1" bgcolor="#CC99FF" colspan="9">
                    Arazi No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        Height="21px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="121px">
                        <asp:ListItem>----Select-----</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; kishan Name&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" 
                        AutoPostBack="True" Height="23px" 
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged" Width="121px">
                        <asp:ListItem>----Select-----</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Location&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server" Height="27px" ReadOnly="True" 
                        Width="98px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CC99FF" class="style16">
                    <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                </td>
                <td bgcolor="#CC99FF" class="style26">
                    <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="118px"></asp:TextBox>
                </td>
                <td bgcolor="#CC99FF" class="style11">
                    A/C By</td>
                <td bgcolor="#CC99FF" class="style23">
                    <asp:TextBox ID="TextBox2" runat="server" Height="23px" Width="148px"></asp:TextBox>
                </td>
                <td bgcolor="#CC99FF" class="style15">
                    <asp:Label ID="Label1" runat="server" Text="Amount"></asp:Label>
                </td>
                <td bgcolor="#CC99FF" class="style24">
                    <asp:TextBox ID="TextBox3" runat="server" Height="23px" Width="93px"></asp:TextBox>
                </td>
                <td bgcolor="#CC99FF" class="style31">
                    Type
                    <asp:DropDownList ID="DropDownList4" runat="server" 
                        Height="22px"   Width="83px">
                        <asp:ListItem>--SELECT--</asp:ListItem>
                        <asp:ListItem>MENTION</asp:ListItem>
                        <asp:ListItem>OTHER</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td bgcolor="#CC99FF" class="style27">
                    <asp:Panel ID="Panel3" runat="server" Height="38px" Width="189px">
                        CHEQUE No&nbsp;<asp:TextBox ID="TextBox4" runat="server" Height="23px" 
                            Width="86px"></asp:TextBox>
                    </asp:Panel>
                </td>
                <td bgcolor="#CC99FF">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                        Width="59px" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#CC99FF" class="style16">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style26">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style11">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style23">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style15">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style24">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style31">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style27">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style20">
                    <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="White" class="style5" colspan="9">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Height="126px" Width="100%" style="margin-left:0px;margin-top:-27px;">
        <table class="style2" width="100%">
            <tr>
                <td class="style1" bgcolor="#CC99FF" colspan="9">
                    Arazi No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" 
                        Height="16px" onselectedindexchanged="DropDownList7_SelectedIndexChanged" 
                        Width="88px">
                        <asp:ListItem>-----Select----</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; kishan Name&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownList8" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="DropDownList8_SelectedIndexChanged">
                        <asp:ListItem>---Select----</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Location&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server" Height="27px" ReadOnly="True" 
                        Width="98px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#CC99FF" class="style16">
                    <asp:Label ID="Label3" runat="server" Text="Date"></asp:Label>
                </td>
                <td bgcolor="#CC99FF" class="style26">
                    <asp:TextBox ID="TextBox7" runat="server" Height="24px" Width="118px"></asp:TextBox>
                </td>
                <td bgcolor="#CC99FF" class="style11">
                    A/C By</td>
                <td bgcolor="#CC99FF" class="style23">
                    <asp:TextBox ID="TextBox8" runat="server" Height="23px" Width="148px"></asp:TextBox>
                </td>
                <td bgcolor="#CC99FF" class="style15">
                    <asp:Label ID="Label4" runat="server" Text="Amount"></asp:Label>
                </td>
                <td bgcolor="#CC99FF" class="style24">
                    <asp:TextBox ID="TextBox9" runat="server" Height="23px" Width="93px"></asp:TextBox>
                </td>
                <td bgcolor="#CC99FF" class="style31">
                    Type
                    <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" 
                        Height="22px"   Width="83px" 
                        onselectedindexchanged="DropDownList6_SelectedIndexChanged">
                        <asp:ListItem>--SELECT--</asp:ListItem>
                        <asp:ListItem>CASH</asp:ListItem>
                        <asp:ListItem>CHEQUE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td bgcolor="#CC99FF" class="style27">
                    <asp:Panel ID="Panel5" runat="server" Height="38px" Width="189px">
                        CHEQUE No&nbsp;<asp:TextBox ID="TextBox10" runat="server" Height="23px" 
                            Width="86px"></asp:TextBox>
                    </asp:Panel>
                </td>
                <td bgcolor="#CC99FF">
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Submit" 
                        Width="69px" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#CC99FF" class="style16">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style26">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style11">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style23">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style15">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style24">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style31">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style27">
                    &nbsp;</td>
                <td bgcolor="#CC99FF" class="style20">
                    <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="White" class="style5" colspan="9">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
                
                <div id="r1" class="p1">
                    &nbsp;
                    <asp:Panel ID="Panel6" runat="server">
                    <table class="style2">
                        <tr>
                            <td>
                                Arazi No&nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList9" runat="server" Height="17px" 
                                    onselectedindexchanged="DropDownList9_SelectedIndexChanged" Width="92px" 
                                    AutoPostBack="True">
                                    <asp:ListItem>---Select----</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kishan Name
                                <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" 
                                    Height="16px" onselectedindexchanged="DropDownList10_SelectedIndexChanged" 
                                    Width="93px">
                                    <asp:ListItem>---Select----</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Status&nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList11" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList11_SelectedIndexChanged">
                                    <asp:ListItem>---Select---</asp:ListItem>
                                    <asp:ListItem>PAID</asp:ListItem>
                                    <asp:ListItem>UNPAID (Cheque)</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
                                <br />
                                <br />
                                <div style="background-color:Navy;color:White;padding:10px; height: 26px; font-weight: 700;width:96%;"">
                                    Arazi No -&nbsp;
                                    <asp:Label ID="Label8" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kishan Name -&nbsp;
                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Location -&nbsp;
                                    <asp:Label ID="Label10" runat="server"></asp:Label>
                                </div>
																		  <p></p> <div style="background-color:#581845;color:White;padding:7px; height: 19px; font-weight: 700;width:96%;"">
                                    Total Amount -&nbsp;
                                    <asp:Label ID="Label11" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Paid Amount -&nbsp;
                                    <asp:Label ID="Label12" runat="server"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Balance Amount -&nbsp;
                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                </div>
								<p></p>
								<div style="padding:7px; height: 18px; font-weight: 700;width:100%;"">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cheque Balance Amount -&nbsp;
                                    <asp:Label ID="Label15" runat="server" style="font-size:14pt;color:red;"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cheque No&nbsp;
                                    <asp:TextBox ID="TextBox11" runat="server" Height="22px" Width="78px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Change Date
                                    <asp:TextBox ID="TextBox12" runat="server" Height="18px" Width="95px"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Height="26px" 
                                        onclick="Button3_Click" Text="Update" Width="85px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label16" runat="server" ForeColor="#003300"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                </div>
                            </td>
                        </tr>
                        
                    </table>

                </asp:Panel>
                <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
                        BorderColor="Tan" Width="100%" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                        GridLines="None"  AutoGenerateColumns="False" style="text-align:left;margin-left:15px;">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue"/>
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                        <Columns>
                        
                  
                  <asp:TemplateField ItemStyle-Width="80px">
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="80px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>A/C BY</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="amount1" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>CHEQUE NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="checno1" runat="server" Text='<%# Eval("chequeno") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                  
                   
                  </Columns>
                    </asp:GridView>

                    &nbsp;<asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" 
                BorderColor="Tan" BorderWidth="1px" Width="100%" CellPadding="2" ForeColor="Black" 
                GridLines="None"  AutoGenerateColumns="False" Height="32px" 
                    style="text-align:left;margin-left:15px;" 
                    onrowdatabound="GridView2_RowDataBound">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                     />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                         <Columns>
                        
                  
                  <asp:TemplateField ItemStyle-Width="50px">
                  <HeaderTemplate>DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date1" runat="server" Text='<%# Eval("date","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="100px">
                  <HeaderTemplate>A/C BY</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="name1" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="amount1" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>CHEQUE NO</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="checno1" runat="server" Text='<%# Eval("chequeno") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>TYPE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="type1" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="1px">
                  <HeaderTemplate>CHEQUE TYPE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="cheque2" runat="server" Text='<%# Eval("chequetype") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="1px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="50px">
                  <HeaderTemplate>PAID DATE</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="date3" runat="server" Text='<%# Eval("moddate","{0:dd, MMM yyyy}") %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                  </asp:TemplateField>
                   
                  </Columns>
            </asp:GridView>
            </div>
            <div id="r1" class="p21">
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                    Font-Size="Small" oncheckedchanged="CheckBox1_CheckedChanged" 
                    style="font-weight: 700" Text="    Hide ME" />
                <br />
                <asp:GridView ID="GridView3" runat="server" BackColor="White" 
                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    Width="100%" AutoGenerateColumns="False">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    <Columns>
                   <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>NAME</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="rate" runat="server" Text='<%#Eval("item")  %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField ItemStyle-Width="30px">
                  <HeaderTemplate>AMOUNT</HeaderTemplate>
                  <ItemTemplate>
                  <asp:Label ID="rate" runat="server" Text='<%#Eval("amount")  %>'></asp:Label>
                  </ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
                  </asp:TemplateField>
                  
                    </Columns>
                </asp:GridView>
            </div>
            </div>
            
            </form>
        </body>
    </html>
