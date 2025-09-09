using Application.Features.Auth.Command.Login;
using Application.Features.Auth.Command.Register;
using MediatR;

namespace BankingApp.Endpoints
{
    public static  class AuthEndpoints
    {
        public static void AddAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/api/auth/register", async (RegisterCommandRequest request, IMediator mediator) =>
            {
                await mediator.Send(request);
                return Results.Ok("User successfully registered");
            });


            app.MapPost("/api/auth/login", async (LoginCommandRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(request);
                return result;
            });
        }
    }
}
