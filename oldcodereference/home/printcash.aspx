<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printcash.aspx.cs" Inherits="printcash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cash Recipt</title>
       <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
   <script type="text/javascript">
       $(document).ready(function () {
           $("#TextBox1").datepicker({
               changeMonth: true,
               changeYear: true,
               dateFormat: 'dd/mm/yy'
           });
           $("#TextBox14").datepicker({
               changeMonth: true,
               changeYear: true,
               dateFormat: 'dd/mm/yy'
           });


       });
    </script>
    <style type="text/css">
    #main
    {
        box-shadow:0px 0px 4px gray;
        height:100%;
        width:98%;
        margin-left:1%;
    }
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 268px;
        }
        .style4
        {
            text-align: center;
            font-size: xx-large;
            height: 30px;
            color: #000066;
        }
        .style5
        {
            text-align: right;
            font-weight: bold;
        }
        .style6
        {
            width: 307px;
        }
        .style8
        {
            text-align: right;
            height: 28px;
        }
        .style10
        {
            font-size: small;
            font-weight: bold;
        }
        .style11
        {
            text-align: center;
            font-size: small;
            height: 14px;
            font-weight: bold;
        }
        .style12
        {
            text-align: center;
            font-size: small;
            height: 16px;
            font-weight: bold;
        }
        .style13
        {
            text-align: right;
            height: 10px;
        }
        .style14
        {
            text-align: center;
            font-size: medium;
            height: 9px;
            font-weight: bold;
        }
        .style16
        {
            text-align: right;
            width: 317px;
        }
        .style17
        {
            text-align: right;
            width: 317px;
            height: 29px;
            font-weight: bold;
        }
        .style18
        {
            height: 29px;
        }
        .style19
        {
            width: 268px;
            height: 29px;
            font-weight: bold;
        }
        .style20
        {
            height: 29px;
            font-weight: bold;
        }
        .style29
        {
            text-align: right;
            width: 317px;
            height: 30px;
            font-weight: bold;
        }
        .style30
        {
            width: 307px;
            height: 30px;
        }
        .style31
        {
            width: 268px;
            height: 30px;
            font-weight: bold;
        }
        .style32
        {
            height: 30px;
            font-weight: bold;
        }
        .style33
        {
            text-align: right;
            width: 317px;
            height: 32px;
            font-weight: bold;
        }
        .style34
        {
            width: 307px;
            height: 32px;
        }
        .style35
        {
            width: 268px;
            height: 32px;
            font-weight: bold;
        }
        .style36
        {
            height: 32px;
            font-weight: bold;
        }
        .style37
        {
            text-align: right;
            width: 317px;
            height: 39px;
            font-weight: bold;
        }
        .style38
        {
            width: 307px;
            height: 39px;
        }
        .style39
        {
            width: 268px;
            height: 39px;
            font-weight: bold;
        }
        .style40
        {
            height: 39px;
            font-weight: bold;
        }
        .style41
        {
            text-align: right;
            width: 317px;
            height: 35px;
            font-weight: bold;
        }
        .style42
        {
            width: 307px;
            height: 35px;
        }
        .style43
        {
            width: 268px;
            height: 35px;
            font-weight: bold;
        }
        .style44
        {
            height: 35px;
            font-weight: bold;
        }
        .style45
        {
            text-align: right;
            width: 317px;
            height: 31px;
            font-weight: bold;
        }
        .style46
        {
            height: 31px;
        }
        .style47
        {
            text-align: right;
            width: 317px;
            height: 55px;
        }
        .style48
        {
            width: 307px;
            height: 55px;
        }
        .style49
        {
            width: 268px;
            height: 55px;
            font-weight: bold;
        }
        .style50
        {
            height: 55px;
            font-weight: bold;
        }
        .style51
        {
            width: 268px;
            font-weight: bold;
        }
        .style52
        {
            width: 307px;
            font-weight: bold;
        }
        .style53
        {
            text-align: right;
            width: 317px;
            font-weight: bold;
        }
        .style54
        {
            text-align: right;
            width: 317px;
            height: 23px;
        }
        .style55
        {
            width: 307px;
            height: 23px;
        }
        .style56
        {
            width: 268px;
            height: 23px;
        }
        .style57
        {
            height: 23px;
        }
        .style58
        {
            width: 268px;
            text-align: right;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
    
        <table class="style1">
            <tr>
                <td class="style8" colspan="4">
                    <strong>Customer Copy </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <strong>ARSH DEVELOPERS &amp; BUILDERS</strong></td>
            </tr>
            <tr>
                <td class="style11" colspan="4">
                    <span class="style10" 
                        
                        
                        style="color: rgb(0, 0, 0); font-family: Hind, sans-serif; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">
                    38A, 150 Road, Ganga Nagar Chauraha, </span></td>
            </tr>
            <tr>
                <td class="style12" colspan="4">
                    <span class="style10" 
                        
                        
                        style="color: rgb(0, 0, 0); font-family: Hind, sans-serif; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">
                    Near National Public school,&nbsp; Shyam Nagar, Kanpur, U.P. 208021, India</span></td>
            </tr>
            <tr>
                <td class="style14" colspan="4">
                    <span class="style10">Call Us -
                    </span>
                    <span style="color: rgb(0, 0, 0); font-family: Hind, sans-serif; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;" 
                        class="style10">
                    +91 9336822863&nbsp;, +91 9452747083&nbsp;&nbsp;&nbsp; 
                    Web - www.harshdeveloper.com</span></td>
            </tr>
            <tr>
                <td class="style13" colspan="4">
                   <center>
                       <p style="padding:6px;background-color:Black;color:White;width:35%; font-weight:bold; height: 17px;"> PAYMENT&nbsp;&nbsp; RECEIPT</p></center> </td>
            </tr>
            <tr>
                <td class="style17">
                    Receipt No - </td>
                <td class="style18">
                    <b>&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </b>
                </td>
                <td class="style19">
                    Receipt Date</td>
                <td class="style20">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style17">
                    Arazi No/Block</td>
                <td class="style18">
                    <b>&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </b>
                </td>
                <td class="style19">
                    Location</td>
                <td class="style20">
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style29">
                    Plot No.</td>
                <td class="style30">
                    <b>&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    </b>
                </td>
                <td class="style31">
                    Area ( Gaj/Sq.ft )</td>
                <td class="style32">
                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="4">
                    <hr /></td>
            </tr>
            <tr>
                <td class="style17">
                    Buyer&#39;s Name      Buyer&#39;s Name</td>
                <td class="style18">
                    <b>&nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </b>
                </td>
                <td class="style19">
                    Mobile No.</td>
                <td class="style20">
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style37">
                    Address</td>
                <td class="style38">
                    <b>&nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    </b>
                </td>
                <td class="style39">
                    Plot Type</td>
                <td class="style40">
                    <asp:Label ID="Label2" runat="server" Text="Normal"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style41">
                    Plot Rate/Gaj</td>
                <td class="style42">
                    <b>&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
&nbsp;/ Gaj</b></td>
                <td class="style43">Total Amount</td>
                <td class="style44">
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33">
                    Advance Amount</td>
                <td class="style34">
                    <b>&nbsp;&nbsp;
                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </b>
                </td>
                <td class="style35">
                    Pay Mode              Pay Mode</td>
                <td class="style36">
                    <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style45">
                    In Words (Rs.) </td>
                <td class="style46" colspan="2">
                    <b>&nbsp;&nbsp;
                    <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                    </b>
                </td>
                <td class="style46">
                    </td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="Label3" runat="server" Text="Cheque No."></asp:Label>
                </td>
                <td class="style34">
                    <b>&nbsp;&nbsp;
                    <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                    </b>
                                    </td>
                <td class="style35">
                    <asp:Label ID="Label4" runat="server" Text="Cheque Date"></asp:Label>
                </td>
                <td class="style36">
                    <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                                    </td>
            </tr>
            <tr>
                <td class="style47">
                    </td>
                <td class="style48">
                    </td>
                <td class="style49">
                    &nbsp;</td>
                <td class="style50">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style53">
                    &nbsp;</td>
                <td class="style52">&nbsp;</td>
                <td class="style51">
                    &nbsp;</td>
                <td>
                    <b></b></td>
            </tr>
            <tr>
                <td class="style53">
                    &nbsp;</td>
                <td class="style52">
                    &nbsp;</td>
                <td class="style51">
                    &nbsp;</td>
                <td>
                    <b></b></td>
            </tr>
            <tr>
                <td class="style54">
                    </td>
                <td class="style55">
                    </td>
                <td class="style56">
                    </td>
                <td class="style57">
                    </td>
            </tr>
            <tr>
                <td class="style16">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style58">
                    <strong style="text-align: right">&nbsp;&nbsp;&nbsp;&nbsp; Authority Signature&nbsp;&nbsp;&nbsp;&nbsp;
                    </strong></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style16">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

