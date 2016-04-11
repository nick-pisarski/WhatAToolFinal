using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WhatAToolFinal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System.Security.Claims;

namespace WhatAToolFinal.Models
{
    public class SampleData2
    {

        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            db.Database.Migrate();

            //Category List
#region
            List<Category> cats = new List<Category>() {
                new Category { Name = "Drill" },
                new Category { Name = "Hammer" },
                new Category { Name = "Heavy Equipment" },
                new Category { Name = "Sander" },
                new Category { Name = "Saw" },
                new Category { Name = "Vehicle" }
            };

            for (int i = 0; i < cats.Count; i++)
            {
                var dbCat = db.Categorys.FirstOrDefault(c => c.Name == cats[i].Name);
                cats[i] = dbCat ?? cats[i];
                if (dbCat != cats[i])
                {
                    db.Categorys.Add(cats[i]);
                }
            }
            db.SaveChanges();
            #endregion
            //User dummy list - 6 total
            #region 
            //ApplicationUser = Name, Title, ImgUrl
            List<ApplicationUser> users = new List<ApplicationUser>();
            var gary = await userManager.FindByNameAsync("gary@email.com");
            if (gary == null)
            {
                // create user
                gary = new ApplicationUser
                {
                    UserName = "gary@email.com",
                    Email = "gary@email.com", 
                    Name = "Gary Johnson",
                    Title = "Technician"
                };
                await userManager.CreateAsync(gary, "Secret123!");
                
            }
            users.Add(gary);

            var mark = await userManager.FindByNameAsync("mark@email.com");
            if (mark == null)
            {
                // create user
                mark = new ApplicationUser
                {
                    UserName = "mark@email.com",
                    Email = "mark@email.com",
                    Name = "Mark O'Malley",
                    Title = "Warehouse Manager"
                };
                await userManager.CreateAsync(mark, "Secret123!");
                // add claims
                await userManager.AddClaimAsync(mark, new Claim("IsAdmin", "true"));
            }
            users.Add(mark);

            var art = await userManager.FindByNameAsync("art@email.com");
            if (art == null)
            {
                // create user
                art = new ApplicationUser
                {
                    UserName = "art@email.com",
                    Email = "art@email.com",
                    Name = "Art O'Malley",
                    Title = "Lead Mechanic"
                };
                await userManager.CreateAsync(art, "Secret123!");
                // add claims
                await userManager.AddClaimAsync(art, new Claim("IsAdmin", "true"));
            }
            users.Add(art);

            var ben = await userManager.FindByNameAsync("ben@email.com");
            if (ben == null)
            {
                // create user
                ben = new ApplicationUser
                {
                    UserName = "ben@email.com",
                    Email = "ben@email.com",
                    Name = "Ben Williams",
                    Title = "Mechanic"
                };
                await userManager.CreateAsync(ben, "Secret123!");
                
            }
            users.Add(ben);

            var chris = await userManager.FindByNameAsync("chris@email.com");
            if (chris == null)
            {
                // create user
                chris = new ApplicationUser
                {
                    UserName = "chris@email.com",
                    Email = "chris@email.com",
                    Name = "Chris Conner",
                    Title = "Custodian"
                };
                await userManager.CreateAsync(chris, "Secret123!");
               
            }
            users.Add(chris);

