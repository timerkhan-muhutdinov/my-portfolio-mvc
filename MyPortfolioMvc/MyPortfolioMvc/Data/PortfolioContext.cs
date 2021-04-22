using Microsoft.EntityFrameworkCore;
using MyPortfolioMvc.Models;

namespace MyPortfolioMvc.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
    }
}
