using DatingAppApi.Data;
using DatingAppApi.Entities;
using DatingAppApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/Users
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();

            if(users == null){
                return NotFound();
            }

            return Ok(users);
        }  

        //Synchronous version
        // [HttpGet] 
        // public ActionResult<IEnumerable<AppUser>> GetUsers()
        // {
        //     var users = _context.Users.ToList();
        //     if(users == null){
        //         return NotFound();
        //     }

        //     return users;
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
           var user = await _userRepository.GetUser(id);

           if(user == null)
           {
            return NotFound();
           }

           return Ok(user);
        }
    }
}