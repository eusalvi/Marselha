using Microsoft.AspNetCore.Identity;
using System;

namespace Marselha.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Cpf { get; set; }
    }
}
