using Microsoft.AspNetCore.Mvc;
using ERP.Application;
using ERP.Domain;
using ERP.Domain.Models;

namespace ERP.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class TaxTypeController : ControllerBase
{
    private readonly ITaxTypeService _taxTypeService;

    public TaxTypeController(ITaxTypeService taxTypeService)
    {
        _taxTypeService = taxTypeService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddTaxType([FromBody] AddTaxTypeRequest request)
    {
        if (!ModelState.IsValid)  return BadRequest(ModelState);

        try
        {
            var taxType = new TaxType
            {
                TaxTypeNm = request.TaxTypeNm,
                TaxTypeCode = request.TaxTypeCode
            };

            var result = await _taxTypeService.AddTaxTypeAsync(taxType, request.CrtuId, request.Logon);
            return Ok(new { message = "Tax Type added successfully", rowsAffected = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateTaxType([FromBody] UpdateTaxTypeRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var taxType = new TaxType
            {
                RecId = request.RecId,
                TaxTypeNm = request.TaxTypeNm,
                TaxTypeCode = request.TaxTypeCode
            };

            var result = await _taxTypeService.UpdateTaxTypeAsync(taxType, request.CrtuId, request.Logon);
            return Ok(new { message = "Tax Type updated successfully", rowsAffected = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("delete/{recId}")]
    public async Task<IActionResult> DeleteTaxType(int recId, [FromQuery] int crtuId, [FromQuery] int logon)
    {
        try
        {
            var result = await _taxTypeService.DeleteTaxTypeAsync(recId, crtuId, logon);
            return Ok(new { message = "Tax Type deleted successfully", rowsAffected = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

public class AddTaxTypeRequest
{
    public string TaxTypeNm { get; set; }
    public string TaxTypeCode { get; set; }
    public int CrtuId { get; set; }
    public int Logon { get; set; }
}

public class UpdateTaxTypeRequest
{
    public int RecId { get; set; }
    public string TaxTypeNm { get; set; }
    public string TaxTypeCode { get; set; }
    public int CrtuId { get; set; }
    public int Logon { get; set; }
}
