using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SIMailer
{
    public class Mailer
    {

        #region Send Mail
        public bool SendMail(Mails objMails)
        {
            try
            {
                foreach (var item in objMails.persons)
                {
                    if(item.isIncluded)
                        {
                        MailMessage mail = new MailMessage();
                        mail.To.Add(item.EmailId);
                        mail.From = new MailAddress("Email");
                        mail.Subject = objMails.Subject;
                        string Body = objMails.Body;
                        mail.Body = Body;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential
                        ("Email", "Password");// Enter senders User name and password
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                        using (dbSIMailerEntities db = new dbSIMailerEntities())
                        {
                            tblSendTo objtblSendTo = new tblSendTo();
                            objtblSendTo.MailId = objMails.Id;
                            objtblSendTo.PersonId = item.Id;
                            objtblSendTo.AdminId = objMails.AdminId;
                            db.tblSendTo.AddObject(objtblSendTo);
                            db.SaveChanges();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;

        } 
        #endregion
    }
}