using FootHub.Models;
using FootHub.Models.DataBase;
using FootHub.Models.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using BCrypt.Net;

namespace FootHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FootHubDBContext dbContext;
        public UserController(FootHubDBContext dBContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto userdto)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userdto.Password);
            var user = new User
            {
                Id = userdto.Id,
                Name = userdto.Name,
                Email = userdto.Email,
                Password = hashedPassword,
                Role = userdto.Role
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var userToUpdate = dbContext.Users.Find(id);
            if (userToUpdate != null)
            {
                return NotFound();
            }
            else
            {
                userToUpdate.Id = updateUserDto.Id;
                userToUpdate.Name = updateUserDto.Name;
                userToUpdate.Email = updateUserDto.Email;
                userToUpdate.Password = updateUserDto.Password;
                userToUpdate.Role = updateUserDto.Role;
            }
            dbContext.Users.Update(userToUpdate);
            dbContext.SaveChanges();

            return Ok();
        }
        public bool CheckIfUserExists (int id)
        {
            var entry = dbContext.Users.Find(id);
            if (entry == null)
                return false;
            else
                return true;
        }
        [HttpGet]
        public IActionResult CheckRole(User user)
        {
            var entry = dbContext.Users
                .Find(user.Id);

            if (entry == null)
                return NotFound();
            else
            {
                return RedirectToAction("Admin");
            }
        }
        
        

    }
}
