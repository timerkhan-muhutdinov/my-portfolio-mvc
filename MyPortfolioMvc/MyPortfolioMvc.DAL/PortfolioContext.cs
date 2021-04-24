using Microsoft.EntityFrameworkCore;
using MyPortfolioMvc.DAL.Entities;

namespace MyPortfolioMvc.DAL
{    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
    }
}
