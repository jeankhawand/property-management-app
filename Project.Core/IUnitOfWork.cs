using System;
using System.Threading.Tasks;
using Project.Core.Repositories;

namespace Project.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IApartmentRepository Apartments { get; }
        IBuyerRespository Buyers { get; }
        Task<int> CommitAsync();
    }
}