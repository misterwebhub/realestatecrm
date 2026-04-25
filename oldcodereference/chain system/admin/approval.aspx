<%@ Page Title="" Language="C#" MasterPageFile="~/admin/homemaster.master" AutoEventWireup="true" CodeFile="approval.aspx.cs" Inherits="admin_approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">  
        .WrapText {  
            width: 100%;  
            word-break: break-all;  
        }  
    </style>
<form runat="server">
<h3>Posted Property </h3>
 <div class="WrapText">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" style="width:100%;text-align:left;"  onrowdatabound="GridView1_RowDataBound"  AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" onrowdeleting="GridView1_RowDeleting">
        <Columns>
           
           <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="TYPE">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_type" runat="server" Text='<%#Eval("protype") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
           <asp:TemplateField HeaderText="SIZE">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_SIZE" runat="server" Text='<%#Eval("prosize") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
             <asp:TemplateField HeaderText="RATE">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_rate" runat="server" Text='<%#Eval("prorate") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="LOCATION">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_LOCATION" runat="server" Text='<%#Eval("prolocation") %>'></asp:Label>  
                    </ItemTemplate>  
                     <ItemStyle Width="120px" />  
                </asp:TemplateField>
          <asp:TemplateField HeaderText="REMARK">  
                    <ItemTemplate>  
                        <asp:Label ID="REMARK" runat="server" Text='<%#Eval("proremark") %>'></asp:Label>  
                    </ItemTemplate>  
			   <ItemStyle Width="120px" />
                </asp:TemplateField>
          <asp:TemplateField HeaderText="NAME">  
                    <ItemTemplate>  
                        <asp:Label ID="proname" runat="server" Text='<%#Eval("proname") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
              <asp:TemplateField HeaderText="MOBILE">  
                    <ItemTemplate>  
                        <asp:Label ID="promobile" runat="server" Text='<%#Eval("promobile") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>
          <asp:TemplateField HeaderText="ADDRESS">  
                    <ItemTemplate>  
                        <asp:Label ID="ADDRESS" runat="server" Text='<%#Eval("proaddress") %>'></asp:Label>  
                    </ItemTemplate>  
                    <ItemStyle Width="150px" />  
                </asp:TemplateField>
           
            <asp:ImageField DataImageUrlField="proimage1" 
                HeaderText="IMAGE 1">
                <ControlStyle Height="100px" Width="100px" />
              
            </asp:ImageField>
            <asp:ImageField DataImageUrlField="proimage2" 
                HeaderText="IMAGE 2">
                <ControlStyle Height="100px" Width="100px" />
            </asp:ImageField>
            <asp:TemplateField HeaderText="STATUS">  
                    <ItemTemplate>  
                        <asp:Label ID="STATUS" runat="server" Text='<%#Eval("status") %>'></asp:Label>  
                    </ItemTemplate>  
               
                <EditItemTemplate>  
                       <asp:HiddenField ID="hdnprice" runat="server" Value='<%#Eval("status") %>' />
<asp:DropDownList ID = "ddlprice" runat = "server">
</asp:DropDownList>
                    </EditItemTemplate> 
                     </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTION">   
                    <ItemTemplate>  
                     <asp:ImageButton ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" width="30px" ImageUrl="agent/edit.png"/> &nbsp;&nbsp;  <asp:ImageButton ID="Button2" runat="server" Text="Delete" CommandName="DELETE"  width="30px" ImageUrl="agent/del.png"/>  
                        
                       
                         
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                    <ItemStyle Width="150px" />
                </asp:TemplateField> 
           
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />

    </asp:GridView>
    </div>
    </form>
</asp:Content>

