<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthlypayment.aspx.cs" Inherits="_161GHA_extrapaymentrecipt" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Bootstrap Example</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.10.0/js/bootstrap-datepicker.min.js"></script>
  <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.10.0/css/bootstrap-datepicker.min.css" />
  <script type="text/javascript">
      $(function () {
          $("#TextBox1").datepicker({
              changeMonth: true,
              changeYear: true,
              format: "dd/mm/yyyy"
          });
          $("#TextBox7").datepicker({
              changeMonth: true,
              changeYear: true,
              format: "dd/mm/yyyy"
          });
          $("#TextBox8").datepicker({
              changeMonth: true,
              changeYear: true,
              format: "dd/mm/yyyy"
          });
      });
</script>
    <style type="text/css">
        .style1
        {
            width: 85px;
        }
        .style3
        {
            width: 142px;
        }
        .style4
        {
            width: 116px;
        }
        .style5
        {
            width: 131px;
        }
        .style6
        {
            width: 134px;
        }
    </style>
</head>
<body>
 <form runat="server">
<div class="container">
 
  <div class="panel-group">
  

    <div class="panel panel-primary">
      <div class="panel-heading">Payment Details</div>
      <div class="panel-body">
      
      <table class="table" style="width:100%;">
    <thead>
      <tr>
        <th class="style3">Date From</th>
        <th class="style5">Date To</th>
        <th class="style4"></th>
        <th class="style1">&nbsp;</th>
        <th class="style6">&nbsp;</th>
        <th>&nbsp;</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td class="style3"> <asp:TextBox ID="TextBox7" runat="server" Width="101px"></asp:TextBox></td>
        <td class="style5"> <asp:TextBox ID="TextBox8" runat="server" Width="101px"></asp:TextBox></td>
        <td class="style4"> <asp:Button ID="Button4" runat="server" Text="Search" class="btn btn-primary"  onclick="Button4_Click" /></td>
        <td class="style1"> &nbsp;</td>
        <td class="style6"> &nbsp;</td>
        <td>
            &nbsp;</td>
      </tr>
     
      <tr>
        <td class="style3"> <strong>Total Amount</strong></td>
        <td class="style5"> 
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#660033" 
                Text="Label"></asp:Label>
          </td>
        <td class="style4"> <strong>Paid Amount</strong></td>
        <td class="style1">  
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#660033" 
                Text="Label"></asp:Label>
          </td>
        <td class="style6"> <strong>Balance Amount</strong></td>
        <td>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#660033" 
                Text="Label"></asp:Label>
          </td>
      </tr>
     
    </tbody>
  </table>
          <br />
          <asp:GridView ID="GridView1" runat="server" style="width:100%;" 
               BackColor="White" BorderColor="#336666" 
              BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
              GridLines="Horizontal" AutoGenerateColumns="False" Font-Bold=true 
              onrowdatabound="GridView1_RowDataBound">
           <Columns>
                       
      
                         <asp:TemplateField>
            <HeaderTemplate>Date</HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("date", "{0:dd/MM/yyyy}")%>' ></asp:Label>
    </ItemTemplate>
   
</asp:TemplateField>

<asp:BoundField DataField="DES" HeaderText="DES" />
<asp:BoundField DataField="VALUE" HeaderText="MONTH AMT" />
<asp:BoundField DataField="BACK" HeaderText="BAL AMT" />
<asp:BoundField DataField="TOTAL AMT" HeaderText="TOTAL AMT" />
<asp:BoundField DataField="PAID AMT" HeaderText="PAID AMT" />
<asp:BoundField DataField="BALANCE AMT" HeaderText="BALANCE AMT" />
<asp:BoundField DataField="MODE" HeaderText="MODE" />
<asp:BoundField DataField="NUMBER" HeaderText="NUMBER" />
</Columns>
              <FooterStyle BackColor="White" ForeColor="#333333" />
              <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#fcf8e3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#F7F7F7" />
              <SortedAscendingHeaderStyle BackColor="#487575" />
              <SortedDescendingCellStyle BackColor="#E5E5E5" />
              <SortedDescendingHeaderStyle BackColor="#275353" />
          </asp:GridView>
      </div>
    </div>

     
  </div>
</div>

</form>
</body></html>