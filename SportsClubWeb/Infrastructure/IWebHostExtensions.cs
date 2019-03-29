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
                                Surface = Surface.Clay
                            },
                             new TennisCourt()
                             {
                                 Name = "John McEnroe",
                                 IsIndoor = false,
                                 HourlyCourtCost = 5,
                                 HourlyIlluminationCost = 1,
                                 Surface = Surface.Hardcourt
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

                    context.Members.AddRange(
                          new Member
                          {
                              FirstName = "Ciccio",
                              LastName = "Pasticio",
                              DateOfBirth = DateTime.Now.AddYears(-30),
                              Phone = "111111",
                              Address = new Address
                              {
                                  StreetAddress = "Fattoria Di Nonna Papera",
                                  StreetNumber = "1",
                                  City = "Topolinia",
                                  Country = "Disney",
                                  ZIP = "222222"
                              }
                          },
                           new Member
                           {
                               FirstName = "Pico",
                               LastName = "De Paperis",
                               DateOfBirth = DateTime.Now.AddYears(-30),
                               Phone = "333333",
                               Address = new Address
                               {
                                   StreetAddress = "Fattoria Di Nonna Papera",
                                   StreetNumber = "2",
                                   City = "Topolinia",
                                   Country = "Disney",
                                   ZIP = "44444"
                               }
                           },
                           new Member
                           {
                               FirstName = "Archimede",
                               LastName = "Pitagorico",
                               DateOfBirth = DateTime.Now.AddYears(-30),
                               Phone = "55555",
                               Address = new Address
                               {
                                   StreetAddress = "Fattoria Di Nonna Papera",
                                   StreetNumber = "3",
                                   City = "Topolinia",
                                   Country = "Disney",
                                   ZIP = "66666"
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