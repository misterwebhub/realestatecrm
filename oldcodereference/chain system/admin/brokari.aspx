<%@ Page Language="C#" AutoEventWireup="true" CodeFile="brokari.aspx.cs" Inherits="admin_salary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
         <script>
             $(function () {




                 //For Asp.Net TextBox

                 $(function () {
                     $('#<%=TextBox1.ClientID%>').datepicker({
                         changeMonth: true,
					   dateFormat: 'dd/mm/yy',
                         changeYear: true
                     });
                 });
	

               

             });
    </script>
           
    </script>
    <style type="text/css" >
        .style1
        {
            width: 100%;
            height: 47px;
        }
        .style7
        {
            height: 39px;
            font-weight: bold;
            text-align: left;
        }
        .style12
        {
            height: 39px;
            font-weight: bold;
        }
        .style27
        {
            height: 36px;
            color: #FFFFFF;
        }
        .style55
        {
            width: 163px;
            height: 39px;
            text-align: center;
            font-weight: bold;
        }
        .style64
        {
            width: 125px;
            height: 39px;
        }
        .style68
        {
            width: 109px;
            height: 39px;
            font-weight: bold;
        }
        .style73
        {
            width: 125px;
            height: 39px;
            font-weight: bold;
        }
        .style82
        {
            width:210px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" 
        style="width:96%;margin-left:2%;box-shadow:0px 0px 10px gray; height: 1295px;">
    
        <table class="style1" class="table table-hover">
            <tr>
                <td colspan="8" style="text-align: left; " 
                    bgcolor="White">
                     <a href="../admin/adminhome.aspx" > <i class="fa fa-home" style="font-size:20px;color:red">BACK HOME</i> </a></td>
            </tr>
            <tr>
                <td colspan="8" style="text-align: center" class="style27" bgcolor="#000066">
                    <strong>BROKARI PAYMENT DETAILS</strong></td>
            </tr>
            <tr>
                <td class="style7" bgcolor="#FFFFCC" colspan="2">
                    AGENT</td>
                <td bgcolor="#FFFFCC" class="style82">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" class="form-control">
                    </asp:DropDownList>
                </td>
                <td class="style64" bgcolor="#FFFFCC">
              
                    <asp:Button ID="Button1" runat="server" Text="Views Booking" Width="120px" 
                        class="btn btn-success" onclick="Button1_Click" />
                </td>
                <td class="style73" bgcolor="#FFFFCC">
                                    &nbsp;</td>
                <td class="style68" bgcolor="#FFFFCC">
                                    &nbsp;</td>
                <td class="style55" bgcolor="#FFFFCC">
                                    &nbsp;</td>
                <td class="style12" bgcolor="#FFFFCC">
                                    &nbsp;</td>
            </tr>
            </table>
            <div class="row">
     <div class="col-sm-12" >
       <asp:GridView ID="GridView2" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" style="width:100%;">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
  </div>
   <div class="col-sm-12"><hr /></div>
    <div class="col-sm-12" >
        <asp:GridView ID="GridView3" runat="server" BackColor="#CCCCCC" 
            BorderColor="#999999" BorderWidth="3px" CellPadding="4" ForeColor="Black" 
            style="width:100%;" BorderStyle="Solid" CellSpacing="2">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" 
                HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
        <div class="col-sm-12"><hr /></div>   
    <div class="col-sm-12">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            ForeColor="Black" GridLines="Vertical" style="width:100%;">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </div>
                    
<div class="col-sm-12">
 <h3>All Details As per As Super Parant</h3> 
<table class="table table-bordered">
    <thead>
      <tr style="background-color:#000;color:White;">
        <th>Total Booked Plot Value</th>
        <th>Total Brokari Before Discount</th>
        <th>Total Discount Value</th>
        <th>Total Brokari After Discount</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
            <td><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
        <td><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
        <td><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
      </tr>
      
      
    </tbody>
  </table>
</div>
       <div class="col-sm-12" >
       <asp:GridView ID="GridView4" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" style="width:100%;">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
  </div>  
  <div class="col-sm-12" ><h3>All Commision Earned By Agent</h3></div>
     <div class="col-sm-12" >
       <asp:GridView ID="GridView5" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" style="width:100%;">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
  </div>  
     <div class="col-sm-12">
 <h3>Total Brokari (Commission)</h3> 
<table class="table table-bordered">
    <thead>
      <tr style="background-color:#000;color:White;">
        <th>Total Brokari</th>
         <th colspan="2">Total PAID</th>
          <th colspan="2">BALANCE</th>
       
       
      </tr>
    </thead>
    <tbody>
    <tr>
    <td style="width:25%;"> <b> <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></b></td>
    <td colspan="2" style="width:25%;"> <asp:Label ID="Label5" runat="server" Text="Label"><b></asp:Label> 
        <asp:Label ID="Label10" runat="server" Text="Label" Font-Bold="True"></asp:Label></b></td>
    <td style="width:25%;"> <b> <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        </b></td>
        <td style="width:25%;">
            <asp:Button ID="Button3" runat="server" Text="PAY BROKARI" 
                class="btn btn-success" onclick="Button3_Click"/></td>
    </tr>
    </tbody></table>
         <asp:Panel ID="Panel1" runat="server">
        
    <table class="table table-bordered">
    <tbody>
    <tr>
    <td><b>DATE</b></td>
    <td><b>PAY MODE</b></td>
    <td > <b>PAID AMOUNT</b></td>
    <td><b>REMARK</b></td>
    <td></td>
    </tr>
    <tr>
     <td>
         <asp:TextBox ID="TextBox1" runat="server" class="form-control" 
            ></asp:TextBox></td>
    <td>
        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
            <asp:ListItem>---SELECT----</asp:ListItem>
            <asp:ListItem>CASH</asp:ListItem>
            <asp:ListItem>ONLINE</asp:ListItem>
            <asp:ListItem>CHEQUE</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td > 
        <asp:TextBox ID="TextBox2" runat="server" class="form-control" 
            TextMode="Number"></asp:TextBox ></td>
    <td>
        <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox></td>
    <td>
        <asp:Button ID="Button2" runat="server" Text="PAID"  class="btn btn-success" 
            onclick="Button2_Click"/></td>
    </tr>
    </tbody>
    
  </table>
   </asp:Panel>
   <div class="col-sm-12" >
       <asp:GridView ID="GridView6" runat="server" CellPadding="4" 
            ForeColor="Black" GridLines="Horizontal" style="width:100%;" 
           AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
           BorderStyle="None" BorderWidth="1px" DataKeyNames="id" 
           OnRowDeleting="GridView6_RowDeleting">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="date" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="mode" HeaderText="MODE" />
                <asp:BoundField DataField="amount" HeaderText="AMOUNT" />
                <asp:BoundField DataField="remark" HeaderText="REAMRK" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
  </div>  
</div>
    
    </div>
    </div>
    </form>
</body>
</html>
