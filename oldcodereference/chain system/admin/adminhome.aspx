<%@ Page Title="" Language="C#" MasterPageFile="~/chain system/admin/homemaster.master" AutoEventWireup="true" CodeFile="adminhome.aspx.cs" Inherits="admin_adminhome1" %>

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


    $(function () {




        //For Asp.Net TextBox


        $('#<%=TextBox1.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
        $('#<%=TextBox2.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });

    });

    </script>
<form id="Form1" runat="server">

<div class="col-md-12">
        <div class="panel panel-success">
            <div class="panel-heading"><h4> <i class="fa fa-plus"></i>Welcome Admin</h4></div>
            <div class="panel-body">
             <div class="form-horizontal row ajax">
                            <div class="form-group">                      
                                <label for="property" class="control-label col-md-2">DATE FROM</label>
                                <div class="col-md-2">
                              
                                    <asp:TextBox ID="TextBox1" runat="server"  class="form-control" placeholder="DD/MM/YY"></asp:TextBox>
                </div>
                 <label for="property" class="control-label col-md-1">DATE TO</label>
                                <div class="col-md-2">
                                  
                                <asp:TextBox ID="TextBox2" runat="server"  class="form-control" placeholder="DD/MM/YY"></asp:TextBox>
                </div>
                            
                                
                                
                                
  
                               
                                <div class="col-md-1">
                                    <asp:Button ID="Button1" runat="server" Text="VIEW" class="btn btn-success btn btn-block" onclick="Button1_Click"/>
                                </div>
								 
                               
                                
                                 
                               
                            </div> 
				
                            <div class="col-md-12">
                              
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                                    BorderColor="#336666"  BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Size=Small 
                                    GridLines="Horizontal" style="width:100%;" AutoGenerateColumns="False" DataKeyNames="CUSTREGNO" class="table table-bordered table-condensed table-responsive table-hover ">
                                    <Columns>  
                    <asp:TemplateField HeaderText="DATE">  
                    <ItemTemplate>  
                        <asp:Label ID="date" runat="server" Text='<%#Eval("DATE","{0:dd/MM/yyyy}") %>'></asp:Label>  
                    </ItemTemplate>  
                   
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="CUSTREGNO">  
                    <ItemTemplate>  
                        <asp:Label ID="formid" runat="server" Text='<%#Eval("CUSTREGNO") %>'></asp:Label>  
                    </ItemTemplate>  
                
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="NAME">  
                    <ItemTemplate>  
                        <asp:Label ID="formid" runat="server" Text='<%#Eval("NAME") %>'></asp:Label>  
                    </ItemTemplate>  
                
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="AMOUNT">  
                    <ItemTemplate>  
                        <asp:Label ID="name1" runat="server" Text='<%#Eval("TOTALAMOUNT") %>'></asp:Label>  
                    </ItemTemplate>  
                       
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="PAID">  
                    <ItemTemplate>  
                        <asp:Label ID="name2" runat="server" Text='<%#Eval("PA") %>'></asp:Label>  
                    </ItemTemplate>  
                       
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BALANCE">  
                    <ItemTemplate>  
                        <asp:Label ID="name3" runat="server" Text='<%#Eval("BALANCE") %>'></asp:Label>  
                    </ItemTemplate>  
                       
                </asp:TemplateField> 
										 <asp:TemplateField HeaderText="ARAZI">  
                    <ItemTemplate>  
                        <asp:Label ID="agent" runat="server" Text='<%#Eval("APPNO") %>'></asp:Label>  
                    </ItemTemplate>  
                       
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PLOT NO">  
                    <ItemTemplate>  
                        <asp:Label ID="location" runat="server" Text='<%#Eval("PLOTNO") %>'></asp:Label>  
                    </ItemTemplate>  
                   
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="SIZE">  
                    <ItemTemplate>  
                        <asp:Label ID="location1" runat="server" Text='<%#Eval("PLOTSIZE") %>'></asp:Label>  
                    </ItemTemplate>  
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STATUS">  
                    <ItemTemplate>  
                        <asp:Label ID="block5" runat="server" Text='<%#Eval("STATUS") %>'></asp:Label>  
                    </ItemTemplate> 
                   
                </asp:TemplateField>   
                <asp:TemplateField HeaderText="MOBILE">  
                    <ItemTemplate>  
                        <asp:Label ID="block" runat="server" Text='<%#Eval("MOBILE") %>'></asp:Label>  
                    </ItemTemplate> 
                   
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="MODE">  
                    <ItemTemplate>  
                        <asp:Label ID="plotno" runat="server" Text='<%#Eval("MODE") %>'></asp:Label>  
                    </ItemTemplate> 
                   
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ASSOSCIATE ID">  
                    <ItemTemplate>  
                        <asp:Label ID="area" runat="server" Text='<%#Eval("AGENTID") %>'></asp:Label>  
                    </ItemTemplate>  
                    
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





