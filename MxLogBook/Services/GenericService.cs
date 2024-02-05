using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        //Set private vars
        private readonly MxLogBookDbContext _context;
        public GenericService(MxLogBookDbContext context)
        {
            //Map Context
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            //Add and save changes to the DB
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            //Return the new entry
            return entity;
        }

        public async Task DeleteAsync(int? id)
        {
            var result = await GetAsync(id);
            _context.Set<T>().Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            //Find the item by id
            var result = await GetAsync(id);

            //Will return true if it exists
            return result != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            //Return all in a list
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            //If Id is null throw error
            if (id == null)
                throw new ArgumentNullException("id");

            //Pull the result
            var result =  await _context.Set<T>().FindAsync(id);

            //If the item doesn't exist throw error
            if (result == null)
                throw new InvalidOperationException("Not Found");

            //Return result
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
