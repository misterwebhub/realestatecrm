<%@ Page Language="C#" AutoEventWireup="true" CodeFile="telelogin.aspx.cs" Inherits="login_form_20_telelogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
  	<title>Login</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

	<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet">

	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
	
	<link rel="stylesheet" href="css/style.css">

	
</head>

<body class="img js-fullheight" style="background-image: url(https://img.freepik.com/free-vector/circles-background-dark-tones_60389-166.jpg?semt=ais_hybrid);">
<form runat="server">
	<section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">Login</h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-6 col-lg-4">
					<div class="login-wrap">
		      	<h3 class="mb-4 text-center">Account Login</h3>
		      	<div class="signin-form">
		      		<div class="form-group">
                     <asp:TextBox  runat="server" name="username" id="username" class="form-control" placeholder="Username" required></asp:TextBox>
        
       
		      		
		      		</div>
	            <div class="form-group">
                
                 <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
	              
	             
	            </div>
	            <div class="form-group">
                 <asp:Button ID="Button1" runat="server" Text="LOGIN" onclick="Button1_Click" class="form-control btn btn-primary"></asp:Button>
	           <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
               <asp:Panel ID="Panel1" runat="server">
               <table style="width:100%;color:White;" >
               <tr><td></td></tr>
               <tr><td><asp:TextBox ID="TextBox1" runat="server" class="form-control"  placeholder="Please Enter Session Code"></asp:TextBox></td></tr>
               <tr><td><asp:Button ID="Button2" runat="server" Text="Validate" 
                       class="form-control btn btn-primary submit px-3" onclick="Button2_Click"></asp:Button></td></tr>
               </table>
               </asp:Panel>
	            </div>
	            
	          </div>
	         
		      </div>
				</div>
			</div>
		</div>
	</section>

	<script src="js/jquery.min.js"></script>
  <script src="js/popper.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/main.js"></script>
  </form>
	</body>
</html>

