using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class printreg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       Label1.Text= Session["creg"].ToString();
       Label3.Text= Session["dateofcom"].ToString();
        Label4.Text=Session["plan"].ToString();
       Label5.Text= Session["mod"].ToString();
       Label6.Text= Session["consamt"].ToString();
       Label7.Text= Session["instpay"].ToString();
       Label8.Text= Session["subduedate"].ToString();
       Label9.Text= Session["exppay"].ToString();
       Label10.Text= Session["dateoflast"].ToString();
       Label11.Text= Session["expirydate"].ToString();
       Label12.Text= Session["agency"].ToString();
       Label13.Text = Session["namedbad"].ToString();
       Label14.Text = Session["appno"].ToString();
       Label15.Text = Session["plotsize"].ToString();
       Label16.Text = Session["nominee"].ToString();
       Label18.Text = Session["reciptno"].ToString();
       Label20.Text = Session["amountword"].ToString();
       Label19.Text = Session["name2nominee"].ToString();
       Label17.Text = Session["espr"].ToString();
       Label21.Text = Session["idcard"].ToString();
    }
}