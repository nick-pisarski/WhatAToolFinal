using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatAToolFinal.Infastructure;
using WhatAToolFinal.Models;
using WhatAToolFinal.Services.ModelDTO;
using WhatAToolFinal.Services;
using Microsoft.Data.Entity;

namespace WhatAToolFinal.Services
{
    public class ToolService

        //Add ToolDTO
    {

        private ToolRepository _toolRepo;
        private ApplicationUserService _userServ;
        private ToolApplicationUserRepository _tauRepo;

        public ToolService(ToolRepository toolRepo, ToolApplicationUserRepository tauRepo)
        {
            _toolRepo = toolRepo;
            _tauRepo = tauRepo;
        //    _userServ = userServ;
        }

        public ICollection<ToolMainDTO> GetListOfTools()
        {
            return (from t in _toolRepo.List()
                    select new ToolMainDTO()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Category = t.Category.Name,
                        Status = t.Status,
                        Location = t.Location,
                        CurrentUser = (from tau in _tauRepo.List()
                                       where tau.ToolId == t.Id && tau.ReturnDate == null
                                       orderby tau.CheckOutDate descending
                                       select new UserDTO()
                                       {
                                           Name = tau.ApplicationUser.Name,
                                           Id = tau.ApplicationUser.Id
                                       }).FirstOrDefault()
                    }).ToList();
        }

        public ICollection<ToolMainDTO> GetListOfToolsByCategory(string category)
        {
            return _toolRepo.GetListOfToolsByCategory(category).Select(t => new ToolMainDTO
            {
                Name = t.Name,
                Id = t.Id,
                Status = t.Status,
                CurrentUser = (from tau in _tauRepo.List()
                               where tau.ToolId == t.Id && tau.ReturnDate == null
                               orderby tau.CheckOutDate descending
                               select new UserDTO()
                               {
                                   Name = tau.ApplicationUser.Name,
                                   Id = tau.ApplicationUser.Id
                               }).FirstOrDefault()
            }).ToList();
        }

        public ToolDetailDTO GetToolById(int id)
        {
            return _toolRepo.GetToolById(id).Select( t => new ToolDetailDTO
            {
                Name = t.Name,
                Id = t.Id,
                Status = t.Status,
                Category = t.Category.Name,
                ImageURL = t.ImgUrl,
            }).FirstOrDefault();
        }
    }
}
