<%@ Page Title="" Language="C#" MasterPageFile="~/chain system/admin/agenthome/agentmaster.master" AutoEventWireup="true" CodeFile="changepass.aspx.cs" Inherits="admin_agenthome_changepass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="content-wrapper" style="min-height: 428.016px;">
  
  <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4 class="m-0 text-success font-weight-bold">Change Password 
               </h4>
          </div><!-- /.col -->
          
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
  
    <!-- Main content -->
    
      <div class="content">
    <div class="container-fluid px-0 px-sm-2">
            
      
            
            
      
      
      
            <div class="row">
    
         
          <div class="col-md-12 ">
            <div class="card shadow-none ">
              <div class="card-body overflow-auto">
                <div id="example3_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer">
                     
                 <div class="row">  
                
                <label for="father" class="control-label col-md-3">Password :</label>               
                <div class="col-md-3">           
                 <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Password" required></asp:TextBox>
                </div>
              
                </div>
                 <div class="row">
                 <label for="father" class="control-label col-md-3">Confirm Password :</label>               
                <div class="col-md-3">           
                 <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Confirm Password" required></asp:TextBox>
                </div>
                </div>
                 <div class="row">
                 <label for="father" class="control-label col-md-3"></label>   
                <div class="col-md-2">           
                    <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-success  btn-block" onclick="Button1_Click"/>
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







