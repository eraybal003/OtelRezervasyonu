using Application.DTO;
using Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RezervasyonAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomTypeController(RoomTypeService typeService) : ControllerBase
{
    private readonly RoomTypeService service1 = typeService;

    [HttpGet]
    public ActionResult<IEnumerable<RoomTypeDTO>> GetAll()
    {
        return Ok(service1.GetTypes());
    }
    [HttpGet("{id}")]
    public ActionResult<RoomTypeDTO> GetById(Ulid id)
    {
        var type = service1.GetById(id);
        if (type.id == default)
        {
            return NotFound();
        }
        return Ok(type);
    }
    [HttpGet("{Name:alpha}")]
    public ActionResult<RoomTypeDTO> GetById(string name)
    {
        var type = service1.GetByName(name);
        if (type.name == default)
        {
            return NotFound();
        }
        return Ok(type);
    }
    [HttpPost]
    public ActionResult Post([FromBody] RoomTypeCreateDTO typeCreate)
    {
        service1.Add(typeCreate);
        return Ok(typeCreate);
    }
    [HttpPut]
    public ActionResult Put([FromBody] RoomTypeUpdateDTO typeUpdate)
    {
        service1.Update(typeUpdate);
        return Ok(typeUpdate);
    }
    [HttpDelete]
    public ActionResult Delete([FromBody] RoomTypeDeleteDTO typeDelete)
    {
        service1.Delete(typeDelete);
        return Ok(typeDelete);
    }

}
