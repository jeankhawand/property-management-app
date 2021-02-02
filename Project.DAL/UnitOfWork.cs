using System.Threading.Tasks;
using Project.Core;
using Project.Core.Repositories;
using Project.DAL.Repositories;

namespace Project.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ApartmentRepository _apartmentRepository;
        private BuyerRepository _buyerRepository;
        public UnitOfWork(AppDbContext context)
        {
           this._context = context;
        }
       

        public IApartmentRepository Apartments => _apartmentRepository = _apartmentRepository ?? new ApartmentRepository(_context);
        public IBuyerRespository Buyers => _buyerRepository = _buyerRepository ?? new BuyerRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}