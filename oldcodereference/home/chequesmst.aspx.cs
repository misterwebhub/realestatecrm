using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;

public partial class home_chequesmst : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ddd2 = DateTime.Now.ToString("dd-mm-yyyy");
       // string format = "dd/mm/yyyy";
       // DateTime dateTime2 = DateTime.ParseExact(dateString2, format, CultureInfo.InvariantCulture);
       // string ddd2 = dateTime2.ToString("mm/dd/yyyy");
        SqlConnection con1 = new SqlConnection(s);

        con1.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select name,date,cheque,amount from remcheque", con1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        string n, d, ch, am, final;
        con1.Close();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                n = ds1.Tables[0].Rows[i][0].ToString();
                d = ds1.Tables[0].Rows[i][1].ToString();
                ch = ds1.Tables[0].Rows[i][2].ToString();
                am = ds1.Tables[0].Rows[i][3].ToString();
                if (d == ddd2)
                {
                    final = "Today you have a cheque Name= " + n + ", Date= " + d + ", cheque No= " + ch + ", Amount= " + am;
                    string f = "http://sms.webguard.in/api/sendhttp.php?authkey=330026AlOBgB2Z85ec8e185P1&mobiles=9129822343&message="+final+"&sender=HEEDKP&route=4&country=91";
                    Response.Redirect(f);
                }
            }
        }
    }
}