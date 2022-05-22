namespace Business.UnitTests.Ioc
{
    public class DependencyInjectionTests
    {
        [Fact(Skip = "Only want to show the 11 test cases")]
        public void Service_Should_Get_Resolved()
        {
            var services = new ServiceCollection();
            services.AddBusinessServices();

            var serviceProvider = services.BuildServiceProvider();

            //Act
            var stringService = serviceProvider.GetService<IStringService>();

            //Assert
            stringService.Should().NotBeNull();
            stringService.Should().BeOfType<StringService>();
        }
    }
}
