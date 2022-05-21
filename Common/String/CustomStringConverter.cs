namespace Common.String
{
    public class CustomStringConverter
    {
        public IList<string> ConvertStringWithSeparatorIntoStringList(string input, string delimiter)
        {
            return input.Split(delimiter).ToList();
        }
    }
}
