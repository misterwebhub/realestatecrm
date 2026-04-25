<%@ Page Language="C#" AutoEventWireup="true" CodeFile="staff.aspx.cs" Inherits="admin_agenthome_agent1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../dr1.css" rel="stylesheet" type="text/css" />
    <link href="../custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
         <script>
             $(function () {




                 //For Asp.Net TextBox


                 $('#<%=TextBox4.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });

             });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div class="col-lg-12 well">
      <div class="panel panel-info">
        <div class="panel-heading">
       <a href="../adminhome.aspx"> <i class="fa fa-home" style="font-size:48px;color:red"></i> </a> <h3 class="panel-title text-center">
                <font color="blue">STAFF JOINING FORM </font>
                        </h3>
                    </div>

                    <div class="panel-body">
                        <div class="form-horizontal row ajax">
                      

                            <div class="form-group">
                                
                                 <label for="agent_type" class="control-label col-md-3">Designation:</label>
                                <div class="col-md-2">
                                    
                                   <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
            </asp:DropDownList>
                                    
                                </div>
                                <asp:LinkButton ID="LinkButton1" runat="server" class="control-label col-md-1" 
                                     onclick="LinkButton1_Click">New</asp:LinkButton>
                                <asp:Label ID="Label3" runat="server" Text="DESIGNATION" class="control-label col-md-2"></asp:Label> 
                                <div class="col-md-2">
                                    
                                   <asp:TextBox ID="TextBox26" runat="server" class="form-control"></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-2">
                                    
                                    <asp:Button ID="Button3" runat="server" Text="ADD" onclick="Button3_Click" />
                                    
                                </div>
                             
                            </div>
                            <div class="form-group">
                                <label for="agent_type" class="control-label col-md-3">EPF ID</label>
                                <div class="col-md-3">
                                     <asp:TextBox ID="TextBox24" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <label for="agent_type" class="control-label col-md-3">EPF AMOUNT</label>
                                <div class="col-md-3">
                                     <asp:TextBox ID="TextBox25" runat="server" class="form-control" Text="0"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="name" class="control-label col-md-3">Applicant Name :</label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <label for="father" class="control-label col-md-3">Father's Name :</label>
                                <div class="col-md-3">
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
                                <label for="religion1" class="control-label col-md-1">SALARY :</label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="TextBox23" runat="server" class="form-control" ></asp:TextBox>
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
                                                <h5 class="panel-title text-center">STAFF DETAIL</h5>
                                            </div>
                                            <div class="panel-body">
                                               
                                                <div class="form-group">
                                                   
                                                    <div class="col-md-8">
                                                     <div class="col-md-12">
                                                     <div class="form-group">
                                
                                 <label for="agent_type" class="control-label col-md-3">Designation:</label>
                                <div class="col-md-5">
                                    
                                   <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
            </asp:DropDownList>
                                    
                                </div>
                                
                                <div class="col-md-4">
                                <asp:Button ID="Button4" runat="server" Text="Search" 
                                        class="btn btn-success" onclick="Button4_Click" 
                                    />
                                </div>
                                </div>
                                                     </div>
                                                     <div class="col-md-12"><br></div>
                                                     <div class="col-md-12">
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand" CellPadding="6" onrowdeleting="GridView1_RowDeleting" style="width:100%;padding:10px;text-align:left;font-size:11pt;"  AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" >  
            <Columns>  
                 
                <asp:TemplateField HeaderText = "Sr.No" ItemStyle-Width="30">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_form1d" runat="server" Text='<%#Eval("formid") %>'></asp:Label>  
                    </ItemTemplate>  
                    
                </asp:TemplateField> 
               
                <asp:TemplateField HeaderText="DESIGNATION">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Plot" runat="server" Text='<%#Eval("designation") %>'></asp:Label>  
                    </ItemTemplate>  
                     
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="NAME">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_size" runat="server" Text='<%#Eval("name") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="180px" />
                      
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="SALARY">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("salary") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                     
                </asp:TemplateField> 
               
                <asp:TemplateField HeaderText="ACTION">   
                    <ItemTemplate>
                   
                        <asp:ImageButton ID="Button2" runat="server" Text="Delete" CommandName="DELETE"  width="30px" ImageUrl="../agent/del.png"/>  
                          <asp:ImageButton ID="btn_view" runat="server" Text="view" CommandName="views" width="30px" ImageUrl="../agent/edit.png" CommandArgument='<%# "~/admin/EDITAGENT.aspx?Parameter="+Eval("formid")%>' /> &nbsp;&nbsp; 
                        
                    </ItemTemplate>  
                    
                    <ItemStyle Width="150px" />
                </asp:TemplateField> 
            </Columns>  
            <HeaderStyle BackColor="navy" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
        </asp:GridView> 
                                  </div>                  </div>
                                                    <div class="col-md-4">
                                                        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
                                                            GridLines="None" AutoGenerateColumns="False" onrowdeleting="GridView2_RowDeleting"   AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" >
                                                            <Columns>  
                 
                <asp:TemplateField HeaderText = "Sr.No" ItemStyle-Width="30">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_form1d" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="150px" />
                </asp:TemplateField> 
               
                <asp:TemplateField HeaderText="DESIGNATION">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Plot" runat="server" Text='<%#Eval("designation") %>'></asp:Label>  
                    </ItemTemplate>  
                     <ItemStyle Width="250px" />
                </asp:TemplateField>  
               <asp:TemplateField HeaderText="ACTION">   
                    <ItemTemplate>
                   
                        <asp:ImageButton ID="Button6" runat="server" Text="Delete" CommandName="DELETE"  width="30px" ImageUrl="../agent/del.png"/>  
                         
                        
                    </ItemTemplate>  
                    
                    <ItemStyle Width="150px" />
                </asp:TemplateField> 
                </Columns>
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                            <SortedDescendingHeaderStyle BackColor="#820000" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                </div>




                
            </div>
           
    </div>
    </form>
</body>
</html>
