using Domain.Entites;
using Persistence.Context;
using Persistence.IRepository;

namespace Persistence.Repository;

public class HotelRepo : Repository<Hotel>, IHotel
{
    public HotelRepo(AppDbContext context) : base(context)
    {
    }
}
