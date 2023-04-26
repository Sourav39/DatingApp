using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DatingAppApi.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection Services,
        IConfiguration config)
        {
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                       .AddJwtBearer(options =>
                       {
                           options.TokenValidationParameters = new TokenValidationParameters
                           {
                               ValidateIssuerSigningKey = true,
                               IssuerSigningKey = new SymmetricSecurityKey(Encoding.
                               UTF8.GetBytes(config["TokenKey"])),
                               ValidateIssuer = false,
                               ValidateAudience = false
                           };
                       });
            return Services;
        }
    }
}