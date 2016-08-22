using SIMailer.Enums;
using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SIMailer.Repositories
{
    public class AdminRepository
    {
        #region Login Admin
        public LoginAdminStatus AdminLogin(Admin objAdmin)
        {
            using (dbSIMailerEntities db = new dbSIMailerEntities())
            {
                LoginAdminStatus status;
                try
                {
                    tblAdmin objtblAdmin = new tblAdmin();
                    if (objAdmin.EmailId == objtblAdmin.EmailId && objAdmin.Password == objtblAdmin.Password)
                    {
                        status = LoginAdminStatus.Successfull;
                    }
                    else if (objAdmin.EmailId == objtblAdmin.EmailId && objAdmin.Password != objtblAdmin.Password)
                    {
                        status = LoginAdminStatus.IncorrectPassowrd;
                    }

                    
                    else
                    {
                        status = LoginAdminStatus.NotRegisterd;
                    }
                    return status;
                }
                catch (Exception ex)
                {
                    status = LoginAdminStatus.Exception;
                    return status;
                }
            }
        } 
        #endregion

        #region Add New Admin
        public bool AddNewAdmin(Admin objAdmin)
        {
            using (dbSIMailerEntities db = new dbSIMailerEntities())
            {
                try
                {
                    tblAdmin objtblAdmin = new tblAdmin();
                    objtblAdmin.EmailId = objAdmin.EmailId;
                    objtblAdmin.Password = objAdmin.Password;
                    db.tblAdmins.AddObject(objtblAdmin);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        #endregion

   
        public bool DeleteAdminById(int AdminId)
        {
            using (dbSIMailerEntities db = new dbSIMailerEntities())
            {
                try
                {
                    IEnumerable<tblAdmin> admins = db.tblAdmins.Where(data => data.Id == AdminId);
                    foreach (tblAdmin objtblAdmin in admins.ToList())
                    {
                        db.tblAdmins.DeleteObject(objtblAdmin);
                        db.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public List<Admin> GetAllData()
        {
            using (dbSIMailerEntities db = new dbSIMailerEntities())
            {
                List<tblAdmin> datatblAdmin = new List<tblAdmin>();
                datatblAdmin = db.tblAdmins.ToList();
                List<Admin> dataAdmin = new List<Admin>();

                for (var i = 0; i < datatblAdmin.Count; i++)
                {
                    dataAdmin.Add(new Admin() { Id = datatblAdmin[i].Id, EmailId = datatblAdmin[i].EmailId });
                }
                return dataAdmin;
            }
        } 

    }
}