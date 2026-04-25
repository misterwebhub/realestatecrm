<%@ Page Title="" Language="C#" MasterPageFile="~/chain system/admin/homemaster.master" AutoEventWireup="true" CodeFile="ADDAGENT.aspx.cs" Inherits="admin_dr" EnableEventValidation = "false" %>

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
	 <script type="text/javascript">
	    var windowObjectReference;


	    function openRequestedPopup() {
               
         var s4 = document.getElementById('TextBox7').value;
			 var s45 = document.getElementById('TextBox23').value;
                  var s11 = document.getElementById('<%=Label111.ClientID%>').innerText;
            windowObjectReference = window.open("http://sms.webguard.in/api/sendhttp.php?authkey=330026ALGWF9NXis645d2f3aP1&mobiles=9335064248,"+s4+"&message=THANK YOU FOR REGISTRATION .YOUR REGISTRATION NO IS "+s11+" AND PASSWORD "+s45+" BY CHHKPL&sender=CHHKPL&route=4&DLT_TE_ID=1207168370765332406");
	       
	   
        }
		
		
</script>
	<script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime(); var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
</script>
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
          <h3 class="panel-title text-center"><font color="blue">ASSOCIATE JOINING FORM </font><asp:Label ID="Label111" runat="server" Font-Bold="True" style="color:#d9edf7;"></asp:Label>
                        </h3>
                    </div>

                    <div class="panel-body">
                        <div class="form-horizontal row ajax">
                      

                            <div class="form-group">
                                
                                 <label for="agent_type" class="control-label col-md-3">Associate:</label>
                                <div class="col-md-9">
                                    
                                   <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
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
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="TextBox22" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                <label for="gender" class="control-label col-md-3">City :</label>
                                <div class="col-md-3">
                                   <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>

                                </div>
                                <label for="religion" class="control-label col-md-2">State :</label>
                                <div class="col-md-4">
                                  <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                                          <div class="form-group">
                                <label for="gender" class="control-label col-md-3">Pincode :</label>
                                <div class="col-md-3">
                                   <asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox>

                                </div>
                                <label for="religion" class="control-label col-md-2">Mobile :</label>
                                <div class="col-md-4">
   
                                                             <asp:TextBox ID="TextBox7" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                              <div class="form-group">
                                <label for="gender" class="control-label col-md-3">Alternate No :</label>
                                <div class="col-md-3">
                     
                                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox>

                                </div>
                                <label for="religion" class="control-label col-md-2">Email :</label>
                                <div class="col-md-4">
  
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
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="TextBox10" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    
                                                    <label for="nominee_age" class="control-label col-md-1">Age</label>
                                                    <div class="col-md-1">
                                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <label for="nominee_relation" class="control-label col-md-1">Relation</label>
                                                    <div class="col-md-3">
                                                         <asp:TextBox ID="TextBox12" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                        
                                                </div>
                                                <div class="form-group">
                                                    <label for="nominee_address" class="control-label col-md-3"> Address</label>
                                                    <div class="col-md-9">
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
                                                <h5 class="panel-title text-center">BANK ACCOUNT DETAILS</h5>
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
                                    onclick="Button1_Click" OnClientClick="javascript:return openRequestedPopup();"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h5 class="panel-title text-center">AGENT DETAIL</h5>
                                            </div>
                                            <div class="panel-body">
                                               
                                                <div class="form-group">
                                                   <div class="col-md-12">
                 <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/chain system/admin/print.png" 
                     style="height:30px;width:30px;" onclick="btnPrint_Click"/> &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
                     ID="ImageButton2" runat="server" ImageUrl="~/chain system/admin/excel.png"  
                     style="height:30px;width:30px;" onclick="ExportToExcel" /></div>
                
          </div>
                                                    <div class="col-md-12">
                                                    
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand" CellPadding="6" onrowdeleting="GridView1_RowDeleting" style="width:100%;padding:10px;text-align:left;font-size:11pt;"  AllowPaging="true"  OnPageIndexChanging="OnPageIndexChanging" PageSize="10">  
	   <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous"
            NextPageText="Next" LastPageText="Last" />
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
                 <asp:TemplateField HeaderText="Agent Name">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Block" runat="server" Text='<%#Eval("name") %>'></asp:Label>  
                    </ItemTemplate>  
                     
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Sponser ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Plot" runat="server" Text='<%#Eval("agentid") %>'></asp:Label>  
                    </ItemTemplate>  
                     
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Sponser Name">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_size" runat="server" Text='<%#Eval("spname") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="150px" />
                      
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Agent Type">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_status" runat="server" Text='<%#Eval("rank") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                     
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Percentage">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_status1" runat="server" Text='<%#Eval("agentper") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                     
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Password">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_password" runat="server" Text='<%#Eval("password") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                     
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="ACTION">   
                    <ItemTemplate>
                   
                        <asp:ImageButton ID="Button2" runat="server" Text="Delete" CommandName="DELETE"  width="30px" ImageUrl="agent/del.png"/>  
                          <asp:ImageButton ID="btn_view" runat="server" Text="view" CommandName="views" width="30px" ImageUrl="agent/edit.png" CommandArgument='<%# "~/admin/EDITAGENT.aspx?Parameter="+Eval("formid")%>' /> &nbsp;&nbsp; 
                        
                    </ItemTemplate>  
                    
                    <ItemStyle Width="150px" />
                </asp:TemplateField> 
            </Columns>  
            <HeaderStyle BackColor="navy" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
        </asp:GridView> 
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

