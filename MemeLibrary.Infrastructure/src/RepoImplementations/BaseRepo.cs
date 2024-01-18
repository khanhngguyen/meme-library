using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemeLibrary.Domain.src.Entities;
using MemeLibrary.Domain.src.RepoInterfaces;
using MemeLibrary.Infrastructure.src.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemeLibrary.Infrastructure.src.RepoImplementations
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DatabaseContext _context; 

        public BaseRepo(DatabaseContext databaseContext)
        {
            _dbSet = databaseContext.Set<T>();
            _context = databaseContext;
        }

        public virtual async Task<IEnumerable<T>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return await _dbSet.Skip(queryOptions.PageNumber * queryOptions.PageNumber)
                .Take(queryOptions.PageSize)
                .ToListAsync();
        }
        public virtual async Task<T> GetOneById(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}