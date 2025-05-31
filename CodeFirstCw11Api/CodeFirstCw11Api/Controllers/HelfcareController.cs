using CodeFirstCw11Api.DTOs;
using CodeFirstCw11Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstCw11Api.Controllers;

[ApiController]
[Route("/[controller]")]
public class HelfcareController : ControllerBase
{
    private readonly IDbService _service;

    public HelfcareController(IDbService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDTO request)
    {
        try
        {
            await _service.AddPrescriptionAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("patients/{id}")]
    public async Task<IActionResult> GetPatientDetails(int id)
    {
        var result = await _service.GetPatientDetailsAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}