using SIMailer.Enums;
using SIMailer.Models.ModelClasses;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIMailer.Controllers
{
    public class AdminController : Controller
    {
        Admin objAdmin = new Admin();
        Mailer objMailer = new Mailer();
        PersonType objPersonType = new PersonType();
        MailCategory objMailCategory = new MailCategory();
        Person objPerson = new Person();
        Mails objMails = new Mails();

        [HttpGet, ActionName("CreateMail")]
        public ActionResult CreateAndEditMail(int? id)
        {
            MailCategory objMailCategory = new MailCategory();
            Person objPerson = new Person();
            PersonType objPersonType = new PersonType();
            ViewBag.dataPerson = objPerson.GetAllData();
            ViewBag.dataMailCategory = objMailCategory.GetAllData();
            ViewBag.dataPersonType = objPersonType.GetAllData();
            if (id == null)
                return View();
            else
            {
                int MailId = (int)id;
                objMails = objMails.GetMailById(MailId);
                if (objMails != null)
                    return View(objMails);
                else
                    return View();
            }
        }

        [HttpPost, ActionName("CreateMail")]
        public ActionResult CreateAndEditMail(Mails objMails)
        {
            bool mailSend = objMails.SendAndUpdateMail(objMails);
            if (mailSend)
                TempData["AlertMessage"] = "Email Successfully Sent";

            else
                TempData["AlertMessage"] = "Email Not Sent";
            return RedirectToAction("Home");
        }

        [HttpGet, ActionName("Home")]
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet, ActionName("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult AdminLogin(Admin objAdminLogin)
        {
            LoginAdminStatus status = objAdminLogin.AdminLogin(objAdminLogin);
            if (status == LoginAdminStatus.Successfull)
                return RedirectToAction("CreateMail");

            else if (status == LoginAdminStatus.IncorrectPassowrd)
            {
                ModelState.AddModelError("", "Incorrect password");
                return View();
            }
            else if (status == LoginAdminStatus.NotRegisterd)
            {
                ModelState.AddModelError("", "Admin not registered");
                return View();
            }
            else
                return View(objAdminLogin);
        }

        [HttpGet, ActionName("RegisterAdmin")]
        public ActionResult RegisterAdmin()
        {
           ViewBag.dataAdmin = objAdmin.GetAllData();
            return View();
        }
        [HttpPost, ActionName("RegisterAdmin")]
        public ActionResult AddNewAdmin(Admin objAdmin)
        {
            bool isAdded = objAdmin.AddNewAdmin(objAdmin);
            if (isAdded)
                TempData["AlertMessage"] = "Registration Successfull";

            else
                TempData["AlertMessage"] = "Registration Failed";

            return RedirectToAction("RegisterAdmin");
        }
 
        [ActionName("DeleteAdmin")]
        public ActionResult DeleteAdminById(int id)
        {
            bool isDeleted = objAdmin.DeleteAdminById(id);
            return RedirectToAction("RegisterAdmin");
        }
     
        [HttpGet, ActionName("AddNewPersonType")]
        public ActionResult AddNewPersonType()
        {
            return View();
        }
  

        [HttpPost, ActionName("AddNewPersonType")]
        public ActionResult AddNewPersonType(PersonType objPersonType)
        {
            bool isDeleted = objPersonType.AddNewPersonType(objPersonType);
            return RedirectToAction("AddPersonType");
        }

        [ActionName("AddNewMailCategory")]
        public bool AddNewMailCategory(MailCategory objMailCategory)
        {
            bool isAdded = objMailCategory.AddNewMailCategory(objMailCategory);
            if (isAdded)
                return true;
            else
                return false;
        }

        [HttpGet, ActionName("ViewAllMailCategory")]
        public ActionResult ViewAllMailCategory(int? id)
        {
            ViewBag.Id = id;
            List<MailCategory> dataMailCategory = new List<MailCategory>();
            dataMailCategory = objMailCategory.GetAllData();
            return View(dataMailCategory);
        }
        [HttpPost, ActionName("ViewAllMailCategory")]
        public ActionResult ViewAllMailCategory(MailCategory objMailCategory)
        {
            bool isAdded = AddNewMailCategory(objMailCategory);
            List<MailCategory> dataMailCategory = new List<MailCategory>();
            dataMailCategory = objMailCategory.GetAllData();
            return View(dataMailCategory);
        }
        [ActionName("DeleteMailCategory")]
        public ActionResult DeleteMailCategoryById(int id)
        {
            bool isDeleted = objMailCategory.DeleteMailCategoryById(id);
            return RedirectToAction("ViewAllMailCategory");
        }
        [HttpGet, ActionName("ViewAllPersonType")]
        public ActionResult ViewAllPersonType(int? id)
        {
            ViewBag.Id = id;
            List<PersonType> dataPersonType = new List<PersonType>();
            dataPersonType = objPersonType.GetAllData();
            return View(dataPersonType);
        }
        [HttpPost, ActionName("ViewAllPersonType")]
        public ActionResult ViewAllPersonType(PersonType objPersonType)
        {
            bool isAdded = objPersonType.AddNewPersonType(objPersonType);
            return View(objPersonType.GetAllData());
 }
        [ActionName("DeletePersonType")]
        public ActionResult DeletePersonTypeById(int id)
        {
            bool isDeleted = objPersonType.DeletePersonTypeById(id);
            return RedirectToAction("ViewAllPersonType");
        }

        [HttpGet, ActionName("ViewAllPerson")]
        public ActionResult ViewAllPerson(int? id)
        {
            ViewBag.id = id;
            ViewBag.dataPersonType = objPersonType.GetAllData();
            return View(objPerson.GetAllData());
        }
        [HttpPost, ActionName("ViewAllPerson")]
        public ActionResult ViewAllPerson(Person objPerson)
        {
            bool isAdded = objPerson.AddPerson(objPerson);
            return RedirectToAction("ViewAllPerson");
        }
        [ActionName("DeletePerson")]
        public ActionResult DeletePersonById(int id)
        {
            bool isDeleted = objPerson.DeletePersonById(id);
            return RedirectToAction("ViewAllPerson");
        }
        [HttpGet, ActionName("ViewAllSendMail")]
        public ActionResult ViewAllSendMail()
        {
            ViewBag.dataMailCategory = objMailCategory.GetAllData();
            ViewBag.dataAdmin = objAdmin.GetAllData();
            List<Mails> dataMails = objMails.GetAllData();
            return View(dataMails);
        }
    }
}