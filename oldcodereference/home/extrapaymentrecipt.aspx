<%@ Page Language="C#" AutoEventWireup="true" CodeFile="extrapaymentrecipt.aspx.cs" Inherits="_161GHA_extrapaymentrecipt" %>

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
    </style>
</head>
<body>
 <form runat=server>
<div class="container">
 
  <div class="panel-group">
    <div class="panel panel-default">
      <div class="panel-heading">Extra Payment</div>
      <div class="panel-body">
      <table class="table">
    <thead>
      <tr>
        <th>Date</th>
        <th>Class</th>
        <th>Name</th>
        <th>Mode</th>
        <th>
            <asp:Label ID="Label1" runat="server" Text="Number"></asp:Label>
          </th>
         <th>Amount</th>
          <th>Reason</th>
           <th></th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="101px"></asp:TextBox></td>
        <td>
            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
        &nbsp;
		
<button type="button" class="btn-primary" data-toggle="modal" data-target="#myModal" style="height:25px;width:45px;">
    New
</button>

        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        &nbsp;
		
<button type="button" class="btn-primary" data-toggle="modal" data-target="#myModal" style="height:25px;width:45px;">
    New
</button>

        </td>
        <td><asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                Height="20px" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                Width="75px">
            <asp:ListItem>---select----</asp:ListItem>
            <asp:ListItem>CASH</asp:ListItem>
            <asp:ListItem>A/C</asp:ListItem>
            </asp:DropDownList></td>
        <td> <asp:TextBox ID="TextBox4" runat="server" Width="112px"></asp:TextBox></td>
        <td> <asp:TextBox ID="TextBox2" runat="server" Width="97px" TextMode="Number"></asp:TextBox></td>
        <td> <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="182px"></asp:TextBox></td>
           <td>
               <asp:Button ID="Button1" runat="server" Text="Add" class="btn btn-primary"  onclick="Button1_Click" /></td>
      </tr>
      
    </tbody>
  </table>
      
      </div>
    </div>

    <div class="panel panel-primary">
      <div class="panel-heading">Details</div>
      <div class="panel-body">
      
      <table class="table" style="width:100%;">
    <thead>
      <tr>
        <th>Date From</th>
        <th>Date To</th>
        <th></th>
        <th class="style1">&nbsp;</th>
        <th>ID</th>
        <th>&nbsp;</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td> <asp:TextBox ID="TextBox7" runat="server" Width="101px"></asp:TextBox></td>
        <td> <asp:TextBox ID="TextBox8" runat="server" Width="101px"></asp:TextBox></td>
        <td> <asp:Button ID="Button4" runat="server" Text="Search" class="btn btn-primary"  onclick="Button4_Click" /></td>
        <td class="style1"> &nbsp;</td>
        <td> <asp:TextBox ID="TextBox9" runat="server" Width="101px" TextMode="Number"></asp:TextBox></td>
        <td>
            <asp:Button ID="Button5" runat="server" Text="Del" class="btn btn-primary" 
                onclick="Button5_Click" /></td>
      </tr>
     
      <tr>
        <td> <strong>Total Amount</strong></td>
        <td> 
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#660033" 
                Text="Label"></asp:Label>
          </td>
        <td> &nbsp;</td>
        <td class="style1"> &nbsp;</td>
        <td> &nbsp;</td>
        <td>
            &nbsp;</td>
      </tr>
     
    </tbody>
  </table>
          <br />
          <asp:GridView ID="GridView1" runat="server" style="width:100%;" 
              AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" 
              BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
           <Columns>
           <asp:BoundField DataField="ID" HeaderText="ID">
                 <ItemStyle Width="70px" />
                            </asp:BoundField>
           <asp:BoundField DataField="date" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="70px" />
                            </asp:BoundField>
                <asp:BoundField DataField="class1" HeaderText="Class">
                 <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="name" HeaderText="Name" >
                             <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mode1" HeaderText="Mode" >
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                           <asp:BoundField DataField="number1" HeaderText="Trans.No" >
                           <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="Amount" >
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="reason" HeaderText="Reason" >
                             <ItemStyle Width="180px" />
                            </asp:BoundField>
                            </Columns>
              <FooterStyle BackColor="White" ForeColor="#333333" />
              <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="White" ForeColor="#333333" />
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
<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Class or Name</h4>
        </div>
        <div class="modal-body">
         <table style="width:100%;">
         <tr><td>Class Name</td><td>
             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td><td>
                 <asp:Button ID="Button2" runat="server" Text="Add Class"  onclick="Button2_Click" /></td></tr>
                 <tr>
                 <tr style="height:50px;"><td></td><td></td><td></td></tr>
                 <td>Class Name</td><td>Name</td><td></td>
                 </tr>
                  <tr><td> <asp:DropDownList ID="DropDownList4" runat="server">
            </asp:DropDownList></td><td>
             <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td><td>
                 <asp:Button ID="Button3" runat="server" Text="Add Name"  onclick="Button3_Click" /></td></tr>

         </table>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
</form>
</body></html>