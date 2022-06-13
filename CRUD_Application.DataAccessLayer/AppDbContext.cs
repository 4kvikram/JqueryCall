using CRUD_Application.DataAccessLayer.EntitieModels;

using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Users> Users { get; set; }
     
    }

    
}