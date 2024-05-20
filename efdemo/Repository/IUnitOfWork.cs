using System;

namespace efdemo.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}
