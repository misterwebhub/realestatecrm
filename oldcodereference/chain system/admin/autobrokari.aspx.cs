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
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                else
                {
                    demo(ds.Tables[0].Rows[i][0].ToString());
                }
            }
        }

    }
    public void demo(string ID1)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select c.formid AS 'BOOKID',c.name AS 'NAME',c.location AS 'LOCATION',c.block AS 'BLOCK',c.plotno AS 'PLOTNO',c.area AS 'SIZE',c.totalamount AS 'PLOT VALUE',c.plc AS 'PLC(%)',c.discount*c.area AS 'DISCOUNT(Rs)',floor(((c.totalamount*c.plc)/100)+c.totalamount-(c.discount*c.area)) AS  'NET AMOUNT' ,r.PAID,c.totalamount+((c.totalamount*c.plc)/100)-(c.discount*c.area)-r.PAID AS 'BALANCE',c.agentid AS 'AGENT ID' from (select formid,sum(paid) AS PAID from bookrecipt  GROUP BY formid) AS r inner join booking AS c  on r.formid=c.formid where c.agentid='" +ID1 + "'", con);


        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        GridView3.DataSource = ds;
        GridView3.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select floor(((c.totalamount*c.plc)/100))+c.totalamount as 'Finalamount',((((c.totalamount*c.plc)/100)+c.totalamount)/c.area) as 'Rate',c.discount,((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount AS 'net rate' ,r.PAID,r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount) AS 'SOLD GZ',r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount AS 'SOLD DISC AMT',floor((r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount)+r.PAID) AS 'NET PAID'  from (select formid,sum(paid) AS PAID from bookrecipt  GROUP BY formid) AS r inner join booking AS c  on r.formid=c.formid where c.agentid='" + ID1 + "'", con);


            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select sum(r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount) AS 'SOLD DISC AMT',sum(floor((r.PAID/(((((c.totalamount*c.plc)/100)+c.totalamount)/c.area)-c.discount)*c.discount)+r.PAID)) AS 'NET PAID'  from (select formid,sum(paid) AS PAID from bookrecipt  GROUP BY formid) AS r inner join booking AS c  on r.formid=c.formid where c.agentid='" + ID1 + "'", con);


            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();



            con.Close();

            GridView1.DataSource = ds1;
            GridView1.DataBind();
            fun(ID1);
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
            divide(afterbr, ID1);
        }
        
    }
    public void fun(String ID1)
    {
        perc = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("WITH demo AS (SELECT  formid,agentid,agentper,0 as lvl  from agent WHERE formid ='" +ID1+ "' UNION ALL SELECT t.formid,t.agentid,t.agentper,c.lvl+1 FROM demo c JOIN agent t ON c.agentid =  t.formid ) SELECT formid AS 'PARANTS',agentper FROM  demo order by lvl DESC", con);  


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
    public void divide(Double afterbr, String ID1)
    {
        Double unit = afterbr / perc;
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("PARANT_Id", typeof(string)),
                            new DataColumn("AGENT(%)", typeof(int)),
                            new DataColumn("Brokari",typeof(float)) });
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("WITH demo AS (SELECT  formid,agentid,agentper,0 as lvl  from agent WHERE formid ='" + ID1 + "' UNION ALL SELECT t.formid,t.agentid,t.agentper,c.lvl+1 FROM demo c JOIN agent t ON c.agentid =  t.formid ) SELECT formid AS 'PARANTS',agentper FROM  demo order by lvl DESC", con);


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
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();
            SqlCommand cmd,cmd1;
            cmd1 = new SqlCommand("DELETE FROM agentwallet WHERE EXISTS(select bookagentid from agentwallet where bookagentid='" + ID1 + "')", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();

            
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                con1.Open();
                cmd = new SqlCommand("insert into agentwallet (bookagentid,walletagentid,walletamount)values('" + ID1 + "','" + dt.Rows[r][0].ToString() + "','" + dt.Rows[r][2].ToString() + "')",con1);
                cmd.ExecuteNonQuery();
                con1.Close();
            }
        }
        else
        {
            GridView4.DataSource = null;
            GridView4.DataBind();
        }

    }
    
}