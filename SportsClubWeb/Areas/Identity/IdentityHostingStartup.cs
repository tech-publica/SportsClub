using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersistenceLayer.EF;
using PersistenceLayer.EF.IdentityModel;

[assembly: HostingStartup(typeof(SportsClubWeb.Areas.Identity.IdentityHostingStartup))]
namespace SportsClubWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<SportsClubContext>();
            });
        }
    }
}