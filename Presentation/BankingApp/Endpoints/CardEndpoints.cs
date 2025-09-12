using Application.Features.Card.Command.CashbackToBalance;
using Application.Features.Card.Command.CreateCard;
using Application.Features.Card.Command.IncreaseCardBalance;
using Application.Features.Card.Command.Payment;
using Application.Features.Card.Queries.GetAllCard;
using Application.Features.Card.Command.CardToCardTransfer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Card.Command.UpdateExpiryDate;

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

            app.MapPost("/increaseCardBalance", async ([FromBody] IncreaseCardBalanceCommandRequest request, [FromServices] IMediator mediator) =>
            {
                var response = await mediator.Send(request);
                return response;
            }).RequireAuthorization();

            app.MapPost("/payment", async ([FromBody] PaymentCommandRequest request, [FromServices] IMediator mediator) =>
            {
                var response = await mediator.Send(request);
                return response;
            }).RequireAuthorization();

            app.MapPost("/cashbackToBalance", async ([FromBody] CashbackToBalanceCommandRequest request, [FromServices] IMediator mediator) =>
            {
                var response = await mediator.Send(request);
                return response;
            }).RequireAuthorization();

            app.MapPost("/cardToCard", async ([FromBody] CardToCardCommandRequest request, [FromServices] IMediator mediator) =>
            {
                var response = await mediator.Send(request);
                return response;
            }).RequireAuthorization();

            app.MapPost("/newExpiryDate", async ([FromBody] UpdateExpiryDateCommandRequest request, [FromServices] IMediator mediator) =>
            {
                var response = await mediator.Send(request);
                return response;
            }).RequireAuthorization();
        }

    }
}
