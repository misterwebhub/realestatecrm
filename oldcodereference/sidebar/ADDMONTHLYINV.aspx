<%@ Page Title="" Language="C#" MasterPageFile="~/sidebar/MasterPage.master" AutoEventWireup="true" CodeFile="ADDMONTHLYINV.aspx.cs" Inherits="sidebar_ADDINV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style type="text/css">
        .style1
        {
            height: 63px;
        }
        .style2
        {
            height: 63px;
            width: 197px;
        }
        .style3
        {
            width: 197px;
            height: 45px;
        }
        .style4
        {
            height: 63px;
            width: 136px;
        }
        .style5
        {
            width: 136px;
            height: 45px;
        }
        .style6
        {
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat=server>
<div class="container">
  
  <div class="panel-group">
    <div class="panel panel-primary">
      <div class="panel-heading"><h4>ADD MONTHLY INESTER FOR PAYMENT DETAILS</h4></div>
      <div class="panel-body">
      
      
          <table class="nav-justified">
              <tr>
                  <td class="style4">
                      INVESTER ID</td>
                  <td class="style2">
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                     <td class="style1">
                         <asp:Button ID="Button1" runat="server" Text="SEARCH" onclick="Button1_Click" /></td>
                         <td class="style1">
                      INVESTER ID</td>
                  <td class="style1">
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                     <td class="style1">
                         <asp:Button ID="Button2" runat="server" Text="DEL" onclick="Button2_Click" /></td>
              </tr>
              <tr>
                  <td class="style5">
                      NAME</td>
                  <td colspan="1" class="style3">
                      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                      <td colspan="4" class="style6"> <asp:Button ID="Button3" runat="server" Text="ADD" 
                              onclick="Button3_Click" /></td>
                      
              </tr>
              <tr>
              <td colspan="6">
                  <asp:GridView ID="GridView1" runat="server" style="width:100%;" 
                      BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                      CellPadding="4" ForeColor="Black" GridLines="Vertical">
                      <AlternatingRowStyle BackColor="White" />
                      <FooterStyle BackColor="#CCCC99" />
                      <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                      <RowStyle BackColor="#F7F7DE" />
                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#FBFBF2" />
                      <SortedAscendingHeaderStyle BackColor="#848384" />
                      <SortedDescendingCellStyle BackColor="#EAEAD3" />
                      <SortedDescendingHeaderStyle BackColor="#575357" />
                  </asp:GridView>
              </td>
                 
              </tr>
          </table>
      
      
      </div>
    </div>
    </div>
    </div>
    </form>
</asp:Content>

