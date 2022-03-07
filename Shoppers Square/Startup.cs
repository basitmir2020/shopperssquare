using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shoppers_Square.Db;
using Shoppers_Square.Helpers;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using Shoppers_Square.Repositories;
using System;

namespace Shoppers_Square
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(_config.GetConnectionString("DB")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 3;
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            }).AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders()
           .AddTokenProvider<CustomEmailConfirmationTokenProvider<ApplicationUser>>("CustomEmailConfirmation");
            services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(5));
            services.Configure<CustomEmailConfirmationTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromDays(5));
            services.AddMvc(o =>
            {
                o.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy",
                    policy => policy.RequireRole("Administrator"));
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.LoginPath = new PathString("/Account/SignIn");
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "ShopperSquare";
            });
            services.AddSession();
            services.Configure<SMTPConfigModel>(_config.GetSection("SMTPConfig"));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImagesRepository, ImageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEnquiryRepository, EnquiryRepository>();
            services.AddScoped<IProductDescriptionRepository, ProductDescriptionRepository>();

            services.AddSingleton<DataProtectionPurposeString>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            services.AddRouting(
                options =>
                {
                    options.AppendTrailingSlash = true;
                    options.LowercaseQueryStrings = true;
                });

            //For Web Api To Return Large Json Object
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
