using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolioMvc.DAL;
using MyPortfolioMvc.DAL.Entities;
using System;
using System.Linq;

namespace MyPortfolioMvc.AppData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PortfolioContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PortfolioContext>>()))
            {
                // Look for any movies.
                if (context.Post.Any())
                {
                    return;   // DB has been seeded
                }

                context.Post.AddRange(
                    new Post
                    {
                        Title = "When Harry Met Sally",
                        CreatedDate = DateTime.Now,
                        Description = "Romantic Comedy",
                        Price = 7.99M
                    },
                    new Post
                    {
                        Title = "When Harry Met Sally",
                        CreatedDate = DateTime.Now,
                        Description = "Romantic Comed 3y",
                        Price = 7.99M
                    },

                    new Post
                    {
                        Title = "Ghostbusters ",
                        CreatedDate = DateTime.Parse("08/08/2018"),
                        Description = "Comed df Ghostbusters gfdg y",
                        Price = 8.99M
                    },

                    new Post
                    {
                        Title = "Ghostbusters 2",
                        CreatedDate = DateTime.Parse("08/08/2018"),
                        Description = "Ghostbusters GhostbustersGhostbustersGhostbustersComedy",
                        Price = 9.99M
                    },

                    new Post
                    {
                        Title = "Rio Bravo",
                        CreatedDate = DateTime.Now,
                        Description = "Rio Rio RioWestern",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
