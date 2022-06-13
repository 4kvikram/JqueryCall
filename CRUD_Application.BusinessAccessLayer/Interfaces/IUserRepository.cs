using CRUD_Application.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Application.BusinessAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        bool AddUsers(RegistrationModel model);
        bool UpdateUsers(RegistrationModel model);
        bool DeleteUsers(int employeeid);
        RegistrationModel GetUsersById(int employeeid);
        List<RegistrationModel> GetAllUsers();
    }
}
