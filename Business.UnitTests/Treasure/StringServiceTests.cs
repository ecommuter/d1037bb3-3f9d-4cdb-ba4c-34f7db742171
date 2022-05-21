namespace Business.UnitTests.Treasure
{
    public class StringServiceTests : TestsBase
    {
        #region Constructor

        public StringServiceTests()
        {
            _fixture.Customizations.Add(
                new TypeRelay(
                    typeof(ICustomStringConverter),
                    typeof(CustomStringConverter)));

            _fixture.Customizations.Add(
                new TypeRelay(
                    typeof(ICustomerNumberOperation),
                    typeof(CustomerNumberOperation)));

            _fixture.Customizations.Add(
                new TypeRelay(
                    typeof(IStringService),
                    typeof(StringService)));
        }

        #endregion

        #region Public Test Methods

        [Theory]
        [MemberData(nameof(TestData))]
        public void GetFirstLongestIncreasingSubsequence_ShouldReturnAString(string input, string delimiter, string output)
        {
            // arrange
            var sut = _fixture.Create<IStringService>();

            // act
            var result = sut.GetFirstLongestIncreasingSubsequence(input, delimiter);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(output);
        }

        #endregion

        #region Private Methods - Test Data

        // To test the whole business flows
        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "6 1 5 9 2", " ", "1 5 9" };
        }

        #endregion
    }
}
