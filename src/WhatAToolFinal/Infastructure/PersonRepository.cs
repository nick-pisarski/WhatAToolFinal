using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Models;
using CoderCamps.Infastructure;

namespace WhatAToolFinal.Infastructure
{
    public class PersonRepository : GenericRepository<Person>
    {
       
        public PersonRepository(ApplicationDbContext db) : base(db) { }
               
        public IQueryable<Person> GetPersonById(int id)
        {
            return _db.Persons.Where(p => p.Id == id).Select(p => p);
        }
    }
}
