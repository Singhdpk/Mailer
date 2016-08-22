using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SIMailer.Repositories
{
    public class PersonRepository
    {
        public bool AddPerson(Person objPerson)
        {
            try
            {
                if (objPerson.Id == 0)
                {
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                      
                        tblPerson objtblPerson = new tblPerson();
                        objtblPerson.EmailId = objPerson.EmailId;
                        objtblPerson.Name = objPerson.Name;
                        objtblPerson.TypeId = objPerson.TypeId;
                        db.tblPersons.AddObject(objtblPerson);
                        db.SaveChanges();

                    }
                }
                else
                {
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                   
                        tblPerson objtblPerson = new tblPerson();
                        objtblPerson.EmailId = objPerson.EmailId;
                        objtblPerson.Name = objPerson.Name;
                        objtblPerson.Id = objPerson.Id;
                        objtblPerson.TypeId = objPerson.TypeId;
                        db.tblPersons.Attach(objtblPerson);
                        db.ObjectStateManager.ChangeObjectState(objtblPerson, EntityState.Modified);
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



        #region Get List Of All Persons
        public List<Person> GetAllData()
        {
            List<Person> dataPerson = new List<Person>();
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    List<tblPerson> datatblPerson = new List<tblPerson>();
                    datatblPerson = db.tblPersons.ToList();
                    foreach (var item in datatblPerson)
                    {
                        dataPerson.Add(new Person
                        {
                            Id = item.Id,
                            EmailId = item.EmailId,
                            Name = item.Name,
                            TypeId = item.TypeId
                        });
                    }
                }
                return dataPerson;
            }
            catch (Exception ex)
            {

            }
            dataPerson = null;
            return dataPerson;
        }
        #endregion

        public bool DeletePersonById(int id)
        {
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    tblPerson objtblPerson = new tblPerson();
                    objtblPerson = db.tblPersons.First(data => data.Id == id);
                    if (objtblPerson != null)
                    {
                        db.tblPersons.DeleteObject(objtblPerson);
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
    }
}