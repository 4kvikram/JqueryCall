using CRUD_Application.BusinessAccessLayer.Interfaces;
using CRUD_Application.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(RegistrationModel model)
        {
            var result = _userRepository.AddUsers(model);
            if (result)
            {
                ResponseModel responseModel = new ResponseModel()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "User Registered sussessfully"
                };
                return Ok(responseModel);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        [HttpGet]
        [Route("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var result = _userRepository.GetUsersById(id);
            if (result != null)
            {
                ResponseModel responseModel = new ResponseModel()
                {
                    IsSuccess = true,
                    Data = result,
                    Message = "User found Successfully"
                };
                return Ok(responseModel);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userRepository.DeleteUsers(id);
            if (result)
            {
                ResponseModel responseModel = new ResponseModel()
                {
                    IsSuccess = true,
                    Data = result,
                    Message = "User deleted Successfully"
                };
                return Ok(responseModel);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var result = _userRepository.GetAllUsers();
            if (result != null)
            {
                ResponseModel responseModel = new ResponseModel()
                {
                    IsSuccess = true,
                    Data = result,
                    Message = "User list "
                };
                return Ok(responseModel);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


       
        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(RegistrationModel model)
        {
            var result = _userRepository.UpdateUsers(model);
            if (result)
            {
                ResponseModel responseModel = new ResponseModel()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "User updated sussessfully"
                };
                return Ok(responseModel);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
