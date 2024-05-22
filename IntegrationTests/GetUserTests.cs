using efdemo.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class GetUserTests : IntegrationTestBase
    {
        private readonly CustomWebApplicationFactory<Program, ApplicationDbContext> _integrationTestFactory;
        private readonly UserCreator _userCreator;

        public GetUserTests(CustomWebApplicationFactory<Program, ApplicationDbContext> factory) : base(factory)
        {
            _integrationTestFactory = factory;
            var scope = factory.Services.CreateScope();
            _userCreator = scope.ServiceProvider.GetRequiredService<UserCreator>();
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var client = _integrationTestFactory.CreateClient();
            string url = "http://localhost:44353/api/user";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetAll_ReturnsAllUsers_FromContainer()
        {
            // Arrange
            await _userCreator.AddUsersAsync();

            var client = _integrationTestFactory.CreateClient();
            string url = "http://localhost:44353/api/user";

            // Act
            var response = await client.GetAsync(url);

            //// Assert
            var json = await response.Content.ReadAsStreamAsync();
            //var result = JsonSerializer.Deserialize<List<User>>(json);
            //Assert.Equal(1, result.Count);
            //Assert.Equal(expectedUsers.First().UserId, actualUsers.First().UserId);
            //Assert.Equal(expectedUsers.Last().UserId, actualUsers.Last().UserId);
        }
    }
}
