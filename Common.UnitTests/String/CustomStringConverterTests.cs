namespace Common.UnitTests.String
{
    public class CustomStringConverterTests
    {
        private readonly Fixture _fixture;

        public CustomStringConverterTests()
        {
            _fixture = new Fixture();

            _fixture.Customizations.Add(
                new TypeRelay(
                    typeof(ICustomStringConverter),
                    typeof(CustomStringConverter)));
        }

        [Theory]
        [InlineData("6 1 5 9 2", " ")]
        public void ConvertStringWithSeparatorIntoStringList_ShouldReturnAListOfStrings_InlineDataTests(string input, string delimiter)
        {
            // arrange
            var sut = CreateCustomStringConverter();

            // act
            var result = sut.ConvertStringWithSeparatorIntoStringList(input, delimiter);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().AllBeOfType<string>();
        }

        [Theory]
        [InlineData("6 1 5 9 2", " ")]
        public void ConvertStringListToNumberList_ShouldReturnAListOfNumbers_InlineDataTests(string input, string delimiter)
        {
            // arrange
            var sut = CreateCustomStringConverter();

            // act
            var stringList = sut.ConvertStringWithSeparatorIntoStringList(input, delimiter);
            var result = sut.ConvertStringListToNumberList(stringList);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().AllBeOfType<int>();
            result.Should().HaveSameCount(stringList);
        }

        private ICustomStringConverter CreateCustomStringConverter() => _fixture.Create<ICustomStringConverter>();
    }
}
