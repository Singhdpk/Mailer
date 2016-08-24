using SIMailer.Enums;
using SIMailer.Models.ModelClasses;
using System;
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
        SendTo objSendTo = new SendTo();
        [HttpGet, ActionName("CreateMail")]
        public ActionResult CreateAndEditMail(int? id)
        {
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
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
            objMails.AdminId = Convert.ToInt32(Session["AdminId"]);
            if (objMails.CategoryId == 0 && objMails.mailCategories.Category != null)
            {
                bool isCategoryAdded = objMailCategory.AddGetMailCategoryId(objMails);
            }
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
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet, ActionName("Login")]
        public ActionResult Login()
        {
            if (Convert.ToInt32(Session["AdminId"]) != 0)
            {
                return RedirectToAction("Home");
            }
            Session["AdminId"] = 0;
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult AdminLogin(Admin objAdminLogin)
        {
            LoginAdminStatus status = objAdminLogin.AdminLogin(objAdminLogin);
            if (status == LoginAdminStatus.Successfull)
            {
                Session["AdminId"] = objAdminLogin.Id;
                return RedirectToAction("Home");
            }

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
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.dataAdmin = objAdmin.GetAllData();
            return View();
        }
        [HttpPost, ActionName("RegisterAdmin")]
        public ActionResult AddNewAdmin(Admin objAdmin)
        {
            AdminRgistrationStatus isAdded = objAdmin.AddNewAdmin(objAdmin);
            if (isAdded == AdminRgistrationStatus.Successfull)
                TempData["AlertMessageAdmin"] = "Registration Successfull";

            else if (isAdded == AdminRgistrationStatus.AlreadyRegistered)
                TempData["AlertMessageAdmin"] = "Already Registered";
            else
                TempData["AlertMessageAdmin"] = "Registration Failed";

            return RedirectToAction("RegisterAdmin");
        }

        [ActionName("DeleteAdmin")]
        public ActionResult DeleteAdminById(int id)
        {
            bool isDeleted = objAdmin.DeleteAdminById(id);
            return RedirectToAction("RegisterAdmin");
        }



        [HttpGet, ActionName("ViewAllMailCategory")]
        public ActionResult ViewAllMailCategory(int? id)
        {
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Id = id;
            List<MailCategory> dataMailCategory = new List<MailCategory>();
            dataMailCategory = objMailCategory.GetAllData();
            return View(dataMailCategory);
        }
        [HttpPost, ActionName("ViewAllMailCategory")]
        public ActionResult ViewAllMailCategory(MailCategory objMailCategory)
        {
            bool isAdded = objMailCategory.AddNewMailCategory(objMailCategory);
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
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
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
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.id = id;
            ViewBag.dataPersonType = objPersonType.GetAllData();
            return View(objPerson.GetAllData());
        }
        [HttpPost, ActionName("ViewAllPerson")]
        public ActionResult ViewAllPerson(Person objPerson)
        {
           

            AddPersonStatus isAdded = objPerson.AddPerson(objPerson);

            if (isAdded == AddPersonStatus.Successfull)
                TempData["AlertMessagePerson"] = "Person Successfully Added";

            else if (isAdded == AddPersonStatus.AlreadyRegistered)
                TempData["AlertMessagePerson"] = "Person with this EMail Already Registered";
            else if(isAdded == AddPersonStatus.IsEdited)
                TempData["AlertMessagePerson"] = "Person Edited Successfully";
            else
                TempData["AlertMessagePerson"] = "Unable to add new person";


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
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.dataMailCategory = objMailCategory.GetAllData();
            ViewBag.dataAdmin = objAdmin.GetAllData();
            List<Mails> dataMails = objMails.GetAllData();
            return View(dataMails);
        }
        [HttpGet, ActionName("ViewAllSendTo")]
        public ActionResult ViewAllSendTo()
        {
            if (Convert.ToInt32(Session["AdminId"]) == 0)
            {
                return RedirectToAction("Login");
            }
            ViewBag.dataMailCategory = objMailCategory.GetAllData();
            ViewBag.dataMails = objMails.GetAllData();
            ViewBag.dataPerson = objPerson.GetAllData();
            ViewBag.dataAdmin = objAdmin.GetAllData();
            return View(objSendTo.GetAllData());
        }
    }
}