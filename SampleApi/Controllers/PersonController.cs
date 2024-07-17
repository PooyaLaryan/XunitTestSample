using Microsoft.AspNetCore.Mvc;
using SampleApi.Model;
using SampleApi.Service;

namespace SampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(IPersonService personService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> InsertAsync(PersonDto personDto)
    {
        var id = await personService.InsertAsync(personDto);
        personService.ExplicitMethodTest();
        return Ok(id);
    }
}
