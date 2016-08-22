using SIMailer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIMailer.Models.ModelClasses
{
    public class Mails
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Body { get; set; }
        [Display(Name = "Admin Name")]
        public int AdminId { get; set; }
        public MailCategory mailCategories { get; set; }
        public List<Person> persons { get; set; }

        MailsRepository objMailsRepository = new MailsRepository();

 
        public Mails GetMailById(int id)
        {
            Mails objMails = new Mails();
            objMails = objMailsRepository.GetMailById(id);
            return objMails;
        } 
   

        public bool SendAndUpdateMail(Mails objMails)
        {
            bool mailSend = objMailsRepository.SendAndUpdateMail(objMails);
            return mailSend;
        }
        public List<Mails> GetAllData()
        {
            List<Mails> dataMails = new List<Mails>();
            dataMails = objMailsRepository.GetAllData();
            return dataMails;
        }

    }
}