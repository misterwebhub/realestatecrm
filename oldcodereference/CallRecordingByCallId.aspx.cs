using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class CallRecordingByCallId : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["amar"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["callId"] != null && Request.QueryString["callId"].ToString() != "")
        {
            fillGrid(Request.QueryString["callId"].ToString());
        }
		if (Request.QueryString["CUSTREGNO"] != null && Request.QueryString["CUSTREGNO"].ToString() != "")
        {
           // Label1.Text=Request.QueryString["CUSTREGNO"].ToString();
        }
		if (Request.QueryString["NAME"] != null && Request.QueryString["NAME"].ToString() != "")
        {
           //Label2.Text=Request.QueryString["NAME"].ToString();
        }
    }

    private void fillGrid(string callId)
    {
        try
        {
            string query = @"SELECT caller_id, duration, call_duration, 
'https://ctv1.sarv.com/telephony/0/voice/streamRecording/59214019'+replace(recording_data,'/','*') AS recording_data, 
CASE WHEN CAST(status AS VARCHAR(20)) = '3' THEN 'Both Answered' ELSE CAST(status AS VARCHAR(20)) END AS call_status  
FROM amar.callerinfo WHERE tab_status = @tab_status AND caller_id = @caller_id; ";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@tab_status", "Valid");
            cmd.Parameters.AddWithValue("@caller_id", callId);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            grd_call_recording_by_call_id.DataSource = dt;
            grd_call_recording_by_call_id.DataBind();

        }
        catch (Exception ex)
        {
            cn.Close();
            throw;
        }
    }

}