namespace Common.UnitTests.String
{
    public class CustomStringConverterTests
    {
        [Theory]
        [InlineData("6 1 5 9 2", " ")]
        public void ConvertStringWithSeparatorIntoStringList_ShouldReturnAListOfStrings_InlineDataTests(string input, string delimiter)
        {
            // arrange
            var sut = new CustomStringConverter();

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
            var sut = new CustomStringConverter();

            // act
            var stringList = sut.ConvertStringWithSeparatorIntoStringList(input, delimiter);
            var result = sut.ConvertStringListToNumberList(stringList);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().AllBeOfType<int>();
            result.Should().HaveSameCount(stringList);
        }
    }
}
