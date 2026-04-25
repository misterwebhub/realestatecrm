<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cheque.aspx.cs" Inherits="broker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html>
<html>
<head>
<title>Cheque Details</title>
 <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".d").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
<link rel="stylesheet" href="css/bootstrap.min.css" type="text/css"/>
<style type="text/css">
    body
    {
        background-image:url("images/gd.jpg");
        background-size:cover;
    }
.wrrper{
width:90%;
margin:0 auto;
height:auto;
border:5px solid #2ECC71;
}
table {
    border-collapse: collapse;
	}

table, td, th {
    border: 1px solid black;	
	text-align:center;
}

th{
padding :5px;
background-color:Maroon;
color:White;
}
td
{
    padding:5px;
}


    .style1
    {
        width: 100%;
    }
    .style2
    {
        color: #FFFFFF;
        font-size: larger;
        font-weight: 700;
        text-align: center;
    }


    .style3
    {
        width: 228px;
    }
    .style4
    {
        width: 139px;
    }
    .style5
    {
        color: #FFFFFF;
        font-size: larger;
        font-weight: 700;
        text-align: center;
        width: 123px;
    }
    .style6
    {
        width: 123px;
    }


    </style>
</head>
<body>
	<form id="Form1" runat="server">
		
<div class="wrrper">

    <table class="style1">
        <tr>
            <td bgcolor="#2ECC71" class="style2" colspan="6">
                CHEQUE ENTRY</td>
        </tr>
        <tr>
            <td bgcolor="#FFFF66">
                Arazi No</td>
            <td class="style6" bgcolor="#FFFF66">
                Kishan Name </td>
            <td class="style4" bgcolor="#FFFF66">
                Kishan Id</td>
            <td bgcolor="#FFFF66">
                Kishan Aadhar Card</td>
            <td class="style3" bgcolor="#FFFF66">
                Bank Name</td>
            <td bgcolor="#FFFF66">
                Cheque No.</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="104px" 
                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style6">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="26px" Width="124px">
                </asp:DropDownList>
            </td>
            <td class="style4">
                <asp:TextBox ID="TextBox1" runat="server" Width="87px" ></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server" Width="149px" ></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox2" runat="server" Width="138px" ></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="112px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFF66">
                Amount</td>
            <td class="style6" bgcolor="#FFFF66">
                Customer Name</td>
            <td class="style4" bgcolor="#FFFF66">
                Status</td>
            <td bgcolor="#FFFF66">
                Cheque Date
            </td>
            <td class="style3" bgcolor="#FFFF66">
                Current date</td>
            <td rowspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Width="106px"></asp:TextBox>
            </td>
            <td class="style6">
                <asp:TextBox ID="TextBox6" runat="server" Width="121px"></asp:TextBox>
            </td>
            <td class="style4">
                <asp:TextBox ID="TextBox10" runat="server" ReadOnly="True" Width="89px">unpaid</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="126px" class="d"></asp:TextBox>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBox11" runat="server" Width="125px" class="d"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFF66" colspan="2">
                Cheque Photo</td>
            <td class="style4" rowspan="2">
                <asp:Image ID="Image1" runat="server" Height="99px" Width="87px" />
            </td>
            <td colspan="3" bgcolor="#FFFF66">
                Reason&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="180px" />
            </td>
            <td class="style6">
                <asp:Button ID="Button2" runat="server" style="font-weight: 700" Text="Upload" 
                    Width="90px" onclick="Button2_Click" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="TextBox7" runat="server" Height="63px" TextMode="MultiLine" 
                    Width="323px"></asp:TextBox>
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" style="font-weight: 700" 
                    Text="Add Details" Width="122px" onclick="Button1_Click" />
                </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="6">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                <asp:BoundField HeaderText="Arazi No" DataField="arazino" />
                <asp:BoundField HeaderText="Kiashan Name" DataField="name" />
                 <asp:BoundField HeaderText="Kishan Id" DataField="kid" />
                  <asp:BoundField HeaderText="Adhar No" DataField="adhar" />
                   <asp:BoundField HeaderText="Bank Name" DataField="bname" />
                    <asp:BoundField HeaderText="Cheque No" DataField="chequeno" />
                     <asp:BoundField HeaderText="Amount" DataField="amount" />
                      <asp:BoundField HeaderText="Customer Name" DataField="customername" />
                       <asp:BoundField HeaderText="Status" DataField="status" />
                                <asp:BoundField HeaderText="Cheque Date" DataField="chequedate" />
                                         <asp:BoundField HeaderText="Current Date" DataField="cdate" />
                                         <asp:ImageField HeaderText="Cheque Photo" DataImageUrlField="cphoto">
                                             <ControlStyle Height="100px" Width="150px" />
                                             <ItemStyle Height="80px" Width="150px" />
                    </asp:ImageField>
                                          <asp:BoundField HeaderText="Reason" DataField="reason" />

                </Columns>
                </asp:GridView>
            </td>
        </tr>

    </table>

</div>
</form>
</body>
</html>
