namespace Common.String
{
    public class CustomStringConverter : ICustomStringConverter
    {
        #region Public Methods

        /// <summary>
        /// Splits the input string with the delimiter into a list of strings.
        /// </summary>
        /// <param name="input">The string that contains numbers with a delimiter.</param>
        /// <param name="delimiter">The separator.</param>
        /// <returns>A list of strings.</returns>
        public IList<string> ConvertStringWithSeparatorIntoStringList(string input, string delimiter)
        {
            return input.Split(delimiter).ToList();
        }

        /// <summary>
        /// Join a list of numbers into a string with the delimiter.
        /// </summary>
        /// <param name="input">The list of numbers.</param>
        /// <param name="delimiter">The separator.</param>
        /// <returns>A string of numbers with delimiter.</returns>
        public string ConvertStringListIntoStringWithSeparator(IList<string> input, string delimiter)
        {
            return string.Join(delimiter, input);
        }

        #endregion
    }
}
