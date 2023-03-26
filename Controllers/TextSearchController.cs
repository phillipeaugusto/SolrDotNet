using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchText.Domain.Command;
using SearchText.Dto.Input;
using SearchText.Services;

namespace SearchText.Controllers;

[Route("v1/text-search")]
public class TextSearchController: ControllerBase
{
    [HttpPost]
    [Route("/text")]
    public async Task<ActionResult<IResult>> AddText(
        [FromBody] TextInputDto textInputDto,
        [FromServices] DocumentService service 
    )
    {
        try
        {
            var serviceCommand = new TextInputCommand(textInputDto);
            var result = await service.Service(serviceCommand);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPost]
    [Route("/pdf")]
    public async Task<ActionResult<IResult>> AddPdf(
        [FromServices] DocumentService service,
        [FromForm] PdfInputDto pdfInputDto 
    )
    {
        try
        {
            var serviceCommand = new PdfInputCommand(pdfInputDto);
            var result = await service.Service(serviceCommand);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpGet]
    [Route("/search")]
    public async Task<ActionResult<IResult>> Search(
        [FromServices] DocumentService service,
        [FromQuery] string searchText,
        [FromQuery] string fieldSearch
    )
    {
        try
        {
            var serviceCommand = new TextSearchCommand(searchText, fieldSearch);
            var result = await service.Service(serviceCommand);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}