using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default5 : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {

            var id = (from a in linq_obj.file_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select a).Single();
            ScriptManager.RegisterStartupScript(this, GetType(), "onload", "alert('**  Your Password is Successfully Send to Your Email**')", true);
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + "~/upload/" + id.img + "\"");
            Response.TransmitFile(Server.MapPath("~/upload/" + id.img));
            Response.End();
        }
    }
}