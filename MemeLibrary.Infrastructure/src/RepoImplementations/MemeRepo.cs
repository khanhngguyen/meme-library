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
    public class MemeRepo : BaseRepo<Meme>, IMemeRepo
    {
        public MemeRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<IEnumerable<Meme>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            IQueryable<Meme> results = _dbSet;

            // Search
            if (!string.IsNullOrWhiteSpace(queryOptions.Search)) {
                results = _dbSet.Where(m => m.Name.ToLower().Contains(queryOptions.Search.ToLower()));
            }

            // Order by
            if (queryOptions.OrderBy == "Most popular") 
            {
                results = results.OrderByDescending(m => m.Captions);
            } else if (queryOptions.OrderBy == "Least popular")
            {
                results = results.OrderBy(m => m.Captions);
            } else if (queryOptions.OrderBy == "A - Z")
            {
                results = results.OrderBy(m => m.Name);
            } else if (queryOptions.OrderBy == "Z - A") 
            {
                results = results.OrderByDescending(m => m.Name);
            }

            // default query;
            results = results
                .Skip(queryOptions.PageNumber * queryOptions.PageSize)
                .Take(queryOptions.PageSize);
            
            return await results.ToListAsync();

            // return base.GetAll(queryOptions);
        }

        public async Task<int> GetLength()
        {
            return await _dbSet.CountAsync();
        }
    }
}