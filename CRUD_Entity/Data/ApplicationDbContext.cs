using CRUD_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Entity.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Customers> Customers { get; set; }
    }
}
