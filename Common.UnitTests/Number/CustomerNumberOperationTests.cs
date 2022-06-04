namespace Common.UnitTests.Number
{
    /// <summary>
    /// People asked why we do unit testing on those methods that only using the built in methods from the framework,
    /// the reason is simply because we do not want to assume those methods will never be changed,
    /// additional logics might be added to break its original purpose hence it is kind of reasonalbe to 
    /// test them as well, and that is the purpose of unit testing too.
    /// 
    /// We are testing the promise of the methods, not the methods' implementations by using either build in framework methods
    /// or writing own logics to return the same results. The promise can be broken once newly added in logics (due to a new 
    /// requirement or incorrect logics) that break its original purpose.
    /// </summary>
    public class CustomerNumberOperationTests
    {
        #region Public Test Methods

        [Theory]
        [MemberAutoMoqData(nameof(TestData))]
        public void CreateNumberIncrementSegments_ShouldReturnListsOfSegments(IList<int> input, IDictionary<int, IList<int>> output, CustomerNumberOperation sut)
        {
            // arrange is done by AutoMoq

            // act
            var result = sut.CreateNumberIncrementSegments(input);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(output.Values);
        }

        [Theory]
        [MemberAutoMoqData(nameof(TestData))]
        public void ConvertNumberListToDictionary_ShouldReturnADictionaryOfSegments(IList<int> input, IDictionary<int, IList<int>> output, CustomerNumberOperation sut)
        {
            // arrange is done by AutoMoq

            // act
            var result = sut.ConvertNumberListToDictionary(input);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(output);
        }

        [Theory]
        [MemberAutoMoqData(nameof(TestDataOrdering))]
        public void SortDictionaryInDescendingOrder_ShouldReturnAListOfStrings(IDictionary<int, IList<int>> input, IDictionary<int, IList<int>> output, CustomerNumberOperation sut)
        {
            // arrange is done by AutoMoq

            // act
            var result = sut.SortDictionaryInDescendingOrder(input);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(output);
        }

        [Theory]
        [MemberAutoMoqData(nameof(TestStringListData))]
        public void ConvertStringListToNumberList_ShouldReturnAListOfNumbers(IList<string> input, IList<int> output, CustomerNumberOperation sut)
        {
            // arrange is done by AutoMoq

            // act
            var result = sut.ConvertStringListToNumberList(input);

            // assert
            result.Should().NotBeNullOrEmpty();
            result.Should().AllBeOfType<int>();
            result.Should().BeEquivalentTo(output);
        }

        [Theory]
        [MemberAutoMoqData(nameof(TestStringListInvalidData))]
        public void ConvertStringListToNumberList_ShouldReturnEmptyList_WhenInputIsInvalid(IList<string> input, CustomerNumberOperation sut)
        {
            // arrange is done by AutoMoq

            // act
            var result = sut.ConvertStringListToNumberList(input);

            // assert
            result.Should().BeEmpty();
        }

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

        // To test the reordering of the dictionary
        private static IEnumerable<object[]> TestDataOrdering()
        {
            yield return new object[] { 
                new Dictionary<int, IList<int>>()
                {
                    { 1, new List<int> { 6 } },
                    { 2, new List<int> { 1, 5, 9 } },
                    { 3, new List<int> { 2 } }
                }, 
                new Dictionary<int, IList<int>>()
                {
                    { 2, new List<int> { 1, 5, 9 } },
                    { 1, new List<int> { 6 } },
                    { 3, new List<int> { 2 } }
                }
            };
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
