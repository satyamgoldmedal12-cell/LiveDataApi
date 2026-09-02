using ERP.Application;
using ERP.Application.Common;
using ERP.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace ERP.Api.Controller;


[ApiController]
[Route("api/[controller]")]
public class DivisionController : ControllerBase
{
    private readonly IDivisionService _divisionService;

    public DivisionController(IDivisionService divisionService)
    {
        _divisionService = divisionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDivisions()
    {
        try
        {
            var divisions = await _divisionService.GetAllDivisionsAsync();
            return Ok(ApiResponse<List<Division>>.SuccessResponse(divisions)); 
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<object>.FailResponse(ex.Message));
        }
    }
}
