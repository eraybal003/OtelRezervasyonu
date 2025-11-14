using Domain.Entites;
using Persistence.Context;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RoomRepo : Repository<Room>, IRoom
    {
        public RoomRepo(AppDbContext context) : base(context)
        {
        }
    }
}
