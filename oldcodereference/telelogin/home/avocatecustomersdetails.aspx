<%@ Page Language="C#" AutoEventWireup="true" CodeFile="avocatecustomersdetails.aspx.cs" Inherits="ragistry_customersdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
      <script type="text/javascript">
          function doPrint() {
              var prtContent = document.getElementById('<%= GridView1.ClientID %>');
              var prtContent1 = document.getElementById('<%= Panel1.ClientID %>');
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
    <style type="text/css">
        .style5
        {
            width: 100%;
        }
        .style6
        {
            text-align: center;
            font-size: large;
            color: #FF0000;
        }
        .style7
        {
            font-weight: 700;
        }
        .style9
        {
        }
        </style>
    <style type="text/css">

        .style5
        {
            width: 100%;
        }
        .style6
        {
            text-align: center;
            font-size: large;
            color: #FF0000;
        }
        .style9
        {
        }
        .style7
        {
            font-weight: 700;
            margin-left: 0px;
        }
        .style11
        {
            color: #FFFFFF;
        }
        .style12
        {
            width: 282px;
        }
        .style13
        {
            width: 159px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Panel ID="Panel1" runat="server">
  
    <table class="style5">
        <tr>
            <td bgcolor="#CCFFCC" class="style6" colspan="6">
                <strong>ARAZI WISECUSTOMER&#39;S&nbsp; DEED DETAILS </strong>
            </td>
        </tr>
        <tr>
            <td bgcolor="#CCFFCC" class="style9">
                <b>Arazi No</b></td>
            <td bgcolor="#CCFFCC" class="style13">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    CssClass="style7" Height="22px" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="105px">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button3" runat="server" Text="All" 
                    onclick="Button3_Click" style="font-weight: 700" Width="37px" />
            </td>
            <td bgcolor="#CCFFCC" colspan="2">
                <b>Deed No.</b></td>
            <td bgcolor="#CCFFCC">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="style7">
                </asp:DropDownList>
            </td>
            <td bgcolor="#CCFFCC">
                <asp:Button ID="Button1" runat="server" CssClass="style7" 
                    onclick="Button1_Click" Text="VIEW" />
                &nbsp;&nbsp; <asp:Button ID="Button2" runat="server" style="font-weight: 700" Text="Print"  OnClientClick="doPrint()"/>
                &nbsp;
                <asp:Label ID="Label6" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="#CCFFCC" class="style9">
                <b>Buyer Name</b></td>
            <td bgcolor="#CCFFCC" class="style13">
                <b>Purchase Date</b></td>
            <td bgcolor="#CCFFCC" colspan="2">
                <b>Total GAJ&nbsp; -&nbsp;&nbsp;&nbsp; Road GAJ&nbsp;&nbsp; =&nbsp; Sale GAJ</b></td>
            <td bgcolor="#CCFFCC">
                <b>Sold Ragistry</b></td>
            <td bgcolor="#CCFFCC">
                <b>Bal GAJ</b></td>
        </tr>
        <tr>
            <td bgcolor="#CCFFCC" class="style9">
                <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Red" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td bgcolor="#CCFFCC" class="style13">
                <asp:Label ID="Label2" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
            </td>
            <td bgcolor="#CCFFCC" colspan="2">
                <asp:Label ID="Label3" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
            </td>
            <td bgcolor="#CCFFCC">
                <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="Red" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td bgcolor="#CCFFCC">
                <asp:Label ID="Label5" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td bgcolor="black" class="style12" colspan="3">
                <span class="style11"><strong>Saller Name</strong></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="Label" 
                    style="color: #FFFFFF; font-weight: 700"></asp:Label>
            </td>
            <td bgcolor="black" style="text-align:right;color:White;font-weight:bold;" colspan="3">
                Total Deed No-&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td colspan="6">
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" ForeColor="Black" GridLines="None" DataKeyNames="CID" onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
       Width="100%" height="100%" 
                    style="text-align:left;" onrowcommand="GridView1_RowCommand">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:BoundField DataField="cid" HeaderText="CID" ReadOnly="true"/>
                         <asp:TemplateField>
            <HeaderTemplate>Date</HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("date", "{0:dd/MM/yyyy}")%>' ></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
  <asp:TextBox ID="txtDOB" Text='<%# Bind("date","{0:yyyy-MM-dd}") %>' TextMode="Date" runat="server"></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
                        <asp:BoundField DataField="name1" HeaderText="NAME-1" />
                        <asp:BoundField DataField="name2" HeaderText="NAME-2" />
                        <asp:BoundField DataField="name3" HeaderText="NAME-3" />
                        <asp:BoundField DataField="plotno" HeaderText="PLOT NO" > <ControlStyle Width="60" />
                        <ControlStyle ForeColor="#006600" />
                        </asp:BoundField>
                        <asp:BoundField DataField="plotsize" HeaderText="PLOT SIZE" > <ControlStyle Width="50" />
                        <ControlStyle ForeColor="Red" />
                        </asp:BoundField>
                        <asp:TemplateField>
            <HeaderTemplate>FILE</HeaderTemplate>
    <ItemTemplate>
        <asp:ImageButton  ID="lbldeed" runat="server" ImageUrl="~/ragistry/adb.png" CommandArgument='<%# Eval("path")%>' CommandName="download"></asp:ImageButton>
    </ItemTemplate>
    
</asp:TemplateField>
                       <asp:BoundField DataField="deedno" HeaderText="DEED" > <ControlStyle Width="80" />
                        <ControlStyle ForeColor="BLUE" />
                        </asp:BoundField> 
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                        HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
            </td>
        </tr>
    </table>
      </asp:Panel>
    
    </div>
    </form>
</body>
</html>
