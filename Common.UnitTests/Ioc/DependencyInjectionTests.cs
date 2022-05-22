namespace Common.UnitTests.Ioc
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void Service_Should_Get_Resolved()
        {
            var services = new ServiceCollection();
            services.AddCommonUtilities();

            var serviceProvider = services.BuildServiceProvider();

            //Act
            var stringService = serviceProvider.GetService<ICustomStringConverter>();

            //Assert
            stringService.Should().NotBeNull();
            stringService.Should().BeOfType<CustomStringConverter>();
        }
    }
}
