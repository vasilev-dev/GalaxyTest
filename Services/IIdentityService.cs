using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyTest.Models;
using Microsoft.AspNetCore.Authentication;

namespace GalaxyTest.Services
{
    public interface IIdentityService
    {
        Task<AuthResult> RegisterAsync(string username, string password);
        Task<AuthResult> LoginAsync(string username, string password);
    }
}
