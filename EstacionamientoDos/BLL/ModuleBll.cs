using EstacionamientoDos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.BLL
{
    public class ModuleBll
    {
        public Data.DashboardEntities _dbo = new Data.DashboardEntities();


        public List<adm_Module> get_adm_Module(adm_Module objetomodulo)
        {
            try
            {
                var lst = new List<adm_Module>();

                if (objetomodulo == null)
                    return null;

                if (objetomodulo.idModule > 0)
                {
                    var res = _dbo.adm_Module.Where(x => x.idModule == objetomodulo.idModule).FirstOrDefault();

                    return new List<adm_Module>() { res };
                }
                else {
                    lst = _dbo.adm_Module.Where(x =>
                        x.nameModule == (string.IsNullOrEmpty(objetomodulo.nameModule)?x.nameModule : objetomodulo.nameModule) &&
                        x.descriptionModule == (string.IsNullOrEmpty(objetomodulo.descriptionModule)? x.descriptionModule: objetomodulo.descriptionModule) &&
                        x.pathModule == (string.IsNullOrEmpty(objetomodulo.pathModule)? x.pathModule: objetomodulo.pathModule) &&
                        x.orderModule == ((objetomodulo.orderModule == null || objetomodulo.orderModule==0)? x.orderModule: objetomodulo.orderModule) &&
                        x.idModelFather == ((objetomodulo.idModelFather == null ) ? x.idModelFather : objetomodulo.idModelFather) &&
                        x.active == (objetomodulo.active == null ? x.active : objetomodulo.active)
                        ).ToList();
                }

                return lst;
            }
            catch {
                return null;
            }
        }

        public List<adm_Module> upd_adm_Module(adm_Module objetomodulo)
        {
            try
            {
                var res = _dbo.adm_Module.Where(x => x.idModule == objetomodulo.idModule).FirstOrDefault();
                res.nameModule = objetomodulo.nameModule;
                res.descriptionModule = objetomodulo.descriptionModule;
                res.pathModule = objetomodulo.pathModule;
                res.orderModule = objetomodulo.orderModule;
                res.idModelFather = objetomodulo.idModelFather;
                res.update_date = DateTime.Now;

                _dbo.SaveChanges();

                return new List<adm_Module>() { res};
            }
            catch {
                return null;
            }
        }

        public List<adm_Module> del_adm_Module(adm_Module objetomodulo)
        {
            try
            {
                var res = _dbo.adm_Module.Where(x => x.idModule == objetomodulo.idModule).FirstOrDefault();
                res.active = false;
                res.update_date = DateTime.Now;

                _dbo.SaveChanges();

                return new List<adm_Module>() { res };
            }
            catch
            {
                return null;
            }
        }

        public List<adm_Module> ins_adm_Module(adm_Module objectUser)
        {
            try
            {
                var lst = new List<adm_Module>();
                _dbo.adm_Module.Add(objectUser);
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