namespace Common.Number
{
    public class CustomerNumberOperation : ICustomerNumberOperation
    {
        public IEnumerable<IList<int>> CreateNumberIncrementSegments(IList<int> input)
        {
            IList<int> newList = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (!newList.Any())
                {
                    newList.Add(input[i]);
                }
                else
                {
                    var previousNumber = input[i - 1];
                    if (previousNumber > input[i])
                    {
                        yield return newList;
                        newList = new List<int>() { input[i] };
                        if (i == input.Count - 1)
                        {
                            yield return newList;
                        }
                    }
                    else
                    {
                        newList.Add(input[i]);
                    }
                }
            }
        }
    }
}
