<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newkishandetails.aspx.cs" Inherits="newkishandetails" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Kishan Payment</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style type="text/css">
        .style1
        {
            width: 74px;
        }
        .style2
        {
            width: 292px;
        }
    </style>
</head>
<body>
<form runat="server">
<div class="container" style="border:1px solid grey;">
  <h2 style="text-align:center;padding:3px 5px;background-color:Maroon;color:White;"> Details Of Company Profit Share With Partner</h2>
             <hr />
             <table class="table">
    <thead>
      <tr>
        <th class="style1">Arazi</th>
        <th class="style2">
            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
            </asp:DropDownList>
        </th>
       
        <th>
            <asp:Button ID="Button1" runat="server" Text="Geta Details" 
                class="btn btn-primary" Font-Bold="True" onclick="Button1_Click"/></th>
      </tr>
    </thead>
   
  </table>
             <div class="panel-group">
    <div class="panel panel-primary">
      <div class="panel-heading"><b><table style="width:100%;"><tr><td style="width:50%;">Kishan Details</td><td style="text-align:right;width:50%;"> ( कम्पनी के द्वारा किसान को दिया गया )</td></tr></table></b></div>
      <div class="panel-body">
       
  <div class="panel panel-default">
      <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
           AutoGenerateColumns="False" style="font-size:11pt;width:100%;" 
          ForeColor="#333333" GridLines="None">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
           <asp:TemplateField HeaderText = "Sr.No" ItemStyle-Width="80">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>

<ItemStyle Width="80px"></ItemStyle>
    </asp:TemplateField>
                            <asp:BoundField DataField="arazi" HeaderText="ARAZI" />
                             <asp:BoundField DataField="id" HeaderText="ID" />
                              <asp:BoundField DataField="kname" HeaderText="NAME" />
                               <asp:BoundField DataField="landsize" HeaderText="LAND SIZE" />
                                <asp:BoundField DataField="landamount" HeaderText="TOTAL" />
                                 <asp:BoundField DataField="PAID" HeaderText="PAID" />
                                  <asp:BoundField DataField="balance" HeaderText="BALANCE" />
                            </Columns>
          <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
          <RowStyle ForeColor="#333333" BackColor="#FFFBD6" />
          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
          <SortedAscendingCellStyle BackColor="#FDF5AC" />
          <SortedAscendingHeaderStyle BackColor="#4D0000" />
          <SortedDescendingCellStyle BackColor="#FCF6C0" />
          <SortedDescendingHeaderStyle BackColor="#820000" />
      </asp:GridView>
      <div class="row">
 
  <div class="col-md-12"><table class="table" border=1>
    <thead>
      <tr style="background-color:#282A35;color:White;text-align:center;">
        <th class="text-center">Total</th>
        <th class="text-center">Paid</th>
        <th class="text-center">Balance</th>
      </tr>
       <tr style="text-align:center;">
        <th class="text-center">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"> <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"> <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></th>
      </tr>
    </thead>
   
  </table></div>
</div>
      
  </div>
      </div>
    </div>
 <div class="panel panel-danger">
      <div class="panel-heading"><b><table style="width:100%;"><tr><td style="width:50%;">Cutomer Details</td><td style="text-align:right;width:50%;"> ( कस्टमर के द्वारा पैसा आया  )</td></tr></table></b></div>
      <div class="panel-body">
       <div class="col-md-12"><table class="table" border=1>
    <thead>
      <tr style="background-color:#282A35;color:White;text-align:center;">
        <th class="text-center">Total</th>
        <th class="text-center">Paid</th>
        <th class="text-center">Balance</th>
      </tr>
       <tr style="text-align:center;">
        <th class="text-center">
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"> <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"> <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></th>
      </tr>
    </thead>
   
  </table></div>
      </div>
      </div>
      <div class="panel panel-success">
      <div class="panel-heading"><b><table style="width:100%;"><tr><td style="width:50%;">Profit Share with Partner</td><td style="text-align:right;width:50%;"> ( कम्पनी लाभ का हिसाब साझेदार के साथ)</td></tr></table></b></div>
      <div class="panel-body">
       <div class="col-md-12"><table class="table" border=1>
    <thead>
      <tr style="background-color:#282A35;color:White;text-align:center;">
        <th class="text-center">Total Income</th>
        <th class="text-center" colspan="2">Total Kishan Paid</th>
        <th class="text-center">Net Balance</th>
      </tr>
       <tr style="text-align:center;">
        <th class="text-center">
            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"  colspan="2"> <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"> <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></th>
      </tr>
      <tr style="background-color:#282A35;color:White;text-align:center;">
        <th class="text-center">Net Balance</th>
        <th class="text-center">Expense (%)</th>
        <th class="text-center">Expense</th>
        <th class="text-center">Balance</th>
      </tr>
       <tr style="text-align:center;">
        <th class="text-center" style="width:25%;"><asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center" style="width:25%;">
            <asp:TextBox ID="TextBox1" runat="server" class="form-control" 
                AutoPostBack="True" ontextchanged="TextBox1_TextChanged" ></asp:TextBox></th>
        <th class="text-center" style="width:25%;"><asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></th>
         <th class="text-center" style="width:25%;"><asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></th>
      </tr>
       <tr style="background-color:#282A35;color:White;text-align:center;">
        <th class="text-center" colspan="2">Total Balance</th>
        <th class="text-center"><i class="fa fa-user" style="font-size:30px;color:white"></i>1</th>
        <th class="text-center"><i class="fa fa-user" style="font-size:30px;color:white"></i>2</th>
      </tr>
      <tr style="text-align:center;">
        <th class="text-center" colspan="2">
            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"> <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></th>
        <th class="text-center"> <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></th>
      </tr>
    </thead>
   
  </table></div>
      </div>
      </div>
</div>
</div>
</form>
</body>
</html>
