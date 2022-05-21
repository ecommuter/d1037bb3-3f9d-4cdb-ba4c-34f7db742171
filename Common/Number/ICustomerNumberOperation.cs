namespace Common.Number
{
    public interface ICustomerNumberOperation
    {
        IDictionary<int, IList<int>> ConvertNumberListToDictionary(IList<int> input);

        IEnumerable<IList<int>> CreateNumberIncrementSegments(IList<int> input);
    }
}
