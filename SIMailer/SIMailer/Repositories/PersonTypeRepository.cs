using SIMailer.Models;
using SIMailer.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SIMailer.Repositories
{
    public class PersonTypeRepository
    {

        public bool AddNewPersonType(PersonType objPersonType)
        {
            try
            {
                if (objPersonType.Id == 0)
                {
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                        tblPersonType objtblPersontype = new tblPersonType();
                        objtblPersontype.Name = objPersonType.Name;
                        db.tblPersonTypes.AddObject(objtblPersontype);
                        db.SaveChanges();

                    }
                }
                else
                {
                    using (dbSIMailerEntities db = new dbSIMailerEntities())
                    {
                        tblPersonType objtblPersontype = new tblPersonType();
                        objtblPersontype.Name = objPersonType.Name;
                        objtblPersontype.Id = objPersonType.Id;
                        db.tblPersonTypes.Attach(objtblPersontype);
                        db.ObjectStateManager.ChangeObjectState(objtblPersontype, EntityState.Modified);
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


        public List<PersonType> GetAllData()
        {
            List<PersonType> dataPersonType = new List<PersonType>();
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    List<tblPersonType> datatblPersonType = new List<tblPersonType>();
                    datatblPersonType = db.tblPersonTypes.ToList();
                    foreach (var item in datatblPersonType)
                    {
                        dataPersonType.Add(new PersonType()
                        {
                            Id = item.Id,
                            Name = item.Name
                        });
                    }
                    return dataPersonType;
                }
            }
            catch (Exception ex)
            {

            }
            dataPersonType = null;
            return dataPersonType;
        }
        public bool DeletePersonTypeById(int id)
        {
            try
            {
                using (dbSIMailerEntities db = new dbSIMailerEntities())
                {
                    tblPersonType objtblPersonType = new tblPersonType();
                    objtblPersonType = db.tblPersonTypes.First(data => data.Id == id);
                    if (objtblPersonType != null)
                    {
                        db.tblPersonTypes.DeleteObject(objtblPersonType);
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