<%@ Page Title="" Language="C#" MasterPageFile="~/sidebar/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="sidebar_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta name="viewport" content="width=device-width, initial-scale=1">

  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
  <script src="https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container-fluid mt-3">

  
      <div class="row">

  <div class="col-12">
   <div class="panel-group">
    <div class="panel panel-default">
      <div class="panel-heading"><h3>INVESTER</h3></div>
      <div class="panel-body">
      <table style="font-size:12pt;width:100%;font-weight:bold;">

      <tr>
        <td class="background-color:#FF9333;">TOTAL INVEST</td>
        <td class="background-color:#DAF7A6;">PROFIT RETURN</td>
        <td class="background-color:#DAF7A6;">(Total+PROFIT)RETURN</td>
        <td class="background-color:#9B59B6;">PAID RETURN</td>
        <td class="background-color:#0B5345;">BALANCE INVEST</td>
        
      </tr>
    
   
      <tr>
        <td class="background-color:#FF9333;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#DAF7A6;"> <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                <td class="background-color:#9B59B6;"> <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#9B59B6;"> <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#0B5345;"> <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
      </tr>
     
   
  </table>
      
      </div>
    </div>

    <div class="panel panel-primary">
      <div class="panel-heading"><H3>KISHAN</H3></div>
      <div class="panel-body"><table style="font-size:12pt;width:100%;font-weight:bold;">

      <tr>
        <td class="background-color:#FF9333;">TOTAL AMOUNT</td>
        <td class="background-color:#DAF7A6;">PAID AMOUNT</td>
        <td class="background-color:#9B59B6;">BALANCE AMOUNT</td>
       
        
      </tr>
    
   
      <tr>
        <td class="background-color:#FF9333;">
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#DAF7A6;"> <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#9B59B6;"> <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
        
      </tr>
     
   
  </table></div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading"><H3>CUSTOMER</H3></div>
      <div class="panel-body"><table style="font-size:12pt;width:100%;font-weight:bold;">

      <tr>
        <td class="background-color:#FF9333;">TOTAL AMOUNT</td>
        <td class="background-color:#DAF7A6;">PAID AMOUNT</td>
        <td class="background-color:#9B59B6;">BALANCE AMOUNT</td>
       
        
      </tr>
    
   
      <tr>
        <td class="background-color:#FF9333;">
            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#DAF7A6;"> <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#9B59B6;"> <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
        
      </tr>
     
   
  </table></div>
    </div>
    <div class="panel panel-primary">
      <div class="panel-heading"><H3>LAND DETAILS</H3></div>
      <div class="panel-body"><table style="font-size:12pt;width:100%;font-weight:bold;">

      <tr>
        <td class="background-color:#FF9333;">TOTAL LAND (GAJ)</td>
        <td class="background-color:#DAF7A6;">SOLD LAND (GAJ)</td>
        <td class="background-color:#9B59B6;">BALANCE LAND (GAJ)</td>
           <td class="background-color:#9B59B6;">BALANCE LAND VALUE</td>
        
      </tr>
    
   
      <tr>
        <td class="background-color:#FF9333;">
            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#DAF7A6;"> <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
        <td class="background-color:#9B59B6;"> <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
         <td class="background-color:#9B59B6;"> <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></td>
      </tr>
     
   
  </table></div>
    </div>
</div>
  </div>

    </div>  
  
</div>
</asp:Content>

