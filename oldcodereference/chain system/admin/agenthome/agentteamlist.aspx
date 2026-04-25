<%@ Page Title="" Language="C#" MasterPageFile="~/admin/agenthome/agentmaster.master" AutoEventWireup="true" CodeFile="agentteamlist.aspx.cs" Inherits="admin_agenthome_agentteamlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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
<div class="content-wrapper" style="min-height: 428.016px;">
  
  <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h4 class="m-0 text-success font-weight-bold">Associate Team List 
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
                <div id="example3_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer"><div class="row">
                <div>
                 <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/admin/print.png" 
                     style="height:30px;width:30px;" onclick="btnPrint_Click"/> &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton 
                     ID="ImageButton2" runat="server" ImageUrl="~/admin/excel.png"  
                     style="height:30px;width:30px;" onclick="ExportToExcel" /></div>
                
          </div>
                <div class="col-12">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" 
                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        GridLines="Vertical" AutoGenerateColumns="False"  AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="20">
                        <Columns>
                        <asp:TemplateField HeaderText = "Sr.No" ItemStyle-Width="50">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="book" runat="server" Text='<%#Eval("formid") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">  
                    <ItemTemplate>  
                        <asp:Label ID="name" runat="server" Text='<%#Eval("name") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="130px" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Sponser Id">  
                    <ItemTemplate>  
                        <asp:Label ID="pro" runat="server" Text='<%#Eval("agentid") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rank">  
                    <ItemTemplate>  
                        <asp:Label ID="rank" runat="server" Text='<%#Eval("rank") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile">  
                    <ItemTemplate>  
                        <asp:Label ID="mobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pan">  
                    <ItemTemplate>  
                        <asp:Label ID="pan" runat="server" Text='<%#Eval("pan") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bank">  
                    <ItemTemplate>  
                        <asp:Label ID="bank" runat="server" Text='<%#Eval("bankname") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account">  
                    <ItemTemplate>  
                        <asp:Label ID="account" runat="server" Text='<%#Eval("account") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IFSC Code">  
                    <ItemTemplate>  
                        <asp:Label ID="ifsc" runat="server" Text='<%#Eval("ifsc") %>'></asp:Label>  
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





