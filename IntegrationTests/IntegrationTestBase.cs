using efdemo.Model;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace IntegrationTests
{
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Program, ApplicationDbContext>>
    {
        public readonly CustomWebApplicationFactory<Program, ApplicationDbContext> Factory;
        public readonly ApplicationDbContext DbContext;

        public IntegrationTestBase(CustomWebApplicationFactory<Program, ApplicationDbContext> factory)
        {
            Factory = factory;
            var scope = factory.Services.CreateScope();
            DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }
    }
}
