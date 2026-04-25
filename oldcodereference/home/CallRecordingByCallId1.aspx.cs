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
        fillGrid();
    }

    private void fillGrid()
    {
        try
        {
            string query = @"SELECT caller_id, duration, call_duration, 
'https://ctv1.sarv.com/telephony/0/voice/streamRecording/59214019'+replace(recording_data,'/','*') AS recording_data, 
CASE WHEN CAST(status AS VARCHAR(20)) = '3' THEN 'Both Answered' ELSE CAST(status AS VARCHAR(20)) END AS call_status  
FROM amar.callerinfo ";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = query;
          //  cmd.Parameters.AddWithValue("@tab_status", "Valid");
           // cmd.Parameters.AddWithValue("@caller_id", callId);
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