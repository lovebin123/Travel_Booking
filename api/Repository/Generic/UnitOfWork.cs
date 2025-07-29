using api.Data;
using api.Interfaces;
using api.Interfaces.Flights;
using api.Interfaces.Hotels;
using api.Repository.Flights;
using api.Repository.Hotels;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

namespace api.Repository.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private Hashtable _repositories;

        public IFlightRepository FlightRepository { get; }
        public IFlightBookingRepository FlightBookingRepository { get; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            _repositories = new Hashtable();

            FlightRepository = new FlightRepository(_context);
            FlightBookingRepository = new FlightBookingRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var typeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                var repoType = typeof(GenericRepository<>).MakeGenericType(typeof(TEntity));
                var repoInstance = Activator.CreateInstance(repoType, _context)!;
                _repositories[typeName] = repoInstance;
            }

            return (IRepository<TEntity>)_repositories[typeName]!;
        }
    }
}
