using Application.DTO;
using Application.Feature;
using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RezervasyonAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController(ReservationService service) : ControllerBase
{
    private readonly ReservationService _service1 = service;

    [HttpGet]
    public ActionResult<IEnumerable<ReservationDTO>> GetAll()
    {
        return Ok(_service1.GetReservation());
    }
    [HttpGet("{id}")]
    public ActionResult<ReservationDTO> GetById(Ulid id)
    {
        var reser = _service1.GetById(id);
        if (reser.id == default)
        {
            return NotFound();
        }
        return Ok(reser);
    }
    [HttpGet("{guest:alpha}")]
    public ActionResult<ReservationDTO> GetByGuest(User guest)
    {
        var reser = _service1.GetByGuest(guest);
        if (reser.guest == default)
        {
            return NotFound();
        }
        return Ok(reser);
    }
    [HttpGet("{status:alpha}")]
    public ActionResult<ReservationDTO> GetByStatus(string status)
    {
        var reser = _service1.GetByStatus(status);
        if (reser.status == default)
        {
            return NotFound();
        }
        return Ok(reser);
    }
}
