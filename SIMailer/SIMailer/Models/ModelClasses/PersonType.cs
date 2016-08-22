using SIMailer.Repositories;
using System.Collections.Generic;

namespace SIMailer.Models.ModelClasses
{
    public class PersonType
    {

        public int Id { get; set; }
        public string Name { get; set; }
        PersonTypeRepository objPersonTypeRepository = new PersonTypeRepository();

  
        public bool AddNewPersonType(PersonType objPersonType)
        {
            bool isAdded = objPersonTypeRepository.AddNewPersonType(objPersonType);
            return isAdded;
        }


        public List<PersonType> GetAllData()
        {
            List<PersonType> dataPersonType = new List<PersonType>();
            dataPersonType = objPersonTypeRepository.GetAllData();
            return dataPersonType;
        } 
    

        public bool DeletePersonTypeById(int id)
        {
            bool isDeleted = objPersonTypeRepository.DeletePersonTypeById(id);
            return isDeleted;
        }
    }
}