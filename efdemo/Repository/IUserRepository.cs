using Model;
using System.Collections;
using System.Collections.Generic;

namespace Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByFirstName(string firstName);

        User GetOnlyByFirstName(string firstName);

        int CountMatchingFirstame(string firstName);

        IEnumerable GetAllFirstNames();
    }
}
