namespace Common.Contract
{
    public interface ICustomStringConverter
    {
        IList<string> ConvertStringWithSeparatorIntoStringList(string input, string delimiter);

        string ConvertStringListIntoStringWithSeparator(IList<string> input, string delimiter);
    }
}