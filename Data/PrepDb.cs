namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext context)
    {
        if(!context.Platforms.Any()) 
        {
            Console.WriteLine("--> Seeding data...");
            context.Platforms.AddRange(new Models.Platform() { 

                Name = "DOT NET",
                Publisher = "Microsoft",
                Cost = "Free"
            },
            new Models.Platform() { 

                Name = "JAVA",
                Publisher = "ORACLE",
                Cost = "Free"
            },
            new Models.Platform() { 

                Name = "LINUX",
                Publisher = "Red Hat",
                Cost = "Free"
            }
            );

            context.SaveChanges();
        }
        else
        Console.WriteLine("--> We already have data");
    }
}