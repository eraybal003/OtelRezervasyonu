using Application.DTO;
using Application.Feature;
using Microsoft.AspNetCore.Mvc;

namespace RezervasyonAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController(HotelService service) : ControllerBase
{
    private readonly HotelService _service = service;

    [HttpGet]
    public ActionResult<IEnumerable<HotelDTO>> GetAll()
    {
        return Ok(_service.GetHotels());
    }
    [HttpGet("{id}")]
    public ActionResult<HotelDTO>GetById(Ulid id)
    {
        var hotel = _service.GetById(id);
        if (hotel.id == default)
        {
            return NotFound();
        }
        return Ok(hotel);
    }
    [HttpGet("{name:alpha}")]
    public ActionResult<HotelDTO>GetByName(string name)
    {
        var hotel = _service.GetByName(name);
        if (hotel.name == default)
        {
            return NotFound();
        }
        return Ok(hotel);
    }
    [HttpGet("{star}")]
    public ActionResult<HotelDTO>GetByStar(int star)
    {
        var hotel = _service.GetByStar(star);
        if (hotel.stars == default)
        {
            return NotFound();
        }
        return Ok(hotel);
    }
    [HttpPost]
    public ActionResult Post([FromBody] HotelCreateDTO hotelCreate)
    {
        _service.Add(hotelCreate);
        return Ok(hotelCreate);
    }
    [HttpPut]
    public ActionResult Put([FromBody] HotelUpdateDTO hotelUpdate)
    {
        _service.Update(hotelUpdate);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete([FromBody] HotelDeleteDTO hotelDelete)
    {
        _service.Delete(hotelDelete);
        return Ok();
    }


}
