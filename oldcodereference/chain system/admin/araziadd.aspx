<%@ Page Title="" Language="C#" MasterPageFile="~/chain system/admin/homemaster.master" AutoEventWireup="true" CodeFile="araziadd.aspx.cs" Inherits="admin_adminhome1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="dr1.css" rel="stylesheet" type="text/css" />
    <link href="custom.min.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type="text/javascript">
function PrintGridData() {
var prtGrid = document.getElementById('<%=GridView1.ClientID %>');
prtGrid.border = 0;
var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
prtwin.document.write(prtGrid.outerHTML);
prtwin.document.close();
prtwin.focus();
prtwin.print();
prtwin.close();
}
</script>
<script type="text/javascript">
    function fetch1() {
 
  
	s4="9129822343";
    s1="9129822344";
       
							
										 
		
    


	fetch("http://sms.webguard.in/api/sendhttp.php?authkey=330026A7runOjvu5f533531P1&mobiles="+s4+"&message=THANK YOU FOR REGISTARTION HEED REAL ESTATE PVT LTD ."+ s1 +"&sender=HEEDKP&route=4&DLT_TE_ID=1207161743809040415")          
  .then(response => response.json())
  .then(data => console.log(data)); 
    
       
    
      
    }
    
 
    

</script>
<script type="text/javascript">

   
    }

    </script>
<form id="Form1" runat="server">

<div class="col-md-12">
        <div class="panel panel-success">
            <div class="panel-heading"><h4> <i class="fa fa-plus"></i>Welcome Admin</h4></div>
            <div class="panel-body">
             <div class="form-horizontal row ajax">
                            <div class="form-group">                      
                                <label for="property" class="control-label col-md-2">Select Arazi:</label>
                                <div class="col-md-4">                                 
                                     <asp:DropDownList ID="DropDownList2" runat="server" class="form-control"  ></asp:DropDownList>
                                 </div>
                            
                                
                                
                                
  
                               
                                <div class="col-md-3">
                                    <asp:Button ID="Button1" runat="server" Text="ADD ARAZI" class="btn btn-success btn btn-block" onclick="Button1_Click"/>
                                </div>
								 
                                
                                
                                 
                               
                            </div> 
				
                            <div class="col-md-12">
                              
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                                    BorderColor="#336666"  BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                                    GridLines="Horizontal" onrowcommand="GridView1_RowCommand" style="width:30%;" AutoGenerateColumns="False" onrowdeleting="GridView1_RowDeleting" OnSelectedIndexChanged = "OnSelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" DataKeyNames="ID">
                                    <Columns>  
                   
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="formid" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                 <ItemStyle Width="100px" />
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ARAZI">  
                    <ItemTemplate>  
                        <asp:Label ID="name" runat="server" Text='<%#Eval("arazi") %>'></asp:Label>  
                    </ItemTemplate>  
                        <ItemStyle Width="200px" />
                </asp:TemplateField> 
										 
                <asp:TemplateField>  
                    <ItemTemplate>  
                    
                  
                                     
                        <asp:ImageButton ID="Button2" runat="server" Text="Delete" CommandName="DELETE"  width="25px" ImageUrl="agent/del.png"/> 
                        
                       
                         
                    </ItemTemplate>  
                   
                    <ItemStyle Width="250px" />
                </asp:TemplateField>  
                </Columns>

                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Left" 
                                        Width="300px" />
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                </asp:GridView>
                                
                            </div>
                  </div>
            
        </div>
        </div>
    </div>
           </form>
</asp:Content>





