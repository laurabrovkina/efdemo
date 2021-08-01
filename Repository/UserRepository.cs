using Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) 
            : base(context)
        {

        }

        public IEnumerable<User> GetByFirstName(string firstName)
        {
            return ApplicationDbContext.Users
                .Where(u => u.FirstName == firstName)
                .OrderByDescending(u => u.LastName);
        }

        public User GetOnlyByFirstName(string lastName)
        {
            return ApplicationDbContext.Users
                .SingleOrDefault(u => u.LastName == lastName);
        }

        public bool HasAny()
        {
            return ApplicationDbContext.Users
                .Any();
        }

        public int CountOfFirstNameJohn()
        {
            // hardcoded example, you won't do that on prod
            return ApplicationDbContext.Users
                .Count(u => u.FirstName == "John");
        }

        public int CountMatchingFirstame(string firstName)
        {
            return ApplicationDbContext.Users
                .Count(u => u.FirstName == firstName);
        }

        public int GetMaximumUserId()
        {
            return ApplicationDbContext.Users
                .Max(u => u.UserId);
        }

        public int GetMinimumUserId()
        {
            return ApplicationDbContext.Users
                .Min(u => u.UserId);
        }

        public IEnumerable GetAllFirstNames()
        {
            return ApplicationDbContext.Users
                .Select(u => u.FirstName)
                .ToList();
        }

        public ApplicationDbContext ApplicationDbContext 
        {
            get 
            {
                return Context as ApplicationDbContext;
            }
        }
    }
}
