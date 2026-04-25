<%@ Page Title="" Language="C#" MasterPageFile="~/admin/agenthome/agentmaster.master" AutoEventWireup="true" CodeFile="teambusin.aspx.cs" Inherits="admin_agenthome_selfbusin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<link type="text/css" href="css/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />

     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
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


                 $('#<%=TextBox1.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });
                 $('#<%=TextBox2.ClientID%>').datepicker({ dateFormat: 'dd/mm/yy' });

             });
    </script>
<div class="content-wrapper" style="min-height: 428.016px;">

  <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4 class="m-0 text-success font-weight-bold">Team Business Report 
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
                
                             <div class="col-md-2">
                             <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
            </asp:DropDownList>
                </div>   
                 
                               
               
                                <div class="col-md-2">
                              
                                    <asp:TextBox ID="TextBox1" runat="server"  class="form-control" TextMode="Date" placeholder="MM/DD/YY"></asp:TextBox>
                </div>
                
                                <div class="col-md-2">
                                  
                                <asp:TextBox ID="TextBox2" runat="server"  class="form-control" TextMode="Date"  placeholder="MM/DD/YY"></asp:TextBox>
                </div>
                <div class="col-md-2">
                                 <asp:Button ID="Button1" runat="server" Text="Submit" 
                                     class="btn btn-success  btn-block" onclick="Button1_Click"/>
                </div>
                </div>
                <br />
                <div class="row">
                 <div>
                 <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/admin/print.png" 
                     style="height:30px;width:30px;" onclick="btnPrint_Click"/> &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
                     ID="ImageButton2" runat="server" ImageUrl="~/admin/excel.png"  
                     style="height:30px;width:30px;" onclick="ExportToExcel" /></div>
                
          </div>
                <div class="col-12">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" AutoGenerateColumns="False">
                        <Columns>
                        <asp:TemplateField HeaderText = "Sr.No" ItemStyle-Width="50">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Book Id">  
                    <ItemTemplate>  
                        <asp:Label ID="book" runat="server" Text='<%#Eval("formid") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cust.Name">  
                    <ItemTemplate>  
                        <asp:Label ID="name" runat="server" Text='<%#Eval("name") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Location">  
                    <ItemTemplate>  
                        <asp:Label ID="pro" runat="server" Text='<%#Eval("location") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Block">  
                    <ItemTemplate>  
                        <asp:Label ID="rank" runat="server" Text='<%#Eval("block") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Plot No">  
                    <ItemTemplate>  
                        <asp:Label ID="plotno" runat="server" Text='<%#Eval("plotno") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paid">  
                    <ItemTemplate>  
                        <asp:Label ID="paid" runat="server" Text='<%#Eval("paid") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Recipt No">  
                    <ItemTemplate>  
                        <asp:Label ID="recid" runat="server" Text='<%#Eval("recid") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Pay Mode"> 
                    <ItemTemplate>  
                        <asp:Label ID="mode" runat="server" Text='<%#Eval("mode") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Remark">  
                    <ItemTemplate>  
                        <asp:Label ID="remark" runat="server" Text='<%#Eval("remark") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent ID">  
                    <ItemTemplate>  
                        <asp:Label ID="agentid" runat="server" Text='<%#Eval("agentid") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Date">  
                    <ItemTemplate>  
                        <asp:Label ID="ifsc" runat="server" Text='<%#Eval("date","{0:dd/MM/yyyy}") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                  
                        </Columns>
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
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
</div>
</asp:Content>



