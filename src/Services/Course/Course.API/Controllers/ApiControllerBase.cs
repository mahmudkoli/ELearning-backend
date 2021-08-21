using Course.API.Extensions;
using ELearning.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Course.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        protected IActionResult OkResult(object data)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Status = ApiResponseStatus.Success.ToString(),
                Message = "The operation has been successful.",
                Data = data
            };
            return ObjectResult(apiResult);
        }

        protected IActionResult OkResult(object data, string message)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Status = ApiResponseStatus.Success.ToString(),
                Message = message,
                Data = data
            };
            return ObjectResult(apiResult);
        }

        protected IActionResult ValidationResult(ModelStateDictionary modelState)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Status = ApiResponseStatus.ValidationError.ToString(),
                Message = "One or more validation failures have occurred.",
                Errors = modelState.GetErrors()
            };
            return ObjectResult(apiResult);
        }

        protected IActionResult BadRequestResult(Exception ex)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Status = ApiResponseStatus.Error.ToString(),
                Message = ex.Message,
                Data = new object(),
                Errors = new List<ValidationError> { new ValidationError { PropertyName = "", PropertyFailures = new string[] { ex.Message } } }
            };
            return ObjectResult(apiResult);
        }

        protected IActionResult ExceptionResult(Exception ex)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Status = ApiResponseStatus.Error.ToString(),
                Message = ex.Message,
                Data = new object(),
                Errors = new List<ValidationError> { new ValidationError { PropertyName = "", PropertyFailures = new string[] { ex.Message } } }
            };
            return ObjectResult(apiResult);
        }

        protected IActionResult ObjectResult(ApiResponse model)
        {
            var result = new ObjectResult(model)
            {
                StatusCode = model.StatusCode
            };
            return result;
        }
    }
}
