using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MemeLibrary.Domain.src.Entities;

namespace MemeLibrary.Domain.src.RepoInterfaces
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAll(QueryOptions queryOptions);
        Task<T> GetOneById(string id);
    }
}