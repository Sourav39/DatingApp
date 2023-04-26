using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppApi.DTOs;
using DatingAppApi.Entities;

namespace DatingAppApi.Repositories
{
    public interface IAccountRepository
    {
        Task<UserDTO> RegisterUser(string username, string password);
        Task<bool> UserExists(string username);
        Task<UserDTO> Login(LoginDTO loginDTO);
    }
}