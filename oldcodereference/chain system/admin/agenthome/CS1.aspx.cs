using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public static string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["ID"] != null)
            {

                id = Session["ID"].ToString();
                // bind2();

            }

            // bind2();



        }
    }
    [WebMethod]
    public static List<object> GetChartData()
    {

        string query = "WITH demo AS (SELECT  formid,name,agentid,0 as lvl  from agent WHERE formid ='" + id + "' UNION ALL SELECT t.formid,t.name,t.agentid,c.lvl+1 FROM demo c JOIN agent t ON c.agentid =  t.formid ) SELECT formid,name,agentid FROM  demo order by lvl DESC";
       // query += " FROM agent where agentid='CHK001'";
        string constr = ConfigurationManager.ConnectionStrings["amar"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                List<object> chartData = new List<object>();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                        {
                            sdr["formid"], sdr["name"]+"<br>"+sdr["formid"], sdr["agentid"]
                        });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }
}