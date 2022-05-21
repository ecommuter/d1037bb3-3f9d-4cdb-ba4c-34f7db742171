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
        /// <returns></returns>
        public IList<string> ConvertStringWithSeparatorIntoStringList(string input, string delimiter)
        {
            return input.Split(delimiter).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IList<int> ConvertStringListToNumberList(IList<string> input)
        {
            return input.Where(s => int.TryParse(s, out _)).Select(int.Parse).ToList();
        }

        #endregion
    }
}
