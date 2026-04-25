<%@ Page Language="C#" AutoEventWireup="true" CodeFile="raghunath.aspx.cs" Inherits="arazi187kha_PRADEEPAGR" %>

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
	    .style1
        {
            width: 14%;
        }
        .style2
        {
            color: #FF0000;
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
			 <tr><td style="width:5%;"><strong>Arazi</strong></td><td  style="width:10%;"> 
                 <strong> <asp:DropDownList ID="DropDownList1" runat="server" 
                     class="form-control" Font-Bold=true AutoPostBack="True" 
                     onselectedindexchanged="DropDownList1_SelectedIndexChanged">
          </asp:DropDownList> </strong> </td>
			     <td class="style1"> <strong>
                     <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Block"></asp:Label>
&nbsp; <asp:DropDownList ID="DropDownList4" runat="server" class="form-control" Font-Bold=true>
          </asp:DropDownList> </strong> </td>
			 <td  style="width:10%;"><strong>Date From:</strong></td><td  style="width:10%;">  
                 <strong>  <asp:TextBox ID="TextBox1" runat="server" class="form-control" Font-Bold=true></asp:TextBox> 
                 </strong> </td>
			 <td  style="width:10%;"><strong>Date To:</strong></td><td  style="width:15%;">  
                 <strong>  <asp:TextBox ID="TextBox2" runat="server" class="form-control" Font-Bold=true></asp:TextBox> 
                 </strong> </td>
			 <td> <strong> <asp:Button ID="Button2" runat="server" class="btn btn-danger" Text="View" onclick="Button2_Click" style="padding:3px 20px;font-weight:bold;background-color:#04AA6D;color:whilte;" 
               /></strong></td>
			 </tr>
		 </table>
		 
		 
		 
            
      
  </div>
  <hr />
  <div class="panel panel-default">
      <div class="panel-heading">
      <span class="ui-priority-primary">
               
                <b>&nbsp;&nbsp;&nbsp;FINAL AMOUNT &nbsp;</b><asp:Label ID="Label16" 
              runat="server" CssClass="style14" 
                    Font-Bold="True" ForeColor="#009900" style="font-weight: bold"></asp:Label>
                <b>&nbsp; PAID AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b> </span>
                <asp:Label ID="Label12" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="#009900" style="font-weight: bold"></asp:Label>
                <span class="ui-priority-primary">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BALANCE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                <asp:Label ID="Label13" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <span class="style2"><strong>D</strong></span>
                <asp:Label ID="Label133" runat="server" CssClass="style14" Font-Bold="True" 
                    ForeColor="Red" style="font-weight: bold"></asp:Label>
      </div>
     
    </div>
    <hr />
    <div class="panel panel-primary">
      <div style="padding:10px;   color: #fff;    background-color: #337ab7;
    border-color: #337ab7;"><strong>REGISTRY</strong></div>
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
                        
                        <asp:BoundField DataField="pmt" HeaderText="BEFORE PAID" ItemStyle-Width="15%" />
                        <asp:BoundField DataField="plotno" HeaderText="PLOT NO" > <ControlStyle Width="60" />
                        <ControlStyle ForeColor="#006600" />
                        </asp:BoundField>
                        <asp:BoundField DataField="plotsize" HeaderText="PLOT SIZE" > <ControlStyle Width="50" />
                        <ControlStyle ForeColor="Red" />
                        </asp:BoundField>
                        
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
                </asp:GridView><br>
		  <asp:Label ID="Label121" runat="server" Text="" style="font-weight:bold;"></asp:Label>
      </div>
    </div>
<br>
    <div class="panel panel-primary">
      <div style="padding:10px;   color: #fff;    background-color: #337ab7;
    border-color: #337ab7;"><strong>Monthly Payment</strong></div>
      <div class="panel-body"><p><strong>Regitry : 
          <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
          +&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EMI : 
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
          =&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Receive Amount :&nbsp;&nbsp;&nbsp;&nbsp; 
          <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>&nbsp;</strong></p>
       <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                    CellPadding="2" ForeColor="Black" GridLines="None" 
                    Width="100%" height="100%"  
                    style="text-align:center;font-size:10pt;font-weight:bold;" HeaderStyle-CssClass="GridHeader">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
		   
                    <Columns>
      <asp:BoundField DataField="CUSTREGNO" HeaderText="REGNO" ItemStyle-Width="10%" > </asp:BoundField>
                         <asp:TemplateField>
            <HeaderTemplate>Date</HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("date", "{0:dd/MM/yyyy}")%>' ItemStyle-Width="10%" ></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
  <asp:TextBox ID="txtDOB" Text='<%# Bind("date","{0:yyyy-MM-dd}") %>' TextMode="Date" runat="server"></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
                        <asp:BoundField DataField="name1" HeaderText="NAME-1" ItemStyle-Width="15%" />
                           <asp:BoundField DataField="recv" HeaderText="RECIEVE" ItemStyle-Width="7%" />
                         <asp:BoundField DataField="total" HeaderText="TOTAL" ItemStyle-Width="7%" />
                         <asp:BoundField DataField="pmt" HeaderText="PAID" ItemStyle-Width="7%" />
                         <asp:BoundField DataField="bal" HeaderText="BALANCE" ItemStyle-Width="7%"  />
                        
                        <asp:BoundField DataField="plotno" HeaderText="PLOT NO" ItemStyle-Width="10%" > 
                        <ControlStyle ForeColor="#006600" />
                        </asp:BoundField>
                        <asp:BoundField DataField="plotsize" HeaderText="SIZE" ItemStyle-Width="7%" > 
                        <ControlStyle ForeColor="Red" />
                        </asp:BoundField>
                        
                       <asp:BoundField DataField="deedno" HeaderText="DEED" ItemStyle-Width="7%" >
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
      </div>
    </div>

   

   

    
  </div>
</div>
</form>
</body>
</html>
