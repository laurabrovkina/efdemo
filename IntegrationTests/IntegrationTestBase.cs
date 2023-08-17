using efdemo;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Xunit;

namespace IntegrationTests
{
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Startup, ApplicationDbContext>>
    {
        public readonly CustomWebApplicationFactory<Startup, ApplicationDbContext> Factory;
        public readonly ApplicationDbContext DbContext;

        public IntegrationTestBase(CustomWebApplicationFactory<Startup, ApplicationDbContext> factory)
        {
            Factory = factory;
            var scope = factory.Services.CreateScope();
            DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }
    }
}
