using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMailer.Repositories
{
    public class MailsRepository
    {

        public Mails GetMailById(int id)
        {
            Mails objMails = new Mails();
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    tblMail objtblMail = new tblMail();
                    objtblMail = db.tblMails.First(data => data.Id == id);
                    objMails.Id = objtblMail.Id;
                    objMails.CategoryId = objtblMail.CategoryId;
                    objMails.Title = objtblMail.Title;
                    objMails.Subject = objtblMail.Subject;
                    objMails.Body = objtblMail.Body;
                    objMails.AdminId = objtblMail.AdminId;
                }
                return objMails;
            }
            catch (Exception ex)
            {

            }
            objMails = null;
            return objMails;
        }


        public bool SendAndUpdateMail(Mails objMails)
        {
            Mailer objMailer = new Mailer();
            try
            {
                if (objMails.Id == 0)
                {
                    tblMail objtblMail = new tblMail();
                    objtblMail.CategoryId = objMails.CategoryId;
                    objtblMail.Title = objMails.Title;
                    objtblMail.Subject = objMails.Subject;
                    objtblMail.Body = objMails.Body;
                    objtblMail.AdminId = objMails.AdminId;
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                        db.tblMails.AddObject(objtblMail);
                        db.SaveChanges();
                        objMails.Id = objtblMail.Id;
                    }
                    bool isSend = objMailer.SendMail(objMails);
                    if (isSend)
                        return true;
                    else
                        return false;
                }
                else
                {
                    tblMail objtblMail = new tblMail();
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                        objtblMail = db.tblMails.First(data => data.Id == objMails.Id);
                        if (objtblMail.CategoryId == objMails.CategoryId &&
                        objtblMail.Title == objMails.Title &&
                        objtblMail.Subject == objMails.Subject &&
                        objtblMail.Body == objMails.Body &&
                        objtblMail.AdminId == objMails.AdminId)
                        {
                            bool isSend = objMailer.SendMail(objMails);
                            if (isSend)
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            tblMail objtblMailUpdate = new tblMail();
                            objtblMailUpdate.CategoryId = objMails.CategoryId;
                            objtblMailUpdate.Title = objMails.Title;
                            objtblMailUpdate.Subject = objMails.Subject;
                            objtblMailUpdate.Body = objMails.Body;
                            objtblMailUpdate.AdminId = objMails.AdminId;
                            using (dbSIMailerEntities dbs = new dbSIMailerEntities())
                            {
                                dbs.tblMails.AddObject(objtblMailUpdate);
                                dbs.SaveChanges();
                                objMails.Id = objtblMailUpdate.Id;
                            }
                            bool isSend = objMailer.SendMail(objMails);
                            if (isSend)
                                return true;
                            else
                                return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public List<Mails> GetAllData()
        {
            List<Mails> dataMails = new List<Mails>();
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    List<tblMail> datatblMail = new List<tblMail>();
                    datatblMail = db.tblMails.ToList();
                    foreach(var item in datatblMail)
                    {
                        dataMails.Add(new Mails()
                        {
                            Id=item.Id,
                            CategoryId=item.CategoryId,
                            Title=item.Title,
                            Subject=item.Subject,
                            Body=item.Body,
                            AdminId=item.AdminId,
                        });
                    }
                }
                return dataMails;
            }
            catch(Exception ex)
            {

            }
            dataMails = null;
            return dataMails;
        }
    }
}