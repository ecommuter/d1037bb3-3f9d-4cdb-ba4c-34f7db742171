namespace Common.String
{
    public interface ICustomStringConverter
    {
        IList<int> ConvertStringListToNumberList(IList<string> input);

        IList<string> ConvertStringWithSeparatorIntoStringList(string input, string delimiter);
    }
}