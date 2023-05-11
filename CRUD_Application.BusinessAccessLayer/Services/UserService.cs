using CRUD_Application.BusinessAccessLayer.Interfaces;
using CRUD_Application.DataAccessLayer;
using CRUD_Application.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace CRUD_Application.BusinessAccessLayer.Services
{
    /// <summary>
    /// using store procedure
    /// </summary>
    public class UserService : IUserRepository
    {
        private readonly AppDbContext context;

        public UserService(AppDbContext context)
        {
            this.context = context;
        }
        public bool AddUsers(RegistrationModel model)
        {
            var FistName = new SqlParameter("@FistName", model.FistName);
            var LastName = new SqlParameter("@LastName", model.LastName);
            var Mobile = new SqlParameter("@Mobile", model.LastName);
            var Email = new SqlParameter("@Email", model.Email);
            var Password = new SqlParameter("@Password", model.Password);
            var id = new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
                Value = 0
            };
            string sql = "exec USP_RegisterUser @FistName,@LastName,@Mobile,@Email,@Password, @id OUT";
            var res = context.Database.ExecuteSqlRaw(sql, FistName, LastName, Mobile, Email, Password, id);
            if (res > 0)
            {
                var userid = Convert.ToInt32(id.Value);
                if (userid > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteUsers(int employeeid)
        {
            var res = context.Database.ExecuteSqlRaw($"delete from tblUsersDetails where id={employeeid}");
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public List<RegistrationModel> GetAllUsers()
        {
            return null;
            var data = context.Users.FromSqlRaw("select * from tblUsersDetails").Select(
                x => new RegistrationModel()
                {
                    Email = x.Email,
                    FistName = x.FistName,
                    Id = x.Id,
                    LastName = x.LastName,
                    Mobile = x.Mobile
                }
                ).ToList();
            //var newdata = data.OrderByDescending(x => x.Id).ToList();
            return data;
        }

        public RegistrationModel GetUsersById(int employeeid)
        {
            var data = context.Users.FromSqlRaw("select * from tblUsersDetails").Select(
                x => new RegistrationModel()
                {
                    Email = x.Email,
                    FistName = x.FistName,
                    Id = x.Id,
                    LastName = x.LastName,
                    Mobile = x.Mobile
                }
                ).FirstOrDefault();
            return data;
        }

        public bool UpdateUsers(RegistrationModel model)
        {
            var FistName = new SqlParameter("@FistName", model.FistName);
            var LastName = new SqlParameter("@LastName", model.LastName);
            var Mobile = new SqlParameter("@Mobile", model.LastName);
            var id = new SqlParameter()
            {
                ParameterName = "@id",
                Value = model.Id
            };
            string sql = "exec USP_UpdateUser @FistName,@LastName,@Mobile, @id";
            var res = context.Database.ExecuteSqlRaw(sql, FistName, LastName, Mobile, id);
            if (res > 0)
            {
                return true;

            }
            return false;
        }
    }
}
