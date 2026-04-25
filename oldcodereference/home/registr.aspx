<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registr.aspx.cs" Inherits="registr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kishan Registration</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
    <script type="text/javascript">
        $(function () {
            $("#countrytabs").tabs();
        });
        $(document).ready(function () {
            $("#TextBox2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
            $("#TextBox10").datepicker({
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
            $("#TextBox67").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });


        });
    </script>
    <style>
        body
        {
            font-size: 11pt;
        }
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 22px;
        }
        .style3
        {
            height: 30px;
        }
        ul
        {
        background-color:#e9e9e9;
        }
        ul li
        {
            list-style:none;
            display:inline-block;
            padding:15px 25px ;
            border-radius:5px;
            background-color:ActiveCaption;
        }
        .t
        {
            text-decoration:none;
            font-size:14pt;
            color:Black;
        }
       ul li:hover
       {
          background-color: #dddddd;
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
            <li>
                <asp:LinkButton ID="LinkButton4" runat="server" class="t" 
                    onclick="LinkButton4_Click">EMPLOYEE</asp:LinkButton></li>
         
        </ul>
        <div id="countrytabs-1">
            <asp:Panel ID="Panel3" runat="server">
            
             <table class="style1">
            <tr>
                <td class="style52" colspan="4">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; KISHAN REGISTRATION</strong></td>
                <td class="style2" style="text-align: center" colspan="2" rowspan="7">
                    <asp:Panel ID="Panel1" runat="server" Height="237px" BackColor="#FFFF99">
                    <table style="height:100%;width:100%;">
   <tr><td>ARAZI</td><td>
       <asp:TextBox ID="TextBox22" runat="server" CssClass="autosuggest3"></asp:TextBox></td></tr>
       <tr><td>KISHAN NAME</td><td>
       <asp:TextBox ID="TextBox16" runat="server" CssClass="autosuggest3"></asp:TextBox></td></tr>
       <tr><td>LOCATION</td><td>
       <asp:TextBox ID="TextBox17" runat="server" CssClass="autosuggest3"></asp:TextBox></td></tr>
       <tr><td></td><td>
           <asp:Button ID="Button6" runat="server" Text="SUBMIT" onclick="Button6_Click" /></td></tr>
           <tr><td></td><td>
               <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="Red"></asp:Label></td></tr>
   </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style52" colspan="4">
                    &nbsp;
                    REG.NO-
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="#000066" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    NAME</td>
                <td class="style53">
                    <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="131px"></asp:TextBox>
                </td>
                <td class="style60">
                    DATE</td>
                <td class="style66">
                    <asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="137px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    MOBILE</td>
                <td class="style54">
                    <asp:TextBox ID="TextBox3" runat="server" Height="24px" Width="131px"></asp:TextBox>
                </td>
                <td class="style61">
                    LAND SIZE</td>
                <td class="style67">
                    <asp:TextBox ID="TextBox4" runat="server" Height="26px" Width="138px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    SALE LAND</td>
                <td class="style55">
                    <asp:TextBox ID="TextBox24" runat="server" Height="24px" Width="131px">0</asp:TextBox>
                </td>
                <td class="style62">
                    SALE RATE</td>
                <td class="style68">
                    <asp:TextBox ID="TextBox25" runat="server" Height="27px" Width="137px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style22">
                    ARAZI</td>
                <td class="style56">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="124px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                        style="font-weight: 700">New</asp:LinkButton>
                </td>
                <td class="style63">
                    LOCATION</td>
                <td class="style69">
                    &nbsp;<asp:TextBox ID="TextBox5" runat="server" Height="26px" Width="136px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    TOTAL AMOUNT</td>
                <td class="style55">
                    <asp:TextBox ID="TextBox6" runat="server" Height="26px" Width="131px"></asp:TextBox>
                </td>
                <td class="style62">
                    BAYANA MODE</td>
                <td class="style68">
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="CASH" 
                        AutoPostBack="True" GroupName="amar" 
                        oncheckedchanged="RadioButton1_CheckedChanged" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="CHEQUE" 
                        AutoPostBack="True" GroupName="amar" 
                        oncheckedchanged="RadioButton2_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td class="style26">
                    <asp:Label ID="Label11" runat="server" Text="TYPE"></asp:Label>
                </td>
                <td class="style57">
                    <asp:TextBox ID="TextBox9" runat="server" Height="24px" Width="130px"></asp:TextBox>
                </td>
                <td class="style64">
                    AMOUNT</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox8" runat="server" Height="24px" Width="134px" 
                        AutoPostBack="True" ontextchanged="TextBox8_TextChanged"></asp:TextBox>
                </td>
                <td class="style29" colspan="2" rowspan="6">
                    <asp:Panel ID="Panel2" runat="server" Height="277px" BackColor="#FF99FF">
                    <table style="height:100%;width:100%;">
     <tr><td class="style51">BROKER NAME</td><td>
         <asp:TextBox ID="TextBox18" runat="server" Height="25px" Width="108px"></asp:TextBox>
     </td></tr>
   <tr><td class="style51">AADHAR NO.</td><td>
       <asp:TextBox ID="TextBox23" runat="server" Height="21px" Width="110px"></asp:TextBox></td></tr>
         <tr><td class="style51">MOBILE NO.</td><td>
       <asp:TextBox ID="TextBox19" runat="server" Height="23px" Width="113px"></asp:TextBox></td></tr>
       <tr><td class="style51"></td><td>
           <asp:Button ID="Button7" runat="server" Text="SUBMIT" onclick="Button7_Click" 
               style="height: 26px" /></td></tr>
           <tr><td class="style51"></td><td>
               <asp:Label ID="Label10" runat="server" Text="Label" ForeColor="Red"></asp:Label></td></tr>
   </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    BALANCE</td>
                <td class="style58">
                    <asp:TextBox ID="TextBox7" runat="server" Height="26px" Width="128px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style65">
                    LAST DATE</td>
                <td class="style71">
                    <asp:TextBox ID="TextBox10" runat="server" Height="24px" Width="135px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    BROKER</td>
                <td class="style57">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="22px" Width="119px">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
                        style="font-weight: 700">New</asp:LinkButton>
                </td>
                <td class="style64">
                    BROKER PAYMENT</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox11" runat="server" Height="24px" Width="136px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    BROKER PAID</td>
                <td class="style57">
                    <asp:TextBox ID="TextBox12" runat="server" Height="24px" Width="131px" 
                        AutoPostBack="True" ontextchanged="TextBox12_TextChanged"></asp:TextBox>
                </td>
                <td class="style64">
                    BROKER BALANCE</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox13" runat="server" Height="24px" Width="134px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style34">
                    BROKER COMMENT</td>
                <td class="style35" colspan="3">
                    <asp:TextBox ID="TextBox14" runat="server" Height="76px" Width="537px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    KISHAN COMMENT</td>
                <td class="style4" colspan="3">
                    <asp:TextBox ID="TextBox15" runat="server" Height="83px" Width="537px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3">
                    </td>
                <td class="style3">
                    </td>
                <td class="style3">
                    </td>
                <td class="style3">
                    </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="SUBMIT" Width="269px" 
                        onclick="Button1_Click" />
                </td>
                <td class="style72">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
        </table>
   </asp:Panel>
        </div>
        <div id="countrytabs-2">
            <asp:Panel ID="Panel5" runat="server">
            
             <table class="style1">
            <tr>
                <td class="style52" colspan="4">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; INVESTER REGISTRATION</strong></td>
                <td class="style2" style="text-align: center" colspan="2" rowspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style52" colspan="4">
                    &nbsp;
                    REG.NO-
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="#000066" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    NAME</td>
                <td class="style53">
                    <asp:TextBox ID="TextBox29" runat="server" Height="26px" Width="131px"></asp:TextBox>
                </td>
                <td class="style60">
                    DATE</td>
                <td class="style66">
                    <asp:TextBox ID="TextBox30" runat="server" Height="26px" Width="137px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    MOBILE</td>
                <td class="style54">
                    <asp:TextBox ID="TextBox31" runat="server" Height="24px" Width="131px"></asp:TextBox>
                </td>
                <td class="style61">
                    TOTAL INVEST AMT</td>
                <td class="style67">
                    <asp:TextBox ID="TextBox49" runat="server" Height="26px" Width="131px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    FINAL RETURN AMT</td>
                <td class="style55">
                    <asp:TextBox ID="TextBox36" runat="server" Height="26px" Width="131px">0</asp:TextBox>
                </td>
                <td class="style62">
                    PAYMENT&nbsp; MODE</td>
                <td class="style68">
                    <asp:RadioButton ID="RadioButton9" runat="server" AutoPostBack="True" 
                        GroupName="T" oncheckedchanged="RadioButton9_CheckedChanged" Text="CASH" />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton10" runat="server" AutoPostBack="True" 
                        GroupName="T" oncheckedchanged="RadioButton10_CheckedChanged" Text="CHEQUE" />
                </td>
            </tr>
            <tr>
                <td class="style26">
                    <asp:Label ID="Label15" runat="server" Text="TYPE"></asp:Label>
                </td>
                <td class="style57">
                    <asp:TextBox ID="TextBox37" runat="server" Height="24px" Width="130px"></asp:TextBox>
                </td>
                <td class="style64">
                    RECIEVE
                    AMOUNT</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox75" runat="server" AutoPostBack="True" Height="24px" 
                        ontextchanged="TextBox75_TextChanged" Width="132px"></asp:TextBox>
                </td>
                <td class="style29" colspan="2" rowspan="6">
                    <asp:Panel ID="Panel4" runat="server" Height="277px" BackColor="#FF99FF">
                    <table style="height:100%;width:100%;">
     <tr><td class="style51">BROKER NAME</td><td>
         <asp:TextBox ID="TextBox39" runat="server" Height="25px" Width="108px"></asp:TextBox>
     </td></tr>
   <tr><td class="style51">AADHAR NO.</td><td>
       <asp:TextBox ID="TextBox40" runat="server" Height="21px" Width="110px"></asp:TextBox></td></tr>
         <tr><td class="style51">MOBILE NO.</td><td>
       <asp:TextBox ID="TextBox41" runat="server" Height="23px" Width="113px"></asp:TextBox></td></tr>
       <tr><td class="style51"></td><td>
           <asp:Button ID="Button14" runat="server" onclick="Button14_Click" 
               style="font-weight: 700" Text="Submit" Width="70px" />
           </td></tr>
           <tr><td class="style51"></td><td>
               <asp:Label ID="Label16" runat="server" Text="Label" ForeColor="Red"></asp:Label></td></tr>
   </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style30">
                    BALANCE</td>
                <td class="style58">
                    <asp:TextBox ID="TextBox42" runat="server" Height="26px" Width="128px" 
                        ReadOnly="True">0</asp:TextBox>
                </td>
                <td class="style65">
                    LAST DATE</td>
                <td class="style71">
                    <asp:TextBox ID="TextBox43" runat="server" Height="24px" Width="135px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    BROKER</td>
                <td class="style57">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="22px" Width="119px">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton8_Click">New</asp:LinkButton>
                </td>
                <td class="style64">
                    BROKER PAYMENT</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox44" runat="server" Height="24px" Width="136px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    BROKER PAID</td>
                <td class="style57">
                    <asp:TextBox ID="TextBox76" runat="server" AutoPostBack="True" Height="26px" 
                        ontextchanged="TextBox76_TextChanged" Width="131px">0</asp:TextBox>
                </td>
                <td class="style64">
                    BROKER BALANCE</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox46" runat="server" Height="24px" Width="134px" 
                        ReadOnly="True">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style34">
                    BROKER COMMENT</td>
                <td class="style35" colspan="3">
                    <asp:TextBox ID="TextBox47" runat="server" Height="76px" Width="537px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    INVESTER COMMENT</td>
                <td class="style4" colspan="3">
                    <asp:TextBox ID="TextBox48" runat="server" Height="83px" Width="537px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    MONTHLY PAYMENT</td>
                <td class="style59">
                 <asp:TextBox ID="TextBox481" runat="server" TextMode="Number"></asp:TextBox>   </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
				 <tr>
                <td class="style9">
                   &nbsp;</td>
                <td class="style59">
                 &nbsp;  </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    <asp:Button ID="Button16" runat="server" Height="28px" onclick="Button16_Click" 
                        style="font-weight: 700" Text="SUBMIT" Width="248px" />
                </td>
                <td class="style72">
                    <asp:Label ID="Label17" runat="server"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
        </table>
   </asp:Panel>
        </div>
        <div id="countrytabs-3">
            <asp:Panel ID="Panel6" runat="server">
          
             <table class="style1">
            <tr>
                <td class="style52" colspan="4">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    BROKER REGISTRATION</strong></td>
                <td class="style2" style="text-align: center" colspan="2" rowspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style52" colspan="4">
                    &nbsp;
                    REG.NO-
                    <asp:Label ID="Label18" runat="server" Font-Bold="True" ForeColor="#000066" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    NAME</td>
                <td class="style53">
                    <asp:TextBox ID="TextBox50" runat="server" Height="26px" Width="131px"></asp:TextBox>
                </td>
                <td class="style60">
                    DATE</td>
                <td class="style66">
                    <asp:TextBox ID="TextBox51" runat="server" Height="26px" Width="137px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14">
                    MOBILE</td>
                <td class="style54">
                    <asp:TextBox ID="TextBox52" runat="server" Height="24px" Width="131px"></asp:TextBox>
                </td>
                <td class="style61">
                    LAST DATE</td>
                <td class="style67">
                    <asp:TextBox ID="TextBox61" runat="server" Height="24px" Width="135px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    TOTAL&nbsp; AMOUNT</td>
                <td class="style55">
                    <asp:TextBox ID="TextBox53" runat="server" Height="26px" Width="131px"></asp:TextBox>
                </td>
                <td class="style62">
                    PAYMENT&nbsp; MODE</td>
                <td class="style68">
                    <asp:RadioButton ID="RadioButton5" runat="server" Text="CASH" 
                        AutoPostBack="True" GroupName="amar" 
                        oncheckedchanged="RadioButton1_CheckedChanged" />
                    <asp:RadioButton ID="RadioButton6" runat="server" Text="CHEQUE" 
                        AutoPostBack="True" GroupName="amar" 
                        oncheckedchanged="RadioButton2_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td class="style26">
                    <asp:Label ID="Label19" runat="server" Text="TYPE"></asp:Label>
                </td>
                <td class="style57">
                    <asp:TextBox ID="TextBox55" runat="server" Height="24px" Width="130px"></asp:TextBox>
                </td>
                <td class="style64">
                    PAID
                    AMOUNT</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox56" runat="server" Height="24px" Width="134px" 
                        AutoPostBack="True" ontextchanged="TextBox8_TextChanged"></asp:TextBox>
                </td>
                <td class="style29" colspan="2" rowspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style30">
                    BALANCE</td>
                <td class="style58">
                    <asp:TextBox ID="TextBox60" runat="server" Height="26px" Width="128px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style65">
                    &nbsp;</td>
                <td class="style71">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style34">
                    BROKER COMMENT</td>
                <td class="style35" colspan="3">
                    <asp:TextBox ID="TextBox65" runat="server" Height="76px" Width="537px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style59">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    <asp:Button ID="Button15" runat="server" onclick="Button15_Click" 
                        style="font-weight: 700" Text="SUBMIT" Width="278px" />
                </td>
                <td class="style72">
                    <asp:Label ID="Label21" runat="server"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
        </table>
              </asp:Panel>
        </div>
        <div id="countrytabs-4">
            <asp:Panel ID="Panel7" runat="server">
           
             <table class="style1">
            <tr>
                <td class="style52" colspan="4">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    EMPLOYEE REGISTRATION</strong></td>
                <td class="style2" style="text-align: center" colspan="2" rowspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style52" colspan="4">
                    &nbsp;
                    REG.NO-
                    <asp:Label ID="Label22" runat="server" Font-Bold="True" ForeColor="#000066" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    NAME</td>
                <td class="style53">
                    <asp:TextBox ID="TextBox66" runat="server" Height="26px" Width="131px"></asp:TextBox>
                </td>
                <td class="style60">
                    DATE</td>
                <td class="style66">
                    <asp:TextBox ID="TextBox67" runat="server" Height="26px" Width="137px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    MOBILE</td>
                <td class="style55">
                    <asp:TextBox ID="TextBox68" runat="server" Height="24px" Width="131px"></asp:TextBox>
                </td>
                <td class="style62">
                    PAYMENT&nbsp; MODE</td>
                <td class="style68">
                    <asp:RadioButton ID="RadioButton11" runat="server" AutoPostBack="True" 
                        GroupName="P" oncheckedchanged="RadioButton11_CheckedChanged" Text="CASH" />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton12" runat="server" AutoPostBack="True" 
                        GroupName="P" oncheckedchanged="RadioButton12_CheckedChanged" Text="CHEQUE" />
                </td>
            </tr>
            <tr>
                <td class="style26">
                    <asp:Label ID="Label23" runat="server" Text="TYPE"></asp:Label>
                </td>
                <td class="style57">
                    <asp:TextBox ID="TextBox71" runat="server" Height="24px" Width="130px"></asp:TextBox>
                </td>
                <td class="style64">
                    PAID
                    AMOUNT</td>
                <td class="style70">
                    <asp:TextBox ID="TextBox77" runat="server"></asp:TextBox>
                </td>
                <td class="style29" colspan="2" rowspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style34">
                    EMPLOYEE&nbsp; COMMENT</td>
                <td class="style35" colspan="3">
                    <asp:TextBox ID="TextBox74" runat="server" Height="76px" Width="537px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style59">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    <asp:Button ID="Button18" runat="server" onclick="Button18_Click" 
                        style="font-weight: 700" Text="SUBMIT" Width="82px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button17" runat="server" onclick="Button17_Click" 
                        style="font-weight: 700" Text="New" Width="60px" />
                </td>
                <td class="style72">
                    <asp:Label ID="Label24" runat="server"></asp:Label>
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style4" colspan="2">
                    &nbsp;</td>
                <td class="style72">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
        </table>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
