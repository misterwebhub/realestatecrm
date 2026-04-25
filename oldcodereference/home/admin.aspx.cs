
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;

public partial class admin : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["ID"].ToString(); 
		//Label1.Text=Server.HtmlEncode(Request.Cookies["ID"].Value);
		//Label1.Text =Request.QueryString["val1"].ToString();
		//Response.Cookies.Add(new HttpCookie("ID",Label1.Text));
		
       
        if (!IsPostBack)
        {
            PopulateData();
			Populate();
        }
    }
	public void Populate()
    {
     SqlConnection con1 = new SqlConnection(s);
            con1.Open();
		SqlDataAdapter da = new SqlDataAdapter("SELECT sum(CAMOUNT)  FROM chequedetails where STATUS='UNPAID' AND CHEQUETYPE='MENTION' AND ID NOT IN(SELECT ID from chequedetails where CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND BSTATUS='BOUNCE')", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
		con1.Close();
		con1.Open();
		 DateTime dt = DateTime.Now;
		SqlDataAdapter da11 = new SqlDataAdapter("SELECT sum(CAMOUNT)  FROM chequedetails where STATUS='PAID' AND CHEQUETYPE='MENTION' AND month(paiddate)='"+dt.Month+"' AND year(paiddate)='"+dt.Year+"' ", con1);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
		con1.Close();
		con1.Open();
		 
		SqlDataAdapter da22 = new SqlDataAdapter("SELECT sum(CAMOUNT)  FROM chequedetails where STATUS='PAID' AND CHEQUETYPE='MENTION' AND paiddate='"+DateTime.Now+"' ", con1);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
		con1.Close();
		if (ds.Tables[0].Rows.Count > 0)
            {
                if(ds.Tables[0].Rows[0][0].ToString()!="")
				{
					
					string str=ds.Tables[0].Rows[0][0].ToString();
					string le=str.Substring(0,3);
					 Label11.Text=le;
					int sty=str.Length-3;
					
					string lef=str.Substring(3,sty);

					//string re=right(str.Length);
				 Label12.Text=", "+ lef;
				}
			else
			{
				 Label11.Text="";
			}
            }
            else
            {
               Label11.Text="";
            }
		if (ds11.Tables[0].Rows.Count > 0)
            {
                if(ds11.Tables[0].Rows[0][0].ToString()!="")
				{
					
					string str=ds11.Tables[0].Rows[0][0].ToString();
					
					//string re=right(str.Length);
					// Label13.Text=str;
				}
			else
			{
				// Label13.Text="0";
			}
            }
            else
            {
              // Label13.Text="0";
            }
		if (ds22.Tables[0].Rows.Count > 0)
            {
                if(ds22.Tables[0].Rows[0][0].ToString()!="")
				{
					
					string str=ds22.Tables[0].Rows[0][0].ToString();
					
					//string re=right(str.Length);
				//	 Label14.Text=str;
				}
			else
			{
				// Label14.Text="0";
			}
            }
            else
            {
              // Label14.Text="0";
            }
		
	}
    public override void VerifyRenderingInServerForm(Control control)
    {
        // this is required for avoid error (control must be placed inside form tag)
    }
    public void PopulateData()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
DateTime dt = DateTime.Now;
		int i=dt.Month;
		int y=dt.Year;

			
            SqlDataAdapter da = new SqlDataAdapter("Select c.CUSTREGNO,c.NAME,c.ARAZI,c.PLOTNO,c.PLOTSIZE,c.CDATE,c.CHEQUENO,c.CAMOUNT,c.CHEQUETYPE,c.STATUS,u.CHECKBY from chequedetails AS c INNER JOIN wjstar1.customerreg1 AS u ON u.CUSTREGNO=c.CUSTREGNO where C.ID NOT IN(SELECT ID from chequedetails where CHEQUETYPE='MENTION' AND STATUS='UNPAID' AND BSTATUS='BOUNCE') AND c.STATUS='UNPAID' AND month(CDATE)=" + i + " AND year(CDATE)=" + y + " ORDER BY c.CDATE ASC ", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();



            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception ty)
        {
            Label1.Text = "Internal Error Found" + ty;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string f = e.Row.Cells[8].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "MENTION")
                {
                    e.Row.Cells[8].ForeColor = Color.Red;
                }


            }
        }
    }
}