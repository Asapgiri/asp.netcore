using Logic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Instantgram.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        AuthLogic _authLogic;

        public AuthController(AuthLogic authLogic)
        {
            _authLogic = authLogic;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            string result = await _authLogic.RegisterUser(model);
            return Ok(new { UserName = result });
        }


        [HttpGet]
        [Route("users")]
        public IEnumerable<IdentityUser> GetUsers()
        {
            return _authLogic.GetAllUser();
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var res = await _authLogic.LoginUser(model);
                Console.WriteLine("token" + res.Token + ", uID: " + res.UserId);
                return Ok(res);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


    }
}
