using Model;
using System.Collections;
using System.Collections.Generic;

namespace Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<ExpanseUser> GetByFirstName(string firstName);

        ExpanseUser GetOnlyByFirstName(string firstName);

        int CountMatchingFirstame(string firstName);

        IEnumerable GetAllFirstNames();
    }
}
