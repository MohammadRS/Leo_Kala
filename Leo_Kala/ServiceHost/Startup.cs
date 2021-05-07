using _0_Framework.Application;
using AccountManagement.Configuration;
using BlogManagement.Infrastructure.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ServiceHost
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddRazorPages();

            #region Context
            services.AddHttpContextAccessor();
            var connectionString = Configuration.GetConnectionString("LeoKala");
            #endregion

            ShopManagementBootstrapper.Configure(services, connectionString);
            DiscountManagementBootstrapper.Configure(services, connectionString);
            InventoryManagementBootstrapper.Configure(services, connectionString);
            BlogManagementBootstrapper.Configure(services, connectionString);
            //CommentManagementBootstrapper.Configure(services, connectionString);
            AccountManagementBootstrapper.Configure(services, connectionString);

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            //services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
            //services.AddTransient<ISmsService, SmsService>();
            //services.AddTransient<IEmailService, EmailService>();


            services.AddHttpContextAccessor();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });


            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminArea",
            //        builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));

            //    options.AddPolicy("Shop",
            //        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

            //    options.AddPolicy("Discount",
            //        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

            //    options.AddPolicy("Account",
            //        builder => builder.RequireRole(new List<string> { Roles.Administrator }));
            //});

            //services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            //    builder
            //        .WithOrigins("https://localhost:44366/")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()));

            //services.AddRazorPages()
            //    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
            //    .AddRazorPagesOptions(options =>
            //    {
            //        options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
            //        options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
            //        options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
            //        options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
            //    })
            //    .AddApplicationPart(typeof(ProductController).Assembly)
            //    .AddApplicationPart(typeof(InventoryController).Assembly)
            //    .AddNewtonsoftJson();


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
