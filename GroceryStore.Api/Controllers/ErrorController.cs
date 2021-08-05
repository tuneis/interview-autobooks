using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroceryStore.Api.Controllers
{
    /// <summary>
    ///     A "catch-all" error handling controller.
    /// </summary>
    [ApiController]
    public class ErrorController : Controller
    {
        /// <summary>
        ///     A logger
        /// </summary>
        private readonly ILogger<ErrorController> _logger;

        /// <summary>
        ///     The almighty constructor.
        /// </summary>
        /// <param name="logger"></param>
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Development error handling that includes stack traces.
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");


            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            _logger.LogError(context.Error, context.Error.Message);

            return Problem(
                context.Error.StackTrace,
                title: context.Error.Message);
        }

        /// <summary>
        ///     Production ready error handling.
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            // get exception handling feature
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            // check context
            if (context == null)
                return Problem();

            // log error
            _logger.LogError(context.Error, context.Error.Message);

            // if explicit app exception is thrown we want the error message
            return Problem(title: context.Error.Message);
        }
    }
}