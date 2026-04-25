﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Drawing;
using System.Globalization;

public partial class arazi357_callerauto : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> names = new List<string> { "heedrealestate", "Ashok8396", "MACHHARIYAOFFICE" };
            for (int i = 0; i < names.Count; i++)
        {
            // Get element at this index.
            string value = null;
                value=names[i];
            // Display with string interpolation.
            maintable(value);
               
        }
            check();
        }
    }
    public void maintable(string user)
    {
        DateTime start = DateTime.Today;
        DateTime end = DateTime.Today;
        int dd = start.Day;
        int dd1 = start.Day;
        int mm = start.Month;
        int yy = start.Year;
        DateTime d2 = start.AddDays(1);
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        SqlCommand cmd1 = new SqlCommand("INSERT INTO callerfeedback1 (CUSTREGNO,reason,date,feeddate,userid) select DISTINCT c.CUSTREGNO,'forword','" + start + "','" + d2 + "','" + user + "'  from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback1 where ID in(select MAX(ID) from callerfeedback1 where date between '" + start + "' AND '" + end + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date between '" + start + "' AND '" + end + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + user + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))  AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(SELECT CUSTREGNO FROM calldemo1 where date='" + start + "')", con1);
        cmd1.ExecuteNonQuery();
        con1.Close();
        con1.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO calldemo1 (CUSTREGNO,reason,date,feeddate,userid) select DISTINCT c.CUSTREGNO,'forword','" + start + "','" + d2 + "','" + user + "'  from wjstar1.customerreg1 c left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback1 where ID in(select MAX(ID) from callerfeedback1 where date between '" + start + "' AND '" + end + "'  group By CUSTREGNO)) as r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback1 where date between '" + start + "' AND '" + end + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where DAY(c.date3) between '" + dd + "' AND '" + dd1 + "'  AND c.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  usertype='" + user + "' AND CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "'))  AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(SELECT CUSTREGNO FROM calldemo1 where date='" + start + "')", con1);
        cmd.ExecuteNonQuery();
        con1.Close();
        
            

    }
    public void check()
    {
        DateTime to = DateTime.Today;
        DateTime nx=DateTime.Today.AddDays(1);
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();

        SqlCommand cmd = new SqlCommand("update calldemo1 set feeddate='"+nx+"' where feeddate<='" + to + "'", con1);
       cmd.ExecuteNonQuery();
        con1.Close();
        
    }
}