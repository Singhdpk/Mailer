using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.IO;
using System.Net.Mail;
using System.Web;

namespace SIMailer
{
    public class Mailer
    {

        public bool SendMail(Mails objMails)
        {
            try
            {
                foreach (var item in objMails.persons)
                {
                    if (item.isIncluded)
                    {
                        string EmailWithTemplate = createEmailWithTemplate(item.Name, objMails.Subject, objMails.Body);
                        MailMessage mail = new MailMessage();
                        mail.To.Add(item.EmailId);
                        mail.From = new MailAddress(" Email From");
                        mail.Subject = objMails.Subject;
                        string Body = EmailWithTemplate;
                        mail.Body = Body;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential
                        ("Email From", "Password");// Enter senders User name and password
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
        public string createEmailWithTemplate(string personName, string subject, string body)

        {

            string EmailWithTemplate = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~\\Templates\\TemplateTesting.html")))

            {

                EmailWithTemplate = reader.ReadToEnd();

            }

            EmailWithTemplate = EmailWithTemplate.Replace("{UserName}", personName); //replacing the required things  

            EmailWithTemplate = EmailWithTemplate.Replace("{Title}", subject);

            EmailWithTemplate = EmailWithTemplate.Replace("{message}", body);

            return EmailWithTemplate;
        }

    }
}