using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Download : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return; 
      
    }
    protected void btn_sendlink_Click1(object sender, EventArgs e)
    {
        var id = (from a in linq_obj.file_msts
                  where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                  select a).Single();


        SmtpClient smtpclient;
        MailMessage message;
        string str23 = "Download Link  " + "http://localhost:1892/Part_14_Download_Form/View.aspx?id=" + id.intglcode;

        smtpclient = new SmtpClient();
        message = new MailMessage();
        try
        {
            message.From = new MailAddress("naushadsoftware97@gmail.com");
            message.To.Add(txt_emailid.Text);  //send email to yahoo
            message.Subject = "Account Activation";
            message.Body = str23;
            smtpclient.Host = "smtp.gmail.com";
            smtpclient.EnableSsl = true;
            smtpclient.UseDefaultCredentials = true;
            System.Net.NetworkCredential network = new System.Net.NetworkCredential();
            network.UserName = "naushadsoftware97@gmail.com"; // moksha mail
            network.Password = "efghEFGH1234!@#$"; //password
            smtpclient.UseDefaultCredentials = true;
            smtpclient.Credentials = network;
            smtpclient.Port = 25;
            smtpclient.Send(message);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "onload", "alert('**  Your Password is Successfully Send to Your Email**')", true);
        //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "~/upload/" + id.img + "\"");
        //Response.TransmitFile(Server.MapPath("~/upload/" + id.img));
        //Response.End();

    }
}