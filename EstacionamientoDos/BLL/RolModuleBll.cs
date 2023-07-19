using EstacionamientoDos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.BLL
{
    public class RolModuleBll
    {
        public Data.DashboardEntities _dbo = new Data.DashboardEntities();

        public List<adm_RolModule> get_adm_RolModule(adm_RolModule objetorm)
        {
            try
            {
                var lst = new List<adm_RolModule>();

                if (objetorm.idRolModule > 0)
                {

                    var obj = _dbo.adm_RolModule.Where(x => x.idRolModule == objetorm.idRolModule).FirstOrDefault();
                    lst.Add(obj);
                }
                else if (objetorm.idModule > 0)
                {
                    lst = _dbo.adm_RolModule.Where(x => x.idModule == objetorm.idModule).ToList();
                }
                else if (objetorm.idRol > 0)
                {
                    lst = _dbo.adm_RolModule.Where(x => x.idRol == objetorm.idRol).ToList();
                }
                else {
                    lst = _dbo.adm_RolModule.Where( x=> x.active == (objetorm.active == null ? x.active : objetorm.active)).ToList();
                }


                return lst;

            }
            catch {
                return null;
            }
        }

        public List<adm_RolModule> upd_adm_RolModule(adm_RolModule objetorm)
        {
            try
            {
                var lst = new List<adm_RolModule>();

                var res = _dbo.adm_RolModule.Where(x => x.idRolModule == objetorm.idRolModule).FirstOrDefault();

                res.idRolModule = objetorm.idRolModule;
                res.idRol = objetorm.idRol;
                res.idModule = objetorm.idModule;
                res.update_date = DateTime.Now;

                _dbo.SaveChanges();
                lst.Add(res);

                return lst;
            }
            catch {
                return null;
            }
        }

        public List<adm_RolModule> del_adm_RolModule(adm_RolModule objetorm)
        {
            try
            {
                var lst = new List<adm_RolModule>();

                var res = _dbo.adm_RolModule.Where(x => x.idRolModule == objetorm.idRolModule).FirstOrDefault();

                
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

        public List<adm_RolModule> ins_adm_RolModule(adm_RolModule objectUser)
        {
            try
            {
                var lst = new List<adm_RolModule>();
                _dbo.adm_RolModule.Add(objectUser);
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