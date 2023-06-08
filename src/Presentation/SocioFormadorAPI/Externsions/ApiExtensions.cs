using SocioFormadorAPI.Midleware;

namespace SocioFormadorAPI.Externsions
{
    public static class ApiExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMidleware>();
        }
    }
}
