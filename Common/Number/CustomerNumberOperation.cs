namespace Common.Number
{
    public class CustomerNumberOperation : ICustomerNumberOperation
    {
        /// <summary>
        /// Sort the dictionary of number segments.
        /// </summary>
        /// <param name="input">the dictionary of number segments.</param>
        /// <returns>Ordered dictionary of number segments.</returns>
        public IOrderedEnumerable<KeyValuePair<int, IList<int>>> SortDictionaryInDescendingOrder(IDictionary<int, IList<int>> input)
        {
            return input.OrderByDescending(i => i.Value.Count).OrderBy(i => i.Key);
        }

        /// <summary>
        /// Create a dictionary from many lists of number segements.
        /// </summary>
        /// <param name="input">A list of numbers.</param>
        /// <returns>A dictionary of number segments.</returns>
        public IDictionary<int, IList<int>> ConvertNumberListToDictionary(IList<int> input)
        {
            IDictionary<int, IList<int>> dict = new Dictionary<int, IList<int>>();

            int key = 0;

            CreateNumberIncrementSegments(input).ToList().ForEach(s =>
            {
                key += 1;
                dict.Add(key, s);
            });

            return dict;
        }

        /// <summary>
        /// Create increasing number segments.
        /// </summary>
        /// <param name="input">A list of numbers.</param>
        /// <returns>A list of number segment.</returns>
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
