namespace Common.Number
{
    public interface ICustomerNumberOperation
    {
        IEnumerable<IList<int>> CreateNumberIncrementSegments(IList<int> input);
    }
}
