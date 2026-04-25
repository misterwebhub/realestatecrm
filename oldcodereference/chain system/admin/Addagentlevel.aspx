<%@ Page Title="" Language="C#" MasterPageFile="~/chain system/admin/homemaster.master" AutoEventWireup="true" CodeFile="Addagentlevel.aspx.cs" Inherits="admin_Addagentlevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
.form-control
{
    display: block;
    width: 100%;
    height: calc(2.25rem + 2px);
    padding: 0.375rem 0.75rem;
    font-size: 10pt;
    font-weight: 400;
    line-height: 1.5;
    color: #495057;
    background-color: #ffffff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    border-radius: 0.25rem;
    box-shadow: inset 0 0 0 rgb(0 0 0 / 0%);
    transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}
.form-control1
{
    color: #1F2D3D;
    background-color: #ffc107;
    border-color: #ffc107;
    box-shadow: none;
 
    font-weight: 400;
    color: #212529;
    text-align: center;
   
    
    border: 1px solid transparent;
    padding: 0.375rem 0.75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: 0.25rem;
   
}
</style>
<form id="Form1" runat=server>
<table style="width:100%;">
<tr>
<th><p style="padding:5px;background-color:Black;color:White;font-weight:bold;text-align:center;">ADD AGENT TYPE</p></th>
</tr>
<tr>
<td style="padding:30px;"><p>TYPE/LEVEL</p>



   <p> <asp:TextBox ID="TextBox1" runat="server"  Width="100%" class="form-control"></asp:TextBox></p>
 <p style="height:10px;"></p>
 <p>PERCENTAGE</p>



   <p> <asp:TextBox ID="TextBox2" runat="server"  Width="100%" class="form-control"></asp:TextBox></p>
    <p style="height:10px;"></p>
       <p><asp:Button ID="Button1" runat="server" Text="ADD " class="form-control1" 
               onclick="Button1_Click"/></p> </td>
</tr>
<tr><td>
<div style="box-shadow:0px 0px 10px black;border-radius:5px;">
<p style="padding:30px;">All Deatils</p>
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
        onrowdeleting="GridView1_RowDeleting" style="width:100%;padding:10px;text-align:left;font-size:14pt;" AllowPaging="true"  OnPageIndexChanging="OnPageIndexChanging" PageSize="10">  
	   <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous"
            NextPageText="Next" LastPageText="Last" />
            <Columns>  
               
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Type">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("name") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Percentage">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Par" runat="server" Text='<%#Eval("percentage") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Par" runat="server" Text='<%#Eval("percentage") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>   
                <asp:TemplateField HeaderText="ACTION">   
                    <ItemTemplate>  
                     <asp:ImageButton ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" width="30px" ImageUrl="agent/edit.png"/> &nbsp;&nbsp; 
                        <asp:ImageButton ID="Button2" runat="server" Text="Delete" CommandName="DELETE"  width="30px" ImageUrl="agent/del.png"/>  
                       
                         
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                    <ItemStyle Width="150px" />
                </asp:TemplateField>  
            </Columns>  
            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
        </asp:GridView>  
</div></td>
</tr>
</table>
</form>
</asp:Content>



