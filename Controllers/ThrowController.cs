using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() => Problem();

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment()) 
            {
                return NotFound();
            }

            var exceptionHedlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem
            (
                detail: exceptionHedlerFeature.Error.StackTrace,
                title: exceptionHedlerFeature.Error.Message
            );
        }
    }
}
