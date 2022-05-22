namespace Common.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonUtilities(this IServiceCollection services)
        {
            services.AddScoped<ICustomStringConverter, CustomStringConverter>();
            services.AddScoped<ICustomerNumberOperation, CustomerNumberOperation>();

            return services;
        }
    }
}
