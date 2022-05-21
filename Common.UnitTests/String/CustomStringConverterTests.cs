namespace Common.UnitTests.String
{
    public class CustomStringConverterTests : TestsBase
    {
        #region Constructor

        public CustomStringConverterTests()
        {
            _fixture.Customizations.Add(
                new TypeRelay(
                    typeof(ICustomStringConverter),
                    typeof(CustomStringConverter)));
        }

        #endregion

        #region Public Test Methods

        [Theory]
        [MemberData(nameof(TestStringData))]
        public void ConvertStringWithSeparatorIntoStringList_ShouldReturnAListOfStrings(string input, string delimiter, IList<string> output)
        {
            // arrange
            var sut = CreateCustomStringConverter();

            // act
            var result = sut.ConvertStringWithSeparatorIntoStringList(input, delimiter);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().AllBeOfType<string>();
            result.Should().BeEquivalentTo(output);
        }

        [Theory]
        [MemberData(nameof(TestStringListData))]
        public void ConvertStringListToNumberList_ShouldReturnAListOfNumbers(IList<string> input, IList<int> output)
        {
            // arrange
            var sut = CreateCustomStringConverter();

            // act
            var result = sut.ConvertStringListToNumberList(input);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().AllBeOfType<int>();
            result.Should().BeEquivalentTo(output);
        }

        [Theory]
        [MemberData(nameof(TestStringListInvalidData))]
        public void ConvertStringListToNumberList_ShouldReturnEmptyList_WhenInputIsInvalid(IList<string> input)
        {
            // arrange
            var sut = CreateCustomStringConverter();

            // act
            var result = sut.ConvertStringListToNumberList(input);

            // assert
            result.Should().BeEmpty();
        }

        #endregion

        #region Private Methods

        private ICustomStringConverter CreateCustomStringConverter() => _fixture.Create<ICustomStringConverter>();

        #endregion

        #region Private Methods - Test Data

        // To test spliting with the delimiter.
        private static IEnumerable<object[]> TestStringData()
        {
            yield return new object[] { "6 1 5 9 2", " ", new List<string> { "6", "1", "5", "9", "2" } };
            yield return new object[] { "61592", " ", new List<string> { "61592" } };
        }

        // To test conversion from a list of strings to a list of numbers.
        private static IEnumerable<object[]> TestStringListData()
        {
            yield return new object[] { new List<string> { "6", "1", "5", "9", "2" }, new List<int> { 6, 1, 5, 9, 2 } };
        }

        // To test invalid list of strings for conversion to a list of numbers.
        private static IEnumerable<object[]> TestStringListInvalidData()
        {
            yield return new object[] { new List<string> { "a", "b", "c" } };
        }

        #endregion
    }
}