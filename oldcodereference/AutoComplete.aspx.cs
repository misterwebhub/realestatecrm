using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;
 
public partial class AutoComplete : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
 
    }
    [WebMethod]
    public static List<string> GetAutoCompleteData(string username)
    {
        string s3 = ConfigurationManager.ConnectionStrings["amar1"].ConnectionString.ToString();
        List<string>result = new List<string>();
 
        using (SqlConnection con = new SqlConnection(s3))
        {

            SqlCommand cmd = new SqlCommand("select CUSTREGNO from wjstar1.recipt1 where CUSTREGNO like '" + username + "%'", con);
               con.Open();
              // cmd.Parameters.AddWithValue("@SearchText", username);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
               {
                   result.Add(dr["Name"].ToString());
               }
                return result;
            
        }
    }
}