<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="_37jajmau_demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 63px;
        }
        .style3
        {
            height: 34px;
        }
    </style>
    <script type="text/javascript">

	 var key="";
										 var from1="";
										 var to1="";
	var s4="";
   
function fetch1() {
 
     s4 = document.getElementById('<%=TextBox2.ClientID%>').value;
	 from1 = document.getElementById('<%=TextBox1.ClientID%>').value;
										
			
		
       // var s4="";
    


	fetch('https://s-ct3.sarv.com/v2/clickToCall/para?user_id=59214019&token=wIE6xwnCMH24p4dImA5U&from='+from1+'&to='+s4+'')
  .then((response) => {
    console.log(response)
    response.json().then((data) => {
        console.log(data);
       
        
    });
}); 
    
   }    
    
    
 
    

</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    FROM</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="15pt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    TO</td>
                <td class="style3">
                    <asp:TextBox ID="TextBox2" runat="server" Font-Size="15pt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="CALL" Width="62px" 
                        onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
