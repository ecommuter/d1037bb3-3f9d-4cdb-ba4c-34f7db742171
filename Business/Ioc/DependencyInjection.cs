namespace Business.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddCommonUtilities();
            services.AddScoped<IStringService, StringService>();
            services.AddLogging();

            return services;
        }
    }
}
