<%@ Page Language="C#" AutoEventWireup="true" CodeFile="credential.aspx.cs" Inherits="credential" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html lang="en">
<head>
	<title>User Crediential</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
    <style type="text/css">


*, *:before, *:after {
  -webkit-box-sizing: inherit;
  -moz-box-sizing: inherit;
  box-sizing: inherit;
}

* {
  padding: 0;
  margin: 0;
}

    </style>
</head>
<body>
	
	
	<div class="container-login100" style="background-image: url('images/bg-01.jpg');">
		<div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
			<form class="login100-form validate-form" runat="server">
            <span class="login100-form-title p-b-37">
                <img src="images/pp.png" style="width:100px;height:100px;margin-top:-30px;"/>
				</span>
				<span class="login100-form-title p-b-37">
					Sign In
				</span>

				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter username or email">
					<asp:TextBox ID="TextBox1" runat="server"  class="input100" placeholder="User Name"></asp:TextBox>
                    <span class="focus-input100"></span>
				</div>

				<div class="wrap-input100 validate-input m-b-25" data-validate = "Enter password">
					<asp:TextBox ID="TextBox2" runat="server" class="input100" 
                        placeholder="password" TextMode="Password"></asp:TextBox>
					<span class="focus-input100"></span>
				</div>
                <div class="wrap-input100 validate-input m-b-25">
                    
            <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="123px">
               <asp:ListItem>USER TYPE</asp:ListItem>
                <asp:ListItem>----Select-----</asp:ListItem>
                <asp:ListItem>ADMIN</asp:ListItem>
                <asp:ListItem>USER</asp:ListItem>
            </asp:DropDownList>
                    
					<span class="focus-input100"></span>
				</div>

				<div class="container-login100-form-btn">
				
						<asp:Button ID="Button1" runat="server" Text="Log In" class="login100-form-btn" 
                            onclick="Button1_Click" />
				
				</div>
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>

				
			</form>

			
		</div>
		
	</div>
	
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/js/main.js"></script>

</body>
</html>