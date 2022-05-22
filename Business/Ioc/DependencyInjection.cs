namespace Business.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddCommonUtilities();
            services.AddScoped<IStringService, StringService>();

            return services;
        }
    }
}
