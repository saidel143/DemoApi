using System;
using System.Threading.Tasks;

namespace Portales.Dal
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}