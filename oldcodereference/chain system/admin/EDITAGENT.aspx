<%@ Page Title="" Language="C#" MasterPageFile="~/admin/homemaster.master" AutoEventWireup="true" CodeFile="EDITAGENT.aspx.cs" Inherits="admin_dr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="dr1.css" rel="stylesheet" type="text/css" />
    <link href="custom.min.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
         <script>
             $(function () {

               


                 //For Asp.Net TextBox
                
                
                     $('#<%=TextBox4.ClientID%>').datepicker({dateFormat:'dd/mm/yy'});
                
             });
    </script>
<form runat="server">

<div class="col-lg-12 well">
      <div class="panel panel-info">
        <div class="panel-heading">
          <h3 class="panel-title text-center"><font color="blue">ASSOCIATE UPDATE </font>
                        </h3>
                    </div>

                    <div class="panel-body">
                        <div class="form-horizontal row ajax">
                      
                      <div class="form-group">
                                
                                 <label for="agent_type1" class="control-label col-md-3">Assosiate ID:</label>
                                <div class="col-md-9">
                                    
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                    
                                </div>
                             
                            </div>
                            <div class="form-group">
                                
                                 <label for="agent_type" class="control-label col-md-3">Sponser ID:</label>
                                <div class="col-md-9">
                                    
                                   <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
            </asp:DropDownList>
                                    
                                </div>
                             
                            </div>
                            <div class="form-group">
                                <label for="agent_type" class="control-label col-md-3">Applied Rank Level:</label>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
       
    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="name" class="control-label col-md-3">Applicant Name :</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="father" class="control-label col-md-3">Father's Name :</label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="gender" class="control-label col-md-3">Gender :</label>
                                <div class="col-md-2">
                                   <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
        <asp:ListItem>--select--</asp:ListItem>
        <asp:ListItem>MALE</asp:ListItem>
        <asp:ListItem>FEMALE</asp:ListItem>
    </asp:DropDownList>
                                </div>
                                <label for="religion" class="control-label col-md-1">DOB :</label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <label for="religion1" class="control-label col-md-2">PASSWORD :</label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="TextBox23" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h5 class="panel-title text-center">Contact Details 
                                                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="WhiteSmoke"></asp:Label><asp:Label ID="Label2"
                                                        runat="server" Text="Label"  ForeColor="WhiteSmoke"></asp:Label></h5>
                                            </div>
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="address" class="control-label col-md-3">Address :</label>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="TextBox22" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                <label for="gender" class="control-label col-md-3">City :</label>
                                <div class="col-md-2">
                                   <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>

                                </div>
                                <label for="religion" class="control-label col-md-2">State :</label>
                                <div class="col-md-3">
                                  <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                                          <div class="form-group">
                                <label for="gender" class="control-label col-md-3">Pincode :</label>
                                <div class="col-md-2">
                                   <asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox>

                                </div>
                                <label for="religion" class="control-label col-md-2">Mobile :</label>
                                <div class="col-md-3">
   
                                                             <asp:TextBox ID="TextBox7" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                              <div class="form-group">
                                <label for="gender" class="control-label col-md-3">Alternate No :</label>
                                <div class="col-md-2">
                     
                                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox>

                                </div>
                                <label for="religion" class="control-label col-md-2">Email :</label>
                                <div class="col-md-3">
  
                                                              <asp:TextBox ID="TextBox9" runat="server" class="form-control" placeholder="xyz@abc.com"></asp:TextBox>                                </div>
                            </div>






                                                    
                                                    
                                                

                                                
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            <fieldset>
                              
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h5 class="panel-title text-center">NOMINEE DETAIL*</h5>
                                            </div>
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="nominee_name" class="control-label col-md-3">Nominee Name</label>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="TextBox10" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    
                                                    <label for="nominee_age" class="control-label col-md-1">Age</label>
                                                    <div class="col-md-1">
                                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <label for="nominee_relation" class="control-label col-md-1">Relation</label>
                                                    <div class="col-md-2">
                                                         <asp:TextBox ID="TextBox12" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                        
                                                </div>
                                                <div class="form-group">
                                                    <label for="nominee_address" class="control-label col-md-3"> Address</label>
                                                    <div class="col-md-7">
                                                         <asp:TextBox ID="TextBox13" runat="server" class="form-control"  TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h5 class="panel-title text-center">OTHER DETAILS</h5>
                                            </div>
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="occupation" class="control-label col-md-2">Occupation</label>
                                                    <div class="col-md-4">
                                                         <asp:TextBox ID="TextBox14" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <label for="qualification" class="control-label col-md-2">Qualification</label>
                                                    <div class="col-md-4">
                                                          <asp:TextBox ID="TextBox15" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="aadhar" class="control-label col-md-2">Aadhar</label>
                                                    <div class="col-md-4">
                                                          <asp:TextBox ID="TextBox16" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <label for="pan" class="control-label col-md-2">Pan</label>
                                                    <div class="col-md-4">
                                                          <asp:TextBox ID="TextBox17" runat="server" class="form-control" 
                                                               ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h5 class="panel-title text-center">BNAK ACCOUNT DETAILS</h5>
                                            </div>
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="bank_name" class="control-label col-md-2">Bank Name</label>
                                                    <div class="col-md-4">
                                                          <asp:TextBox ID="TextBox18" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <label for="branch_add" class="control-label col-md-2">Branch Add</label>
                                                    <div class="col-md-4">
                                                          <asp:TextBox ID="TextBox19" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="account_no" class="control-label col-md-2">A/C No.</label>
                                                    <div class="col-md-4">
                                                         <asp:TextBox ID="TextBox20" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <label for="ifsc_code" class="control-label col-md-2">IFSC Code</label>
                                                    <div class="col-md-4">
                                                         <asp:TextBox ID="TextBox21" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h5 class="panel-title text-center">UPLOADS</h5>
                                            </div>
                                            <div class="panel-body">
                                                <div class="form-group">
                                                    <label for="aadhar_img" class="control-label col-md-2">Aadhar</label>
                                                    <div class="col-md-4">
                                                         <asp:FileUpload ID="FileUpload1" runat="server"  class="form-control" />
                                                    </div>
                                                    <label for="pan_img" class="control-label col-md-2">Pan</label>
                                                    <div class="col-md-4">
                                                         <asp:FileUpload ID="FileUpload2" runat="server"  class="form-control" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label for="bank_img" class="control-label col-md-2">Bank Passbook / Cancel Cheque</label>
                                                    <div class="col-md-4">
                                                        <asp:FileUpload ID="FileUpload3" runat="server"  class="form-control" />
                                                    </div>
                                                    <label for="photo_img" class="control-label col-md-2">Image</label>
                                                    <div class="col-md-4">
                                                         <asp:FileUpload ID="FileUpload4" runat="server"  class="form-control" />
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                   </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-lg-12">
                                <h4 class="text-center">DECLARATION</h4>
                                <div class="checkbox">
                                    <label class="text-warning">
        <asp:CheckBox ID="CheckBox1" runat="server" name="other[all_correct]" value="1" required=""/>
                                        I do hereby declare that the above particulars
are true and correct to the best of my knowledge and nothing has been cancelled.
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-lg-offset-5">
                             
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-success btn-lg btn-block" 
                                    onclick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h5 class="panel-title text-center"></h5>
                                            </div>
                                            <div class="panel-body">
                                               
                                                <div class="form-group">
                                                   
                                                    <div class="col-md-12">
                                                    
   
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                </div>




                
            </div>
           </form>
</asp:Content>

