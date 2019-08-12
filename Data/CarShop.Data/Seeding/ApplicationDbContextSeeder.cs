namespace CarShop.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarShop.Data.Models.Ads;
    using CarShop.Data.Models.Vehicles;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new UserSeeder(),
                              new SettingsSeeder(),
                          };
            await dbContext.Trucks.AddAsync(new Truck());
            await dbContext.Buses.AddAsync(new Bus());
            await dbContext.Motorcycles.AddAsync(new Motorcycle());
            await dbContext.Cars.AddAsync(new Car());
            await dbContext.Ads.AddAsync(new Ad());
            await dbContext.VipAds.AddAsync(new VipAd());
            await dbContext.TopAds.AddAsync(new TopAd());

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
