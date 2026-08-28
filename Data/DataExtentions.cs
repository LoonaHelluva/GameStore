using Microsoft.EntityFrameworkCore;

namespace GameStore;

public static class DataExtentions
{
    //DB Migration
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider
                                .GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    //Adding Data Base
    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameStore");

        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (!context.Set<Genre>().Any())
                {
                    context.Set<Genre>().AddRange(
                        new Genre { Name = "Racing Sim" },
                        new Genre { Name = "Fighting" },
                        new Genre { Name = "Life Sim" },
                        new Genre { Name = "Platformer" }
                    );
                }

                context.SaveChanges();
            })
        );
    }
}