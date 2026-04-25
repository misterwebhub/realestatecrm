using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Script.Serialization;

public partial class CallReport : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["amar"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MyWebHookEndpoint();
            Response.Write("\"GODBLESSYOU\"");
        }
    }

    private void MyWebHookEndpoint()
    {
        try
        {
            using (StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                var jsonSerializer = new JavaScriptSerializer();
                var jsonString = string.Empty;
                var body = reader.ReadToEnd();
                var urlString = body.Replace("push_report=", "");
                var output = HttpUtility.UrlDecode(urlString);
                var data = jsonSerializer.Deserialize<Root>(output);
                if (data == null)
                {
                    return;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO amar.callerinfo ([date], caller_id, recording_data, duration, status, node_id, visit_id, recording_time, json_format, tab_status, call_duration) 
            VALUES (@date, @caller_id, @recording_data, @duration, @status, @node_id, @visit_id, @recording_time, @json_format, @tab_status, @call_duration);";
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@caller_id", data.callId ?? null);
                cmd.Parameters.AddWithValue("@recording_data", data.recordings[0].file ?? null);
                cmd.Parameters.AddWithValue("@duration", data.talkDuration);
                cmd.Parameters.AddWithValue("@status", data.callStatus);
                cmd.Parameters.AddWithValue("@node_id", data.recordings[0].nodeid ?? null);
                cmd.Parameters.AddWithValue("@visit_id", data.recordings[0].visitId ?? null);
                cmd.Parameters.AddWithValue("@recording_time", data.recordings[0].time ?? null);
                cmd.Parameters.AddWithValue("@json_format", body);
                cmd.Parameters.AddWithValue("@tab_status", "Valid");
                cmd.Parameters.AddWithValue("@call_duration", data.lastFirstDuration);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            cn.Close();
            //set_error_deatails(cn, ex.Message);
        }
    }

    private void set_error_deatails(SqlConnection cn, string error)
    {
        string chck = "";
        if (cn.State == ConnectionState.Closed)
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["amar"].ConnectionString);
            cn.Open();
        }
        else
        {
            chck = "O";
        }
        string query = "insert into set_error(tran_date, res) VALUES (@tran_date, @msg)";
        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.AddWithValue("@tran_date", DateTime.Now);
        cmd.Parameters.AddWithValue("@msg", error);
        cmd.ExecuteNonQuery();
        if (chck != "O")
        {
            cn.Close();
        }
    }

    private void ErrorLogFile(string body)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: -> ", body);
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = HttpContext.Current.Server.MapPath("~/ErrorLog/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    private class ApiPara
    {
        public string userId { get; set; }
        public string fromType { get; set; }
        public string from { get; set; }
        public string toType { get; set; }
        public string to { get; set; }
    }

    private class NHDetail
    {
        public string CTC { get; set; }
        public string status { get; set; }
        public string recording { get; set; }
        public string ping { get; set; }
        public string number { get; set; }
        public string visitId { get; set; }
        public string nodeId { get; set; }
        public int totalRingDuration { get; set; }
        public int totalHoldDuration { get; set; }
        public int talkDuration { get; set; }
        public string talkSTime { get; set; }
        public string talkETime { get; set; }
        public string answerSTime { get; set; }
        public string answerETime { get; set; }
        public int answerDuration { get; set; }
        public string cli { get; set; }
        public int retry { get; set; }
    }

    private class Recording
    {
        public string nodeid { get; set; }
        public string visitId { get; set; }
        public string file { get; set; }
        public string time { get; set; }
    }

    private class Root
    {
        public ApiPara api_para { get; set; }
        public object did { get; set; }
        public string cType { get; set; }
        public int campId { get; set; }
        public string ivrSTime { get; set; }
        public string ivrETime { get; set; }
        public int ivrDuration { get; set; }
        public string userId { get; set; }
        public string cNumber { get; set; }
        public string masterNumCTC { get; set; }
        public string masterAgent { get; set; }
        public string masterAgentNumber { get; set; }
        public int masterGroupId { get; set; }
        public int talkDuration { get; set; }
        public int agentOnCallDuration { get; set; }
        public string callId { get; set; }
        public string firstAttended { get; set; }
        public string firstAnswerTime { get; set; }
        public string lastHangupTime { get; set; }
        public int lastFirstDuration { get; set; }
        public object custAnswerSTime { get; set; }
        public object custAnswerETime { get; set; }
        public int custAnswerDuration { get; set; }
        public int callStatus { get; set; }
        public object ivrExecuteFlow { get; set; }
        public int HangupBySourceDetected { get; set; }
        public string forward { get; set; }
        public int totalHoldDuration { get; set; }
        public TotalCreditsUsed totalCreditsUsed { get; set; }
        public List<object> ivrIdArr { get; set; }
        public List<object> aAnsH { get; set; }
        public List<object> aH { get; set; }
        public List<string> nH { get; set; }
        public List<Recording> recordings { get; set; }
        public List<object> voiceMail { get; set; }
        public List<object> cliArr { get; set; }
        public List<object> aHDetail { get; set; }
        public List<NHDetail> nHDetail { get; set; }
        public List<object> modules { get; set; }
        public string callDisposition { get; set; }
        public string callBack { get; set; }
    }

    private class TotalCreditsUsed
    {
        public int freeHit { get; set; }
        public int paidHit { get; set; }
        public int amount { get; set; }
    }


}