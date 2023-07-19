using EstacionamientoDos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EstacionamientoDos.MasterPage.Admin
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionUser"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {

                var vUserRol = ((adm_User)Session["SessionUser"]);
                var lstRolModule = ((List<adm_RolModule>)Session["SessionModule"]);
                var lstSubModules = ((List<adm_Module>)Session["SessionSubModule"]);


                lblNombreUser.Text = vUserRol.nameUser + " "+ vUserRol.firstNameUser;


                if (lstRolModule.Count > 0) {
                    var espacioColumna = 12 / lstRolModule.Count;

                    foreach (var rolModule in lstRolModule) {
                        HtmlGenericControl divCol = new HtmlGenericControl("div");
                        divCol.Attributes.Add("class", "col-md-"+espacioColumna.ToString());

                        HtmlGenericControl divDDL = new HtmlGenericControl("div");
                        divDDL.Attributes.Add("class", "dropdown");

                        HtmlGenericControl btn = new HtmlGenericControl("button");
                        btn.Attributes.Add("class", "btn btn-secondary dropdown-toggle");
                        btn.Attributes.Add("type", "button");
                        btn.Attributes.Add("data-bs-toggle", "dropdown");
                        btn.Attributes.Add("aria-expanded", "false");
                        btn.InnerHtml = rolModule.adm_Module.nameModule;

                        divDDL.Controls.Add(btn);

                        if (lstSubModules.Count > 0) {
                            HtmlGenericControl ul = new HtmlGenericControl("ul");
                            ul.Attributes.Add("class", "dropdown-menu");

                            foreach (var submodulos in (lstSubModules.Where(x=> x.idModelFather== rolModule.idModule))) {
                                HtmlGenericControl li = new HtmlGenericControl("li");
                                HtmlGenericControl a = new HtmlGenericControl("a");

                                a.Attributes.Add("class", "dropdown-item");
                                a.Attributes.Add("href",submodulos.pathModule);
                                a.InnerHtml = submodulos.nameModule;

                                li.Controls.Add(a);
                                ul.Controls.Add(li);
                            }
                            divDDL.Controls.Add(ul);

                        }

                        
                        divCol.Controls.Add(divDDL);
                        divMenus.Controls.Add(divCol);

                    }

                }

                //string ruta = "";
                //string nombre = "Catalogos";

                //HtmlGenericControl li = new HtmlGenericControl("li");
                //li.InnerText = "Contenido del elemento li";


                //listOption.Controls.Add(li);

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["SessionUser"] = null;
            Session["SessionRol"] = null;
            Session["SessionModule"] = null;
            Session["SessionSubModule"] = null;
            lblNombreUser.Text = string.Empty;

            Response.Redirect("~/Login.aspx");

        }

        
       
    }
}