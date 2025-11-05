using Application.DTO;
using Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RezervasyonAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController(RoomService roomService) : ControllerBase
{
    private readonly RoomService _roomService1 = roomService;

    [HttpGet]
    public ActionResult<IEnumerable<RoomDTO>> GetAll()
    {
        return Ok(_roomService1.GetRoomDTOs());
    }
    [HttpGet("{id}")]
    public ActionResult<RoomDTO> GetById(Ulid id)
    {
        var room = _roomService1.GetById(id);
        if (room.id == default)
        {
            return NotFound();
        }
        return Ok(room);
    }
    [HttpGet("{number}")]
    public ActionResult<RoomDTO> GetById(string number)
    {
        var room = _roomService1.GetByNumber(number);
        if (room.roomnumber == default)
        {
            return NotFound();
        }
        return Ok(room);
    }
    [HttpPost]
    public ActionResult Post([FromBody] RoomCreateDTO roomCreate)
    {
        _roomService1.Add(roomCreate);
        return Ok();
    }
    [HttpPut]
    public ActionResult Put([FromBody] RoomUpdateDTO roomUpdate) 
    {
        _roomService1.Update(roomUpdate);
        return Ok(roomUpdate);
    }
    [HttpDelete]
    public ActionResult Delete([FromBody] RoomDeleteDTO roomDelete)
    {
        _roomService1.Delete(roomDelete);
        return Ok(roomDelete);
    }
}
