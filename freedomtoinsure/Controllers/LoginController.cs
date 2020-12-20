
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using freedomtoinsure.IServices;
using freedomtoinsure.Models;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace freedomtoinsure.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserAuthentication _userAuthentication;
        public LoginController(IUserAuthentication userAuthentication)
        {
            _userAuthentication = userAuthentication;
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
        // POST /UserLogin
        [AllowAnonymous]
        [HttpPost("UserLogin")]
        public IActionResult UserLogin([FromForm] Authentication login)
        {
            login.Password = CreateMD5(login.Password);
            var token = _userAuthentication.Authenticate(login);
            if (token == null)
                return BadRequest(new { message = "Wrong wwewcredentials" });
            return Ok(new { token });
        }
    }
}
