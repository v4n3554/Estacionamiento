using EstacionamientoDos.BLL;
using EstacionamientoDos.Data;
using EstacionamientoDos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionamientoDos.Views.Catalogs
{
    public partial class Module : System.Web.UI.Page
    {
        public ModuleBll objBll = new ModuleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Initialization();
            }
        }

        private void Initialization()
        {
            try
            {
                txtNombre.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtPath.Text = string.Empty;
                txtOrden.Text = string.Empty;
                


                getResume();
                getFather(ddlPadre);
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        public void getResume()
        {
            try
            {
                var lstObjeto = objBll.get_adm_Module(new Data.adm_Module() { active = true });

                Utils.lstadm_Module = lstObjeto;
                gvResume.DataSource = Utils.lstadm_Module;
                gvResume.DataBind();
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }


        public void getFather(DropDownList ddl)
        {
            try
            {
                var a = objBll.get_adm_Module(new adm_Module());
                var lstFather = objBll.get_adm_Module(new Data.adm_Module() { active = true, idModelFather = 0 }).ToList();
                lstFather.Add(new Data.adm_Module() { idModule = 0, nameModule = "" });
                ddl.DataSource = (lstFather.OrderBy(x => x.idModule));
                ddl.DataValueField = "idModule";
                ddl.DataTextField = "nameModule";
                ddl.DataBind();

            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this,"Error", ex.Message);
            }
        }

        protected void gvResume_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlPadre = e.Row.FindControl("ddlPadreOper") as DropDownList;
                    getFather(ddlPadre);

                    (e.Row.FindControl("txtNameOper") as TextBox).Text = Utils.lstadm_Module[e.Row.RowIndex].nameModule.ToString();
                    (e.Row.FindControl("txtNameOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtDescOper") as TextBox).Text = Utils.lstadm_Module[e.Row.RowIndex].descriptionModule.ToString();
                    (e.Row.FindControl("txtDescOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtPathOper") as TextBox).Text = Utils.lstadm_Module[e.Row.RowIndex].pathModule.ToString();
                    (e.Row.FindControl("txtPathOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtOrdenOper") as TextBox).Text = Utils.lstadm_Module[e.Row.RowIndex].orderModule.ToString();
                    (e.Row.FindControl("txtOrdenOper") as TextBox).Enabled = false;
                    ddlPadre.SelectedValue = Utils.lstadm_Module[e.Row.RowIndex].idModelFather.ToString();
                    ddlPadre.Enabled = false;

                    //(e.Row.FindControl("txtcreateOper") as TextBox).Text = Utils.lstadm_Module[e.Row.RowIndex].create_date.ToString();
                    //(e.Row.FindControl("txtcreateOper") as TextBox).Enabled = false;

                    (e.Row.FindControl("ibtnCancelOper") as ImageButton).Visible = false;
                    (e.Row.FindControl("ibtnGuardarOper") as ImageButton).Visible = false;
                    (e.Row.FindControl("ibtnConsultarOper") as ImageButton).Visible = true;
                    (e.Row.FindControl("ibtnEliminarOper") as ImageButton).Visible = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        protected void ibtnConsultarOper_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton objibtnAccionesFondo = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)objibtnAccionesFondo.NamingContainer;

                (gvrow.FindControl("txtNameOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtDescOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtPathOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtOrdenOper") as TextBox).Enabled = true;
                (gvrow.FindControl("ddlPadreOper") as DropDownList).Enabled = true;


                (gvrow.FindControl("ibtnCancelOper") as ImageButton).Visible = true;
                (gvrow.FindControl("ibtnGuardarOper") as ImageButton).Visible = true;
                (gvrow.FindControl("ibtnConsultarOper") as ImageButton).Visible = false;
                (gvrow.FindControl("ibtnEliminarOper") as ImageButton).Visible = false;
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        protected void ibtnGuardarOper_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton objibtnAccionesFondo = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)objibtnAccionesFondo.NamingContainer;

                int vidModule = Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idModule"]);

                var objetomo = new adm_Module()
                {
                    idModule = vidModule,
                    nameModule = (gvrow.FindControl("txtNameOper") as TextBox).Text,
                    descriptionModule= (gvrow.FindControl("txtDescOper") as TextBox).Text,
                    pathModule = (gvrow.FindControl("txtPathOper") as TextBox).Text,
                    orderModule = string.IsNullOrEmpty((gvrow.FindControl("txtOrdenOper") as TextBox).Text)?0:Convert.ToInt32((gvrow.FindControl("txtOrdenOper") as TextBox).Text),
                    idModelFather = Convert.ToInt32((gvrow.FindControl("ddlPadreOper") as DropDownList).SelectedValue),
                    update_date = DateTime.Now
                    
                };


                var res = objBll.upd_adm_Module(objetomo);
                if (res != null && res.Count > 0)
                {
                    Utils.ModalAlertaMsj(this, "Success", "Registro Actualizado");
                    Initialization();
                }
                else
                {
                    Utils.ModalAlertaMsj(this, "Error", "Error al actualizar");
                }





            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }

        }

        protected void ibtnEliminarOper_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton objibtnAccionesFondo = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)objibtnAccionesFondo.NamingContainer;

                int vidModuler = Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idModule"]);

                var res = objBll.del_adm_Module(new Data.adm_Module() { idModule = vidModuler });
                if (res.Count > 0)
                {
                    Initialization();
                    Utils.ModalAlertaMsj(this, "Success", "Registro Borrado");
                }
                else
                {
                    Utils.ModalAlertaMsj(this, "Error", "Error al eliminar");
                }
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }

        }

        protected void ibtnCancelOper_Click(object sender, ImageClickEventArgs e)
        {
            Initialization();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                var objeto = new Data.adm_Module()
                {
                    active = true
                    ,create_date=DateTime.Now
                    ,nameModule=txtNombre.Text
                    ,descriptionModule = txtDesc.Text
                    ,pathModule = txtPath.Text
                    ,orderModule = Convert.ToInt32(txtOrden.Text)
                    ,idModelFather = Convert.ToInt32(ddlPadre.SelectedValue)
                };

                var res = objBll.ins_adm_Module(objeto);
                if (res != null && res.Count > 0)
                {

                    Utilidades.Utils.ModalAlertaMsj(this, "Success", "Registro Guardado");
                    Initialization();
                }
                else
                {
                    Utilidades.Utils.ModalAlertaMsj(this, "Error", "Error al guardar registro");
                }
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }


    }
}