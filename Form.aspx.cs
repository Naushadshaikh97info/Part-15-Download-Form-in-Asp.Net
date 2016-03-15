using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Default3 : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static string img;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        fill_data();

        if(Request.QueryString["id"] !=null)
        {
            fill_data();
        }
       
    }
    private void fill_data()
    {
        var id = (from a in linq_obj.file_msts
               
                  select new
                  {
                      code = a.intglcode,
                      name = a.name,
                      img = "~/upload/" + a.img
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void onclick_download(object sender, EventArgs e)
    {

        LinkButton lnk = (LinkButton)sender;
        int code = Convert.ToInt32(lnk.CommandArgument.ToString());

        var id = (from a in linq_obj.file_msts
                  where a.intglcode == code
                  select a).Single();
        Response.Redirect("Download.aspx?id=" + code);

        //LinkButton lnk = (LinkButton)sender;
        //int code = Convert.ToInt32(lnk.CommandArgument.ToString());

        //var id = (from a in linq_obj.file_msts
        //          where a.intglcode == code
        //          select a).Single();
        //SmtpClient smtpclient;
        //MailMessage message;
        //string str23 = "Download Link  " + "http://localhost:1171/Part%2014%20Download%20Form/View.aspx?id=" + code;

        //smtpclient = new SmtpClient();
        //message = new MailMessage();
        //try
        //{
        //    message.From = new MailAddress("naushadsoftware97@gmail.com");
        //    message.To.Add(TextBox1.Text);  //send email to yahoo
        //    message.Subject = "Account Activation";
        //    message.Body = str23;
        //    smtpclient.Host = "smtp.gmail.com";
        //    smtpclient.EnableSsl = true;
        //    smtpclient.UseDefaultCredentials = true;
        //    System.Net.NetworkCredential network = new System.Net.NetworkCredential();
        //    network.UserName = "naushadsoftware97@gmail.com"; // moksha mail
        //    network.Password = "efghEFGH1234!@#$"; //password
        //    smtpclient.UseDefaultCredentials = true;
        //    smtpclient.Credentials = network;
        //    smtpclient.Port = 25;
        //    smtpclient.Send(message);
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
        //ScriptManager.RegisterStartupScript(this, GetType(), "onload", "alert('**  Your Password is Successfully Send to Your Email**')", true);
        //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "~/upload/" + id.img + "\"");
        //Response.TransmitFile(Server.MapPath("~/upload/" + id.img));
        //Response.End();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fill_data();
    }
}