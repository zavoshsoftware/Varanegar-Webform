using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Varanegar2017.Models;

namespace Varanegar
{
    public partial class UploadResume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id =1;
                using (VaranegarEntities db = new VaranegarEntities())
                {
                    var n = (from a in db.Texts
                             where a.TextID == id
                             select a).FirstOrDefault();
              
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            string new_filename = string.Empty;

            if (fuImage.PostedFile.ContentLength != 0)
            {
                string original_filename = Path.GetFileName(fuImage.PostedFile.FileName);

                new_filename =
                    Guid.NewGuid().ToString() +
                    Path.GetExtension(original_filename);

                string new_filepath = Server.MapPath("~/Uploads/Resume/" + new_filename);
                fuImage.PostedFile.SaveAs(new_filepath);
                ViewState["GImage"] = new_filename;
            }

            using (VaranegarEntities db = new VaranegarEntities())
            {
                Resumes re = new Resumes();
                re.resumeid = Guid.NewGuid();
                re.IsDelete = false;
                re.resumeFile = new_filename;
                re.SubmitDate = DateTime.Now;
                re.submitIP = Request.UserHostAddress;

                db.Resumes.Add(re);
                db.SaveChanges();

                pnlsuccess.Visible = true;
            }
        }
    }
}