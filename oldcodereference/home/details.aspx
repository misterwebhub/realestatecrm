<%@ Page Language="C#" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>KISHAN PAYMENT</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
      <script>
          function doPrint() {
              var prtContent = document.getElementById('<%= GridView1.ClientID %>');
              var prtContent1 = document.getElementById('<%= Panel2.ClientID %>');
              prtContent.border = 0; //set no border here
              var WinPrint = window.open('', '', 'left=100,top=100,width='+'1000,height='+'1000,toolbar=0,scrollbars=1,status=0,resizable=0');
              WinPrint.document.write(prtContent1.outerHTML);
             // WinPrint.document.write(prtContent.outerHTML);
              WinPrint.document.close();
              WinPrint.focus();
              WinPrint.print();
              WinPrint.close();
          }
          function doPrint1() {
              var prtContent = document.getElementById('<%= GridView2.ClientID %>');
              var prtContent1 = document.getElementById('<%= Panel3.ClientID %>');
              prtContent.border = 0; //set no border here
              var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
              WinPrint.document.write(prtContent1.outerHTML);
              // WinPrint.document.write(prtContent.outerHTML);
              WinPrint.document.close();
              WinPrint.focus();
              WinPrint.print();
              WinPrint.close();
          }
</script>

  <link rel="stylesheet" href="/resources/demos/style.css"/>
  
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>



    <script type="text/javascript">
        $(function () {
            $("#countrytabs").tabs();
        });
        $(document).ready(function () {
            $("#TextBox3").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox8").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox30").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox43").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox9").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox15").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox17").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });


        });
    </script>
    <style type="text/css">
    footer {
  font-size: 9px;
  color: #f00;
  text-align: center;
}

@page {
  size: A4;
  margin: 11mm 17mm 17mm 17mm;
}

