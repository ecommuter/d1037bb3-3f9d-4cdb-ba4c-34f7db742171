namespace Common.UnitTests.Number
{
    public class CustomerNumberOperationTests : TestsBase
    {
        #region Constructor

        public CustomerNumberOperationTests()
        {
            _fixture.Customizations.Add(
                new TypeRelay(
                    typeof(ICustomerNumberOperation),
                    typeof(CustomerNumberOperation)));
        }

        #endregion

        #region Public Test Methods

        [Theory]
        [MemberData(nameof(TestData))]
        public void CreateNumberIncrementSegments_ShouldReturnListsOfSegments(IList<int> input, IDictionary<int, IList<int>> output)
        {
            // arrange
            var sut = CreateCustomerNumberOperation();

            // act
            var result = sut.CreateNumberIncrementSegments(input);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(output.Values);
        }

        #endregion

        #region Private Methods

        private ICustomerNumberOperation CreateCustomerNumberOperation() => _fixture.Create<ICustomerNumberOperation>();

        #endregion

        #region Private Methods - Test Data

        // To test conversion from a list of number to a dictionary
        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] { new List<int> { 6, 1, 5, 9, 2 }, new Dictionary<int, IList<int>>() 
            {
                { 1, new List<int> { 6 } },
                { 2, new List<int> { 1, 5, 9 } },
                { 3, new List<int> { 2 } }
            } };
        }

        #endregion
    }
}
