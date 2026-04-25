using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;
using System.Net.NetworkInformation;


public partial class login_form_20_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getid();
        }

    }
    public static string GetMachineId()
    {
        string machineId = string.Empty;
        try
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    machineId = obj["SerialNumber"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions 
            Console.WriteLine(ex.Message);
        }
        return machineId;
    } 
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    protected void getid()
    {

        ManagementObjectCollection mbcList = null;
        ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
        mbcList = mbs.Get();
        string processorid = "";
        foreach (ManagementObject mo in mbcList)
        {
            processorid = mo["ProcessorID"].ToString();

        }
        Label1.Text = processorid;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        Label1.Text = GetMachineId();
       /* Response.Write("Your IP Address: " + Request.UserHostAddress + "<BR>");
        Response.Write("Your Computer Name: " + System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName);*/
       /* string name = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name;
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Logged in User\\n" + name + "');", true);*/
    }
}