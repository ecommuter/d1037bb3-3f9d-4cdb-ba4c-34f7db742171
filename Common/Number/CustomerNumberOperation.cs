namespace Common.Number
{
    /// <summary>
    /// People asked why we do unit testing on those methods that only using the built in methods from the framework,
    /// the reason is simply because we do not want to assume those methods will never be changed,
    /// additional logics might be added to break its original purpose hence it is kind of reasonalbe to 
    /// test them as well, and that is the purpose of unit testing too.
    /// </summary>
    public class CustomerNumberOperation : ICustomerNumberOperation
    {
        /// <summary>
        /// Sort the dictionary of number segments.
        /// </summary>
        /// <param name="input">the dictionary of number segments.</param>
        /// <returns>Ordered dictionary of number segments.</returns>
        public IOrderedEnumerable<KeyValuePair<int, IList<int>>> SortDictionaryInDescendingOrder(IDictionary<int, IList<int>> input)
        {
            return input.OrderByDescending(i => i.Value.Count).ThenBy(i => i.Key);
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
                    // This deals with the first item
                    newList.Add(input[i]);
                }
                else
                {
                    var previousNumber = input[i - 1];
                    if (previousNumber > input[i])
                    {
                        yield return newList;
                        newList = new List<int>() { input[i] };
                    }
                    else
                    {
                        newList.Add(input[i]);
                    }
                }

                // This is the last item
                if (i == input.Count - 1)
                {
                    yield return newList;
                }
            }
        }

        /// <summary>
        /// Convert a list of number strings to a list of numbers.
        /// </summary>
        /// <param name="input">A string with numbers separated with a delimiter.</param>
        /// <returns>A list of numbers.</returns>
        public IList<int> ConvertStringListToNumberList(IList<string> input)
        {
            return input.Where(s => int.TryParse(s, out _)).Select(int.Parse).ToList();
        }

        /// <summary>
        /// Convert a list of number to a list of strings.
        /// </summary>
        /// <param name="input">A list of numbers.</param>
        /// <returns>A list of strings.</returns>
        public IList<string> ConvertNumberListToStringList(IList<int> input)
        {
            return input.ToList().ConvertAll(x => x.ToString());
        }
    }
}
