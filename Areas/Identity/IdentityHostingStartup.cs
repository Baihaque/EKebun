using System;
using EKebun.Areas.Identity.Data;
using EKebun.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EKebun.Areas.Identity.IdentityHostingStartup))]
namespace EKebun.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EKebunNewContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EKebunNewContextConnection")));

                services.AddDefaultIdentity<EKebunUser>()
                    .AddEntityFrameworkStores<EKebunNewContext>();
            });
        }
    }
}