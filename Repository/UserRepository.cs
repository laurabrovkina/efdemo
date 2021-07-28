using Model;
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
                .Where(u => u.FirstName == firstName);
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
