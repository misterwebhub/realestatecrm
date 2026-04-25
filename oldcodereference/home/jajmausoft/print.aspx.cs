using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
       // Label1.Text = Session["ref"].ToString();       
       Label2.Text= Session["creg"].ToString();
       Label3.Text= Session["ascname"].ToString();
       Label4.Text = Session["recipt"].ToString();
       Label5.Text = Session["asccode"].ToString();
       Label6.Text = Session["date"].ToString();
       Label7.Text = Session["dudate"].ToString();
     //  Label8.Text = Session["ndate"].ToString();
       Label12.Text = Session["instno"].ToString();
       Label13.Text = Session["endterm"].ToString();
      // Label10.Text = Session["ascaddr"].ToString();
      // Label9.Text = Session["planterm"].ToString();
      // Label11.Text = Session["mod"].ToString();
       Label14.Text = Session["amr"].ToString();
       Label16.Text = Session["expr"].ToString();
       Label17.Text = Session["subam"].ToString();
       Label18.Text = Session["latecharge"].ToString();
       Label15.Text = Session["assaddr"].ToString();
       Label19.Text = Session["amwrd"].ToString();
       Label20.Text = Session["book"].ToString();
      // Label21.Text= Session["tdp"].ToString();
      // Label8.Text = Session["tpdp"].ToString();
      // Label22.Text = Session["tbdp"].ToString();
      // Label23.Text = Session["rdp"].ToString();

      // Label24.Text = Session["rpdp"].ToString();
      // Label25.Text = Session["rbdp"].ToString();
       Label27.Text = Session["balrec"].ToString();
       Label26.Text = Session["chequebounce"].ToString();
      // Label28.Text = Session["chequeno"].ToString();


    }
}