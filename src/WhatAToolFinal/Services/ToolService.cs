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


    {

        private ToolRepository _toolRepo;

        private ToolApplicationUserRepository _tauRepo;

        private ApplicationUserRepository _auRepo;

        public ToolService(ToolRepository toolRepo, ToolApplicationUserRepository tauRepo, ApplicationUserRepository auRepo)
        {
            _toolRepo = toolRepo;
            _tauRepo = tauRepo;
            _auRepo = auRepo;

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
            return _toolRepo.GetToolById(id).Select(t => new ToolDetailDTO
            {
                Name = t.Name,
                Id = t.Id,
                Status = t.Status,
                Category = t.Category.Name,
                ImageURL = t.ImgUrl,
                MachineHours = t.MachineHours,
                Manufacturer = t.Manufacturer,
            }).FirstOrDefault();
        }

        public DateTime? ReturnTool(ReturnToolModelDTO tool, string username)
        {
            //get ToolAppUser
            ToolApplicationUser tau = _tauRepo.GetCurrentTAUByToolId(tool.ToolId, username).Include(t => t.Tool).FirstOrDefault();

            if (tau != null)
            {
                //update return date
                tau.ReturnDate = DateTime.Now;
                
                //update a status and machinehours, save changes
                tau.Tool.Status = "Available";
                tau.Tool.MachineHours += tool.MachineHours;

                //save changees
                _toolRepo.SaveChanges();
            }
            return tau?.ReturnDate.Value;
        }

        public void CheckOutTool(ReturnToolModelDTO tool, string username)
        {
            //get the tool by Id
            Tool t = _toolRepo.GetToolById(tool.ToolId).FirstOrDefault();
            ApplicationUser u = _auRepo.GetPersonByUserName(username).FirstOrDefault();

            if (t != null && u.Id != null)
            {
                //update a status save changes
                t.Status = "Unavailable";

                //Create tau
                ToolApplicationUser tau = new ToolApplicationUser
                {
                    UserId = u.Id,
                    ToolId = tool.ToolId,
                    CheckOutDate = DateTime.Now
                };
                _tauRepo.Add(tau);

                //save changees
                _toolRepo.SaveChanges();
            }
        }

    }
}
