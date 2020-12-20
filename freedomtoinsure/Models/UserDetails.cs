using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace freedomtoinsure.Models
{
    public class UserDetails
    {
        [Required]
        public int UserDetailsId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
       
    }
}
