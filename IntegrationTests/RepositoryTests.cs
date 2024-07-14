using efdemo.Model;
using efdemo.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class RepositoryTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllUsers()
        {
            // Arrange
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=EfExpenseDemo;Integrated Security=True";
            var databaseContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString);
            var databaseContext = new ApplicationDbContext(databaseContextOptions.Options);
            var userRepository = new UserRepository(databaseContext);
            var expectedUsers = await databaseContext.Users.ToListAsync();

            // Act
            var actualUsers = userRepository.GetAll();
            var result = actualUsers.OfType<User>().ToList();

            // Assert
            Assert.Equal(expectedUsers.Count, result.Count);
            // Assert.Equal(expectedUsers.First().UserId, actualUsers.First().UserId);
            // Assert.Equal(expectedUsers.Last().UserId, actualUsers.Last().UserId);
        }
    }
}