using Application.Features.Card.Command.CreateCard;
using Application.Features.Card.Queries.GetAllCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Endpoints
{
    public static class CardEndpoints
    {
        public static void AddCardEndpoints(this WebApplication app)
        {
            app.MapPost("/addcard", async ([FromBody]CreateCardCommandRequest request, [FromServices]IMediator mediator) =>
            {
                var response = await mediator.Send(request);
                return response;
            }).RequireAuthorization();

            app.MapGet("/getcardsByUserId", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCardByUserIdQueryRequest() { });
                return Results.Ok(response);
            }).RequireAuthorization();

        }

    }
}
