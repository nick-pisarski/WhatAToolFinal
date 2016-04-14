using CoderCamps.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Models;

namespace WhatAToolFinal.Infastructure
{
    public class ToolApplicationUserRepository : GenericRepository<ToolApplicationUser>
    {
        public ToolApplicationUserRepository(ApplicationDbContext db) : base(db) { }

        public IQueryable<ToolApplicationUser> GetCurrentTAUByToolId(int tId, string username)
        {
            return (from tau in _db.ToolApplicationUsers
                    where tau.ToolId == tId && tau.ApplicationUser.UserName == username && tau.ReturnDate == null
                    select tau);

        }

        

    }


}