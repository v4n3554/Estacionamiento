using EstacionamientoDos.BLL;
using EstacionamientoDos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionamientoDos
{
    public partial class Login : System.Web.UI.Page
    {
        public LoginBll objBll = new LoginBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ModalAlertaMsj(string sTitulo, string sMensaje)
        {

            lblTituloMensajeMaster.Text = sTitulo;
            lblMensajeMaster.Text = sMensaje;
            mpeMensajeMaster.Show();

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

            try
            {
                var resultado= objBll.GetInfoUser(txtUser.Text, txtPassword.Text);

                if (resultado == null)
                {
                    Session["SessionUser"] = null;
                    Session["SessionRol"] = null;
                    Session["SessionModule"] = null;
                    Session["SessionSubModule"] = null;

                    ModalAlertaMsj("Error", "El usuario No existe");
                }
                else
                {
                    Session["SessionUser"] = resultado.Item1;
                    Session["SessionRol"] = resultado.Item2;
                    Session["SessionModule"] = resultado.Item3;
                    Session["SessionSubModule"] = resultado.Item4;


                    Response.Redirect("~/Index.aspx");
                }
            }
            catch (Exception ex) {
                ModalAlertaMsj("Error", ex.Message);
            }

            
        }

        
    }
}