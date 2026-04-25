<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>
<html lang="en">

<!-- Mirrored from www.msprindia.com/admin by HTTrack Website Copier/3.x [XR&CO'2014], Thu, 06 Apr 2023 15:29:37 GMT -->
<!-- Added by HTTrack --><meta http-equiv="content-type" content="text/html;charset=UTF-8" /><!-- /Added by HTTrack -->
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Associate Login</title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&amp;display=fallback">
  <!-- Font Awesome -->
  
    <link href="assets/theme/plugins/fontawesome-free/css/all.min.css" rel="stylesheet"
        type="text/css" />
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="assets/theme/plugins/icheck-bootstrap/icheck-bootstrap.min.css" rel="stylesheet"
        type="text/css" />
 
  <!-- Theme style -->
  <link rel="stylesheet" href="assets/theme/dist/css/adminlte.css">
</head>
<body class="hold-transition login-page" style="background:url(assets/home-1.jpg);background-size: cover;">
<div class="login-box">
   
  <!-- /.login-logo -->
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
        <a href="admin.aspx" class="h1"><h4 style="font-weight:bold;color:Navy;">Heed Real Estate Pvt. Ltd.</h4></a>
    </div>
    <div class="card-body">
      <p class="login-box-msg">Sign in to start your session</p>

      
                    
      
      <form runat=server>
        <div class="input-group mb-3">
        
            <asp:TextBox  runat="server" class="form-control " id="username" placeholder="User ID"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
           <asp:TextBox  runat="server" class="form-control " id="password" placeholder="Password" TextMode="Password"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <div class="icheck-primary">
             
                <asp:CheckBox id="remember" name="remember" runat="server" />
              <label for="remember">
                Remember Me
              </label>
            </div>
          </div>
          <!-- /.col -->
          <div class="col-4">
         
              <asp:Button ID="Button1" class="btn btn-primary btn-block" runat="server" 
                  Text="Sign in" onclick="Button1_Click" />
          </div>
          <div class="col-12">
              <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
          </div>
          <!-- /.col -->
        </div>
      </form>

      
     
      
    </div>
    <!-- /.card-body -->
  </div>
  <!-- /.card -->
</div>
<!-- /.login-box -->

<!-- jQuery -->
<script src="assets/theme/plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="assets/theme/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="assets/theme/dist/js/adminlte.min.js"></script>
</body>

<!-- Mirrored from www.msprindia.com/admin by HTTrack Website Copier/3.x [XR&CO'2014], Thu, 06 Apr 2023 15:29:37 GMT -->
</html>

