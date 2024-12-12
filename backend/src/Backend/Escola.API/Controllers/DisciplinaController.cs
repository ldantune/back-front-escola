using Escola.Application.UseCases.Disciplinas.Get;
using Escola.Application.UseCases.Disciplinas.GetByCodDisc;
using Escola.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DisciplinaController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseDisciplinasJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetDisciplinasUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Disciplinas.Any())
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseDisciplinaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCodDisc(
        [FromServices] IGetByCodDisciplinaUseCase useCase,
        [FromRoute] int id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }
}
