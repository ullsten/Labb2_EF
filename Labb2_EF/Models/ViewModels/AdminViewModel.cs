using Microsoft.AspNetCore.Identity;

namespace Labb2_EF.Models.ViewModels
{
    public class AdminViewModel
    {
        public IdentityUser[]? Administrators { get; set; }
    }
}
