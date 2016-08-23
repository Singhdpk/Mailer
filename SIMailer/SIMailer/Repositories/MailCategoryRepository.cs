using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SIMailer.Repositories
{
    public class MailCategoryRepository
    {
  
        public List<MailCategory> GetAllData()
        {
            List<MailCategory> dataMailCategory = new List<MailCategory>();
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    List<tblMailCategory> datatblMailCategory = new List<tblMailCategory>();
                    datatblMailCategory = db.tblMailCategories.ToList();
                    foreach (var item in datatblMailCategory)
                    {
                        dataMailCategory.Add(new MailCategory()
                        {
                            Id = item.Id,
                            Category = item.Category,
                        });
                    }
                }
                dataMailCategory.Add(new MailCategory {Category="Add new category" });
                return dataMailCategory;
            }
            catch (Exception ex)
            {

            }
            return dataMailCategory;
        }


        #region Add New Mail Category
        public bool AddNewMailCategory(MailCategory objMailcategory)
        {

            try
            {
                if (objMailcategory.Id == 0)
                {
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                        tblMailCategory objtblMailCategory = new tblMailCategory();
                        objtblMailCategory.Category = objMailcategory.Category;
                        db.tblMailCategories.AddObject(objtblMailCategory);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                        tblMailCategory objtblMailCategory = new tblMailCategory();
                        objtblMailCategory.Id = objMailcategory.Id;
                        objtblMailCategory.Category = objMailcategory.Category;
                        db.tblMailCategories.Attach(objtblMailCategory);
                        db.ObjectStateManager.ChangeObjectState(objtblMailCategory, EntityState.Modified);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        public bool DeleteMailCategoryById(int id)
        {
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    tblMailCategory objtblMailCategory = new tblMailCategory();
                    objtblMailCategory = db.tblMailCategories.First(data => data.Id == id);
                    if (objtblMailCategory != null)
                    {
                        db.tblMailCategories.DeleteObject(objtblMailCategory);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public bool EditMailCategoryById(MailCategory objMailCategory)
        {
            try
            {
                tblMailCategory objtblMailCategory = new tblMailCategory();
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {

                    objtblMailCategory = db.tblMailCategories.First(data => data.Id == objMailCategory.Id);

                }
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    if (objtblMailCategory != null)
                    {
                        objtblMailCategory.Category = objMailCategory.Category;
                        db.tblMailCategories.Attach(objtblMailCategory);
                        db.ObjectStateManager.ChangeObjectState(objtblMailCategory, EntityState.Modified);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public bool AddGetMailCategoryId(Mails objMails)
        {
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    tblMailCategory objtblMailCategory = new tblMailCategory();
                    objtblMailCategory.Category = objMails.mailCategories.Category;
                    db.tblMailCategories.AddObject(objtblMailCategory);
                    db.SaveChanges();
                    objMails.CategoryId = objtblMailCategory.Id;
                }
                    return true;
            }
            catch(Exception ex)
            {

            }
            return false;

           
        }
    }
}