
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="custsmssend.aspx.cs" Inherits="smssend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	<script type="text/javascript">
	    var windowObjectReference;


	    function openRequestedPopup() {
                var s = document.getElementById('<%=Label1.ClientID%>').innerHTML;
       
                  
            windowObjectReference = window.open("http://sms.webguard.in/api/sendhttp.php?authkey=330026AlOBgB2Z85ec8e185P1&mobiles=9129822343&message=" +s+ "&sender=HEEDKP&route=4&country=91");
	       
	   
        }
		
		
</script>
   
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
