using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Labb2_EF.Models;

namespace Labb2_EF.Data
{
    public class SchoolDbContext : IdentityDbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }
        public DbSet<Labb2_EF.Models.Student> Student { get; set; } = default!;
        public DbSet<Labb2_EF.Models.Teacher> Teacher { get; set; } = default!;
    }
}