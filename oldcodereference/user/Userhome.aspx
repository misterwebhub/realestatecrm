<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Userhome.aspx.cs" Inherits="user_Userhome" %>

<link rel="stylesheet" href="css/style1.css" type="text/css" media="screen" />

<div class="example">
    <ul id="nav">
        <li class="current"><a>
           Home
        </a></li>
        <li><a>Bond</a>
            <ul>
                <li><a href="../home/regcertificate.aspx " target="_blank">ADD Bond</a></li>
              <li><a href="../home/paymentdpdetails.aspx" target="_blank">Customer D.P Details </a></li>
				  <li><a href="../home/DPEMIDetail.aspx" target="_blank">Customer EMI & D.P Details </a></li>
               
                  
            </ul>
        </li>
        <li><a>Reciept</a>
            <ul>
				<li><a>Recipt Entry</a><ul><li><a href="../home/reciptupashok.aspx" target="_blank">Recipt Entry</a></li>
					<li><a href="../home/emical.aspx" target="_blank">EMI DEATILS</a></li>
					
					</ul></li>
                 
                  <li><a href="../home/printrecipt.aspx" target="_blank">Print Recipt</a></li>
				<li><a href="form/Ashokuser.aspx" target="_blank">User Recipt Details</a></li>
            </ul>
        </li>
        <li><a>Plot/Payment</a>
         <ul>
               
                <li><a href="../home/PLOTDETashok.aspx" target="_blank">Plot Details Arazi wise(Registry) </a></li>
                 
			
			 
            </ul>
        </li>
                <li><a>Details</a>
         <ul>
			
			
                <li><a href="../home/Detail.aspx" target="_blank">Month wise paid installment</a></li>
                <li><a href="../home/customerdetails.aspx" target="_blank">Customer Payment Deatils </a></li>
			   <li><a href="../home/chequesms1.aspx" target="_blank">Cheque Entry</a></li>
			 
                
            </ul>
        </li>
		
		
		<li><a href="../home/sms/sms.aspx" target="_blank">Send SMS</a></li>
		<li><a href="../home/userchequepaid.aspx" target="_blank">A/C PAYMENT</a></li>
		
			
		
    </ul>
    <form runat=server>
    <div><p>
        <strong>WELCOME : -</strong>  <asp:label ID="Label1" runat="server" 
            text="Label" ForeColor="Maroon" Font-Bold="True" Font-Size="Medium"></asp:label>
</p>
		
		<table style="height:60%;width:100%;margin-top:0%;">
		<tr> <td><a href="../map2/174MI/174MI.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 174MI map</p></a></td>
    <td><a href="../map2/506MAP/506MAP.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 506 map</p></a></td>
			<td><a href="../map2/161GHA/arazi161gha.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 161GHA map</p></a></td>
    
		
		</tr>
		<tr>
		<td><a href="../arazi372KAmap/372kamap.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 372KA map</p></a></td>
			     <td><a href="../arazi385KA/arazi385ka.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 385KA map</p></a></td>
           <td><a href="../arazi137/arazi137map.aspx" target="_blank" style="text-decoration:none;color:black;"><p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 137 map</p></a></td> 
			
		</tr>
    <tr>
    <td><a href="../map/map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;margin-top:0%;font-size:15px;font-weight:bold;text-align:center;">Arazi 152 map</p></a></td>
    <td><a href="../map2/375KA.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;text-align:center;">Arazi 375KA map</p></a></td>
    <td><a href="../map2/30,31/30,31map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;text-align:center;">Arazi 30,31 map</p></a></td>
   
    </tr>
    <tr>
    <td><a href="../map2/436MAP/436MAP.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 436 map</p></a></td>
    <td><a href="../map2/1412MAP/1412MAP.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1412 map</p></a></td>
    <td><a href="../map2/1989/newlovekush.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1989 map</p></a></td>
    
    </tr>
    <tr>
    <td><a href="../30neeghanew/30beeghanewsite.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 161 part 2 map</p></a></td>
      <td><a href="../arazi2011map/map2011.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 2011 map</p></a></td>
      
		  <td><a href="../arazi186map/arazi186map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 186 MI map</p></a></td>
     
    </tr>
		 <tr>
    <td><a href="../arazi254map/arazi254.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 254 map</p></a></td>
      <td><a href="../arazi1414/arazi1414.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1414</p></a></td>
      
		  <td><a href="../arazi2001GA/arazi2001ga.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 2001GA</p></a></td>
     
    </tr>
			 <tr>
    <td><a href="../arazi1452/arazi1452map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1452 map</p></a></td>
      <td><a href="../arazi357/arazi357.aspx"target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 357 map</p></a></td>
      
		  <td><a  href="../arazi217/arazi217.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 217 map</p></a></td>
     
    </tr>
			 <tr>
    <td><a href="../arazi187kha/arazi187kha.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 187KHA map</p></a></td>
     <td><a href="../arazi320/arazi320map.aspx" target="_blank" style="text-decoration:none;color:black;"><p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 320 map</p></a></td> 
      
		      <td><a href="../arazi353/arazi353.aspx" target="_blank" style="text-decoration:none;color:black;"><p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 353 map</p></a></td> 
     
    </tr>
			<tr>
    <td><a href="../arazi419/arazi419.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 419 map</p></a></td>
     <td><a href="../arazi340/arazi340.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 340 map</p></a></td> 
      
		     <td><a  href="../ARAZI308/arazi308map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 308 map</p></a></td>
     
    </tr>
			<tr>
    <td><a href="../arazi1731/arazi1731map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 1731 map</p></a></td>
     <td><a href="../arazi190/arazi190.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 190</p></a></td> 
      
		     <td><a href="../arazi179/arazi179map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 179</p></a></td>
     
    </tr>
			<tr>
    <td><a href="../arazi343/Arazimap343.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 343 imlipur map</p></a></td>
     <td><a href="../JDBHATTA/JDBHATTA.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">JD BHATTA MAP</p></a></td> 
      
		     <td><a href="../arazi397/arazi397.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 397 Map</p></a></td>
     
    </tr>
		<tr>
    <td><a href="../arazi156/Arazi156map.aspx" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Arazi 156 map</p></a></td>
     <td><a href="#" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">soon</p></a></td> 
      
		     <td><a href="#" target="_blank" style="text-decoration:none;color:black;">	<p style="padding:5px;background-color:yellow;width:50%;font-size:15px;font-weight:bold;margin-top:0%;text-align:center;">Coming Soon</p></a></td>
     
    </tr>	
			
    </table>
	
	
		
	
	
		
		
		
		
		
		
		
		
		
				
		
		
		
		

		 </div></form>
</div>
