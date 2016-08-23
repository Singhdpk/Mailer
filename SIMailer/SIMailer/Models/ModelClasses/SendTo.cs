using SIMailer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMailer.Models.ModelClasses
{
    public class SendTo
    {
        public int Id { get; set; }
        public int MailId { get; set; }
        public int PersonId { get; set; }
        public int Adminid { get; set; }

        SendToRepository objSendToRepository = new SendToRepository();
        public List<SendTo> GetAllData()
        {
            List<SendTo> dataSendTo = new List<SendTo>();
            dataSendTo = objSendToRepository.GetAllData();
            return dataSendTo;
        }
    }
}