using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using backend.Context;
using backend.Models.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        public UserController(AppDbContext context)
        {   
            this.context = context;
        }

        [HttpGet("{email}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(string email)
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.Email == email);
            if(user == null)
            {
                var userJson = new User
                {
                    Email = null,
                    Name = null
                };
                return Ok(userJson);
            }

            string userIdJson = JsonSerializer.Serialize(user.Id);

            Response.Cookies.Append("UserIdCookie", userIdJson, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(1)
            });
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            var userExist = await context.User.AnyAsync(u => u.Email == user.Email);
            if(userExist)
            {
                throw new Exception("Email já cadastrado");
            }
            context.User.Add(user);
            await context.SaveChangesAsync();

            return Ok(user);
        }
    }
}