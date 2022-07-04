using AutoMapper;
using FlightBooking.Admin.Identity;
using FlightBooking.Admin.Models;
using FlightBooking.Admin.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var authenticationProviderKey = "TestKey";
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlightBooking.Reports", Version = "v1" });
            //});
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = authenticationProviderKey;
                options.DefaultChallengeScheme = authenticationProviderKey;
                options.DefaultScheme = authenticationProviderKey;
            })

           // Adding Jwt Bearer
           .AddJwtBearer(authenticationProviderKey, options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = Configuration["JWT:ValidAudience"],
                   ValidIssuer = Configuration["JWT:ValidIssuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
               };
           });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlightBooking.Admin", Version = "v1" });
            });
            services.AddDbContext<FlightDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // For Identity
            // For Identity
            services.AddIdentity<AppUsers, IdentityRole>()
            .AddEntityFrameworkStores<FlightDBContext>()
            .AddDefaultTokenProviders();
            // Way-1: Register Profiles and/or Mapping manually. 
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            // services.AddHttpContextAccessor();//Add for jwt token 
            services.AddTransient<IAirlineRepository, AirlineRepository>();
            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddTransient<IScheduleRepository, ScheduledRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
               
            }
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightBooking.Admin v1"));
            app.UseCors(builder =>
            {
                builder
                //.WithOrigins(adminApiConfiguration.ApplicationBaseUrl)  //particular specific domain 
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
