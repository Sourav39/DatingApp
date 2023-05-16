using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppApi.DTOs;
using DatingAppApi.Entities;

namespace DatingAppApi.Repositories
{
    public interface IUserRepository
    {      
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<MemberDto>> GetMemberAsync();
        Task<MemberDto> GetMemberAsync(string username);
        Task<MemberDto> GetUser(int id);
    }
}