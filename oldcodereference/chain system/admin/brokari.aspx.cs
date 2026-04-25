﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Globalization;
using System.Drawing;

public partial class admin_salary : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar9"].ConnectionString.ToString();
    static string id;
    public static double perc = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            Panel1.Visible =false;
        }
    }
    public void bind()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select formid,CONCAT(formid,'-->',name) as demo from agent", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataTextField = "demo";
        DropDownList1.DataValueField = "formid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    public void demo()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select c.formid AS 'BOOKID',c.name AS 'NAME',c.location AS 'LOCATION',c.block AS 'BLOCK',c.plotno AS 'PLOTNO',c.area AS 'SIZE',c.totalamount AS 'PLOT VALUE',c.plc AS 'PLC(%)',c.discount*c.area AS 'DISCOUNT(Rs)',floor(((c.totalamount*c.plc)/100)+c.totalamount-(c.discount*c.area)) AS  'NET AMOUNT' ,r.PAID,c.totalamount+((c.totalamount*c.plc)/100)-(c.discount*c.area)-r.PAID AS 'BALANCE',c.agentid AS 'AGENT ID' from (select formid,sum(paid) AS PAID from bookrecipt  GROUP BY formid) AS r inner join booking AS c  on r.formid=c.formid where c.agentid='" + DropDownList1.SelectedValue.ToString() + "' AND c.secondstatus IN('Book','Hold')" , con);


        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select floor(((c.totalamount*c.plc)/100))+c.totalamount as 'FINAL AMOUNT',((((c.totalamount*c.plc)/100)+c.totalamount)/c.area) as 'RATE',c.discount,((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount AS 'NET RATE' ,r.PAID,r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount) AS 'SOLD GZ',r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount AS 'SOLD DISC AMT',floor((r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount)+r.PAID) AS 'NET PAID'  from (select formid,sum(paid) AS PAID from bookrecipt  GROUP BY formid) AS r inner join booking AS c  on r.formid=c.formid where c.agentid='" + DropDownList1.SelectedValue.ToString() + "' AND c.secondstatus IN('Book','Hold')", con);


        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount) AS 'SOLD DISC AMT',sum(floor((r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount)+r.PAID)) AS 'NET PAID'  from (select formid,sum(paid) AS PAID from bookrecipt  GROUP BY formid) AS r inner join booking AS c  on r.formid=c.formid where c.agentid='" + DropDownList1.SelectedValue.ToString() + "' AND c.secondstatus IN('Book','Hold')", con);


        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();


       
        con.Close();
       
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        fun();
        Double total = 0, dis = 0;
        if (ds2.Tables[0].Rows.Count > 0)
        {
            if (ds2.Tables[0].Rows[0][1].ToString() != "")
            {
                total = Convert.ToDouble(ds2.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                total = 0;
            }
            if (ds2.Tables[0].Rows[0][0].ToString() != "")
            {
                dis = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                dis = 0;
            }
        }
        else
        {
            total = 0;
            dis = 0;

        }
        Double beforebr = (total * perc) / 100;
        Label1.Text = total.ToString();
        Label2.Text = dis.ToString();
        Double afterbr = beforebr - dis;
        Label4.Text = beforebr.ToString();
        Label3.Text = afterbr.ToString();
        divide(afterbr);
    }
    public void fun()
    {
        perc = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("WITH demo AS (SELECT  formid,agentid,agentper,0 as lvl  from agent WHERE formid ='" + DropDownList1.SelectedValue.ToString() + "' UNION ALL SELECT t.formid,t.agentid,t.agentper,c.lvl+1 FROM demo c JOIN agent t ON c.agentid =  t.formid ) SELECT formid AS 'PARANTS',agentper FROM  demo order by lvl DESC", con);  


        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView2.DataSource = ds;
        GridView2.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][1].ToString() != "")
            {
                perc = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
            }
            else
            {
                perc = 0;
            }
        }

    }
    public void divide(Double afterbr)
    {
        Double unit = afterbr / perc;
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("PARANT_Id", typeof(string)),
                            new DataColumn("AGENT(%)", typeof(int)),
                            new DataColumn("Brokari",typeof(float)) });
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("WITH demo AS (SELECT  formid,agentid,agentper,0 as lvl  from agent WHERE formid ='" + DropDownList1.SelectedValue.ToString() + "' UNION ALL SELECT t.formid,t.agentid,t.agentper,c.lvl+1 FROM demo c JOIN agent t ON c.agentid =  t.formid ) SELECT formid AS 'PARANTS',agentper AS 'AGENT (%)' FROM  demo order by lvl DESC", con);


        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Double percn = 0,p8=0;
            string id = "";
            DataRow dr = dt.NewRow();
            dr = null;
            for (int w  =ds.Tables[0].Rows.Count-1; w >=0 ; w--)
            {
                dr = dt.NewRow();
                if (w ==Convert.ToInt32(ds.Tables[0].Rows.Count-1))
                {
                    if (ds.Tables[0].Rows[w][0].ToString() != "")
                    {
                       id =ds.Tables[0].Rows[w][0].ToString();
                    }
                    else
                    {
                        id = null;
                    }
                    if (ds.Tables[0].Rows[w][1].ToString() != "")
                    {
                        percn = Convert.ToDouble(ds.Tables[0].Rows[w][1].ToString());
                    }
                    else
                    {
                        percn =0;
                    }
                    dr["PARANT_Id"] = id;
                    dr["AGENT(%)"] = percn;
                    dr["Brokari"] = unit * percn;
                    dt.Rows.Add(dr);
                }
                else
                {
                    if (ds.Tables[0].Rows[w][0].ToString() != "")
                    {
                        id = ds.Tables[0].Rows[w][0].ToString();
                    }
                    else
                    {
                        id = null;
                    }
                    if (ds.Tables[0].Rows[w][1].ToString() != "")
                    {
                        Double p1 = 0,p2=0;
                        p1 = Convert.ToDouble(ds.Tables[0].Rows[w][1].ToString());
                        p8 = p1;
                        p2 = Convert.ToDouble(ds.Tables[0].Rows[w+1][1].ToString());
                        percn=p1 - p2;
                    }
                    else
                    {
                        percn = 0;
                    }
                    dr["PARANT_Id"] = id;
                    dr["AGENT(%)"] = p8;
                    dr["Brokari"] = unit * percn;
                    dt.Rows.Add(dr);
                }
            }
        }
        if (dt.Rows.Count > 0)
        {
            GridView4.DataSource = dt;
            GridView4.DataBind();
        }
        else
        {
            GridView4.DataSource = null;
            GridView4.DataBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        demo();
        show();
    }
    public void show()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select bookagentid AS 'Agent ID',	walletamount AS 'Wallet Amount' from agentwallet where walletagentid='" + DropDownList1.SelectedValue.ToString() + "'", con);


        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(CAST(walletamount AS Decimal(12,0))) from agentwallet where walletagentid='" + DropDownList1.SelectedValue.ToString() + "'", con);


        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Double brokari = 0,paid=0;
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select sum(amount) from brokari where agentid='" + DropDownList1.SelectedValue.ToString() + "'", con);


        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da3 = new SqlDataAdapter("select id,date, mode,amount,remark  from brokari where agentid='" + DropDownList1.SelectedValue.ToString() + "'", con);


        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        con.Close();
        if (ds3.Tables[0].Rows.Count > 0)
        {
            GridView6.DataSource = ds3;
            GridView6.DataBind();
        }
        else
        {
            GridView6.DataSource = null;
            GridView6.DataBind();
        }
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0][0].ToString() != "")
            {

                brokari = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                paid = 0;
            }
           
        }
        else
        {
            brokari = 0;
        }
        if (ds2.Tables[0].Rows.Count > 0)
        {

            if (ds2.Tables[0].Rows[0][0].ToString()!="" )
            {

                paid = Convert.ToDouble(ds2.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                paid = 0;
            }
        }
        else
        {
            paid = 0;
        }
        Double bal = brokari - paid;
        Label9.Text = brokari.ToString("N0");
        Label10.Text = paid.ToString("N0");
        Label6.Text = bal.ToString("N0");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView5.DataSource = ds;
            GridView5.DataBind();
        }
        else
        {
            GridView5.DataSource =null;
            GridView5.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        string s2 = TextBox1.Text;
        string dd = s2.Substring(0, 2);
        string mm = s2.Substring(3, 2);
        string yy = s2.Substring(6, 4);
       string date1 = mm + "/" + dd + "/" + yy;
       SqlCommand cmd = new SqlCommand("insert into brokari(agentid,date,mode,amount,remark)values('" + DropDownList1.SelectedValue.ToString() + "','"+date1+"','"+DropDownList2.Text+"',"+TextBox2.Text+",'"+TextBox3.Text+"')", con);
       cmd.ExecuteNonQuery();
       con.Close();
       string message = "Record Added Successfully";
       System.Text.StringBuilder sb = new System.Text.StringBuilder();
       sb.Append("<script type = 'text/javascript'>");
       sb.Append("window.onload=function(){");
       sb.Append("alert('");
       sb.Append(message);
       sb.Append("')};");
       sb.Append("</script>");
       ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
       TextBox2.Text = "";
       TextBox3.Text = "";
       show();
    }
    protected void GridView6_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView6.Rows[e.RowIndex];
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete FROM brokari where id=" + Convert.ToInt32(GridView6.DataKeys[e.RowIndex].Value.ToString()) + "", con);
        cmd.ExecuteNonQuery();
        con.Close();
        show();  
    }
}