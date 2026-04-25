<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mentiondetails.aspx.cs" Inherits="arazi187kha_mentiondetails" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Expense Form</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
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
          $("#TextBox9").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });
          $("#TextBox10").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });



      });
    </script>
    <script type="text/javascript">

        function doPrint() {
            var prtContent = document.getElementById('rp');

            prtContent.border = 0; //set no border here
            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');
            WinPrint.document.write(prtContent.outerHTML);
            // WinPrint.document.write(prtContent.outerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
       
    </script>
</head>
<body>

<div class="container">
<br />
<div style="padding:5px;background-color:Black;color:White;">
<marquee direction="left" scrollamount=5 style="font-size:15pt;">===> ** Heed Real Estate Pvt. Ltd. ** <===&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;===> ** Heed Real Estate Pvt. Ltd. ** <===&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;==> ** Heed Real Estate Pvt. Ltd. ** <===</marquee>
</div>
<br />
    <form id="Form1" runat="server">
<div class="panel panel-primary">
      <div class="panel-heading"><strong>Mention Cheuqe Details (23/10/2023) </strong> </div>
      <div class="panel-body">
  
       <div class="form-inline" >
    <div class="form-group">
      <label for="email">Total Unpaid Amount</label>&nbsp;&nbsp;&nbsp;&nbsp;
    
         <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#990000" 
            Font-Bold="True" Font-Size="Large"></asp:Label>
         
        <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="#990000" 
            Font-Bold="True"></asp:Label>
         
    </div>
    <div class="form-group">
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
         
    </div>
    <div class="form-group">
      <label for="email">Monthy Paid Amount</label>&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="#990000" Font-Bold="True"></asp:Label>
         
         
    </div>
     <div class="form-group">
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
         
    </div>
    <div class="form-group">
      <label for="email">Today Paid Amount</label>&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    
<asp:Label ID="Label3" runat="server" Text="Label" ForeColor="#990000" Font-Bold="True"></asp:Label>
         
    </div>

  </div>



     



   
     
      </div>
    </div>


  
     </form>
   
 
 
  
</div>

</body>
</html>

