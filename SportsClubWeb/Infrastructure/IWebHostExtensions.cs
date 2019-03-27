using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersistenceLayer.EF;
using SportsClubModel.Domain;

namespace SportsClubWeb.Infrastructure
{
    public static class IWebHostExtensions
    {
        public static IWebHost EnsureMigrationsandPopulate(this IWebHost host)
        {
            using (var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<SportsClubContext>())
                {
                    context.Database.Migrate();
                    if (context.Courts.Any())
                    {
                        return host;
                    }
                    context.Courts.AddRange(
                            new TennisCourt()
                            {
                                Name = "Rod Laver",
                                IsIndoor = false,
                                HourlyCourtCost = 5,
                                HourlyIlluminationCost = 1,
                                Surface = Surface.Hardcourt
                            },
                             new TennisCourt()
                             {
                                 Name = "John McEnroe",
                                 IsIndoor = false,
                                 HourlyCourtCost = 5,
                                 HourlyIlluminationCost = 1,
                                 Surface = Surface.Grass
                             },
                             new PadelCourt()
                             {
                                 Name = "Fernando Belasteguin",
                                 IsIndoor = false,
                                 HourlyCourtCost = 5,
                                 HourlyIlluminationCost = 1,
                                 Surface = Surface.Grass
                             }

                    );

                    context.Members.Add(
                          new Member
                          {
                              FirstName = "Ciccio",
                              LastName = "Pasticio",
                              DateOfBirth = DateTime.Now.AddYears(-30),
                              Phone = "7777777",
                              Address = new Address
                              {
                                  StreetAddress = "Fattoria Di Nonna Papera",
                                  City = "Topolinia",
                                  Country = "Disney",
                                  ZIP = "00000"
                              }
                          }
                    );

                    context.SaveChanges();
                }
            }
            return host;
        }
    }
}