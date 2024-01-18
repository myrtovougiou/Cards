using CardsApi.Abstractions.Mappers;
using CardsApi.Abstractions.Repositories;
using CardsApi.Abstractions.Services;
using CardsApi.Dtos;
using CardsApi.Mappers;
using CardsApi.Models;
using CardsApi.Repositories;
using CardsApi.Requests;
using CardsApi.Services;
using CardsApi.Validators;
using FluentValidation;

namespace CardsApi.Extensions
{
    public static class RegistrationExtensions
    {
        public static void RegisterMappers(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMapper<Card, CardRequest>, CardRequestMapper>();
            builder.Services.AddScoped<IMapper<CardRequest, Card>, CardMapper>();
            builder.Services.AddScoped<IMapper<CreateCardRequest, Card>, CreateCardRequestToCardMapper>();
            builder.Services.AddScoped<IMapper<Card, CardDto>, CardDtoMapper>();
            builder.Services.AddScoped<IMapper<User, UserDto>, UserDtoMapper>();
        }

        public static void RegisterRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICardRepository, CardRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICardService, CardService>();
            builder.Services.AddScoped<IUserService, UserService>();
        }

        public static void RegisterValidators(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<Card>, CardValidator>();
        }
    }
}
