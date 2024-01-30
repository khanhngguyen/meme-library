using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MemeLibrary.Application.src.ServiceInterfaces;
using MemeLibrary.Domain.src.Entities;
using MemeLibrary.Domain.src.RepoInterfaces;

namespace MemeLibrary.Application.src.Services
{
    public class MemeService : IMemeService
    {
        private readonly IMemeRepo _memeRepo;

        public MemeService(IMemeRepo memeRepo)
        {   
            _memeRepo = memeRepo;
        }

        public async Task<IEnumerable<Meme>> GetAll(QueryOptions queryOptions)
        {
            return await _memeRepo.GetAll(queryOptions);
        }

        public async Task<Meme> GetOneById(string id)
        {
            return await _memeRepo.GetOneById(id);
        }

        public async Task<int> GetEntityCount()
        {
            return await _memeRepo.GetLength();
        }
    }
}