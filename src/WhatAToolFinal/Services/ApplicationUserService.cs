using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Infastructure;
using WhatAToolFinal.Models;
using WhatAToolFinal.Services.ModelDTO;

namespace WhatAToolFinal.Services
{
    public class ApplicationUserService
    {
        private ApplicationUserRepository _auRepo;

        public ApplicationUserService(ApplicationUserRepository auRepo)
        {
            _auRepo = auRepo;
        }

        public ICollection<AppUserDTO> ListAllUsers()
        {
            return _auRepo.List().Select(u => new AppUserDTO {
                Id = u.Id,
                Name = u.Name,
                Title = u.Title
            
            }).ToList();
        }
        public AppUserDTO GetUserById(string id)
        {
            return _auRepo.GetPersonById(id).Select(u => new AppUserDTO {
                Id = u.Id,
                Name = u.Name,
                Title = u.Title
            }).FirstOrDefault();
        }
       

    }
}
