<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kishanarazipayment.aspx.cs" Inherits="kishanarazipayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script type="text/javascript">
        function expandcollapse(name) {
            var div = document.getElementById(name);
            var img = document.getElementById('img' + name);
            if (div.style.display == 'none') {
                div.style.display = "inline";
                img.src = "minus.png";
                
            }
            else {
                div.style.display = "none";
                img.src = "select.png";
            }
        }
    </script>
      <style type="text/css">  
            .scrolling {  
                position: absolute;  
            }  
              
            .gvWidthHight {  
                overflow: scroll;  
                height: 500px;  
                width: 100%;  
            }  
        </style> 
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        body {margin:0;}
        .style5
        {
            width: 100%;
            height: 95px;
        }
        .style7
        {
            width: 87px;
            text-align: center;
        }
        .style9
        {
            width: 89px;
            text-align: center;
        }
        .style10
        {
            text-align: center;
        }
        .style12
        {
            width: 89px;
            text-align: center;
            font-weight: bold;
        }
        .style14
        {
            width: 87px;
            text-align: center;
            font-weight: bold;
        }
        .style15
        {
            text-align: center;
            font-weight: bold;
        }
        .style21
        {
            text-align: center;
            font-weight: bold;
            width: 55px;
        }
        .style22
        {
            text-align: center;
            width: 55px;
        }
        .style25
        {
            text-align: center;
            font-weight: bold;
            width: 71px;
        }
        .style26
        {
            text-align: center;
            width: 71px;
        }
        .style27
        {
            text-align: center;
            font-weight: bold;
            }
        .style28
        {
            text-align: center;
            width: 53px;
        }
        .style37
        {
            width: 74px;
            text-align: center;
            font-weight: bold;
        }
        .style38
        {
            width: 74px;
            text-align: center;
        }
        .style39
        {
            width: 78px;
            text-align: center;
            font-weight: bold;
        }
        .style40
        {
            width: 78px;
            text-align: center;
        }
        .style43
        {
            width: 100px;
            text-align: center;
            font-weight: bold;
        }
        .style44
        {
            width: 100px;
            text-align: center;
        }
        .style51
        {
            width: 85px;
            text-align: center;
            font-weight: bold;
        }
        .style52
        {
            width: 85px;
            text-align: center;
        }
        .style55
        {
            width: 90px;
            text-align: center;
            font-weight: bold;
        }
        .style56
        {
            width: 90px;
            text-align: center;
        }
        .style57
        {
            width: 82px;
            text-align: center;
            font-weight: bold;
        }
        .style58
        {
            width: 82px;
            text-align: center;
        }
        .style59
        {
            width: 81px;
            text-align: center;
            font-weight: bold;
        }
        .style60
        {
            width: 81px;
            text-align: center;
        }
        .style63
        {
            text-align: center;
            font-weight: bold;
            width: 73px;
        }
        .style64
        {
            text-align: center;
            }
        .style67
        {
            width: 77px;
            text-align: center;
            font-weight: bold;
        }
        .style68
        {
            width: 77px;
            text-align: center;
        }
        .style71
        {
            width: 95px;
            text-align: center;
            font-weight: bold;
        }
        .style72
        {
            width: 95px;
            text-align: center;
        }
        .style73
        {
            width: 97px;
            text-align: center;
            font-weight: bold;
        }
        .style74
        {
            width: 97px;
            text-align: center;
        }
        .style75
        {
            width: 44px;
        }
        .style76
        {
            background-color: #003300;
        }
        .style77
        {
            text-align: center;
            color: #FFCCFF;
            background-color: #003300;
        }
        .style78
        {
            color: #FFFF00;
        }
        .style79
        {
            color: #66FFFF;
        }
        .style80
        {
            color: #FFCCCC;
        }
        .style83
        {
            width: 17px;
        }
        .style84
        {
            width: 92px;
            text-align: center;
            font-weight: bold;
        }
        .style85
        {
            width: 92px;
            text-align: center;
        }
        .style86
        {
            width: 100%;
        }
        .style87
        {
            width: 100px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:100%;width:100%;box-shadow:0px 0px 10px black;border-radius:8px;" >
    <div style="width:100%;position:fixed;background-color:Red;border-radius:8px;overflow: hidden;top:0%;">
    <p style="padding:10px;margin:0px;background-color:Black;color:White;font-weight:bold;text-align:center;border-radius:10px 10px 0px 0px;font-sizE:x-large;">Kishan & Customer Summry Details&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label383" runat="server" Text="Label"></asp:Label>
&nbsp;* 1800 =
        <asp:Label ID="Label384" runat="server" Text="Label"></asp:Label>
		&nbsp;Rs/ Beegha &nbsp;&nbsp;&nbsp;<a href="../sidebar/araziaddfordetails.aspx" style="color:white;">ADD Arazi for Land</a></p>
        <table style="width:100%;">
    <tr><td class="style1"><strong style="text-align: right">Arazi</strong></td>
        <td class="style75">
        <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" Width="133px" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    </td><td>
        <asp:Button ID="Button1" runat="server" Text="ARAZI WISE" BackColor="#660033" 
                ForeColor="White" Height="27px" style="font-weight: 700" Width="104px" 
                onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="ALL DETAILS" 
                BackColor="#003300" ForeColor="White" 
                style="font-weight:bold; margin-left: 0px;" Width="110px" Height="27px" 
                onclick="Button2_Click" />&nbsp;&nbsp;<asp:Panel ID="Panel3" runat="server">
            </asp:Panel>
        </td>
                
                <td>
                    &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red" 
                        style="color: #000066"></asp:Label></td>
                </tr>
    
    <tr><td class="style77" colspan="2">
            <strong>INVESTER PAYMENT</strong></td>
        <td class="style76" colspan="2">
            &nbsp;<strong><span class="style78">TOTAL INV</span>&nbsp;&nbsp;
            <asp:Label ID="Label378" runat="server" Text="000000000000" 
                style="color: #FFFF00"></asp:Label>
            &nbsp;&nbsp;&nbsp; &nbsp;<span class="style78">PROFIT</span>&nbsp;&nbsp;
            <asp:Label ID="Label381" runat="server" Text="000000000000" 
                style="color: #FFFF00"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; <span class="style79">(INV+PROFIT)AMT</span>&nbsp;&nbsp;
            <asp:Label ID="Label379" runat="server" Text="000000000000" 
                style="color: #CCFFFF"></asp:Label>
&nbsp;&nbsp;&nbsp; <span class="style80">PAID AMT</span>&nbsp;
            <asp:Label ID="Label380" runat="server" Text="000000000000" 
                style="color: #FFCCCC"></asp:Label>
			&nbsp;&nbsp;&nbsp; <span  style="color: white;">BAL AMT</span>&nbsp;
            <asp:Label ID="Label389" runat="server" Text="000000000000" 
                style="color: white;"></asp:Label>
            </strong></td>
                
                </tr>
    
    <tr><td class="style1" colspan="4">
            <table class="style5" border="1">
                <tr>
                    <td bgcolor="#00FF99" colspan="4" style="width:370px;">
                        <b style="text-align: center">CUSTOMER DETAILS</b></td>
                    <td bgcolor="#FFCC99" class="style10" colspan="3">
                        <b>KISHAN DETAILS</b></td>
                    <td bgcolor="#99CCFF" colspan="7">
                        <b>LAND DETAILS</b></td>
                </tr>
                <tr>
                    <td bgcolor="#00FF99" class="style83">
                    </td>
                    <td bgcolor="#00FF99" class="style63">
                        Total</td>
                    <td bgcolor="#00FF99" class="style14">
                        Paid</td>
                    <td bgcolor="#00FF99" class="style84">
                        Balance</td>
                    <td bgcolor="#FFCC99" class="style25">
                        Total</td>
                    <td bgcolor="#FFCC99" class="style67">
                        Paid</td>
                    <td bgcolor="#FFCC99" class="style14">
                        Balance</td>
                    <td bgcolor="#99CCFF">
                        <strong>&nbsp;Total Deed</strong></td>
                    <td bgcolor="#99CCFF" class="style71">
                        Sale</td>
                    <td bgcolor="#99CCFF" class="style12">
                        Sold</td>
                    <td bgcolor="#99CCFF" class="style73">
                        Bal.Land</td>
                    <td bgcolor="#99CCFF" class="style43">
                        Total Amt</td>
                    <td bgcolor="#99CCFF" class="style15">
                        Sold Amt</td>
                    <td bgcolor="#99CCFF" class="style15">
                        Bal. Amt</td>
                </tr>
                <tr>
                    <td bgcolor="#00FF99" class="style83">
                    </td>
                    <td bgcolor="#00FF99" class="style64">
                        <asp:Label ID="Label348" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="#000066"></asp:Label>
                    </td>
                    <td bgcolor="#00FF99" class="style7">
                        <asp:Label ID="Label349" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="#000066"></asp:Label>
                    </td>
                    <td bgcolor="#00FF99" class="style85">
                        <asp:Label ID="Label350" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="#000066"></asp:Label>
                    </td>
                    <td bgcolor="#FFCC99" class="style26">
                        <asp:Label ID="Label351" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="#003300"></asp:Label>
                    </td>
                    <td bgcolor="#FFCC99" class="style68">
                        <asp:Label ID="Label352" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="#003300"></asp:Label>
                    </td>
                    <td bgcolor="#FFCC99" class="style7">
                        <asp:Label ID="Label353" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="#003300"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF">
                        <asp:Label ID="Label390" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style72">
                        <asp:Label ID="Label355" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style9">
                        <asp:Label ID="Label357" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style74">
                        <asp:Label ID="Label358" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style44">
                        <asp:Label ID="Label359" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style10">
                        <asp:Label ID="Label360" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style10">
                        <asp:Label ID="Label361" runat="server" Text="0" Font-Bold="True" 
                            ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                </table>
        </td>
                </tr>
    
    </table>
         <asp:Panel ID="Panel4" runat="server">
       
    <div>
        <table style="width:100%;text-align:center;background-color:black;color:White;font-size:11pt;" border=1>
            <tr>
                <td style="width:112px;">
                    ARAZI</td>
                <td style="width:81px;">
                    TOTAL</td>
                <td style="width:81px;">
                    PAID</td>
                <td style="width:79px;">
                    BALANCE</td>
                <td style="width:81px;">
                    TOTAL</td>
                <td style="width:81px;">
                    PAID</td>
                <td style="width:80px;">
                    BALANCE</td>
                <td style="width:102px;">
                    TOTAL DEED</td>
                <td>
                    RATE</td>
                <td>
                    SALE</td>
                <td style="width:39px;">
                    SOLD</td>
                <td style="width:79px;">
                    BALANCE</td>
                <td>
                    TOTAL AMT</td>
                <td>
                    SOLD AMT</td>
                <td>
                    BAL AMT</td>
                <td>
                    AVG AMT</td>
            </tr>
        </table>
             </div>
     </asp:Panel>
    </div>
    
    </div>
    <div style="height:auto;width:100%;margin-top:16%;">
        
        <asp:Panel ID="Panel1" runat="server" Height="95px">
            <table class="style5" border="1">
                <tr>
                    <td bgcolor="#00FF99" class="style10" colspan="4">
                        <b style="text-align: center">CUSTOMER DETAILS</b></td>
                    <td bgcolor="#FFCC99" class="style10" colspan="3">
                        <b>KISHAN DETAILS</b></td>
                    <td bgcolor="#99CCFF" class="style10" colspan="8">
                        <b>LAND DETAILS</b></td>
                    <td bgcolor="#99CCFF" class="style10">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td bgcolor="#00FF99" class="style27">
                        Arazi</td>
                    <td bgcolor="#00FF99" class="style21">
                        Total</td>
                    <td bgcolor="#00FF99" class="style14">
                        Paid</td>
                    <td bgcolor="#00FF99" class="style39">
                        Balance</td>
                    <td bgcolor="#FFCC99" class="style25">
                        Total</td>
                    <td bgcolor="#FFCC99" class="style12">
                        Paid</td>
                    <td bgcolor="#FFCC99" class="style37">
                        Balance</td>
                    <td bgcolor="#99CCFF" class="style51">
                        Total Deed</td>
                    <td bgcolor="#99CCFF" class="style59">
                        Sale</td>
                    <td bgcolor="#99CCFF" class="style37">
                        &nbsp;Rate</td>
                    <td bgcolor="#99CCFF" class="style57">
                        Sold</td>
                    <td bgcolor="#99CCFF" class="style55">
                        Bal.Land</td>
                    <td bgcolor="#99CCFF" class="style43">
                        Total Amt</td>
                    <td bgcolor="#99CCFF" class="style15">
                        Sold Amt</td>
                    <td bgcolor="#99CCFF" class="style15">
                        Bal. Amt</td>
                    <td bgcolor="#99CCFF" class="style15">
                        Avg. Amt</td>
                </tr>
                <tr>
                    <td bgcolor="#00FF99" class="style28">
                        <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#00FF99" class="style22">
                        <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#00FF99" class="style7">
                        <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#00FF99" class="style40">
                        <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#FFCC99" class="style26">
                        <asp:Label ID="Label6" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#FFCC99" class="style9">
                        <asp:Label ID="Label7" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#FFCC99" class="style38">
                        <asp:Label ID="Label8" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style52">
                        <asp:Label ID="Label9" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style60">
                        <asp:Label ID="Label10" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style38">
                        <asp:Label ID="Label11" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style58">
                        <asp:Label ID="Label12" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style56">
                        <asp:Label ID="Label14" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style44">
                        <asp:Label ID="Label16" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style10">
                        <asp:Label ID="Label13" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style10">
                        <asp:Label ID="Label15" runat="server" Text="0"></asp:Label>
                    </td>
                    <td bgcolor="#99CCFF" class="style10">
                        <asp:Label ID="Label382" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <br />
        
        <asp:Panel ID="Panel2" runat="server" Height="100%">
       
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                style="width:100%;" onrowdatabound="GridView1_RowDataBound">

            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <a href="JavaScript:expandcollapse('<%# Eval("toarazi") %>');">
            <img src="select.png" border="0" id='img<%# Eval("toarazi") %>' style="height:30px;width:30px;"  />
            </ItemTemplate>
            
            </asp:TemplateField>
            <asp:BoundField DataField="toarazi" HeaderText="Arazi">
                        <HeaderStyle BackColor="#00FF99" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
                        <asp:BoundField DataField="CUS_Total" HeaderText="TOTAL" >
                <HeaderStyle BackColor="#00FF99" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
            <asp:BoundField DataField="CUS_Paid" HeaderText="PAID" >
                <HeaderStyle BackColor="#00FF99" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
            <asp:BoundField DataField="CUS_Balance" HeaderText="BALANCE" >
                <HeaderStyle BackColor="#00FF99" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
            <asp:BoundField DataField="KIS_Total" HeaderText="TOTAL" >
                <HeaderStyle BackColor="#FFCC99" />
                <ItemStyle BackColor="#FFCC99" />
                </asp:BoundField>
            <asp:BoundField DataField="KIS_Paid" HeaderText="PAID" >
                <HeaderStyle BackColor="#FFCC99" />
                <ItemStyle BackColor="#FFCC99" />
                </asp:BoundField>
            <asp:BoundField DataField="KIS_Bal" HeaderText="BALANCE" >
                <HeaderStyle BackColor="#FFCC99" />
                <ItemStyle BackColor="#FFCC99" />
                </asp:BoundField>
            <asp:BoundField DataField="TOTAL_DEED" HeaderText="TOTAL DEED" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Rate" HeaderText="RATE" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Sale" HeaderText="SALE" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Red" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Sold" HeaderText="SOLD" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Red" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Bal" HeaderText="BALANCE" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Red" />
                </asp:BoundField>
            <asp:BoundField DataField="Total_AMT" HeaderText="TOTAL AMT" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="Sold_AMT" HeaderText="SOLD AMT" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="Bal_AMT" HeaderText="BAL AMT" >
                <HeaderStyle BackColor="#99CCFF" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="Avg_AMT" HeaderText="AVG AMT" >
                <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="Black" ForeColor="White" />
                </asp:BoundField>
            <asp:TemplateField>
            <ItemTemplate>
            <TR>
            <td colspan="100%">
            <div id='<%# Eval("toarazi") %>' style="display:none;" />
             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" style="width:100%;">
             <Columns>
             <asp:TemplateField HeaderText = "S.N" HeaderStyle-Width="29px">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
        </asp:TemplateField>
              <asp:BoundField DataField="fromarazi" HeaderText="Arazi"  HeaderStyle-Width="83.5px">
          <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
                        <asp:BoundField DataField="CUS_Total" HeaderText="TOTAL"  HeaderStyle-Width="84px">
                         <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
            <asp:BoundField DataField="CUS_Paid" HeaderText="PAID" HeaderStyle-Width="84.5px">
             <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
            <asp:BoundField DataField="CUS_Balance" HeaderText="BALANCE" HeaderStyle-Width="82px" >
             <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#00FF99" />
                </asp:BoundField>
            <asp:BoundField DataField="KIS_Total" HeaderText="TOTAL"  HeaderStyle-Width="85px"  >
             <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#FFCC99" />
                </asp:BoundField>
            <asp:BoundField DataField="KIS_Paid" HeaderText="PAID"  HeaderStyle-Width="84px" >
             <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#FFCC99" />
                </asp:BoundField>
            <asp:BoundField DataField="KIS_Bal" HeaderText="BALANCE" >
             <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#FFCC99" />
                </asp:BoundField>
            <asp:BoundField DataField="TOTAL_DEED" HeaderText="TOTAL DEED" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Rate" HeaderText="RATE" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Sale" HeaderText="SALE"  HeaderStyle-Width="46px" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Red" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Sold" HeaderText="SOLD" >
             <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Red" />
                </asp:BoundField>
            <asp:BoundField DataField="LAN_Bal" HeaderText="BALANCE" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF"  Font-Bold="True" ForeColor="Red"/>
                </asp:BoundField>
            <asp:BoundField DataField="Total_AMT" HeaderText="TOTAL AMT" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="Sold_AMT" HeaderText="SOLD AMT" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="Bal_AMT" HeaderText="BAL AMT" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle BackColor="#99CCFF" />
                </asp:BoundField>
            <asp:BoundField DataField="Avg_AMT" HeaderText="AVG AMT" >
            <HeaderStyle BackColor="Black" ForeColor="White" />
                <ItemStyle  BackColor="Black" ForeColor="White" />
                </asp:BoundField>
           <asp:TemplateField>
        <ItemTemplate>
           
        </ItemTemplate>
        </asp:TemplateField>
             </Columns>
             </asp:GridView>
            </td>
            </TR>
            </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            </asp:GridView>
       
        </asp:Panel>
        
    </div>
    </form>
</body>
</html>
