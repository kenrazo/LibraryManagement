using FluentValidation;
using LibraryManagement.Application.Abstractions.Pipelines;
using LibraryManagement.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryManagement.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddMediatR(m =>
                {
                    m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                })
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>))
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly());

            return services;
        }

        private static IServiceCollection AddAutoMapperProfile(
            this IServiceCollection services, Assembly assembly)
            => services
                .AddAutoMapper(
                (_, config) => config
                .AddProfile(new MappingProfile(assembly)),
                Array.Empty<Assembly>());
    }
}
