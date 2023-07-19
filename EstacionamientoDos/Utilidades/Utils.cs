using AjaxControlToolkit;
using EstacionamientoDos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionamientoDos.Utilidades
{
    public static class Utils
    {
        public static List<adm_User> lstadm_User = new List<adm_User>();
        public static List<adm_Module> lstadm_Module = new List<adm_Module>();
        public static List<adm_Rol> lstadm_Rol = new List<adm_Rol>();
        public static List<adm_RolModule> lstadm_RolModule = new List<adm_RolModule>();
        public static List<adm_RolUser> lstadm_RolUser = new List<adm_RolUser>();

        public static void ModalAlertaMsj(Page ObjPage, string sTitulo, string sMensaje)
        {

            

            (ObjPage.Controls[0].FindControl("lblTituloMensajeMaster") as Label).Text = sTitulo;
            (ObjPage.Controls[0].FindControl("lblMensajeMaster") as Label).Text = sMensaje;
            (ObjPage.Controls[0].FindControl("mpeMensajeMaster") as ModalPopupExtender).Show();


        }
    }
}