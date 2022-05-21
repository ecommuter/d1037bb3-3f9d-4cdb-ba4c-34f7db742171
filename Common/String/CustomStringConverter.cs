namespace Common.String
{
    public class CustomStringConverter : ICustomStringConverter
    {
        #region Public Methods

        /// <summary>
        /// Splits the input string with the delimiter into a list of strings.
        /// </summary>
        /// <param name="input">The string that contains numbers with a delimiter.</param>
        /// <param name="delimiter"></param>
        /// <returns>A list of strings.</returns>
        public IList<string> ConvertStringWithSeparatorIntoStringList(string input, string delimiter)
        {
            return input.Split(delimiter).ToList();
        }

        /// <summary>
        /// Convert a list of number strings to a list of numbers.
        /// </summary>
        /// <param name="input">A string with numbers separated with a delimiter.</param>
        /// <returns>A list of numbers.</returns>
        public IList<int> ConvertStringListToNumberList(IList<string> input)
        {
            return input.Where(s => int.TryParse(s, out _)).Select(int.Parse).ToList();
        }

        #endregion
    }
}
