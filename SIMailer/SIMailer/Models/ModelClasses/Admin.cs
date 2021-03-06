﻿using SIMailer.Enums;
using SIMailer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIMailer.Models.ModelClasses
{
    public class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailId { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        AdminRepository objAdminRepository = new AdminRepository();
        #region Login Admin
        public LoginAdminStatus AdminLogin(Admin objAdminLogin)
        {
            LoginAdminStatus status = objAdminRepository.AdminLogin(objAdminLogin);
            return status;
        }
        #endregion

        #region Add New Admin
        public AdminRgistrationStatus AddNewAdmin(Admin objAdminRegister)
        {
            AdminRgistrationStatus isAdded = objAdminRepository.AddNewAdmin(objAdminRegister);
            return isAdded;
        }
        #endregion

        #region Delete Admin By Id
        public bool DeleteAdminById(int AdminId)
        {
            bool isDeleted = objAdminRepository.DeleteAdminById(AdminId);
            return isDeleted;
        }
        #endregion

        #region Get All Data OF Admin
        public List<Admin> GetAllData()
        {
            List<Admin> dataAdmin = objAdminRepository.GetAllData();
            return dataAdmin;
        } 
        #endregion
    }
}