namespace Business.Treasure
{
    public class StringService : IStringService
    {
        #region Private Fields

        private readonly ICustomStringConverter _customStringConverter;

        #endregion

        #region Constructor

        public StringService(ICustomStringConverter customStringConverter)
        {
            _customStringConverter = customStringConverter;
        }

        #endregion

        #region Public Test Methods

        public IList<int> GetFirstLongestIncreasingSubsequence(string input, string delimiter)
        {
            var stringList = _customStringConverter.ConvertStringWithSeparatorIntoStringList(input, delimiter);
            return _customStringConverter.ConvertStringListToNumberList(stringList);
        }

        #endregion
    }
}
