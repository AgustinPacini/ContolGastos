using System.Collections.Generic;
using System.Threading.Tasks;
using APIControlGastos.Context;
using APIControlGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControlGastos.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ControlgastosContext _context;

        public BaseRepository(ControlgastosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

