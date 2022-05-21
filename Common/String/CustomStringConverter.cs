namespace Common.String
{
    public class CustomStringConverter
    {
        public IList<string> ConvertStringWithSeparatorIntoStringList(string input, string delimiter)
        {
            return input.Split(delimiter).ToList();
        }

        public IList<int> ConvertStringListToNumberList(IList<string> input)
        {
            return input.Where(s => int.TryParse(s, out _)).Select(int.Parse).ToList();
        }
    }
}
