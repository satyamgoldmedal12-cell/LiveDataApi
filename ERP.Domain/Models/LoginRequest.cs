using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Domain.Models
{
    public class LoginRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
