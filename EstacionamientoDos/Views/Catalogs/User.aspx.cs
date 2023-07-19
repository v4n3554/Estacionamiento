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
    public partial class User : System.Web.UI.Page
    {
        
        public UserBll objBll = new UserBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Initialization();
            }
        }

        private void Initialization() {
            try
            {
                txtUser.Text = string.Empty;
                txttel.Text = string.Empty;
                txtPsw.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtcp.Text = string.Empty;
                txtapp.Text = string.Empty;
                txtapm.Text = string.Empty;
                txtaddress.Text = string.Empty;



                getResume();
            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                var objeto = new Data.adm_User()
                {
                    active = true
                    ,
                    addressUser = txtaddress.Text
                    ,
                    idUser = 0
                    ,
                    nameUser = txtNombre.Text
                    ,
                    firstNameUser = txtapp.Text
                    ,
                    secondNameUser = txtapm.Text
                    ,
                    create_date = DateTime.Now
                    ,
                    telephoneUser = string.IsNullOrEmpty(txttel.Text) ? 0 : Convert.ToInt64(txttel.Text)
                    ,
                    aliasUser = txtUser.Text
                    ,CPUser= txtcp.Text
                    ,passwordUser = txtPsw.Text
                    ,emailUser=txtEmail.Text
                };

                var res = objBll.ins_adm_User(objeto);
                if (res != null && res.Count > 0)
                {

                    Utilidades.Utils.ModalAlertaMsj(this, "Succes", "Registro Guardado");
                    Initialization();
                }
                else {
                    Utilidades.Utils.ModalAlertaMsj(this, "Error", "Error al guardar registro");
                }
            }
            catch (Exception ex)
            {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        public void getResume() {
            try
            {
                var lstObjeto = objBll.get_adm_User(new Data.adm_User() { active=true});

                Utils.lstadm_User = lstObjeto;
                gvResume.DataSource = Utils.lstadm_User;
                gvResume.DataBind();
            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        protected void ibtnConsultarOper_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton objibtnAccionesFondo = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)objibtnAccionesFondo.NamingContainer;

                
                (gvrow.FindControl("txtUserOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtNameOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtAPPOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtAPMOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtaddressOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtcpOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtphoneOper") as TextBox).Enabled = true;
                (gvrow.FindControl("txtEmailOper") as TextBox).Enabled = true;


                (gvrow.FindControl("ibtnCancelOper") as ImageButton).Visible = true;
                (gvrow.FindControl("ibtnGuardarOper") as ImageButton).Visible = true;
                (gvrow.FindControl("ibtnConsultarOper") as ImageButton).Visible = false;
                (gvrow.FindControl("ibtnEliminarOper") as ImageButton).Visible = false;
            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }

        protected void ibtnGuardarOper_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton objibtnAccionesFondo = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)objibtnAccionesFondo.NamingContainer;

                int vIdUser = Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idUser"]);

                var objetomo = new adm_User() {
                    addressUser = (gvrow.FindControl("txtaddressOper") as TextBox).Text,
                    firstNameUser = (gvrow.FindControl("txtAPPOper") as TextBox).Text,
                    secondNameUser = (gvrow.FindControl("txtAPMOper") as TextBox).Text,
                    aliasUser= (gvrow.FindControl("txtUserOper") as TextBox).Text,
                    update_date=DateTime.Now,
                    telephoneUser= string.IsNullOrEmpty((gvrow.FindControl("txtphoneOper") as TextBox).Text)?0:Convert.ToInt64((gvrow.FindControl("txtphoneOper") as TextBox).Text),
                    nameUser= (gvrow.FindControl("txtNameOper") as TextBox).Text,
                    CPUser= (gvrow.FindControl("txtcpOper") as TextBox).Text
                    ,idUser= vIdUser
                    ,emailUser= (gvrow.FindControl("txtEmailOper") as TextBox).Text,
                };


                var res = objBll.upd_adm_User(objetomo);
                if (res != null && res.Count > 0)
                {
                    Utils.ModalAlertaMsj(this,"Success","Registro Actualizado");
                    Initialization();
                }
                else {
                    Utils.ModalAlertaMsj(this,"Error","Error al actualizar");
                }


                


            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }

        }

        protected void ibtnEliminarOper_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton objibtnAccionesFondo = sender as ImageButton;
                GridViewRow gvrow = (GridViewRow)objibtnAccionesFondo.NamingContainer;

                int vIdUser = Convert.ToInt32(gvResume.DataKeys[gvrow.RowIndex].Values["idUser"]);

                var res = objBll.del_adm_User(new Data.adm_User() { idUser = vIdUser });
                if (res.Count > 0)
                {
                    Initialization();
                    Utils.ModalAlertaMsj(this, "Success", "Registro Borrado");
                } 
                else {
                    Utils.ModalAlertaMsj(this,"Error","Error al eliminar");
                }
            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this,"Error",ex.Message);
            }
            
        }

        protected void ibtnCancelOper_Click(object sender, ImageClickEventArgs e)
        {
            Initialization();
        }

        protected void gvResume_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    (e.Row.FindControl("txtUserOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].aliasUser.ToString();
                    (e.Row.FindControl("txtUserOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtNameOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].nameUser.ToString();
                    (e.Row.FindControl("txtNameOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtAPPOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].firstNameUser.ToString();
                    (e.Row.FindControl("txtAPPOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtAPMOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].secondNameUser.ToString();
                    (e.Row.FindControl("txtAPMOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtaddressOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].addressUser.ToString();
                    (e.Row.FindControl("txtaddressOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtcpOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].CPUser.ToString();
                    (e.Row.FindControl("txtcpOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtphoneOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].telephoneUser.ToString();
                    (e.Row.FindControl("txtphoneOper") as TextBox).Enabled = false;
                    //(e.Row.FindControl("txtcreateOper") as TextBox).Text = Utils.lstadm_User[e.Row.RowIndex].create_date.ToString();
                    //(e.Row.FindControl("txtcreateOper") as TextBox).Enabled = false;
                    (e.Row.FindControl("txtEmailOper") as TextBox).Text = (String.IsNullOrEmpty(Utils.lstadm_User[e.Row.RowIndex].emailUser)? string.Empty : Utils.lstadm_User[e.Row.RowIndex].emailUser.ToString());
                    (e.Row.FindControl("txtEmailOper") as TextBox).Enabled = false;

                    (e.Row.FindControl("ibtnCancelOper") as ImageButton).Visible = false;
                    (e.Row.FindControl("ibtnGuardarOper") as ImageButton).Visible = false;
                    (e.Row.FindControl("ibtnConsultarOper") as ImageButton).Visible = true;
                    (e.Row.FindControl("ibtnEliminarOper") as ImageButton).Visible = true;
                }
            }
            catch (Exception ex) {
                Utils.ModalAlertaMsj(this, "Error", ex.Message);
            }
        }
    }
}