@media print {
  footer {
    position: fixed;
    bottom: 0;
  }

  .content-block, p {
    page-break-inside: avoid;
  }

  html, body {
    width: 210mm;
    height: 297mm;
  }
}
    
        body
        {
            font-size: 14pt;
            margin:0px;
            height:100%;
        }
        
         ul
        {
        background-color:#e9e9e9;
        margin-top:0%;
        position:fixed;
        z-index:1;
       
        }
        ul li
        {
            list-style:none;
            display:inline-block;
            padding:8px 20px ;
            border-radius:5px;
            background-color:ActiveCaption;
        }
        .t
        {
            text-decoration:none;
            font-size:12pt;
            color:Black;
        }
       ul li:hover
       {
          background-color: #dddddd;
       }
        #u
        {
               
       BOX-SHADOW:0PX 0PX 20PX BLACK;
            width:100%;
            background-color:#F9E79F;
          
        }
        .style1
        {
            width:100%;
            height:100%;
        }
        #r
        {
            
            
        }
        .style2
        {
            width: 312px;
        }
        .style3
        {
            width: 304px;
        }
        .style4
        {
            width: 92px;
            font-weight: bold;
        }
        .style8
        {
            width: 129px;
            font-weight: bold;
        }
        .style9
        {
            width: 116px;
        }
        .style11
        {
            width: 130px;
        }
        .style12
        {
            font-size: x-small;
        }
        .style13
        {
            width: 116px;
            font-size: small;
        }
        .style14
        {
            width: 129px;
            font-size: small;
            font-weight: bold;
        }
        .style17
        {
            width: 130px;
            font-size: small;
        }
        .style20
        {
            width: 150px;
            font-weight: bold;
        }
        .style21
        {
            font-size: small;
        }
        .style22
        {
            width: 92px;
            font-size: small;
            font-weight: bold;
        }
        .style25
        {
            width: 159px;
            font-size: small;
        }
        .style26
        {
            width: 159px;
        }
        .style27
        {
            width: 150px;
            font-size: small;
            font-weight: bold;
        }
        .style28
        {
            width: 131px;
            font-size: small;
            font-weight: bold;
        }
        .style29
        {
            width: 131px;
            font-weight: bold;
        }
        
        .style30
        {
            width: 312px;
            height: 35px;
        }
        .style31
        {
            width: 134px;
            font-size: small;
            font-weight: bold;
        }
        .style32
        {
            width: 134px;
            font-weight: bold;
        }
        .style33
        {
            width: 92px;
            font-weight: bold;
            height: 24px;
        }
        .style34
        {
            width: 130px;
            height: 24px;
        }
        .style35
        {
            width: 134px;
            font-weight: bold;
            height: 24px;
        }
        .style36
        {
            width: 159px;
            height: 24px;
        }
        .style37
        {
            width: 129px;
            font-weight: bold;
            height: 24px;
        }
        .style38
        {
            width: 116px;
            height: 24px;
        }
        .style39
        {
            width: 150px;
            font-weight: bold;
            height: 24px;
        }
        .style40
        {
            color: #000066;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li><asp:LinkButton ID="LinkButton3" runat="server"
                    onclick="LinkButton3_Click" class="t">KISHAN</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton5" runat="server" 
                    onclick="LinkButton5_Click" class="t">INVESTER</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton6" runat="server" 
                    onclick="LinkButton6_Click" class="t">BROKER</asp:LinkButton></li>
            <li><asp:LinkButton ID="LinkButton7" runat="server" 
                    onclick="LinkButton7_Click" class="t">OTHER</asp:LinkButton></li>
         
        </ul>
        <div id="countrytabs-1">
            <asp:Panel ID="Panel2" runat="server">
               <div id="u">
    
        <table class="style1">
            <tr>
                <td bgcolor="#FF99FF" class="style2" style="text-align: center;height:30px;" colspan="8">
                    <strong>Kishan Pyament Details</strong></td>
            </tr>
            <tr >
                <td class="style3" colspan="8">
                    Arazi&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp; Kishan Name
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" style="font-weight: 700; height: 26px;" 
                        Text="view" Width="74px" onclick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Broker" onclick="Button2_Click" />
                    &nbsp;&nbsp;&nbsp; <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="doPrint()" />
                    &nbsp;&nbsp; <span class="style40"><strong>Cheque Mention Unpaid Amount&nbsp;&nbsp;&nbsp; </strong>
                    </span><strong>
                    <asp:Label ID="Label32" runat="server" CssClass="style40"></asp:Label>
                    </strong></td>
            </tr>
            <tr class="style12">
                <td class="style22">
                    ARAZI</td>
                <td class="style17">
                    <asp:Label ID="Label2" runat="server" Text="00000000000000"></asp:Label>
                </td>
                <td class="style28">
                    NAME</td>
                <td class="style25">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style14">
                    TOTAL LAND</td>
                <td class="style13">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style27">
                    LAST DATE</td>
                <td class="style13">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style12">
                <td class="style22">
                    TOTAL AMT</td>
                <td class="style17">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style28">
                    PAID AMT</td>
                <td class="style25">
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style14">
                    BALANCE AMT</td>
                <td class="style13">
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style27">
                    UNPAID CHEQUE AMT</td>
                <td class="style13">
                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style21">
                <td class="style4">
                    BROKER NAME</td>
                <td class="style11">
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style29">
                    BROKER. TOTAL AMT</td>
                <td class="style26">
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style8">
                    BROKER PAID AMT</td>
                <td class="style9">
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style20">
                    BROKER. BALANCE AMT</td>
                <td class="style9">
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr><td colspan="8" >
            <div id="r">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

       
  
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False" 
                        style="font-size:12pt;width:100%;" 
                        onrowdatabound="GridView1_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="reciptid" HeaderText="Recipt ID" />
                            <asp:BoundField DataField="date" HeaderText="Date" 
                                DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="amount" HeaderText="Amount" />
                            <asp:BoundField DataField="bpaid" HeaderText="Broker" />
                            <asp:BoundField DataField="unpaidamt" HeaderText="UN Paid" />
                            <asp:BoundField DataField="paymode" HeaderText="Pay Mode" />

                            <asp:BoundField DataField="cheqdate" HeaderText="Cheque date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="cheqno" HeaderText="Cheq. No" />
                            <asp:BoundField DataField="refno" HeaderText="Ref.No" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                           
                            <asp:BoundField DataField="reason" HeaderText="Reson" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
               </asp:GridView>
               </div>
        
    
  
   
            
            </td></tr>
           </table>
           </div>
           
     </asp:Panel>
        </div>
        <div id="countrytabs-2">
            
            <asp:Panel ID="Panel3" runat="server">
            
           <div id="Div1">
    
        <table class="style1">
            <tr>
                <td bgcolor="#FF99FF" class="style30" style="text-align: center" colspan="8">
                    <strong>Invester Pyament Details&nbsp;&nbsp; </strong> <a href="assigninv.aspx" target="_blank">Assign Invester</a></td>
            </tr>
            <tr>
                <td class="style3" colspan="8" bgcolor="#99FFCC">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="width:100%;">
                        <ContentTemplate>
                            Invester Name&nbsp;
                            <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" 
                                Height="29px" onselectedindexchanged="DropDownList5_SelectedIndexChanged" 
                                Width="115px">
                            </asp:DropDownList>
                            &nbsp; ID
                            <asp:DropDownList ID="DropDownList3" runat="server" Height="29px" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="115px">
                            </asp:DropDownList>
                            &nbsp; Invester ID &nbsp;
                            <asp:TextBox ID="TextBox1" runat="server" Height="27px" 
                                style="font-size: medium" Width="90px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                style="font-weight: 700; height: 26px;" Text="view" Width="74px" />
                            &nbsp;&nbsp;
                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button4" runat="server" onclick="Button2_Click" Text="Broker" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button5" runat="server" OnClientClick="doPrint1()" 
                                Text="Print" />
                            <strong><span class="style40">&nbsp;&nbsp;&nbsp;&nbsp; Cheque Mention Unpaid Amount&nbsp;&nbsp;&nbsp; </span>
                            <asp:Label ID="Label33" runat="server" CssClass="style40"></asp:Label>
                            </strong>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
            </tr>
            <tr class="style12">
                <td class="style22" bgcolor="#99FFCC">
                    ID</td>
                <td class="style17" bgcolor="#99FFCC">
                    <asp:Label ID="Label15" runat="server" Text="00000000000000"></asp:Label>
                </td>
                <td class="style31" bgcolor="#99FFCC">
                    NAME</td>
                <td class="style25" bgcolor="#99FFCC">
                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style14" bgcolor="Lime">
                    TOTAL ONE AMT</td>
                <td class="style13" bgcolor="Lime">
                    <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style27" bgcolor="#FF6600">
                    TOTAL RETURN AMT</td>
                <td class="style13" bgcolor="#FF6600">
                    <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style12">
                <td class="style22" bgcolor="#99FFCC">
                    REG DATE</td>
                <td class="style17" bgcolor="#99FFCC">
                    <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style31" bgcolor="#99FFCC">
                    LAST DATE</td>
                <td class="style25" bgcolor="#99FFCC">
                    <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style14" bgcolor="Lime">
                    RECV&nbsp; AMT</td>
                <td class="style13" bgcolor="Lime">
                    <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style27" bgcolor="#FF6600">
                    RETURN AMT</td>
                <td class="style13" bgcolor="#FF6600">
                    <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style21">
                <td class="style4" bgcolor="#99FFCC">
                    &nbsp;</td>
                <td class="style11" bgcolor="#99FFCC">
                    &nbsp;</td>
                <td class="style32" bgcolor="#99FFCC">
                    UNPAID CHEQUE AMT</td>
                <td class="style26" bgcolor="#99FFCC">
                    <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style8" bgcolor="Lime">
                    BAL RECV AMT</td>
                <td class="style9" bgcolor="Lime">
                    <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style20" bgcolor="#FF6600">
                    BALANCE RETURN AMT</td>
                <td class="style9" bgcolor="#FF6600">
                    <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style21">
                <td class="style33" bgcolor="#66FFFF">
                    BROKER NAME</td>
                <td class="style34" bgcolor="#66FFFF">
                    <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style35" bgcolor="#66FFFF">
                    BROKER. TOTAL AMT</td>
                <td class="style36" bgcolor="#66FFFF">
                    <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style37" bgcolor="#66FFFF">
                    BROKER PAID AMT</td>
                <td class="style38" bgcolor="#66FFFF">
                    <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style39" bgcolor="#66FFFF">
                    BROKER BALANCE AMT</td>
                <td class="style38" bgcolor="#66FFFF">
                    <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="style21">
                <td bgcolor="#66FFFF" class="style4">
                    SELECT TYPE</td>
                <td bgcolor="#66FFFF" class="style11">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="22px" Width="103px">
                        <asp:ListItem>--SELECT----</asp:ListItem>
                        <asp:ListItem style="color:green;">RECEIVE</asp:ListItem>
                        <asp:ListItem style="color:red;">RETURN</asp:ListItem>
                        <asp:ListItem style="color:blue;">ALL DETAILS</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td bgcolor="#66FFFF" class="style32">
                    <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
                        style="font-weight: 700" Text="Search" />
                </td>
                <td bgcolor="#66FFFF" class="style26">
                    <asp:Label ID="Label31" runat="server" ForeColor="Red" 
                        style="font-weight: 700; font-size: medium" Text="Label"></asp:Label>
                </td>
                <td bgcolor="#66FFFF" class="style8">
                    &nbsp;</td>
                <td bgcolor="#66FFFF" class="style9">
                    &nbsp;</td>
                <td bgcolor="#66FFFF" class="style20">
                    &nbsp;</td>
                <td bgcolor="#66FFFF" class="style9">
                    &nbsp;</td>
            </tr>
            <tr><td colspan="8">
            <div id="Div2">

       
   
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" Width="100%" AutoGenerateColumns="False" 
                        style="font-size:12pt;HEIGHT:100%;overflow:scroll;" Font-Bold="True" 
                        onrowdatabound="GridView2_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="invrecipt" HeaderText="Recipt ID" />
                            <asp:BoundField DataField="date" HeaderText="Date" 
                                DataFormatString = "{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="type" HeaderText="Type" />
                            <asp:BoundField DataField="amount" HeaderText="Amount" />
                            <asp:BoundField DataField="bpaid" HeaderText="Amount" />
                            <asp:BoundField DataField="unpamt" HeaderText="UNP Amount" />
                            <asp:BoundField DataField="paymode" HeaderText="Pay Mode" />
                            <asp:BoundField DataField="chekdate" HeaderText="Cheque date" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="chkno" HeaderText="Cheq. No" />
                            <asp:BoundField DataField="refby" HeaderText="Ref.No" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                           
                            <asp:BoundField DataField="reason" HeaderText="Reson" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="left" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
               </asp:GridView>
         
    
    </div>
            </td></tr>
           </table>
           </div>
           
            </asp:Panel>
        </div>
        <div id="countrytabs-3">
            
            <asp:Panel ID="Panel4" runat="server">
            broker
            </asp:Panel>
        </div>
        <div id="countrytabs-4">
           
            <asp:Panel ID="Panel5" runat="server">
            employee
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>

