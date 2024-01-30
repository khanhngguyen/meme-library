using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MemeLibrary.Domain.src.Entities;

namespace MemeLibrary.Application.src.ServiceInterfaces
{
    public interface IMemeService
    {
        Task<IEnumerable<Meme>> GetAll(QueryOptions queryOptions);
        Task<Meme> GetOneById (string id);
        Task<int> GetEntityCount();
    }
}