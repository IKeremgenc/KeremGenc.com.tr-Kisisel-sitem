using KeremCvTemplate.Data.Concrete.EntityFramework.Contexts;
using KeremCvTemplate.Entites.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KeremCvTemplate.service.Abstract;
using KeremCvTemplate.service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeremCvTemplate.service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DetnisContex>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                // User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<DetnisContex>();
            serviceCollection.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(15);
            });

            //serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<IMailService, MailManager>();
            return serviceCollection;
        }
    }
}
