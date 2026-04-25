<%@ Page Title="" Language="C#" MasterPageFile="~/chain system/admin/agenthome/agentmaster.master" AutoEventWireup="true" CodeFile="mappdf.aspx.cs" Inherits="chain_system_admin_agenthome_mappdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
 <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
      $(document).ready(function () {

          $(".ty").datepicker({
              changeMonth: true,
              changeYear: true,
              dateFormat: 'dd/mm/yy'
          });

      });
 
    </script>
<style>
body {margin:0;}

.navbar {
  overflow: hidden;
  background-color: #333;
  position: fixed;
  top: 0;
  width: 100%;
        left: 0px;
        height: 138px;
    }

.main {
  padding: 16px;

  height: 1500px; /* Used in this example to enable scrolling */
}
.style1
{
    width:100%;
        height: 139px;
    }
    .style3
    {
        height: 27px;
        text-align: center;
    }
    .style4
    {
        height: 29px;
    }
    .style5
    {
        height: 37px;
        text-align: center;
        color: #FFFFFF;
        font-size: large;
    }
    .style6
    {
        height: 45px;
    }
        .style7
        {
            width: 100%;
        }
        .style10
        {
            width: 190px;
            text-align: center;
            font-weight: bold;
            color: #FFFFFF;
        }
        .style9
        {
            text-align: center;
            font-weight: bold;
            color: #FFFFFF;
        }
        .style12
        {
            width: 190px;
            font-weight: bold;
        }
        .style13
        {
            font-weight: bold;
            text-align: center;
            color: #006600;
        }
        .style14
        {
            text-decoration: none;
            color: #006600;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="navbar">
     <table class="style1">
            <tr>
                <td bgcolor="#003300" class="style5" colspan="2">
                    <strong>PDF &amp; ELECTRONIC MAP</strong></td>
            </tr>
            
            <tr>
                <td class="style3" bgcolor="#CCFF99">
                    <asp:Button ID="Button1" runat="server" Height="38px" Text="SHOW PDF MAP" 
                        Width="222px" BackColor="#3366FF" BorderColor="#CC0000" 
                        BorderStyle="Groove" CssClass="style4" Font-Bold="True" ForeColor="Yellow" 
                        onclick="Button1_Click" />
                </td>
                <td class="style3" bgcolor="#CCFF99">
                    <asp:Button ID="Button2" runat="server" Height="35px" Text="SHOW ELECTRONIC MAP" 
                        Width="222px" BackColor="#3366FF" BorderColor="#CC0000" 
                        BorderStyle="Groove" CssClass="style4" Font-Bold="True" ForeColor="Yellow" 
                        onclick="Button2_Click" />
                </td>
            </tr>
            
            </table>

</div>
<div class="main">
  
  
    <asp:Panel ID="Panel2" runat="server" Height="631px" Width="1050px">
                   
                    <table class="style7" border="1">
                        <tr>
                            <td class="style10" bgcolor="#000066">
                                ARAZI</td>
                            <td bgcolor="#000066" class="style9">
                                MAP</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                152 (30 BEEGHA)</td>
                            <td class="style13">
                                <a href="../map/map.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                161 MI</td>
                            <td class="style13">
                                <a href="../30neeghanew/30beeghanewsite.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                161 GHA (9 BEEGHA)</td>
                            <td class="style13">
                                <a href="../map2/161GHA/arazi161gha.aspx" target="_blank" class="style14">
                                CLICK HERE
                                </a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                186 MI (KHAJOOR)</td>
                            <td class="style13">
                                <a href="../arazi186map/arazi186map.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                506</td>
                            <td class="style13">
                                <a href="../map2/506MAP/506MAP.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                30/31</td>
                            <td class="style13">
                                <a href="../map2/30,31/30,31map.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                254</td>
                            <td class="style13">
                                <a href="../arazi254map/arazi254.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                174 MI</td>
                            <td class="style13">
                                <a href="../map2/174MI/174MI.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                372 KA</td>
                            <td class="style13">
                                <a href="../arazi372KAmap/372kamap.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                385 KA</td>
                            <td class="style13">
                                <a href="../arazi385KA/arazi385ka.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                375 KA</td>
                            <td class="style13">
                                <a href="../map2/375KA.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                436</td>
                            <td class="style13">
                                <a href="../map2/436MAP/436MAP.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                1412</td>
                            <td class="style13">
                               <a href="../map2/1412MAP/1412MAP.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                1414</td>
                            <td class="style13">
                                <a href="../arazi1414/arazi1414.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                2011</td>
                            <td class="style13">
                                <a href="../arazi2011map/map2011.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                137 RAMAIPUR</td>
                            <td class="style13">
                                <a href="../arazi137/arazi137map.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                               2001 GA</td>
                            <td class="style13">
                               <a href="../arazi2001GA/arazi2001ga.aspx" target="_blank" class="style14">CLICK HERE</a></td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                     </asp:Panel>
                <br />
                    <asp:Panel ID="Panel1" runat="server" Height="631px">
						<table style="width:100%;">
							<tr>
								<td>
									ARAZI</td><td>
                        <asp:DropDownList ID="DropDownList2" runat="server"  class="form-control">
                        </asp:DropDownList>
								</td>
								<td>
                        <asp:Button ID="Button4" runat="server" style="font-weight: 700" Text="SHOW" 
									Width="81px" onclick="Button4_Click" /></td>
                      <td>
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label></td>
							</tr>
							<tr><td colspan="4">
                       
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                            DataKeyNames="PID" Width="100%" AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand1"
                           
                           >
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#330099" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                            <Columns>
                        <asp:BoundField DataField="PID" HeaderText="PID" ReadOnly="true"/>
                         <asp:TemplateField>
            <HeaderTemplate>Date</HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("date", "{0:dd/MM/yyyy}")%>' ></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
  <asp:TextBox ID="txtDOB" Text='<%# Bind("date","{0:yyyy-MM-dd}") %>' TextMode="Date" runat="server"></asp:TextBox>
</EditItemTemplate>
</asp:TemplateField>
                       
                        <asp:TemplateField>
            <HeaderTemplate>FILE</HeaderTemplate>
    <ItemTemplate>
        <asp:ImageButton  ID="lbldeed" runat="server" ImageUrl="~/pdfmap/adb.png" CommandArgument='<%# Eval("path")%>' CommandName="download"></asp:ImageButton>
    </ItemTemplate>
    
</asp:TemplateField>
                        
                    </Columns>
                        </asp:GridView>
							</td>
						</tr>
	</table>
                    </asp:Panel>
  
  
</div>
</asp:Content>

