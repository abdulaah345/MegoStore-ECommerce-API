using MegoStore.Application.Interfaces;
using MegoStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitofWork
    {

        private readonly AppDbContext _context;
        private readonly Dictionary<Type,object> _repositores = new Dictionary<Type,object>();
        public UnitOfWork(AppDbContext context) {

            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositores.ContainsKey(typeof(T)))
            {
                return _repositores[typeof(T)] as IGenericRepository<T>;
            }
            var repositores = new GenericRepository<T>(_context);
            _repositores[typeof (T)] = repositores;
            return repositores;
           
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
