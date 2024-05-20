using efdemo.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class UserCreator
    {
        private readonly ApplicationDbContext _dbContext;

        public UserCreator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUsersAsync()
        {
            var users = new List<ExpanseUser>
            {
                new ExpanseUser
                {
                    FirstName = "User1",
                    LastName = "Last Name User1",
                    CreatedDate = DateTime.Now
                },
                new ExpanseUser
                {
                    FirstName = "User2",
                    LastName = "Last Name User2",
                    CreatedDate = DateTime.Now
                },
                new ExpanseUser
                {
                    FirstName = "User3",
                    LastName = "Last Name User3",
                    CreatedDate = DateTime.Now
                },
                new ExpanseUser
                {
                    FirstName = "User4",
                    LastName = "Last Name User4",
                    CreatedDate = DateTime.Now
                },                
                new ExpanseUser
                {
                    FirstName = "User5",
                    LastName = "Last Name User5",
                    CreatedDate = DateTime.Now
                },
                new ExpanseUser
                {
                    FirstName = "User6",
                    LastName = "Last Name User6",
                    CreatedDate = DateTime.Now
                },
                new ExpanseUser
                {
                    FirstName = "User7",
                    LastName = "Last Name User7",
                    CreatedDate = DateTime.Now
                },
                new ExpanseUser
                {
                    FirstName = "User8",
                    LastName = "Last Name User8",
                    CreatedDate = DateTime.Now
                }
            };

            await _dbContext.Users.AddRangeAsync(users);
            await _dbContext.SaveChangesAsync();
        }
    }
}
