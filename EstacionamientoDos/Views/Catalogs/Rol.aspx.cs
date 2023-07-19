using EstacionamientoDos.BLL;
using EstacionamientoDos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionamientoDos.Views.Catalogs
{
    public partial class Rol : System.Web.UI.Page
    {
        
        public RolBll objBll = new RolBll();

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
                
                getResume();
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
                var lstObjeto = objBll.get_adm_Rol(new Data.adm_Rol() { active = true });

                Utils.lstadm_Rol = lstObjeto;
                gvResume.DataSource = Utils.lstadm_Rol;
                gvResume.DataBind();
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                var objeto = new Data.adm_Rol(){active = true,nameRol = txtNombre.Text, create_date=DateTime.Now};

                var res = objBll.ins_adm_Roll(objeto);
                if (res != null && res.Count > 0)
                {

                    Utilidades.Utils.ModalAlertaMsj(this, "Succes", "Registro Guardado");
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


        protected void gvResume_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    (e.Row.FindControl("txtRolOper") as TextBox).Text = Utils.lstadm_Rol[e.Row.RowIndex].nameRol.ToString();
                    (e.Row.FindControl("txtRolOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtcreateOper") as TextBox).Text = Utils.lstadm_Rol[e.Row.RowIndex].create_date.ToString();
                    (e.Row.FindControl("txtcreateOper") as TextBox).Enabled = false;

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


                (gvrow.FindControl("txtRolOper") as TextBox).Enabled = true;
                
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

                int vIdRol = Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idRol"]);

                var objetomo = new Data.adm_Rol() 
                {
                    idRol = vIdRol,
                    nameRol = (gvrow.FindControl("txtRolOper") as TextBox).Text,
                    update_date = DateTime.Now
                };


                var res = objBll.upd_adm_Rol(objetomo);
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

                int vIdRol = Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idRol"]);

                var res = objBll.del_adm_Rol(new Data.adm_Rol() { idRol = vIdRol });
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

    }
}