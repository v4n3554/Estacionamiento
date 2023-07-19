using EstacionamientoDos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoDos.BLL
{
    public class UserBll
    {

        public Data.DashboardEntities _dbo = new Data.DashboardEntities();

        public List<adm_User> get_adm_User(adm_User objectUser)
        {
            try
            {
                var lst = new List<adm_User>();

                if (objectUser == null)
                    return null;

                if (objectUser.idUser > 0)
                {
                    var obj = _dbo.adm_User.Where(x => x.idUser == objectUser.idUser).FirstOrDefault();
                    lst.Add(obj);
                }
                else
                {
                    lst = _dbo.adm_User.Where(x =>
                        x.addressUser == (string.IsNullOrEmpty(objectUser.addressUser) ? x.addressUser : objectUser.addressUser) &&
                        x.aliasUser == (string.IsNullOrEmpty(objectUser.aliasUser) ? x.aliasUser : objectUser.aliasUser) &&
                        x.passwordUser == (string.IsNullOrEmpty(objectUser.passwordUser) ? x.passwordUser : objectUser.passwordUser) &&
                        x.nameUser == (string.IsNullOrEmpty(objectUser.nameUser) ? x.nameUser : objectUser.nameUser) &&
                        x.firstNameUser == (string.IsNullOrEmpty(objectUser.firstNameUser) ? x.firstNameUser : objectUser.firstNameUser) &&
                        x.secondNameUser == (string.IsNullOrEmpty(objectUser.secondNameUser) ? x.secondNameUser : objectUser.secondNameUser) &&
                        x.telephoneUser == ((objectUser.telephoneUser == 0 || objectUser.telephoneUser == null) ? x.telephoneUser : objectUser.telephoneUser) &&
                        x.CPUser == (string.IsNullOrEmpty(objectUser.CPUser)?x.CPUser:objectUser.CPUser) &&
                        x.active == (objectUser.active == null? x.active: objectUser.active)
                    ).ToList();
                }



                return lst;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<adm_User> upd_adm_User(adm_User objectUser)
        {
            try
            {
                var res = _dbo.adm_User.Where(x => x.idUser == objectUser.idUser).FirstOrDefault();
                res.idUser = objectUser.idUser;
                res.aliasUser = objectUser.aliasUser;
                res.passwordUser = objectUser.passwordUser;
                res.nameUser = objectUser.nameUser;
                res.firstNameUser = objectUser.firstNameUser;
                res.secondNameUser = objectUser.secondNameUser;
                res.addressUser = objectUser.addressUser;
                res.telephoneUser = objectUser.telephoneUser;
                res.update_date = DateTime.Now;
                res.emailUser = objectUser.emailUser;

                _dbo.SaveChanges();
                return new List<adm_User>() { res};
            }
            catch (Exception ex) {
                return null;
            }
        }

        public List<adm_User> del_adm_User(adm_User objectUser)
        {
            try
            {
                var res = _dbo.adm_User.Where(x => x.idUser == objectUser.idUser).FirstOrDefault();
                res.update_date = DateTime.Now;
                res.active = false;

                _dbo.SaveChanges();
                return new List<adm_User>() { res};

            }
            catch {
                return null;
            }
        }

        public List<adm_User> ins_adm_User(adm_User objectUser)
        {
            try
            {
                var lst = new List<adm_User>();
                _dbo.adm_User.Add(objectUser);
                _dbo.SaveChanges();

                lst.Add(objectUser);

                return lst;
            }
            catch {
                return null;
            }
        }


    }
}