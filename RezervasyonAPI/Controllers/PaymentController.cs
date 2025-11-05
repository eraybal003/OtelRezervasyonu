using Application.DTO;
using Application.Feature;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RezervasyonAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController(PaymentServ payment) : ControllerBase
{
    private readonly PaymentServ _payment1 = payment;

    [HttpGet]
    public ActionResult<IEnumerable<PaymentDTO>> GetAll()
    {
        return Ok(_payment1.GetPayments());
    }
    [HttpGet("{id}")]
    public ActionResult<PaymentDTO>GetById(Ulid id)
    {
        var pay = _payment1.GetById(id);
        if (pay.id == default)
        {
            return NotFound();
        }
        return Ok(pay);
    }
    [HttpGet("{status}")]
    public ActionResult<PaymentDTO>GetByStatus(string status)
    {
        var pay = _payment1.GetByStatus(status);
        if (pay.status == default)
        {
            return NotFound();
        }
        return Ok(pay);
    }
    [HttpGet("{methods:alpha}")]
    public ActionResult<PaymentDTO>GetByMethods(string methods)
    {
        var pay = _payment1.GetByMethod(methods);
        if (pay.paymentmethod == default)
        {
            return NotFound();
        }
        return Ok(pay);
    }
    [HttpPost]
    public ActionResult Post([FromBody] PaymentCreateDTO paymentCreate)
    {
        _payment1.Add(paymentCreate);
        return Ok(paymentCreate);
    }
    [HttpPut]
    public ActionResult Put([FromBody] PaymentUpdateDTO paymentUpdate)
    {
        _payment1.Update(paymentUpdate);
        return Ok(paymentUpdate);
    }
    [HttpDelete]
    public ActionResult Delete([FromBody] PaymentDeleteDTO paymentDelete)
    {
        _payment1.Delete(paymentDelete);
        return Ok(paymentDelete);
    }
}
