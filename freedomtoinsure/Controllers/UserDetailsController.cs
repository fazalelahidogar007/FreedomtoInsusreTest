using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using freedomtoinsure.IServices;
using freedomtoinsure.Models;
using System.Text;
using freedomtoinsure.Context;
using System.Threading.Tasks;
using System;
using System.Security.Claims;

namespace freedomtoinsure.Controllers
{
    public class UserDetailsController :ControllerBase
    {
        private readonly FreedomtoinsureDatabaseContext _context;

        public UserDetailsController(FreedomtoinsureDatabaseContext context)
        {
            _context = context;
        }

        // POST UserDetailsADD
        //[Authorize]
        [HttpPost("UserDetailsADD")]
        public async Task<IActionResult> UserDetailsADD([FromForm] UserDetails userDetails)
        {
            try
            {
               // userDetails.UserDetailsId = int.Parse(User.FindFirst(ClaimTypes.Name)?.Value);
                userDetails.Password = CreateMD5(userDetails.Password);
              
                _context.userdetails.Add(userDetails);
                await _context.SaveChangesAsync();
                return Ok(new { result = true, userDetails });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Missing parameters or parameter equal to zero", userDetails });
            }
        }

        // Create MD5 hash for the password
        private string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }





    }
}