using Microsoft.Extensions.Logging;

namespace Business.Treasure
{
    public class StringService : IStringService
    {
        #region Private Fields

        private readonly ICustomStringConverter _customStringConverter;
        private readonly ICustomerNumberOperation _customerNumberOperation;
        private readonly ILogger<StringService> _logger;

        #endregion

        #region Constructor

        public StringService(
            ICustomStringConverter customStringConverter, 
            ICustomerNumberOperation customerNumberOperation,
            ILogger<StringService> logger)
        {
            _customStringConverter = Guard.Against.Null(customStringConverter, nameof(customStringConverter));
            _customerNumberOperation = Guard.Against.Null(customerNumberOperation, nameof(customerNumberOperation));
            _logger = Guard.Against.Null(logger, nameof(logger));
        }

        #endregion

        #region Public Test Methods

        /// <summary>
        /// This method controls the flow.
        /// </summary>
        /// <param name="input">The input string for numbers separated with whitespace.</param>
        /// <param name="delimiter">The separator between numbers in the input string.</param>
        /// <returns>The first string with longest increasing subsequence.</returns>
        public string GetFirstLongestIncreasingSubsequence(string input, string delimiter)
        {
            var firstLongestNumberSequence = string.Empty;

            try
            {
                var stringList = _customStringConverter.ConvertStringWithSeparatorIntoStringList(input, delimiter);
                var numberList = _customerNumberOperation.ConvertStringListToNumberList(stringList);
                var segmentsDictionary = _customerNumberOperation.ConvertNumberListToDictionary(numberList);
                var orderedSegments = _customerNumberOperation.SortDictionaryInDescendingOrder(segmentsDictionary);

                var firstSegment = orderedSegments.FirstOrDefault();

                var numbersString = _customerNumberOperation.ConvertNumberListToStringList(firstSegment.Value);
                firstLongestNumberSequence = _customStringConverter.ConvertStringListIntoStringWithSeparator(numbersString, delimiter);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred when executing the GetFirstLongestIncreasingSubsequence method in the StringService with message {Error}", ex.Message);
            }

            return firstLongestNumberSequence;
        }

        #endregion
    }
}
