using EstacionamientoDos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EstacionamientoDos.BLL;
using EstacionamientoDos.Data;

namespace EstacionamientoDos.Views.Configuration
{
    public partial class RolUser : System.Web.UI.Page
    {
        public RolUserBll objBll = new RolUserBll();
        public RolBll objRolBll = new RolBll();
        public UserBll objUserBll = new UserBll();
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
                
                getResume();
                getRol(ddlRol);
                getUser(ddlUsuario);
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        private void getRol(DropDownList ddl)
        {
            try
            {
                Utils.lstadm_Rol = objRolBll.get_adm_Rol(new adm_Rol() { active = true });
                ddl.DataSource = Utils.lstadm_Rol;
                ddl.DataTextField = "nameRol";
                ddl.DataValueField = "idRol";
                ddl.DataBind();
            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this,"Error",ex.Message);
            }
        }

        private void getUser(DropDownList ddl) {
            try
            {
                Utils.lstadm_User = objUserBll.get_adm_User(new adm_User() { active = true });
                ddl.DataSource = Utils.lstadm_User;
                ddl.DataTextField = "aliasUser";
                ddl.DataValueField = "idUser";
                ddl.DataBind();
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
                var lstObjeto = objBll.get_adm_RolUser(new Data.adm_RolUser() { active = true });

                Utils.lstadm_RolUser = lstObjeto;
                gvResume.DataSource = Utils.lstadm_RolUser;
                gvResume.DataBind();
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
                    DropDownList ddlRol = e.Row.FindControl("ddlRolOper") as DropDownList;
                    DropDownList ddlUsuario = e.Row.FindControl("ddlUserOper") as DropDownList;
                    getRol(ddlRol);
                    getUser(ddlUsuario);

                    ddlRol.SelectedValue = Utils.lstadm_RolUser[e.Row.RowIndex].idRol.ToString();
                    ddlRol.Enabled = false;
                    ddlUsuario.SelectedValue = Utils.lstadm_RolUser[e.Row.RowIndex].idUser.ToString();
                    ddlUsuario.Enabled = false;

                    (e.Row.FindControl("txtcreateOper") as TextBox).Text = Utils.lstadm_RolUser[e.Row.RowIndex].create_date.ToString();
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

                (gvrow.FindControl("ddlRolOper") as DropDownList).Enabled = true;
                (gvrow.FindControl("ddlUserOper") as DropDownList).Enabled = true;

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

                int vid= Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idRolUser"]);

                var objetomo = new adm_RolUser()
                {
                    idRolUser = vid,
                    idRol = Convert.ToInt32((gvrow.FindControl("ddlRolOper") as DropDownList).SelectedValue),
                    idUser = Convert.ToInt32((gvrow.FindControl("ddlUserOper") as DropDownList).SelectedValue),
                    update_date = DateTime.Now

                };


                var res = objBll.upd_adm_RolUser(objetomo);
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

                int vid = Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idRolUser"]);

                var res = objBll.del_adm_RolUser(new Data.adm_RolUser() { idRolUser=vid });
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

                var objeto = new Data.adm_RolUser()
                {
                    active = true
                    ,
                    create_date = DateTime.Now
                    ,
                    idRol = Convert.ToInt32(ddlRol.SelectedValue)
                    ,idUser = Convert.ToInt32(ddlUsuario.SelectedValue)
                    
                };

                var res = objBll.ins_adm_RolUser(objeto);
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