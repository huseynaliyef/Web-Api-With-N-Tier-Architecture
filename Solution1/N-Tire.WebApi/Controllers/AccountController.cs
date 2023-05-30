using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using N_Tire.BusinessLogic.Abstractions;
using N_Tire.BusinessLogic.Logics;
using N_Tire.BusinessLogic.Models.DTO.Account;
using System.Threading.Tasks;

namespace N_Tire.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountLogic _accountLogic;
        public AccountController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleUIDTO r)
        {
            var operation = await _accountLogic.CreateRole(r);
            if (operation)
            {
                return Ok("Role Successfully Created.");
            }
            else
            {
                return Ok("The role has already been created!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUIDTO u)
        {
            var operation = await _accountLogic.Register(u);
            if(operation)
            {
                return StatusCode(StatusCodes.Status201Created, "Resgistration is successfully.");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, "Resgistration is unsuccessfully!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUIDTO user)
        {
            var operation  = await _accountLogic.Login(user);
            if (operation)
            {
                return StatusCode(StatusCodes.Status200OK, "Logined successfully.");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, "Email or Password is wrong!");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountLogic.Logout();
            return Ok("Successfully logout.");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateYourData(UpdateUIDTO u)
        {
            var operation = await _accountLogic.Update(u);
            if(operation)
            {
                await _accountLogic.Logout();
                return Ok("Your data is updated successfully.");
            }
            else
            {
                return Ok("Email or Password is wrong!");
            }
        }
    }
}
