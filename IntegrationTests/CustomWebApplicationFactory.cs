using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.TestHost;
using DotNet.Testcontainers.Builders;
using Testcontainers.MsSql;
using Xunit;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup, TDbContext> : WebApplicationFactory<TStartup>,
        IAsyncLifetime where TStartup : class where TDbContext : DbContext
    {
        private readonly MsSqlContainer _msSqlContainer;

        public CustomWebApplicationFactory()
        {
            _msSqlContainer = new MsSqlBuilder()
                .WithImage("efdemo-db")
                .WithPassword("TestDatabase$")
                .WithCleanUp(true)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
                .Build();
        }

        public new async Task DisposeAsync() => await _msSqlContainer.DisposeAsync();

        public new async Task InitializeAsync() => await _msSqlContainer.StartAsync();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveDbContext<TDbContext>();
                services.AddDbContext<TDbContext>(options => { options.UseSqlServer(_msSqlContainer.GetConnectionString()); });
                services.AddTransient<UserCreator>();
            });
        }
    }
}
