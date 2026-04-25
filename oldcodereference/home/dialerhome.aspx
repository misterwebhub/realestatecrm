<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialerhome.aspx.cs" Inherits="dialer_dialerhome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $('.num').click(function () {
            var num = $(this);
            var text = $.trim(num.find('.txt').clone().children().remove().end().text());
            var telNumber = $('#telNumber');
            $(telNumber).val(telNumber.val() + text);
        });
        var s4 = document.getElementById('<%=telNumber.ClientID%>').value;
      //  var s4="9616554748";
   const options = {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    Authorization: 'Bearer 240762|L4QdGaR5eXSnLaO4gni1WrxJzvoox1WJ2atOccTm'
  },
  body: 'false'
};

fetch('https://panelv2.cloudshope.com/api/click_to_call?from_number=9129822343&to_number=9170746268&callback_url=from_number%2Cto_number%2Canswer_time%2Cstatus%20', options)
  .then((response) => {
    console.log(response)
    response.json().then((data) => {
        console.log(data);
    });
});
   
    


    });
    

</script>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBox2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 00);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });
</script>
<style type="text/css">
@import url(http://fonts.googleapis.com/css?family=Lato:300);
@import url(http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.min.css);
body
{
    margin: 0;
    padding: 0;
    font-family: 'Lato' , sans-serif;
    color: #333;
    background-size: 100%;
    -webkit-font-smoothing: antialiased;
    -webkit-text-size-adjust: none;
    background-color: #475264;
}
.pu
{
    position:fixed;
    margin-left:40%;
}
p
{
    margin: 0;
    padding: 0 0 10px 0;
    line-height: 20px;
}
.span4
{
    width: 80px;
    float: left;
    margin: 0 8px 10px 8px;
}

.phone
{
    margin-top: 15px;
    width:60%;
    height:460px;
    background: #fff;
}
.tel
{
    margin-bottom: 10px;
    margin-top: 10px;
    border: 1px solid #9e9e9e;
    border-radius: 0px;
}
.num-pad
{
    padding-left: 10px;
    width:310px;
}


.num
{
    border: 1px solid #9e9e9e;
    -webkit-border-radius: 999px;
    border-radius: 999px;
    -moz-border-radius: 999px;
    height: 80px;
    background-color: #fff;
    color: #333;
    cursor: pointer;
}
.num:hover
{
    background-color: #9e9e9e;
    color: #fff;
    transition-property: background-color .2s linear 0s;
    -moz-transition: background-color .2s linear 0s;
    -webkit-transition: background-color .2s linear 0s;
    -o-transition: background-color .2s linear 0s;
}
.txt
{
    font-size: 30px;
    font-weight:bold;
    text-align: center;
    margin-top: 15px;
    font-family: 'Lato' , sans-serif;
    line-height: 30px;
    color: #333;
}
.small
{
    font-size: 15px;
}

.btn
{
    font-weight: bold;
    -webkit-transition: .1s ease-in background-color;
    -webkit-font-smoothing: antialiased;
    letter-spacing: 1px;
    width:94%;
}
.btn:hover
{
    transition-property: background-color .2s linear 0s;
    -moz-transition: background-color .2s linear 0s;
    -webkit-transition: background-color .2s linear 0s;
    -o-transition: background-color .2s linear 0s;
}
.spanicons
{
    width: 72px;
    float: left;
    text-align: center;
    margin-top: 40px;
    color: #9e9e9e;
    font-size: 30px;
    cursor: pointer;
}
.spanicons:hover
{
    color: #3498db;
    transition-property: color .2s linear 0s;
    -moz-transition: color .2s linear 0s;
    -webkit-transition: color .2s linear 0s;
    -o-transition: color .2s linear 0s;
}
.active
{
    color: #3498db;
}
td
{
    width:40%;
}
#rt
{
    height:100%;
    width:50%;
    float:left;
}
    .style1
    {
        font-size: large;
    }
    .style2
    {
        height: 67px;
    }
    .style3
    {
        font-size: medium;
    }
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 500px;
        height: 400px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    

<div class="container">
<div id="rt">

    <asp:Panel ID="Panel1" runat="server" style="width:100%;height:600px;background-color:Scrollbar;margin-top:15px;">
    <table style="height:100%;width:100%;">
    <tr style="height:10%;">
        <td style="font-size:25pt;text-align:center;font-weight:bold;" 
            bgcolor="#000066" class="fa-inverse">CUSTOMER FEEDBACK DETAILS</td></tr>
     <tr style="height:5%;"><td style="font-size:15pt;text-align:left;font-weight:bold;" 
             bgcolor="#FFCCFF">&nbsp;<span class="style3">REG.NO
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
         &nbsp;&nbsp;MOBILE NO &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
         </span> </td></tr>
     <tr><td bgcolor="#99FF66" class="style2"><span class="style1">REASON</span> &nbsp;
         <asp:TextBox ID="TextBox1" runat="server" Height="33px" Width="178px"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;<strong>DATE</strong>
         <asp:TextBox ID="TextBox2" runat="server" Height="33px" Width="92px"></asp:TextBox>
         &nbsp;&nbsp;
         <asp:Button ID="Button3" runat="server" Font-Bold="True" Height="35px" 
             onclick="Button3_Click" Text="ADD FEEDBACK" Width="119px" />
         &nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="Label"></asp:Label>
         </td></tr>
      <tr style="height:85%;"><td>
          <asp:Panel ID="Panel2" runat="server" Height="522px">
             
              <asp:GridView ID="GridView1" runat="server" 
                  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                  CellPadding="4" Width="100%" AutoGenerateColumns="False">
                  <Columns>
                      <asp:BoundField DataField="date" HeaderText="CALLING DATE" DataFormatString = "{0:dd/MM/yyyy}">
                      <ItemStyle Width="30px" />
                      </asp:BoundField>
                      <asp:BoundField DataField="feeddate" HeaderText="GIVEN DATE">
                      <ItemStyle Width="30px" />
                      </asp:BoundField>
                      <asp:BoundField DataField="reason" HeaderText="FEEDBACK" >
                      <ItemStyle Width="200px" />  </asp:BoundField>
                  </Columns>
                  <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                  <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                  <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                  <RowStyle BackColor="White" ForeColor="#330099" />
                  <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                  <SortedAscendingCellStyle BackColor="#FEFCEB" />
                  <SortedAscendingHeaderStyle BackColor="#AF0101" />
                  <SortedDescendingCellStyle BackColor="#F6F0C0" />
                  <SortedDescendingHeaderStyle BackColor="#7E0000" />
              </asp:GridView>
          </asp:Panel>
      </td></tr>
    </table>
    <div>
    <ul id="authors"></ul>
    </div>
    </asp:Panel>


</div>
<div id="rt" class="pu">
    
                    <table style=" width:100%;" >
                    <tr>
                    <td colspan="2"><asp:TextBox ID="telNumber" runat="server"></asp:TextBox></td>
                    </tr><tr><td>
                            <asp:Button ID="Button1" runat="server" Text="CALL"  class="btn" 
                                BackColor="#66BB6A" OnClientClick="javascript:return fetch();" 
                                onclick="Button1_Click"/></td><td>
                            <asp:Button ID="Button2" runat="server" Text="RESET"  
                                class="btn" BackColor="Red" onclick="Button2_Click"/></td></tr></table>
                        
                </div>

          

<div class="loading" align="center">
    Loading. Please wait.<br />
    <br />
 <img src="loader.gif" />
</div>
    </form>
</body>
</html>
