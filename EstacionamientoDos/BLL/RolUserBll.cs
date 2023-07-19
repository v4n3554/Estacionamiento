using EstacionamientoDos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.BLL
{
    public class RolUserBll
    {
        public Data.DashboardEntities _dbo = new Data.DashboardEntities();

        public List<adm_RolUser> get_adm_RolUser(adm_RolUser objetorm)
        {
            try
            {
                var lst = new List<adm_RolUser>();

                if (objetorm.idRolUser > 0)
                {

                    var obj = _dbo.adm_RolUser.Where(x => x.idRolUser == objetorm.idRolUser).FirstOrDefault();
                    lst.Add(obj);
                }
                else if (objetorm.idUser > 0)
                {
                    lst = _dbo.adm_RolUser.Where(x => x.idUser == objetorm.idUser).ToList();
                }
                else if (objetorm.idRol > 0)
                {
                    lst = _dbo.adm_RolUser.Where(x => x.idRol == objetorm.idRol).ToList();
                }
                else
                {
                    lst = _dbo.adm_RolUser.Where(x => x.active == (objetorm.active == null ? x.active : objetorm.active)).ToList();
                }


                return lst;

            }
            catch
            {
                return null;
            }
        }

        public List<adm_RolUser> upd_adm_RolUser(adm_RolUser objetorm)
        {
            try
            {
                var lst = new List<adm_RolUser>();

                var res = _dbo.adm_RolUser.Where(x => x.idRolUser == objetorm.idRolUser).FirstOrDefault();

                res.idRolUser = objetorm.idRolUser;
                res.idRol = objetorm.idRol;
                res.idUser = objetorm.idUser;
                res.update_date = DateTime.Now;

                _dbo.SaveChanges();
                lst.Add(res);

                return lst;
            }
            catch
            {
                return null;
            }
        }

        public List<adm_RolUser> del_adm_RolUser(adm_RolUser objetorm)
        {
            try
            {
                var lst = new List<adm_RolUser>();

                var res = _dbo.adm_RolUser.Where(x => x.idRolUser == objetorm.idRolUser).FirstOrDefault();


                res.update_date = DateTime.Now;
                res.active = false;
                _dbo.SaveChanges();
                lst.Add(res);

                return lst;
            }
            catch
            {
                return null;
            }
        }

        public List<adm_RolUser> ins_adm_RolUser(adm_RolUser objectUser)
        {
            try
            {
                var lst = new List<adm_RolUser>();
                _dbo.adm_RolUser.Add(objectUser);
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