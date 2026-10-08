using MegoStore.Application.Dtos;
using MegoStore.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterDto dto);
         //Task<AuthModel> CreateJwtToken(TokenRequestModel model);
         Task<AuthModel?> LoginAsync(LoginDto loginDto);
        Task<string> AddRoleAsync(AddRoleModel model);



    }
}
