using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityWeb.Data;
using IdentityWeb.Models;
using IdentityServer4.EntityFramework.DbContexts;
namespace IdentityWeb.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var build = new DbContextOptionsBuilder<ApplicationDbContext>();
            build.UseSqlServer(Configuration.GetConnectionString("DefaultConnection").ToString());
            return new ApplicationDbContext(build.Options);

        }

    }
    public class PersistedGrantDbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var build = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            build.UseSqlServer(Configuration.GetConnectionString("DefaultConnection").ToString(), b => b.MigrationsAssembly("IdentityWeb"));
            return new PersistedGrantDbContext(build.Options, new IdentityServer4.EntityFramework.Options.OperationalStoreOptions());

        }
    }
    public class ConfigurationDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var build = new DbContextOptionsBuilder<ConfigurationDbContext>();
            build.UseSqlServer(Configuration.GetConnectionString("DefaultConnection").ToString(), b => b.MigrationsAssembly("IdentityWeb"));
            return new ConfigurationDbContext(build.Options, new IdentityServer4.EntityFramework.Options.ConfigurationStoreOptions());

        }
    }
}