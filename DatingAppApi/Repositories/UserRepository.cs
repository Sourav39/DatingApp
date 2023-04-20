using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppApi.Data;
using DatingAppApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingAppApi.Repositories
{
    public class UserRepository : IUserRepository
    {        
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(_ => _.Id == id);            
        }
    }
}