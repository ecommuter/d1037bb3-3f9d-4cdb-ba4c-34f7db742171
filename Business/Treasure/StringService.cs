namespace Business.Treasure
{
    public class StringService : IStringService
    {
        #region Private Fields

        private readonly ICustomStringConverter _customStringConverter;
        private readonly ICustomerNumberOperation _customerNumberOperation;

        #endregion

        #region Constructor

        public StringService(ICustomStringConverter customStringConverter, ICustomerNumberOperation customerNumberOperation)
        {
            _customStringConverter = customStringConverter;
            _customerNumberOperation = customerNumberOperation;
        }

        #endregion

        #region Public Test Methods

        /// <summary>
        /// This method controls the flow.
        /// </summary>
        /// <param name="input">The input string for numbers separated with whitespace.</param>
        /// <param name="delimiter">The separator between numbers in the input string.</param>
        /// <returns>The first string with longest increasing subsequence.</returns>
        public IList<int> GetFirstLongestIncreasingSubsequence(string input, string delimiter)
        {
            var stringList = _customStringConverter.ConvertStringWithSeparatorIntoStringList(input, delimiter);
            return _customStringConverter.ConvertStringListToNumberList(stringList);
        }

        #endregion
    }
}
