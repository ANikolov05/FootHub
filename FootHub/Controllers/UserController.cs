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
            var user = new User
            {
                Id = userdto.Id,
                Email = userdto.Email,
                Password = userdto.Password,
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
                userToUpdate.Email = updateUserDto.Email;
                userToUpdate.Password = updateUserDto.Password;
                dbContext.Users.Update(userToUpdate);
                dbContext.SaveChanges();
            }

            return Ok();
        }

    }
}
