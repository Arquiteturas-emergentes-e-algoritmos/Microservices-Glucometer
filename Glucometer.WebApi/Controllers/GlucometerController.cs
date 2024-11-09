using Glucometer.Application.Command;
using Glucometer.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Glucometer.WebApi.Controllers;

[ApiController]
[Route("v1/glucometer")]
public class GlucometerController : ControllerBase
{
    [Route("")]
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult PostAddTest([FromBody] AddTestCommand command, [FromServices] GlucometerService handler)
    {
        try
        {
            if (!command.Validate() || !ModelState.IsValid)
                return BadRequest();
            handler.Handle(command);
            return Ok("Adicionado com sucesso");
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpGet]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult GetTests([FromBody] GetGlucometerCommand command, [FromServices] GlucometerService handler)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var tests = handler.Handle(command);
            return Ok(tests);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpPut]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateTest([FromBody] UpdateTestCommand command, [FromServices] GlucometerService handler)
    {
        try
        {
            if (!command.Validate() || !ModelState.IsValid)
                return BadRequest();
            handler.Handle(command);
            return Ok("Atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("{Id}")]
    [HttpDelete]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteTest([FromBody] DeleteTestCommand command, [FromServices] GlucometerService handler)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();
            handler.Handle(command);
            return Ok("Deletado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
