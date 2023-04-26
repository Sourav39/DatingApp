using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppApi.Entities;

namespace DatingAppApi.Repositories
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}