using EstacionamientoDos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.BLL
{
    public class RolBll
    {
        public Data.DashboardEntities _dbo = new Data.DashboardEntities();

        public List<adm_Rol> get_adm_Rol(adm_Rol objetoRol)
        {
            try
            {
                var lst = new List<adm_Rol>();
                if (objetoRol == null)
                    return null;

                if (objetoRol.idRol > 0)
                {
                    var obj = _dbo.adm_Rol.Where(x => x.idRol == objetoRol.idRol).FirstOrDefault();
                    lst.Add(obj);

                }
                else {
                    lst = _dbo.adm_Rol.Where(x =>
                    x.active == (objetoRol.active == null ? x.active : objetoRol.active) &&
                    x.nameRol== (string.IsNullOrEmpty(objetoRol.nameRol)? x.nameRol: objetoRol.nameRol)
                    ).ToList();
                }



                return lst;
            }
            catch {
                return null;
            }
        }

        public List<adm_Rol> upd_adm_Rol(adm_Rol objetoRol)
        {
            try
            {
                var res = _dbo.adm_Rol.Where(x => x.idRol == objetoRol.idRol).FirstOrDefault();
                
                res.nameRol = objetoRol.nameRol;
                res.update_date = DateTime.Now;
                _dbo.SaveChanges();

                return new List<adm_Rol>() { res};

            }
            catch {
                return null;
            }
        }

        public List<adm_Rol> del_adm_Rol(adm_Rol objetoRol)
        {
            try
            {
                var res = _dbo.adm_Rol.Where(x => x.idRol == objetoRol.idRol).FirstOrDefault();

                res.active = false;
                res.update_date = DateTime.Now;
                _dbo.SaveChanges();

                return new List<adm_Rol>() { res };

            }
            catch
            {
                return null;
            }
        }

        public List<adm_Rol> ins_adm_Roll(adm_Rol objectUser)
        {
            try
            {
                var lst = new List<adm_Rol>();
                _dbo.adm_Rol.Add(objectUser);
                _dbo.SaveChanges();

                lst.Add(objectUser);

                return lst;
            }
            catch
            {
                return null;
            }
        }
    }
}