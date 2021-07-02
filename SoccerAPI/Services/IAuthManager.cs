using SoccerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerAPI.Services
{
    interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUser user);
        Task<string> CreateToken();
    }
}
