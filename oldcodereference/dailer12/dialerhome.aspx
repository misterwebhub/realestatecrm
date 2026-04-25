<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialerhome.aspx.cs" Inherits="dialer_dialerhome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    

    <script src = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.js"></script>
<script>
    var count = 0;
    $(document).ready(function () {
       
        $('.txt').click(function () {
            var num = ($(this).clone().children().remove().end().text());
            var textField = $('#telNumber');
            textField.val(textField.val() + num.trim())







        });

    });
   
      </script>
  

<script type="text/javascript">

	 var key="";
										 var from1="";
										 var to1="";
	var s4="";
   
function fetch1() {
 show1();
     s4 = document.getElementById('<%=telNumber.ClientID%>').value;
	
										 var userid = document.getElementById('<%=Label4444.ClientID%>').innerHTML;
       
										
										 
		if(userid=="heedrealestate")
		{
			
			from1="9129822343";
		
		}
		else
		{
			if(userid=="Ashok8396")
		    {
			
			    from1="8115338396";
			
		    }
			else
			{
				if(userid=="MACHHARIYAOFFICE")
		    {
			
			    from1="7000851919";
			
		    }
			}
		}
       // var s4="";
    


	fetch('https://s-ct3.sarv.com/v2/clickToCall/para?user_id=59214019&token=wIE6xwnCMH24p4dImA5U&from='+from1+'&to='+s4+'')
  .then((response) => {
    console.log(response)
    response.json().then((data) => {
        console.log(data);
        document.getElementById('callid').textContent=data.callId;
                document.getElementById("TextBox3333").value = document.getElementById("callid").innerText;
        
    });
}); 
    }
       
     function fetch3()
      {
      document.getElementById('<%=telNumber.ClientID%>').value = "";
      } 

       function show1() {
        document.getElementById("put1").style.display = "block";
      
    }
    
 
    

</script>


    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

<style type="text/css">
.smartphone {
  position: relative;
  width: 320px;
  height: 500px;
  margin: auto;
  border: 16px black solid;
  border-top-width: 60px;
  border-bottom-width: 68px;
  border-radius: 36px;
}

/* The horizontal line on the top of the device */
.smartphone:before {
  content: '';
  display: block;
  width: 60px;
  height: 5px;
  position: absolute;
  top: -30px;
  left: 50%;
  transform: translate(-50%, -50%);
  background: #333;
  border-radius: 10px;
}

/* The circle on the bottom of the device */
.smartphone:after {
  content: '';
  display: block;
  width: 35px;
  height: 35px;
  position: absolute;
  left: 50%;
  bottom: -65px;
  transform: translate(-50%, -50%);
  background: #333;
  border-radius: 50%;
}

