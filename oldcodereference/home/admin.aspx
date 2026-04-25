<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
<link rel="stylesheet" href="css/style1.css" type="text/css" media="screen" />

<link href="css/swc.css" rel="stylesheet" type="text/css" />
<script src="Scripts/jquery-1.7.1.js"></script>
            <script language="javascript" >
                $(document).ready(function () {
                    var gridHeader = $('#<%=GridView1.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=GridView1.ClientID%> tr th').each(function (i) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHead").append(gridHeader);
                    $('#GHead').css('position', 'absolute');
                    $('#GHead').css('top', $('#<%=GridView1.ClientID%>').offset().top);

                });
            </script>
</head>
<div class="example">
    <ul id="nav">
     	 <li><a>Payment</a>
			 <ul>
				   <li><a>Company Hishab</a>
					  <ul> 
					 
					 <li><a>RAGHUNATH</a>
				 <ul> 
					 
					 <li><a href="../pradhan/addentry.aspx" target="_blank">Arazi Wise Add Plot & Arazi</a></li>
					 <li><a href="../pradhan/Totaldetails.aspx" target="_blank">Month Wise payment(Month) </a></li>
					 <li><a href="../pradhan/totalpaymentdetails.aspx" target="_blank">Customer Summury Payment Deatils </a></li>
					 <li><a href="../pradhan/Detailskishan.aspx" target="_blank">All Arazi & Single Month Details</a></li>
					 <li><a href="../pradhan/monthdetailst.aspx" target="_blank">Single Arazi & All Month Details</a></li>
					  <li><a href="../pradhan/raghunathdeedadd.aspx" target="_blank">Add Deed No for Payment</a></li>
					  <li><a href="../pradhan/raghunath.aspx" target="_blank">Deed Details</a></li>
					 <li><a href="../pradhan/monthlypayment.aspx" target="_blank">Compromise Payment Details</a></li>
					 </ul>
				 </li>
						 <li><a>PRADEEP AGRAWAL</a>
				 <ul> 
					 
					 <li><a href="PRADEEPAGR.aspx" target="_blank">DETAILS</a></li>
					 
					 </ul>
				 </li> 
						  
						  
						  <li><a>Partner</a>
						  <ul> 
					 
					 <li><a href="newkishandetails.aspx" target="_blank">Partner Hishab</a></li>
					 
					 </ul>
				 </li>
						  
						 
					 
					 </ul>
				 </li>
				 <li><a href="arazipayment.aspx" target="_blank">Total Arazi wise Payment</a></li>
		  <li><a href="Totaldetails.aspx" target="_blank">Arazi wise payment( Month) </a></li>
				 <li><a>PAID -NON PAID</a><ul>		
			
			<li><a href="Detail.aspx" target="_blank">Month wise paid-none installment</a></li>
					 <li><a href="datewisepayment.aspx" target="_blank">Date wise paid-non installment</a></li>
			 </ul>
				 </li> 
		          
		<li><a href="totalpaymentdetails.aspx" target="_blank">Customer Summury Payment Deatils </a></li>
				
				 <li><a href="kishanarazipayment.aspx" target="_blank">Customer & Kishan Deatils </a></li>
				 <li><a href="../sidebar/home.aspx" target="_blank">Invester,Customer & Kishan Summery </a></li>
				  <li><a href="officesummery.aspx" target="_blank">Office Summery Deatils </a></li>
				<li><a href="../ragistry/customersdetails136.aspx" target="_blank">CA Details</a></li>
				 
			
				
		
	</ul>
	</li>	 
		<li><a>Add User</a>
            <ul>
                <li><a href="../user/registration.aspx " target="_blank">Add New User</a></li>
				 <li><a href="../telelogin/teleregform.aspx " target="_blank">Add New Tele User</a></li>
				 <li><a href="userdetails.aspx " target="_blank">User Account Details</a></li>
                <li><a>Bank</a>
		<ul>
			<li><a href="bank/bank.aspx" target="_blank">Bank details Entry</a></li>
			</ul>
		</li>
				
				
            </ul>
        </li>
        <li><a>Bond</a>
            <ul>
                <li><a href="regcertificate.aspx " target="_blank">ADD Bond</a></li>
                <li><a href="regcertificatedetails.aspx " target="_blank">Edit or Delete Bond </a></li>
                <li><a href="Registartiondetails.aspx" target="_blank">Total Customer Bond Details </a></li>
                  <li><a href="regcount.aspx" target="_blank">Registration count </a></li>
				<li><a href="paymentdpdetails.aspx" target="_blank">Customer D.P Details </a></li> <li><a href="DPEMIDetail.aspx" target="_blank">Customer D.P & EMI Details </a></li>
				<li><a href="demoarazimap.aspx" target="_blank">Plot Not Sale ADD</a></li>
            </ul>
        </li>
        <li><a>Reciept</a>
            <ul>
				<li><a>Recipt Entry</a><ul><li><a href="Recipt.aspx" target="_blank">Recipt Entry</a></li>
					<li><a href="extrapaymentrecipt.aspx" target="_blank">Extra Payment</a></li>
					<li><a href="emical.aspx" target="_blank">EMI DETAILS</a></li>
					
					</ul></li>
                 <li><a href="Reciptup.aspx" target="_blank">Recipt Edit or Delete</a></li>
				 <li><a href="printrecipt.aspx" target="_blank">Print Recipt</a></li>
					 <li><a href="RECIPTDELETE.aspx" target="_blank">Delete Recipt</a></li>
				
				<li><a href="chequebounce.aspx" target="_blank">Cheque Bounce</a></li>
				 <li><a href="userreciptdetails.aspx" target="_blank">User Recipt Details</a></li>
				 <li><a href="userpayment.aspx" target="_blank">User Recived Amount Details</a></li>
                
            </ul>
        </li>
        <li><a>Plot/Payment</a>
         <ul>
                <li><a href="plotadd.aspx" target="_blank">Add Plot or Arazi </a></li>
			  <li><a href="paymentragistry.aspx" target="_blank">Ragistry Payment Entry </a></li>
                <li><a href="PLOTDET.aspx" target="_blank">Plot Details Arazi wise(Registry) </a></li>
               
			  <li><a href="registrydetails.aspx" target="_blank">Moved Registry Details </a></li>
			  <li><a href="cancel.aspx" target="_blank">Cancel Plot Details </a></li>
			 
            </ul></li><li><a>Details</a>
				  <ul><li><a href="brokarentry.aspx" target="_blank">Broker Entry</a></li><li><a href="broker.aspx" target="_blank">Broker Details</a></li>
			 <li><a href="brokarpayment.aspx" target="_blank">Broker Payment Details</a></li>
			 <li><a>Customer Cheque</a><ul>
				 <li><a href="chequesms.aspx" target="_blank">Customer Cheque Entry</a></li>
				  <li><a href="chequedetails.aspx" target="_blank">Customer Cheque Reminder</a></li>
				  <li><a href="customermention.aspx" target="_blank"> Other Mention Details</a></li>
				 				

				 </ul></li>
			  <li><a href="remidercheque.aspx" target="_blank">Reminder Cheque Details</a></li>
      
                <li><a href="customerdetailsheed.aspx" target="_blank">Customer Payment Deatils </a></li>
			 <li><a href="totalcheque.aspx" target="_blank">Kishan-Invester Cheque Deatils </a></li>
					  <li><a>MAP</a><ul><li><a href="PDFMAP.aspx" target="_blank">MAP PDF </a></li>
						  
						  </ul></li>
	
                
            </ul>
        </li>
		<li><a>Kishan</a>
		<ul>
			<li><a href="kishan/kishanentry.aspx" target="_blank">Kishan Entry</a></li>
			<li><a href="kishan/checkentry.aspx" target="_blank">Cheque Entry form</a></li>
			<li><a>Invester(%)</a><ul>
				<li><a href="invsterintrest/investerbondint.aspx" target="_blank">Invester Bond</a></li>
				<li><a href="invsterintrest/paymentint.aspx" target="_blank">Invester Recipt</a></li>
				<li><a href="invsterintrest/invintrestpayment.aspx" target="_blank">Invester Payment Details</a></li>
				</ul></li>
			<li><a href="registr.aspx" target="_blank">Kishan Bond</a></li>
			<li><a href="registrupdate.aspx" target="_blank">Kishan Bond UPDATE</a></li>
			<li><a href="RECIPTUPDATE.aspx" target="_blank">Kishan Recipt Update</a></li>
			<li><a href="kishanpayment.aspx" target="_blank">Kishan Payment</a></li>
			<li><a href="details.aspx" target="_blank">Kishan Payment Details</a></li>
			<li><a href="../ragistry/AddRagistry.aspx" target="_blank">Ragistry</a></li>
				<li><a href="patment.aspx" target="_blank">ADD kishan for mention payment</a></li>
			
			
			</ul>
		</li>
		<li><a>Expences</a>
		<ul>
			<li><a href="cheuesearch.aspx" target="_blank">Find Cheque</a></li>
			<li><a href="expence.aspx" target="_blank">Expences Entry</a></li>
			<li><a href="expence recipt.aspx" target="_blank">Monthly Hisab Company</a></li>
			<li><a href="officehishab.aspx" target="_blank">Monthly Hisab Details</a></li>
			</ul>
		</li>
			<li><a href="#" target="_blank">Arazi(%)</a>
					 <ul>
					 <li><a>Add Entry</a>
				 <ul> 
					 
					 <li><a href="https://heedrealestate.com/newproj/Extrapayamount.aspx" target="_blank">Exp. Entry</a></li>
					
					 </ul>
						 </li>
					 <li><a>Bond</a>
				 <ul> 
					 
					 <li><a href="jajmausoft/regcertificate.aspx" target="_blank">Add Bond</a></li>
					 <li><a href="jajmausoft/regcertificatedetails.aspx" target="_blank">Edit Bond</a></li>
					 </ul>
						 </li>
						 <li><a>Recipt</a>
				 <ul> 
					 
					 <li><a href="jajmausoft/Recipt.aspx" target="_blank">Add Recipt</a></li>
					 <li><a href="jajmausoft/Reciptup.aspx" target="_blank">Edit Recipt</a></li>
					  <li><a href="jajmausoft/printrecipt.aspx" target="_blank">Print Recipt</a></li>
					  <li><a href="jajmausoft/RECIPTDELETE.aspx" target="_blank">Delete Recipt</a></li>
					  <li><a href="jajmausoft/userreciptdetails.aspx" target="_blank">User Recipt Details</a></li>
					 </ul>
						 </li>
						  <li><a>Payment</a>
				 <ul> 
					 
					 <li><a href="jajmausoft/customerdetailsheed.aspx" target="_blank">Customer Payment Details</a></li>
					 <li><a href="jajmausoft/Detail.aspx" target="_blank">Total Monthwise Payment</a></li>
					  <li><a href="jajmausoft/totalpaymentdetails.aspx" target="_blank">Customer Summery Payment</a></li>
					  
					 </ul>
						 </li>
						 <li><a>Plot Details</a>
				 <ul> 
					 
					 <li><a href="jajmausoft/PLOTDET.aspx" target="_blank">Plot Details</a></li>
					 
					  
					 </ul>
						 </li>
					 </ul>
		
		
		</li>
		
		
		
		<li><a style="padding:10px 20px;Background-color:red;color:yellow;">Partner</a>
		<ul>
			 
			<li><a>Partner Details</a><ul><li><a href="partner.aspx" target="_blank">Partner details(June-December)</a></li>
				<li><a href="partner2.aspx" target="_blank">Partner details(January)</a></li>
				</ul></li>
			<li><a href="partnerpaid.aspx" target="_blank">Partner Paid Amount details</a></li>
			  <li><a href="invester.aspx" target="_blank">Invester</a></li>
			<li><a href="../demo5/investerreturn.aspx" target="_blank">Alok Kumar</a></li>
			
			</ul>
			
		
		
				 
		
		
				   
		
		
		
		<li><a href="calc.aspx" target="_blank">CALC</a></li>
			</ul>
		</li>

    </ul>
     <form id="Form1" runat=server>
    <div><p>
        <strong >WELCOME : -</strong>  <asp:label ID="Label1" runat="server" 
            text="Label" ForeColor="Yellow" Font-Bold="True" Font-Size="Medium"></asp:label>
		
</p>
		<p style="text-align:right;margin-right:10%;">
			<table style="width:35%;float:right;">
				<tr><td style="font-size:18pt;font-weight:bold;color:white;"></td>
					<td>
         <asp:label ID="Label11" runat="server" 
            text="Label" ForeColor="White" Font-Bold="True" Font-Size="XX-Large"></asp:label>
			 <a href="mentiondetails.aspx" target="_blank"><asp:label ID="Label12" runat="server" 
												   text="Label" ForeColor="Yellow" Font-Bold="True" Font-Size="Large"></asp:label></a></td>
				<td style="font-size:18pt;font-weight:bold;color:white;"></td><td> <asp:label ID="Label13" runat="server" 
						text="" ForeColor="Yellow" Font-Bold="True" Font-Size="Large"></asp:label></td>
					<td style="font-size:18pt;font-weight:bold;color:white;"></td><td> <asp:label ID="Label14" runat="server" 
						text="" ForeColor="Yellow" Font-Bold="True" Font-Size="Large"></asp:label></td>
				
				</tr>
		</table>
		
</p>
	<table style="height:100%;width:100%;margin-top:0%;">
		<tr> <td><a href="../map2/174MI/174MI.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 174MI map</p></a></td>
    <td><a href="../map2/506MAP/506MAP.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 506 map</p></a></td>
			<td><a href="../map2/161GHA/arazi161gha.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 161GHA map</p></a></td>
    <td><a href="../arazi187kha/arazi187kha.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 187KHA map</p></a></td>
		
		</tr>
		<tr>
		<td><a href="../arazi372KAmap/372kamap.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 372KA map</p></a></td>
			     <td><a href="../arazi385KA/arazi385ka.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 385KA map</p></a></td>
           <td><a href="../arazi137/arazi137map.aspx" target="_blank" style="text-decoration:none;color:black;"><p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 137 map</p></a></td> 
			  <td><a href="../arazi320/arazi320map.aspx" target="_blank" style="text-decoration:none;color:black;"><p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 320 map</p></a></td>
		</tr>
    <tr>
    <td><a href="../map/map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;margin-top:0%;font-size:15px;font-weight:bold;text-align:center;">Arazi 152 map</p></a></td>
    <td><a href="../map2/375KA.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;text-align:center;">Arazi 375KA map</p></a></td>
    <td><a href="../map2/30,31/30,31map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;text-align:center;">Arazi 30,31 map</p></a></td>
		<td><a href="../arazi353/arazi353.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;text-align:center;">Arazi 353 map</p></a></td>
    </tr>
    <tr>
    <td><a href="../map2/436MAP/436MAP.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 436 map</p></a></td>
    <td><a href="../map2/1412MAP/1412MAP.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1412 map</p></a></td>
    <td><a href="../map2/1989/newlovekush.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1989 map</p></a></td>
		<td><a href="../37jajmau/jajmau30.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 37 Jajmau map</p></a></td>
    </tr>
    <tr>
    <td><a href="../30neeghanew/30beeghanewsite.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 161 part 2 map</p></a></td>
      <td><a href="../arazi2011map/map2011.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 2011 map</p></a></td>
      
		  <td><a href="../arazi186map/arazi186map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 186 MI map</p></a></td>
     	<td><a href="../arazi419/arazi419.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 419 map</p></a></td>
    </tr>
		 <tr>
    <td><a href="../arazi254map/arazi254.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 254 map</p></a></td>
      <td><a href="../arazi1414/arazi1414.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1414</p></a></td>
      
		  <td><a href="../arazi2001ga/arazi2001ga.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 2001GA</p></a></td>
     	<td><a href="../arazi1413/arazi1413.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1413</p></a></td>
    </tr>
		<tr>
    <td><a href="../arazi1452/arazi1452map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1452 map</p></a></td>
      <td><a  href="../arazi357/arazi357.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 357 map</p></a></td>
      
		 <td><a  href="../arazi217/arazi217.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 217 map</p></a></td>
     	<td><a  href="../ARAZI308/arazi308map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 308 map</p></a></td>
    </tr>
		<tr>
    <td><a href="../arazi340/arazi340.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 340 map</p></a></td>
      <td><a  href="../arazi1731/arazi1731map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1731 map</p></a></td>
      
		 <td><a  href="../arazi246/arazi246map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 246_12BEEGHA map</p></a></td>
     	<td><a  href="../arazi190/arazi190.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 190</p></a></td>
    </tr>
		<tr>
    <td><a href="../arazi100/arazi100.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 100 map</p></a></td>
      <td><a  href="../arazi179/arazi179map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 179</p></a></td>
      
		 <td><a  href="../arazi343/Arazimap343.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 343 imlipur map</p></a></td>
     	<td><a  href="../JDBHATTA/JDBHATTA.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">JD BHATTA</p></a></td>
    </tr>
		
		<tr>
    <td><a href="../arazi156/arazi156map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 156 map</p></a></td>
      <td><a  href="../arazi397/arazi397.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 397 map</p></a></td>
      
		 <td><a  href="#" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">soon</p></a></td>
     	<td><a  href="#" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">soon</p></a></td>
    </tr>
		
    </table>
	
	
		
		
		
		
		
		
		
		
		
				
		
		
		
		

		 </div>
         
         <div id="boxes">
<div id="dialog" class="window" style="height:600px;width:80%;"> 
<div id="san">
<a href="#" class="close agree"><img src="css/close-icon.png" width="25" style="float:right; margin-right: -25px; margin-top: -20px;"></a>
</div>
  <div id="GHead"></div> 
                    <%-- This GHead is added for Store Gridview Header  --%>
                    <div style="height:100%; overflow:auto">
<asp:GridView ID="GridView1" runat="server" 
                         Width="100%" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" 
                        onrowdatabound="GridView1_RowDataBound" Font-Bold=True font-size=small>
                       
                        <Columns>
                            <asp:BoundField DataField="CUSTREGNO" HeaderText="REG.NO" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="ARAZI" HeaderText="ARAZI NO." />
                            <asp:BoundField DataField="PLOTNO" HeaderText="PLOT NO" />
                            <asp:BoundField DataField="PLOTSIZE" HeaderText="PLOT SIZE" />
                            <asp:BoundField DataField="CDATE" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="CHEQUENO" HeaderText="CHEQUE NO" />
                            <asp:BoundField DataField="CAMOUNT" HeaderText="AMOUNT" >
                            <ControlStyle Font-Bold="True" Font-Size="20pt" />
                            <ItemStyle Font-Bold="True" Font-Size="15pt" ForeColor="#00CC00" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHEQUETYPE" HeaderText="CHEQUE TYPE" />
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                            <asp:BoundField DataField="CHECKBY" HeaderText="CHECK BY" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView> </div>
</div>
<div style="width:100%; font-size: 32pt; color:white; height: 100%; display: none; opacity: 0.4;" id="mask"></div>
</div>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script> 
<script src="css/swc.js"></script>
         </form>
</div>

