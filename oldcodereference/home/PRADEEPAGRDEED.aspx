<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRADEEPAGRDEED.aspx.cs" Inherits="arazi187kha_PRADEEPAGR" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Bootstrap Example</title>
   <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {

          $("#TextBox1").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox2").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
         



      });
    </script>
	
	<style type="text/css">

		
	.GridHeader
{
    text-align:center !important;    
}
	</style>
</head>
<body>
 <form runat="server">
<div class="container">
<h3 style="TEXT-ALIGN:CENTER;PADDING:6PX;BACKGROUND-COLOR:Black;COLOR:White;">MONTHLY PAYMENT DETAILS</h3>
  <div class="panel-group">
     <div class="form-inline">
		 <table style="width:100%;" >
			 <tr><td style="width:5%;">Arazi</td><td  style="width:10%;"> <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" Font-Bold=true>
          </asp:DropDownList> &nbsp;</td>
			 <td  style="width:10%;"> DATE FROM</td><td  style="width:10%;">  
                 <asp:TextBox ID="TextBox1" runat="server" Height="31px" Width="106px"></asp:TextBox>
                 </td>
			 <td  style="width:10%;">DATE TO</td><td  style="width:15%;">  
                 <asp:TextBox ID="TextBox2" runat="server" Height="31px" Width="106px"></asp:TextBox>
                 </td>
			 <td> <asp:Button ID="Button2" runat="server" class="btn btn-danger" Text="View" onclick="Button2_Click" style="padding:3px 20px;font-weight:bold;background-color:#04AA6D;color:whilte;" 
               /></td>
			 </tr>
			 </table>
		 
		 
		 
            
      
  </div>
  <hr />
  <div class="panel panel-default">
  <div class="panel-heading" style="text-align:right;background-color:#DAF7A6;">
      
               
                <b>&nbsp;</b><asp:Label ID="Label134" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold" Visible="False"></asp:Label>
                 <b>&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <asp:Label ID="Label135" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold" Visible="False"></asp:Label>
      </div>
      <div class="panel-heading">
          <span class="ui-priority-primary">
               
                <b>TOTAL AMOUNT&nbsp;<asp:Label ID="Label1235" runat="server" 
              CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
      &nbsp;PAID AMOUNT&nbsp;
                <asp:Label ID="Label1236" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
      &nbsp; BALANCE&nbsp;
                <asp:Label ID="Label1237" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
          <br />
&nbsp;&nbsp;&nbsp; ---&nbsp; DISCOUNT
                <asp:Label ID="Label133" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; --DISCOUNT&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1238" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
          <br />
          <br />
          <hr />
          FINAL AMOUNT &nbsp;</b><asp:Label ID="Label16" 
              runat="server" CssClass="style14" 
                    Font-Bold="True" ForeColor="#009900" style="font-weight: bold"></asp:Label>
                <b>&nbsp; PAID AMOUNT&nbsp;&nbsp; </b> </span>
                <asp:Label ID="Label12" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="#009900" style="font-weight: bold"></asp:Label>
                <span class="ui-priority-primary">&nbsp;&nbsp;&nbsp;BALANCE&nbsp; </span>
                <asp:Label ID="Label13" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
               
      &nbsp;&nbsp;&nbsp;&nbsp; <strong>FREE REGISTRY</strong>
          <span class="ui-priority-primary">
               
                <b>
                <asp:Label ID="Label1239" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
          &nbsp; DISCOUNT
                <asp:Label ID="Label1240" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
          </b> </span>
               
      </div>
	  <div class="panel-heading" style="text-align:right;">
      
               
                <span class="ui-priority-primary">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
      </div>
    </div>
    <hr />
    <div class="panel panel-primary">
      <div style="padding:10px;   color: #fff;    background-color: #337ab7;border-color: #337ab7;"><strong>REGISTRY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
               
               <asp:Label ID="Label123" runat="server" CssClass="style14" 
              Font-Bold="True" ForeColor="White" style="font-weight: bold"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="Label1234" runat="server" CssClass="style14" Font-Bold="True" 
              ForeColor="White" style="font-weight: bold"></asp:Label>
          </strong></div>
      <div class="panel-body">
      
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" ForeColor="Black" GridLines="None" DataKeyNames="CID"  
                    Width="100%" height="100%" 
                    style="text-align:left;font-size:10pt;font-weight:bold;">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                       
      <asp:BoundField DataField="CUSTREGNO" HeaderText="REGNO" />
                         <asp:TemplateField>
            <HeaderTemplate>Date</HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("date", "{0:dd/MM/yyyy}")%>' ></asp:Label>
    </ItemTemplate>
   
</asp:TemplateField>
                        <asp:BoundField DataField="name1" HeaderText="NAME-1" />
                         <asp:BoundField DataField="total" HeaderText="Total" />
                        <asp:BoundField DataField="pmt" HeaderText="Paid" />
                         <asp:BoundField DataField="bal" HeaderText="Balance" />
                        <asp:BoundField DataField="plotno" HeaderText="PLOT NO" > <ControlStyle Width="60" />
                        <ControlStyle ForeColor="#006600" />
                        </asp:BoundField>
                        <asp:BoundField DataField="plotsize" HeaderText="PLOT SIZE" > <ControlStyle Width="50" />
                        <ControlStyle ForeColor="Red" />
                        </asp:BoundField>
                        
                       <asp:BoundField DataField="deedno" HeaderText="DEED" > <ControlStyle Width="80" /></asp:BoundField> 
                        <asp:BoundField DataField="regamt" HeaderText="FREE REGISTRY" > <ControlStyle Width="80" /></asp:BoundField> 
                         <asp:BoundField DataField="discp" HeaderText="DISCOUNT" > <ControlStyle Width="80" />
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
		  <br>
      </div>
    </div>
<br>
    <div class="panel panel-primary">
    </div>

   

   

    
  </div>
</div>
</form>
</body>
</html>
