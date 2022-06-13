using CRUD_Application.BusinessAccessLayer.Interfaces;
using CRUD_Application.DataAccessLayer;
using CRUD_Application.DataAccessLayer.EntitieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Application.Models;

namespace CRUD_Application.BusinessAccessLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool AddUsers(RegistrationModel model)
        {
            Users Users = new Users()
            {
                Email = model.Email,
                FistName = model.FistName,
                CreatedBy = model.FistName,
                CreatedDate = DateTime.Now,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Password = model.Password,
                ModifyedBy=model.FistName,
                ModifyedDate=DateTime.Now,
                
            };
            context.Users.Add(Users);
            int i = context.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateUsers(RegistrationModel model)
        {
            var emp = context.Users.Find(model.Id);
            if (emp == null)
            {
                return false;
            }
            emp.FistName = model.FistName;
            model.LastName = model.LastName;
            emp.LastName = model.LastName;
            emp.Mobile = model.Mobile;

            context.Users.Update(emp);
            int i = context.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteUsers(int Usersid)
        {
            var emp = context.Users.Find(Usersid);
            if (emp == null)
            {
                return false;
            }
            context.Users.Remove(emp);
            int i = context.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            return false;
        }

        public List<RegistrationModel> GetAllUsers()
        {
            var Userss = context.Users.Select(
                x =>
                new RegistrationModel()
                {
                    LastName = x.LastName,
                    Mobile = x.Mobile,
                    FistName = x.FistName,
                    //Password = x.Password,  
                    Email = x.Email,
                    Id = x.Id
                }
                ).ToList();
            return Userss;
        }

        public RegistrationModel GetUsersById(int Usersid)
        {
            var Userss = context.Users.Where(x => x.Id == Usersid).Select(
               x =>
               new RegistrationModel()
               {
                   LastName = x.LastName,
                   Mobile = x.Mobile,
                   FistName = x.FistName,
                   //Password = x.Password,  
                   Email = x.Email,
                   Id = x.Id
               }
               ).FirstOrDefault();
            return Userss;
        }

    }
}
