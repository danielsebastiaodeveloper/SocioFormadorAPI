using System.Net;
using System.Text.Json;
using SocioFormador.Application.Wrappers;

namespace SocioFormadorAPI.Midleware
{
    public class ErrorHandlerMidleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMidleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Success = false, Message = error.Message };

                switch (error)
                {
                    case SocioFormador.Application.Exceptions.ApiExceptions e:
                        //Custom Aplication Error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        break;

                    case SocioFormador.Application.Exceptions.ValidationException e:
                        // Custom Application
                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        //Not Found Error
                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        break;
                    default:
                        //unhandle Error 
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);

            }
        }
    }
}
