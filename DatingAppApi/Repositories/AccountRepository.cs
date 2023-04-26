using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatingAppApi.Data;
using DatingAppApi.DTOs;
using DatingAppApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
         private readonly ITokenService _tokenService;
        public AccountRepository(DataContext context, ITokenService tokenService)
        {
            _context = context;
             _tokenService = tokenService;
        }

        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(_=>_.UserName == loginDTO.Username);                        

            if( user == null) return null;
            
             using var hmac = new HMACSHA512(user.PasswordSalt);

             var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

             for(int i = 0; i < computedHash.Length; i++)
             {
                if(computedHash[i] != user.PasswordHash[i])
                {
                    return null;
                }                
             }
             return new UserDTO
             {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
             };
        }

        public async Task<UserDTO> RegisterUser(string username, string password)
        {
           using var hmac = new HMACSHA512();
           var user = new AppUser
          {
              UserName = username.ToLower(),
              PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
              PasswordSalt = hmac.Key
          };
         
          _context.Users.Add(user);
          await _context.SaveChangesAsync();

          return new UserDTO
          {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
          };
        }
      
        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(_=>_.UserName == username.ToLower());
        }
    }
}