using SIMailer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMailer.Models.ModelClasses
{
    public class MailCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }

        MailCategoryRepository objMailCategoryRepository = new MailCategoryRepository();
        public List<MailCategory> GetAllData()
        {
            List<MailCategory> dataMailCategory = new List<MailCategory>();
            dataMailCategory = objMailCategoryRepository.GetAllData();
            return dataMailCategory;
        }

        public bool DeleteMailCategoryById(int id)
        {
            bool isDeleted = objMailCategoryRepository.DeleteMailCategoryById(id);
            return isDeleted;
        }
        public bool EditMailCategoryById(MailCategory objMailCategory)
        {
            bool isEdited = objMailCategoryRepository.EditMailCategoryById(objMailCategory);
            return isEdited;
        }

        public bool AddNewMailCategory(MailCategory objMailcategory)
        {
            bool isAdded = objMailCategoryRepository.AddNewMailCategory(objMailcategory);
            return isAdded;
        }
    }
}