using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.Service;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.Service;
using System.Configuration;
using System.Text;

namespace SWD.SportShirtShop.Services.Extension
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)

        {


            string GetConnectionString()
            {
                IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true).Build();
                return configuration["ConnectionStrings:DefaultConnectionString"];
            }
            services.AddDbContext<SportShirtShopDBContext>(options =>
            options.UseSqlServer(GetConnectionString()));
            services.AddScoped<UnitOfWork>();


            // Register your services here
            services.AddScoped<TokenService>();
            services.AddScoped<IShirtEditionSerivice, ShirtEditionSerivce>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IShirtService, ShirtService>();
            services.AddScoped<IOrderService, OrderService>();  
            services.AddScoped<IPayosService, PayosService>();
            services.AddScoped<PayosService> ();
            services.AddScoped<IPaymentService, PaymentService>();
            // services.AddScoped<IEmailService,EmailService>();

            //services.AddScoped<IReviewService, ReviewService>();
            //services.AddRazorComponents();
            //services.AddScoped<IEmailService, EmailService>();

            //services.AddScoped<IVnpaymentService, VNPaymentService>();

            //services.AddScoped<IProductRelationService, ProductRelationService>();
            //services.AddScoped<IPayosService, PayosService>();


            //services.AddFluentEmail("");
            //services.AddRazorTemplating();
            // Add other services as needed
            // services.AddScoped<OtherService>();

            return services;
        }
        
    }
}
