using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class NewFolder1_fun : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection(s);
         con1.Open();
         SqlDataAdapter da = new SqlDataAdapter("select  SUBSTRING(DUDATE,0,3),SUBSTRING(DUDATE,4,2),SUBSTRING(DUDATE,7,4) from recipt1", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
        int i;
        con1.Close();
        con1.Open();
         string s2="";
        if(ds.Tables[0].Rows.Count>0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                s2 = ds.Tables[0].Rows[i][1].ToString() + "/" + ds.Tables[0].Rows[i][0].ToString()+"/"+ ds.Tables[0].Rows[i][2].ToString() ;
                s2 = "" + s2;
               
              

           }
          }
           
    }
}