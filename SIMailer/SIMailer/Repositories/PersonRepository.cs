using SIMailer.Enums;
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
        public AddPersonStatus AddPerson(Person objPerson)
        {
            try
            {
                if (objPerson.Id == 0)
                {
                    tblPerson objtblPerson = new tblPerson();
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                        objtblPerson = db.tblPersons.First(data => data.EmailId == objPerson.EmailId);
                    }
                    if (objtblPerson == null)
                    {
                        using (dbSIMailerEntities db = new dbSIMailerEntities())
                        {


                            objtblPerson.EmailId = objPerson.EmailId;
                            objtblPerson.Name = objPerson.Name;
                            objtblPerson.TypeId = objPerson.TypeId;
                            db.tblPersons.AddObject(objtblPerson);
                            db.SaveChanges();
                            return AddPersonStatus.Successfull;
                        }
                    }
                    else
                    {
                        return AddPersonStatus.AlreadyRegistered;
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
                        return AddPersonStatus.IsEdited;
                    }
                }

                
            }
            catch (Exception ex)
            {
                return AddPersonStatus.Exception;
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