/* The screen (or content) of the device */
.smartphone .content {
 width: 320px;
  height: 485px;
  background: white;
}

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
  
  
    width:30%;
}
.pu1
{
   
   
    width:70%;
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
    
    width:100%;
    height:500px;
    background: #fff;
}
.tel
{
    margin-bottom: 10px;
    margin-top: 10px;
    border: 1px solid #9e9e9e;
    border-radius: 0px;
    width:314px;
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
    height: 70px;
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

#rt
{
    height:100%;
   
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


.num-pad
{
    padding-left: 10px;
    width:310px;
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
    width: 80px;
    height:65px;
    border-radius:100%;
    margin: 0 8px 10px 8px;
    
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
#put1
{
    position:absolute;
height:372px;
margin-left:1%;
width:900px;
background-color:white;
box-shadow:0px 0px 20px black;
display:none;
margin-top:260px;
overflow:hidden;
}
#rat
{

padding:10px;
background-color:black;
color:white;

position:absolute;
margin-left:97%;

}
 .style1111
        {
            width: 100%;
            height: 213px;
        }
        .style2222
        {
            color: #660033;
            height: 42px;
            font-size: x-large;
        }
        .style3333
        {
            height: 53px;
        }
        .style4444
        {
            font-weight: bold;
        }
        .style5555
        {
            height: 37px;
        }
        .style6666
        {
            height: 38px;
        }
        .style9999
        {
            width: 160px;
        }
        .style11111
        {
            width: 182px;
        }
        .style13333
        {
            width: 134px;
        }
        .style15555
        {
            width: 165px;
        }
        .style16666
        {
            width: 167px;
        }
        .style17777
        {
            width: 177px;
        }
</style>


</head>
<body>
    <form id="form1" runat="server">
    

<div class="container">
<div id="rt" class="pu1">

    <asp:Panel ID="Panel1" runat="server" style="width:100%;height:628px;background-color:Scrollbar;margin-top:15px;">
    <table style="height:100%;width:100%;">
    <tr style="height:10%;">
        <td style="font-size:25pt;text-align:center;font-weight:bold;color:White;" 
            bgcolor="#000066" class="fa-inverse">CUSTOMER FEEDBACK DETAILS</td></tr>
     <tr style="height:5%;"><td style="font-size:15pt;text-align:left;font-weight:bold;" 
             bgcolor="#FFCCFF">&nbsp;<span class="style3">REG.NO
         <asp:Label ID="Label1111" runat="server" Text="Label"></asp:Label>
         &nbsp;&nbsp;MOBILE NO &nbsp;&nbsp;<asp:Label ID="Label2222" runat="server" 
             Text="Label"></asp:Label>
         &nbsp;
         <asp:TextBox ID="TextBox3333" runat="server" Height="22px" Width="262px"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </span> 
         <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
             style="font-weight: 700;border-radius:100px;" Text="POPUP"/>
         </td></tr>
     <tr><td bgcolor="#99FF66" class="style2"><span class="style1">REASON</span> &nbsp;
         <asp:TextBox ID="TextBox1111" runat="server" Height="33px" Width="178px"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;<strong>DATE</strong>
         <asp:TextBox ID="TextBox2222" runat="server" Height="33px" Width="92px"  
             TextMode="Date"></asp:TextBox>
         &nbsp;&nbsp;
         <asp:Button ID="Button3" runat="server" Font-Bold="True" Height="35px" 
             onclick="Button3_Click" Text="ADD FEEDBACK" Width="123px" />
         &nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label3333" runat="server" ForeColor="Red" Text="Label"></asp:Label>
         <br />
         <asp:Label ID="Label4444" runat="server" ForeColor="#99FF66" Text="Label"></asp:Label>
         &nbsp;<asp:Label ID="callid" runat="server" ForeColor="#99FF66" Text=""></asp:Label>
         </td></tr>
      <tr style="height:85%;"><td>
          <asp:Panel ID="Panel2" runat="server" Height="480px">
             
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
    <div style="margin-left:10px;width:98%;height:628px;margin-top:15px;">
    <div class="smartphone">
  <div class="content">
      <div class="row">
        <div class="col-md-4 col-md-offset-4 phone">
            <div class="row1">
                <div class="col-md-12">
                
    <asp:TextBox type="tel" name="name" id="telNumber" class="form-control tel" value="" 
                        runat="server" Font-Bold=true Font-Size="25pt"></asp:TextBox>
                    <div class="num-pad">
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                1
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                2 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                3 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                4 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                5 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                6 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                7 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                8 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                9 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                *
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                0 
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="num">
                            <div class="txt">
                                #
                            </div>
                        </div>
                    </div>
                    </div>
                    <div class="clearfix">
                    </div>
                    <table style=" width:100%;text-align:center;" ><tr><td>
                            <asp:Button ID="Button1" runat="server" Text="CALL"  class="btn" 
                                BackColor="#66BB6A" 
                                onclick="Button1_Click"/></td><td>
                           <asp:Button ID="Button2" runat="server" Text="RESET"  class="btn" 
                                BackColor="Red" onclick="Button2_Click" 
                                /></td></tr></table>
                        
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div>
                    </div>
                </div>
            </div>
            <div class="clearfix">
            </div>
        </div>
    </div>
  </div>
</div>
    </div>
    </div>
</div>


 <asp:Panel ID="Panel3" runat="server" >
<div id="put1">

    <asp:Button ID="rat" runat="server" Text="X" onclick="rat_Click"  />
   
  
<div style="height:460px;width:900px; margin-top:-48px;font-size:11pt;" >

<table class="style1111">
            <tr>
                <td class="style2222" style="text-align: center">
                    <strong>CUSTOMER EMI DETAILS</strong></td>
            </tr>
            <tr>
                <td bgcolor="#66FF99" class="style3333">
                    <b>CUSTOMER REG.NO.&nbsp;&nbsp;&nbsp;
                    </b>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="style4444" Height="27px" 
                        style="font-size: large" Width="141px" ReadOnly="True"></asp:TextBox>
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                    <b>&nbsp;&nbsp;&nbsp;&nbsp;
                    </b>
                    <asp:Label ID="Label1" runat="server" style="color: #FF0000; " 
                        Text="Label" CssClass="style4444"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#FF99FF" class="style5555">
                    <b>ARAZI -&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT.NO -&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PLOT SIZE -
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BOOKING DATE -
                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; END DATE&nbsp; -
                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </b></td>
            </tr>
            <tr>
                <td bgcolor="#FFFFCC" class="style6666">
                    <strong>NAME  </strong>- <b>
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </b></td>
            </tr>
            <tr>
                <td bgcolor="#CCCCCC">
                    <table class="style1111">
                        <tr>
                            <td class="style15555">
                    <strong>TOTAL AMOUNT&nbsp;</strong></td>
                            <td class="style16666">
                                <b><asp:Label 
                        ID="Label6" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9">
                                <b>RECIEVE AMOUNT&nbsp;</b></td>
                            <td class="style17">
                                <b>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11">
                                <b>BALANCE AMOUNT</b></td>
                            <td class="style13">
                                <b> <asp:Label ID="Label8" runat="server" 
                        Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15555">
                                <b>DOWN PAYMENT</b></td>
                            <td class="style16666">
                                <b>
                    <asp:Label ID="Label16" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9999">
                                <b>RECIEVE D.P&nbsp;</b></td>
                            <td class="style17777">
                                <b> <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11111">
                                <b>BALANCE D.P</b></td>
                            <td class="style13333">
                                <b>
                    <asp:Label ID="Label18" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15555">
                                <b>TOTAL EMI</b></td>
                            <td class="style16666">
                                <b>
                    <asp:Label ID="Label9" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9999">
                                <b>PAID EMI&nbsp;</b></td>
                            <td class="style17777">
                                <b>
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style11111">
                                <b>BALANCE EMI</b></td>
                            <td class="style13333">
                                <b>
                    <asp:Label 
                        ID="Label11" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15555">
                                <b>TOTAL MONTH EMI</b></td>
                            <td class="style16666">
                                <b>
                    <asp:Label ID="Label20" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9999">
                                <b>NO. OF PAID EMI</b></td>
                            <td class="style17777">
                                <b>
                    <asp:Label ID="Label21" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
&nbsp;&nbsp; =&nbsp;
                    <asp:Label ID="Label24" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style11111">
                                <b>BALANCE EMI MONTH</b></td>
                            <td class="style13333">
                                <b>
                    <asp:Label 
                        ID="Label22" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15555">
                                <b>LATE EMI</b></td>
                            <td class="style16666">
                                <b>
                    <asp:Label ID="Label12" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                            <td class="style9999">
                                <b>LATE EMI PAYMENT</b></td>
                            <td class="style17777">
                                <b>
                    <asp:Label ID="Label13" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    </b>
                            </td>
                            <td class="style11111">
                                &nbsp;</td>
                            <td class="style13333">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style15555">
                                <strong>FIXED EMI</strong></td>
                            <td class="style16666">
                                <b>
                    <asp:Label ID="Label23" runat="server" Text="Label" ForeColor="#003300"></asp:Label>
                    </b>
                            </td>
                            <td class="style9999">
                                &nbsp;</td>
                            <td class="style17777">
                                &nbsp;</td>
                            <td class="style11111">
                                &nbsp;</td>
                            <td class="style13333">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style15555">
                                <b>ADVANCE AMOUNT</b></td>
                            <td class="style16666">
                                <b> <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                    </b>
                            </td>
                            <td class="style9999">
                                <strong>LAST PAID DATE </strong></td>
                            <td class="style17777">
                                <asp:Label ID="Label25" 
            runat="server" Text="Label"></asp:Label></td>
                            <td class="style11111">
                              <strong>AMOUNT </strong></td>
                            <td class="style13333">
                                 <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </table>
                    <b>&nbsp;</b><br />
                </td>
            </tr>
        </table>
        </div>
</div>
  </asp:Panel>
    </form>
</body>
</html>
