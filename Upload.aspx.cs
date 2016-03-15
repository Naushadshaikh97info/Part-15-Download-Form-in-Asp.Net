using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    DataClassesDataContext linq_obj = new DataClassesDataContext();
    static string img;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        fill_data();
    }
    private void fill_data()
    {
        var id = (from a in linq_obj.file_msts
                  select new
                  {
                      code = a.intglcode,
                      name = a.name,
                      img ="~/upload/" + a.img
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != null)
        {
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
            img = FileUpload1.FileName;
        }
        linq_obj.insert_file(txt_img.Text, img);
        linq_obj.SubmitChanges();
        fill_data();
        txt_img.Text = "";
        
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["id"] = code;
        var id = (from a in linq_obj.file_msts
                  where a.intglcode == code
                  select a).Single();
        txt_img.Text = id.name;
        img = id.img;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        linq_obj.delete_file(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        linq_obj.SubmitChanges();

        fill_data();
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fill_data();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != null)
        {
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/upload/" + FileUpload1.FileName);
            img = FileUpload1.FileName;
        }

        linq_obj.update_file(Convert.ToInt32(ViewState["id"].ToString()), txt_img.Text, img);
        linq_obj.SubmitChanges();

        fill_data();
        Response.Redirect("Upload.aspx");
    }
}