<%@ Page Language="C#" AutoEventWireup="true" CodeFile="investerbondint.aspx.cs" Inherits="invsterintrest_investerbondint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
    <script type="text/javascript">
        $(function () {
       
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
                   });
    </script>
    <style type="text/css">

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
            height: 34px;
        }
        .style4
        {
            height: 24px;
        }
        .style5
        {
            height: 28px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <asp:Panel ID="Panel5" runat="server">
            
             <table class="style1">
            <tr>
                <td class="style3" colspan="4" bgcolor="#CC33FF">
                    <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; INVESTER REGISTRATION</strong></td>
                <td class="style2" style="text-align: center" colspan="2" rowspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5" colspan="4" bgcolor="#CCFFFF">
                    REG.NO-
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="#000066" 
                        Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10" bgcolor="#CCFFFF">
                    NAME</td>
                <td class="style53" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox29" runat="server" Height="26px" Width="131px"></asp:TextBox>
                </td>
                <td class="style60" bgcolor="#CCFFFF">
                    DATE</td>
                <td class="style66" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox30" runat="server" Height="26px" Width="137px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style14" bgcolor="#CCFFFF">
                    MOBILE</td>
                <td class="style54" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox31" runat="server" Height="24px" Width="131px"></asp:TextBox>
                </td>
                <td class="style61" bgcolor="#CCFFFF">
                    TOTAL INVEST AMT</td>
                <td class="style67" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox49" runat="server" Height="26px" Width="131px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style18" bgcolor="#CCFFFF">
                    FINAL RETURN AMT</td>
                <td class="style55" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox36" runat="server" Height="26px" Width="131px">0</asp:TextBox>
                </td>
                <td class="style62" bgcolor="#CCFFFF">
                    PAYMENT&nbsp; MODE</td>
                <td class="style68" bgcolor="#CCFFFF">
                    <asp:RadioButton ID="RadioButton9" runat="server" AutoPostBack="True" 
                        GroupName="T" oncheckedchanged="RadioButton9_CheckedChanged" Text="CASH" />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton10" runat="server" AutoPostBack="True" 
                        GroupName="T" oncheckedchanged="RadioButton10_CheckedChanged" Text="CHEQUE" />
                </td>
            </tr>
            <tr>
                <td class="style26" bgcolor="#CCFFFF">
                    <asp:Label ID="Label15" runat="server" Text="TYPE"></asp:Label>
                </td>
                <td class="style57" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox37" runat="server" Height="24px" Width="130px"></asp:TextBox>
                </td>
                <td class="style64" bgcolor="#CCFFFF">
                    RECIEVE
                    AMOUNT</td>
                <td class="style70" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox75" runat="server" AutoPostBack="True" Height="24px" 
                        ontextchanged="TextBox75_TextChanged" Width="132px"></asp:TextBox>
                </td>
                <td class="style29" colspan="2" rowspan="7">
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
                <td class="style30" bgcolor="#CCFFFF">
                    BALANCE</td>
                <td class="style58" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox42" runat="server" Height="26px" Width="128px" 
                        ReadOnly="True">0</asp:TextBox>
                </td>
                <td class="style65" bgcolor="#CCFFFF">
                    LAST DATE</td>
                <td class="style71" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox43" runat="server" Height="24px" Width="135px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style26" bgcolor="#CCFFFF">
                    BROKER</td>
                <td class="style57" bgcolor="#CCFFFF">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="22px" Width="119px">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton8_Click">New</asp:LinkButton>
                </td>
                <td class="style64" bgcolor="#CCFFFF">
                    BROKER PAYMENT</td>
                <td class="style70" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox44" runat="server" Height="24px" Width="136px">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style26" bgcolor="#CCFFFF">
                    BROKER PAID</td>
                <td class="style57" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox76" runat="server" AutoPostBack="True" Height="26px" 
                        ontextchanged="TextBox76_TextChanged" Width="131px">0</asp:TextBox>
                </td>
                <td class="style64" bgcolor="#CCFFFF">
                    BROKER BALANCE</td>
                <td class="style70" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox46" runat="server" Height="24px" Width="134px" 
                        ReadOnly="True">0</asp:TextBox>
                </td>
            </tr>
                 <tr>
                     <td bgcolor="#CCFFFF" class="style26">
                         INTREST (%)</td>
                     <td bgcolor="#CCFFFF" class="style57">
                         <asp:TextBox ID="TextBox77" runat="server" Height="23px" Width="80px"></asp:TextBox>
                         &nbsp;Only Number</td>
                     <td bgcolor="#CCFFFF" class="style64">
                         &nbsp;</td>
                     <td bgcolor="#CCFFFF" class="style70">
                         &nbsp;</td>
                 </tr>
            <tr>
                <td class="style34" bgcolor="#CCFFFF">
                    BROKER COMMENT</td>
                <td class="style35" colspan="3" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox47" runat="server" Height="76px" Width="537px" 
                        TextMode="MultiLine">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9" bgcolor="#CCFFFF">
                    INVESTER COMMENT</td>
                <td class="style4" colspan="3" bgcolor="#CCFFFF">
                    <asp:TextBox ID="TextBox48" runat="server" Height="83px" Width="537px" 
                        TextMode="MultiLine">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9" bgcolor="#CCFFFF">
                    &nbsp;</td>
                <td class="style59" bgcolor="#CCFFFF">
                    &nbsp;</td>
                <td class="style7" bgcolor="#CCFFFF">
                    &nbsp;</td>
                <td class="style72" bgcolor="#CCFFFF">
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
    </form>
</body>
</html>
