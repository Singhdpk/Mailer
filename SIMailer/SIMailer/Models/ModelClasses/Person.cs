using SIMailer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIMailer.Models.ModelClasses
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Display(Name = "Type")]
        [Required(ErrorMessage = "Required")]
        public int TypeId { get; set; }
        public bool isIncluded { get; set; }

        PersonRepository objPersonRepository = new PersonRepository();

        public bool AddPerson(Person objPerson)
        {
            bool isAdded = objPersonRepository.AddPerson(objPerson);
            return isAdded;
        }

   public List<Person> GetAllData()
        {
            List<Person> dataPerson = new List<Person>();
            dataPerson = objPersonRepository.GetAllData();
            return dataPerson;
        } 

        public bool DeletePersonById(int id)
        {
            bool isDeleted =objPersonRepository.DeletePersonById(id);
            return isDeleted;
        }
    }
}