using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MemeLibrary.Domain.src.Entities;
using MemeLibrary.Domain.src.RepoInterfaces;
using MemeLibrary.Infrastructure.src.Database;

namespace MemeLibrary.Infrastructure.src.RepoImplementations
{
    public class MemeRepo : BaseRepo<Meme>, IMemeRepo
    {
        public MemeRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}