using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMailer.Repositories
{
    public class SendToRepository
    {
        public List<SendTo> GetAllData()
        {
            List<SendTo> dataSendTo = new List<SendTo>();
            try
            {
                List<tblSendTo> datatblSendTo = new List<tblSendTo>();
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    datatblSendTo = db.tblSendTo.ToList();
                    foreach(var item in datatblSendTo)
                    {
                        dataSendTo.Add(new SendTo()
                        {
                            Id=item.Id,
                            MailId = item.MailId,
                            PersonId = item.PersonId,
                            Adminid = item.AdminId,
                        });
                    }
                }
                return dataSendTo;
            }
            catch(Exception ex)
            {

            }
            dataSendTo = null;
            return dataSendTo;
        }
    }
}