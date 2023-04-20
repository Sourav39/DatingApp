using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppApi.Entities;

namespace DatingAppApi.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();

        Task<AppUser> GetUser(int id);
    }
}