            var john = await userManager.FindByNameAsync("john@email.com");
            if (john == null)
            {
                // create user
                john = new ApplicationUser
                {
                    UserName = "john@email.com",
                    Email = "john@email.com",
                    Name = "John Francis",
                    Title = "Mechanic"
                };
                await userManager.CreateAsync(john, "Secret123!");
                
            }
            users.Add(john);
            #endregion
            //Tool dummy list - 8 total
            #region
            //Tool = Name, Manufacturer, Category, Status, Location, ImgUrl, MachineHours
            List<Tool> tools = new List<Tool>() {
            new Tool
            {
                Name = "LDX120C Drill",
                Manufacturer = "Black & Decker",
                Category = cats.First(c => c.Name == "Drill"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 19.0,
                ImgUrl = "http://whichcordlessdrill.com/wp-content/uploads/2014/01/1390078498041_Black-Decker-LDX120C.jpg",
            },
            new Tool
            {
                Name = "RK1806K2 Drill",
                Manufacturer = "Rockwell",
                Category = cats.First(c => c.Name == "Drill"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 0.0,
                ImgUrl = "http://ecx.images-amazon.com/images/I/81O-wOBUWTL._SX425_.jpg",
            },
            new Tool
            {
                Name = "TR89100 Electric Demolition Jackhammer",
                Manufacturer = "TR Industrial",
                Category = cats.First(c => c.Name == "Heavy Equipment"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 4.0,
                ImgUrl = "http://hydra-lister-old.s3-website-us-west-1.amazonaws.com/TR_Industrial_TR89100_Electric_Demolition_Jackhammer_With_3__0_res.jpg",
            },
            new Tool
            {
                Name = "51-624 20-Ounce Hammer",
                Manufacturer = "Stanley",
                Category = cats.First(c => c.Name == "Hammer"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 8.5,
                ImgUrl = "http://www.stanleytools.com/_Classes/SBDShared/Customizations/Imageresizer.ashx?path=Uv9nPfrJg/gTIssExi49kLutpsz4DwUkU3njX8bp1zKauTh1EVTNjPdNWYzLkTvX&w=0&h=0&crop=false&defaultimage=3JhL/PUahpIaPibUqpKcvsjGu1JWj+osbe7R/cQRRNiLtCt/eLtifIk9TjIcZinBABrQPjh3GNQdXdRx/18X4kFiMVwsALC9N/hW3nQB81gAPl8m7ATYqPieXgn8p/He/ov2d74cKXaK7MbJY5G4nA==",
            },
            new Tool
            {
                Name = "BO4556K 2.0 Amp 4-1/2-Inch Finishing Sander",
                Manufacturer = "Makita",
                Category = cats.First(c => c.Name == "Sander"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 13.5,
                ImgUrl = "http://ecx.images-amazon.com/images/I/41juLu5bMGL._AA160_.jpg",
            },
            new Tool
            {
                Name = "Evolv 12 amp Corded 7 1/4-in Circular Saw",
                Manufacturer = "Craftsman",
                Category = cats.First(c => c.Name == "Saw"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 37.5,
                ImgUrl = "http://ecx.images-amazon.com/images/I/71%2BGoVObMOL._SL1000_.jpg",
            },
            new Tool
            {
                Name = "19.2 Volt Reciprocating Saw Variable Speed",
                Manufacturer = "Craftsman",
                Category = cats.First(c => c.Name == "Saw"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 22.0,
                ImgUrl = "http://ecx.images-amazon.com/images/I/61YB1F-G%2BKL._SL1458_.jpg",
            },
            new Tool
            {
                Name = "K1170 AC225S Stick Welder",
                Manufacturer = "Lincoln Electric",
                Category = cats.First(c => c.Name == "Heavy Equipment"),
                Status = "Available",
                Location = "Warehouse",
                MachineHours = 87.5,
                ImgUrl = "http://ecx.images-amazon.com/images/I/41UCrD3ywIL.jpg",
            },
        };
            #endregion

            for (int i = 0; i < tools.Count; i++)
            {
                var dbTool = db.Tools.FirstOrDefault(t => t.Name == tools[i].Name);
                tools[i] = dbTool ?? tools[i];
                if (tools[i] != dbTool)
                {
                    // use user manager
                    db.Tools.Add(tools[i]);
                }
            }
            db.SaveChanges();

            //ToolApplicationUser dummy list
            #region
            //ToolApplicationUser = PersonId, ToolId, CheckOutDate, ReturnDate
            List<ToolApplicationUser> tp = new List<ToolApplicationUser> {
            new ToolApplicationUser
            {
                UserId = users[1].Id,
                ToolId = tools[2].Id,
                CheckOutDate = new DateTime(2015, 7, 25), //(yyyy,mm,dd)
                ReturnDate = new DateTime(2015, 7, 26),
            },
            new ToolApplicationUser
            {
                UserId = users[2].Id,
                ToolId = tools[4].Id,
                CheckOutDate = new DateTime(2015, 7, 25),
                ReturnDate = new DateTime(2015, 7, 31),
            },
            new ToolApplicationUser
            {
                UserId = users[3].Id,
                ToolId = tools[7].Id,
                CheckOutDate = new DateTime(2015, 8, 25),

            },
            new ToolApplicationUser
            {
                UserId = users[3].Id,
                ToolId = tools[4].Id,
                CheckOutDate = new DateTime(2015, 7, 25),
                ReturnDate = new DateTime(2015, 7, 27),
            },
            new ToolApplicationUser
            {
                UserId = users[5].Id,
                ToolId = tools[6].Id,
                CheckOutDate = new DateTime(2015, 7, 25),

            }
        };
            #endregion
            for (int i = 0; i < tp.Count; i++)
            {
                var dbToolApplicationUser = db.ToolApplicationUsers.FirstOrDefault(t => t.Id == tp[i].Id);
                tp[i] = dbToolApplicationUser ?? tp[i];
                if (tp[i] != dbToolApplicationUser)
                {
                    // use user manager
                    db.ToolApplicationUsers.Add(tp[i]);
                }
            }
            db.SaveChanges();



        }
    }
}
