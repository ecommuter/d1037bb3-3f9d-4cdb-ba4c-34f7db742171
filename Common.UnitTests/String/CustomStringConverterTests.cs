namespace Common.UnitTests.String
{
    public class CustomStringConverterTests
    {
        [Theory]
        [InlineData("6 1 5 9 2", " ")]
        public void ConvertStringWithSeparatorIntoStringList_ShouldReturnAListOfNumbers_InlineDataTests(string input, string delimiter)
        {
            // arrange
            var sut = new CustomStringConverter();

            // act
            var result = sut.ConvertStringWithSeparatorIntoStringList(input, delimiter);

            // assert
            result.Should().NotBeNullOrEmpty();
        }
    }
}
