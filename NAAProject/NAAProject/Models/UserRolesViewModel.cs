using Microsoft.AspNetCore.Identity;
using NAAProject.Data.Models.Domain;
using System.Data;

namespace NAAProject.Models
{
    public class UserRolesViewModel
    {
        public List<IdentityUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
