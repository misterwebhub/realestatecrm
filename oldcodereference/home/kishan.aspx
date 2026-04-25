<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kishan.aspx.cs" Inherits="kishan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
          $("#TextBox10").datepicker({
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
            font-size: large;
            color: #990000;
            }
        .style4
        {
        }
        .style7
        {
            width: 147px;
        }
        .style9
        {
            width: 262px;
        }
        .style10
        {
            width: 262px;
            height: 45px;
        }
        .style14
        {
            width: 262px;
            height: 41px;
        }
        .style18
        {
            width: 262px;
            height: 39px;
        }
        .style22
        {
            width: 262px;
            height: 42px;
        }
        .style26
        {
            width: 262px;
            height: 36px;
        }
        .style29
        {
        }
        .style30
        {
            width: 262px;
            height: 38px;
        }
        .style34
        {
            width: 262px;
            height: 76px;
        }
        .style35
        {
            height: 76px;
        }
        .style51
        {
            width: 97px;
        }
        .style52
        {
            font-size: large;
            color: #990000;
            text-align: left;
        }
        .style53
        {
            width: 168px;
            height: 45px;
        }
        .style54
        {
            width: 168px;
            height: 41px;
        }
        .style55
        {
            width: 168px;
            height: 39px;
        }
        .style56
        {
            width: 168px;
            height: 42px;
        }
        .style57
        {
            width: 168px;
            height: 36px;
        }
        .style58
        {
            width: 168px;
            height: 38px;
        }
        .style59
        {
            width: 168px;
        }
        .style60
        {
            width: 147px;
            height: 45px;
        }
        .style61
        {
            width: 147px;
            height: 41px;
        }
        .style62
        {
            width: 147px;
            height: 39px;
        }
        .style63
        {
            width: 147px;
            height: 42px;
        }
        .style64
        {
            width: 147px;
            height: 36px;
        }
        .style65
        {
            width: 147px;
            height: 38px;
        }
        .style66
        {
            width: 151px;
            height: 45px;
        }
        .style67
        {
            width: 151px;
            height: 41px;
        }
        .style68
        {
            width: 151px;
            height: 39px;
        }
        .style69
        {
            width: 151px;
            height: 42px;
        }
        .style70
        {
            width: 151px;
            height: 36px;
        }
        .style71
        {
            width: 151px;
            height: 38px;
        }
        .style72
        {
            width: 151px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:100%;width:80%;margin-left:10%;border:5px solid blue;">
   
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
           <asp:Button ID="Button7" runat="server" Text="SUBMIT" onclick="Button7_Click" /></td></tr>
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
   
    </div>
    

<div id="type1" style="display:none" align = "center">
   
</div>

<div id="from1" style="display:none" align = "center">
    
</div>
    </form>
</body>
</html>
