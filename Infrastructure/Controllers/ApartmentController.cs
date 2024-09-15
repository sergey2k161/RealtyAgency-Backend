using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RealtyAgency.Core.Repositories.DTO;
using RealtyAgency.Core.Repositories.Interfaces.ApartmentRepository;

namespace RealtyAgency.Infrastructure.Controllers;

[ApiController]
[EnableCors("AllowSpecificOrigin")]
[Route("api")]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService _apartmentService;

    public ApartmentController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    [HttpPost("create/apartment")]
    public async Task<IActionResult> CreateApartmentAsync([FromBody] CreateApartmentDTO model)
    {
        //var userCommonUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var createApartment = await _apartmentService.CreateApartmentAsync(model);
        
        return Ok(createApartment);
    }
    
    //[HttpDelete("delete/apartment/{apartmentId}")]
    
}