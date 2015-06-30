using maplenursery.DataModel;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maplenursery.admin
{
    public partial class addplant : System.Web.UI.Page
    {
        public string values;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected async void Save_Click(object sender, EventArgs e)
        {
            try
            {


                if (FileUpload1 != null && FileUpload1.HasFile)
                {

                    string filename = FileUpload1.FileName;
                    ParseFile file = new ParseFile("filename.jpg", FileUpload1.FileBytes);
                    await file.SaveAsync();
                    ParseObject addplant = new ParseObject("Plant");
                    addplant["name"] = Name.Text;
                    addplant["description"] = Description.Text;
                    addplant["image"] = file;
                    await addplant.SaveAsync();


                }
            }
            catch (Exception en)
            {
                lblerror.Text = en.ToString();
            }

        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string img = ((Image)e.Row.FindControl("Image1")).ImageUrl;
        //        string[] ext = img.Split('.');
        //        if (ext.Length == 1)
        //        {
        //            ((Image)e.Row.FindControl("Image1")).Visible = false;
        //        }
        //        else
        //        {
        //            ((Image)e.Row.FindControl("Image1")).Visible = true;
        //        }
        //    }
        //    //BindGrid();
        //}

    }
    }
