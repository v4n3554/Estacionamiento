using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstacionamientoDos.Data;


namespace EstacionamientoDos.BLL
{
    public class LoginBll
    {
        public DashboardEntities _dbo = new DashboardEntities();
        
        public Tuple<adm_User,adm_RolUser,List<adm_RolModule>, List<adm_Module>> GetInfoUser(string vEmail, string vPass)
        {
            try
            {
                var resUser = _dbo.adm_User.FirstOrDefault(x => x.emailUser == vEmail && x.passwordUser == vPass && x.active == true);
                if (resUser == null)
                    return null;

                var resRolModule = new List<adm_RolModule>();
                var resSubModule = new List<adm_Module>();
                var resRolUser = (from a in _dbo.adm_RolUser.Include("adm_User").Include("adm_Rol")
                           where a.idUser== resUser.idUser
                           select a).FirstOrDefault();

                if (resRolUser != null ) {
                    resRolModule = (from a in _dbo.adm_RolModule.Include("adm_Rol").Include("adm_Module")
                               where a.idRol == resRolUser.idRol && a.active==true
                               select a).ToList();
                    if (resRolModule.Count > 0) {
                        foreach (var modulo in resRolModule) {
                            resSubModule.AddRange((_dbo.adm_Module.Where(x => x.idModelFather == modulo.idModule && x.active==true).ToList()));
                        }
                    }
                    
                                   

                }

                return Tuple.Create(resUser, resRolUser, resRolModule, resSubModule);
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}