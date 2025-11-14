using Domain.Entites;
using Persistence.Context;
using Persistence.IRepository;

namespace Persistence.Repository
{
    public class RoomTypeRepo : Repository<RoomType>, IRoomType
    {
        public RoomTypeRepo(AppDbContext context) : base(context)
        {
        }
    }
}
