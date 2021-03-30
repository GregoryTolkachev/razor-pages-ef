using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;



namespace razor_pages_ef.Models
{

    public static class DataStart
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using var context = new StoreGameContext(
                serviceProvider.GetRequiredService<DbContextOptions<StoreGameContext>>()
                );

            if (context.Game.Any())
            {
                return;
            }

            context.Game.AddRange(
                new Game { Price = 5.99M, Title = "War", ReleaseDate = DateTime.Parse("1972-02-08") },
                new Game { Price = 16.99M, Title = "Battleship", ReleaseDate = DateTime.Parse("1982-02-08") },
                new Game { Price = 28.89M, Title = "Settlers of Catan", ReleaseDate = DateTime.Parse("2006-01-08") }

            );

            context.SaveChanges();

        }

    }

}