using Microsoft.AspNetCore.Mvc;
using Recruitment.Contracts.Services;
using Recruitment.Data.DTOs;
using Recruitment.Data.Enums;

namespace Recruitment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly ICRUDServiceExample _serviceExample;

    public ExampleController(ICRUDServiceExample serviceExample)
    {
        _serviceExample = serviceExample;
    }

    [HttpGet(Name = "GetEntity")]
    public async Task<IActionResult> Get([FromQuery] Guid entityId, [FromHeader(Name="Accept")] string format)
    {
        try
        {
            var result = await _serviceExample.Get(entityId);

            return Ok(result);
        }
        catch (KeyNotFoundException e)
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpPut(Name = "CreateEntity")]
    public async Task<IActionResult> Put([FromBody] NewExampleEntityDTO entity, [FromHeader(Name="Accept")] string format)
    {
        try
        {
            var result = await _serviceExample.Create(entity);

            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpPost(Name = "UpdateEntity")]
    public async Task<IActionResult> Post([FromBody] ExampleEntityDTO entity, [FromHeader(Name="Accept")] string format)
    {
        try
        {
            var result = await _serviceExample.Update(entity);

            return Ok(result);
        }
        catch (KeyNotFoundException e)
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
    
    [HttpDelete(Name = "DeleteEntity")]
    public async Task<IActionResult> Delete([FromQuery] Guid entityId)
    {
        try
        {
            await _serviceExample.Delete(entityId);
    
            return Ok();
        }
        catch (KeyNotFoundException e)
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500);
        }
    }
}