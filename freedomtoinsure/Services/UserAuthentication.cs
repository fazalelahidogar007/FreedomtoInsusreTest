using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using freedomtoinsure.Context;
using freedomtoinsure.Helper;
using freedomtoinsure.IServices;
using freedomtoinsure.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace freedomtoinsure.Services
{
    public class UserAuthentication : IUserAuthentication
    {
        private readonly FreedomtoinsureDatabaseContext _context;
        private readonly AppSettings _appSettings;
        public UserAuthentication(IOptions<AppSettings> appSettings,
            FreedomtoinsureDatabaseContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public string Authenticate(Authentication login)
        {
            // Validate the User Credentials
            var userDetails = _context.userdetails.SingleOrDefault(
                x => x.UserName == login.Username && x.Password == login.Password
            );
            if (userDetails == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userDetails.UserDetailsId.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
