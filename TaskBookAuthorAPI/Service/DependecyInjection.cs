using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Service.DTOs.Account;
using Service.Helpers;
using Service.Services.Interfaces;
using Service.Services;
using FluentValidation.AspNetCore;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();


            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();


            return services;
        }
    }
}
