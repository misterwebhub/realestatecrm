<%@ Page Title="" Language="C#" MasterPageFile="~/admin/agenthome/agentmaster.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="admin_agenthome_selfbusin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<link type="text/css" href="css/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />

     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
         <script>
             $(function () {




                 //For Asp.Net TextBox


                

             });
    </script>
<div class="content-wrapper" style="min-height: 428.016px;">

  <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4 class="m-0 text-success font-weight-bold">
               </h4>
          </div><!-- /.col -->
          
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
  
    <!-- Main content -->
    
     <div class="content-wrapper" style="min-height: 428.016px;">
  
  <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4 class="m-0 text-success font-weight-bold">User Profile</h4>
          </div><!-- /.col -->
          <div class="col-sm-6">
            
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
  
    <!-- Main content -->
    
    
<div class="content">


    <!-- Main content -->
    <div class="container-fluid  text-xs">
        
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card shadow-none">
                    <div class="card-body text-center">
                                                 
                         
                        
                                                      
                        
                        
                        <p class="mt-3 h5 text-bold mb-1">
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
                      
                        <p class="text-bold">ID : <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></p>
                        <p class="">SPONSOR ID : <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>/ <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></p>
                    </div>
                </div>
                <div class="card shadow-none">
                    <div class="card-body p-0">
                        <table class="table table-avatar">
                            <tbody><tr class="bg-light">
                                <th colspan="2" class="text-success">CONTACT DETAIL</th>
                            </tr>
                            <tr>
                                <th>CONTACT</th>
                                <td><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>EMAIL</th>
                                <td><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>ADDRESS</th>
                                <td><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                           
                        </tbody></table>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
               
                
                <div class="card card-primary card-outline card-outline-tabs bg-transparent shadow-none">
              <div class="card-header p-0 border-bottom-0 ">
                <ul class="nav nav-tabs" id="custom-tabs-four-tab" role="tablist">
                  
                  
                  <li class="nav-item">
                    <a class="nav-link active" id="personal-detail-tab" data-toggle="pill" href="#personal-detail" role="tab" aria-controls="personal-detail" aria-selected="true">Personal Detail</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" id="bank-detail-tab" data-toggle="pill" href="#bank-detail" role="tab" aria-controls="bank-detail" aria-selected="false">Bank Account</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" id="document" data-toggle="pill" href="#bank-doc" role="tab" aria-controls="bank-detail" aria-selected="false">Document</a>
                  </li>
                </ul>
              </div>
              <div class="card-body bg-white ">
                <div class="tab-content" id="custom-tabs-four-tabContent">
                  
                  <div class="tab-pane fade" id="bank-detail" role="tabpanel" aria-labelledby="bank-detail-tab">
                     <table class="table table-hover table-bordered">
                            <tbody><tr>
                                <th style="width:110px">BANK</th>
                                <td><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>BRANCH</th>
                                <td><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>IFSC</th>
                                <td><asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>ACCOUNT</th>
                                <td><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                        </tbody></table>
                  </div>
                  <div class="tab-pane fade active show" id="personal-detail" role="tabpanel" aria-labelledby="personal-detail-tab">
                     <table class="table table-hover table-bordered">
                         <tbody><tr>
                                <th style="width:130px">FATHER NAME</th>
                                <td><asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>GENDER</th>
                                <td><asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>DOB</th>
                                <td><asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>PAN No</th>
                                <td><asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr class="border-bottom">
                                <th>NOMINEE</th>
                                <td><asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                        </tbody></table>
                  </div>
                   <div class="tab-pane fade active show" id="bank-doc" role="tabpanel" aria-labelledby="personal-detail-tab">
                    <div class="row justify-content-center">
                    
                    <div class="col-md-3 col-7 m-2">
                        <p class="text-center mb-2">ID Proof</p>
                        <a data-fancybox="Commercial" href="https://www.msprindia.com//uploads/a725edd0fd8654037cd29f9328138dde.jpe?auto=compress&amp;cs=tinysrgb&amp;h=6&amp;w=9">
                            <asp:Image ID="Image1" runat="server" class="img-fluid zoom border border-success" style="height:150px"/>
                        </a>
                    </div>
                    
                    <div class="col-md-3 col-7 m-2">
                        <p class="text-center mb-2">PAN Card</p>
                        <a data-fancybox="Commercial" href="https://www.msprindia.com//uploads/03fd77ec82bfb7797b1f4a26e8b7a643.jpe?auto=compress&amp;cs=tinysrgb&amp;h=6&amp;w=9">
                            <asp:Image ID="Image2" runat="server" class="img-fluid zoom border border-success" style="height:150px"/>
                        </a>
                    </div>
                    <div class="col-md-3 col-7 m-2">
                        <p class="text-center mb-2">Bank Proof</p>
                        <a data-fancybox="Commercial" href="https://www.msprindia.com//uploads/4ec67cedd35a45baa785e01df201575a.jpe?auto=compress&amp;cs=tinysrgb&amp;h=6&amp;w=9">
                            <asp:Image ID="Image3" runat="server" class="img-fluid zoom border border-success" style="height:150px"/>
                        </a>
                    </div>
                  
                </div>    
                  </div>
                </div>
              </div>
            </div>
                
                
                
                
                
                
                
        </div>
        
        
    </div>
</div>
</div>

</div>
</asp:Content>



