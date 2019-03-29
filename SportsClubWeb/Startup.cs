using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PersistenceLayer.EF;
using PersistenceLayer.EF.Async.Repositories;
using PersistenceLayer.EF.Async.UnitsOfWork;
using PersistenceLayer.EF.Repositories;
using PersistenceLayer.EF.UnitsOfWork;
using SportsClubModel.CoreAbstractions.Async.Repositories;
using SportsClubModel.CoreAbstractions.Async.UnitsOfWork;
using SportsClubModel.CoreAbstractions.Repositories;
using SportsClubModel.CoreAbstractions.UnitsOfWork;
using System;

namespace SportsClubWeb
{
    public class Startup
    {

        public Startup(IConfiguration configuration) =>
           Configuration = configuration;

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc(opt => opt.ModelBindingMessageProvider.SetValueIsInvalidAccessor(val => "This field is not of the right type"));
            services.AddDbContext<SportsClubContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseSqlServer(
                    Configuration["Data:SportsClubContext:ConnectionString"]));
            services.AddTransient<CourtUnitOfWork, EFCourtUnitOfWork>();
            services.AddTransient<CourtRepository, EFCourtRepository>();
            services.AddTransient<MemberRepository, EFMemberRepository>();
            services.AddTransient<MemberUnitOfWork, EFMemberUnitOfWork>();
            services.AddTransient<TournamentsRepository, EFTournamentRepository>();
            services.AddTransient<ReservationUnitOfWork, EFReservationUnitOfWork>();
            services.AddTransient<ReservationRepository, EFReservationRepository>();
            services.AddTransient<ReservationUnitOfWorkAsync, EFReservationUnitOfWorkAsync>();
            services.AddTransient<ReservationRepositoryAsync, EFReservationRepositoryAsync>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                   {
                       var handlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                       if (handlerFeature != null)
                       {
                           var logger = loggerFactory.CreateLogger("Global Exception Handling Logger");
                           logger.LogError(500, handlerFeature.Error, handlerFeature.Error.Message);
                       }
                       context.Response.StatusCode = 500;
                       await context.Response.WriteAsync("We are sorry but we encountered an error, please try again later");
                   });
                });
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();

            // app.Run(async (context) =>
            // {
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "reservations/{dateOfReservation?}",
                    defaults: new { controller = "Reservation", action = "Index", dateOfReservation = DateTime.Today }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
