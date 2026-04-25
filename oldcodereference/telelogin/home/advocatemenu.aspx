<%@ Page Language="C#" AutoEventWireup="true" CodeFile="advocatemenu.aspx.cs" Inherits="dialer_advocatemenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height:600px
        }
        .auto-style2 {
            text-align: center;
            font-size: x-large;
            height: 42px;
            color: #FFFFFF;
        }
        .auto-style3 {
            text-align: center;
            color: #FFFFFF;
        }
        .auto-style4 {
            height: 9px;
        }
        .auto-style5 {
            height: 447px;
        }
        .auto-style8  {
            text-decoration: none;
         
          
        }
        #dr {
            width:100%;
            height:100%;
        }
        .rt td{
           
            height:50px;
            width:25%;
        }
            .rt td a {
                padding:10px 40px;
                width:100%;
                background-color:black;
                color:white;
            }
            .rt td a:hover {
                padding:10px 40px;
                width:100%;
                background-color:yellow;
                color:red;
            }
        
        .auto-style9 {
            text-align: center;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color:bisque;width:60%;height:600px;margin-left:20%;box-shadow:0px 0px 10px black;">
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" style="background-color: #800000"><strong>HEED REAL ESTATE PRIVATE LIMITED</strong></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <table id="dr" class="rt">
                        <tr>
                            <td class="auto-style9" ><a href="advocatepaymentragistry.aspx" target="_blank" class="auto-style8"><strong>Ragistry Payment Details</strong></a></td>
                           <td class="auto-style9"><a href="avocatecustomersdetails.aspx" target="_blank" class="auto-style8"><strong>Customer Deed PDF</strong></a></td>
                           <td class="auto-style9"><a href="#" target="_blank" class="auto-style8"><strong>Test2</strong></a></td>
                        
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style3" style="background-color: #333333"><strong>copyright@ heedknp&nbsp;</strong></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
