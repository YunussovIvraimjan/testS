using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class IndexController : ControllerBase
{
    [HttpGet]
    [ActionName("")]
    public ContentResult GeHtml()
    {
        try
        {
            string html = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <title>Title</title>
</head>
<body>
<form method=""post"" action=""index/addUser"">
    <label for=""firstName"">First name:</label><br>
    <input type=""text"" id=""firstName"" name=""firstName"" value=""John""><br>
    <label for=""lastName"">Last name:</label><br>
    <input type=""text"" id=""lastName"" name=""lastName"" value=""Doe""><br><br>
    <input type=""submit"" value=""Submit"">
</form>
</body>
</html>";

            var directory = Directory.GetCurrentDirectory();

            var path = $"{directory}/index.html";
            
            var readAllText = System.IO.File.ReadAllText(path);

            return new ContentResult
            {
                Content = readAllText,
                ContentType = "text/html"
            };
            return Content(html);
        }
        catch (Exception e)
        {
            throw;
        }
    }
    
    
    [HttpGet]
    [ActionName("GetById")]
    [ProducesResponseType(typeof(IndexExampleResponse), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(Error))]
    [SwaggerOperation(
        Summary = "Получение по айди",
        Description = "Получаем что-то по айди, если не найдно получаем 500 ошибку",
        Tags = new []{"Users"},
        OperationId = "GetById")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(new IndexExampleResponse());
        }
        catch (Exception e)
        {
            return StatusCode(500, new Error());
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(Error))]
    public IActionResult Add(ExampleRequest request)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, new Error());
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(Error))]
    public IActionResult AddUser([FromForm]ExampleRequest request)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, new Error());
        }
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(Error))]
    public IActionResult Delete(ExampleRequest request)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, new Error());
        }
    }
    
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(Error))]
    public IActionResult Path(ExampleRequest request)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, new Error());
        }
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(Error))]
    public IActionResult Put(ExampleRequest request)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, new Error());
        }
    }
}

public class ExampleRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class IndexExampleResponse
{
    public object Data { get; set; }
}

public class Error
{
    public string Message { get; set; }
}