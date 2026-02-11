using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            // Se agregan todos los validators que se vayan a crear en su respectiva carpeta.
            // https://docs.fluentvalidation.net/en/latest/aspnet.html
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Behaviors.ValidationBehavior<,>));
            return services;
        }
    }
}
