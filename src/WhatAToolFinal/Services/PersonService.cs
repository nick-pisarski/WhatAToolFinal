using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Infastructure;
using WhatAToolFinal.Models;

namespace WhatAToolFinal.Services
{
    public class PersonService
    {

        private PersonRepository _personRepo;

        public PersonService(PersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public ICollection<Person> GetListOfPersons()
        {
            return _personRepo.List().ToList();
        }

        public Person GetPersonById(int id)
        {
            return _personRepo.GetPersonById(id).FirstOrDefault();
        }
    }
}
