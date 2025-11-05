namespace Domain.Entites;

public class RoomType: CommonClass.CommonBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Ulid RoomId { get; set; }
    public ICollection<Room> Rooms { get; set; } = new List<Room>();


}
