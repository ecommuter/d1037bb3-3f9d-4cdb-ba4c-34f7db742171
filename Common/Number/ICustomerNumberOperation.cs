namespace Common.Number
{
    public interface ICustomerNumberOperation
    {
        IOrderedEnumerable<KeyValuePair<int, IList<int>>> SortDictionaryInDescendingOrder(IDictionary<int, IList<int>> input);

        IDictionary<int, IList<int>> ConvertNumberListToDictionary(IList<int> input);

        IEnumerable<IList<int>> CreateNumberIncrementSegments(IList<int> input);
    }
}
