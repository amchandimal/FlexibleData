using FlexibleDataApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlexibleDataApplication.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FlexibleData> FlexibleData { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    
    }
}
