using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Models;
using CoderCamps.Infastructure;

namespace WhatAToolFinal.Infastructure
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>
    {
       
        public ApplicationUserRepository(ApplicationDbContext db) : base(db) { }

        public IQueryable<ApplicationUser> GetPersonById(string id)
        {
            return _db.Users.Where(p => p.Id == id).Select(p => p);
        }
        public IQueryable<ApplicationUser> GetPersonByUserName(string username)
        {
            return _db.Users.Where(p => p.UserName == username).Select(p => p);
        }
    }
}
