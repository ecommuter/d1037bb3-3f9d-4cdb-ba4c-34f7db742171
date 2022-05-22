namespace TestLibrary.Attributes
{
    /// <summary>
    /// Helper DataAttribute to use the regular xUnit based DataAttributes with AutoFixture and Mocking capabilities.
    /// </summary>
    /// <seealso cref="Xunit.Sdk.DataAttribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AutoCompositeDataAttribute : DataAttribute
    {
        /// <summary>
        /// The attributes
        /// </summary>
        private readonly DataAttribute baseAttribute;

        /// <summary>
        /// The automatic data attribute
        /// </summary>
        private readonly DataAttribute autoDataAttribute;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompositeDataAttribute" /> class.
        /// </summary>
        /// <param name="baseAttribute">The base attribute.</param>
        /// <param name="autoDataAttribute">The automatic data attribute.</param>
        public AutoCompositeDataAttribute(DataAttribute baseAttribute, DataAttribute autoDataAttribute)
        {
            this.baseAttribute = baseAttribute;
            this.autoDataAttribute = autoDataAttribute;
        }

        /// <summary>
        /// Returns the data to be used to test the theory.
        /// </summary>
        /// <param name="testMethod">The method that is being tested</param>
        /// <returns>
        /// One or more sets of theory data. Each invocation of the test method
        /// is represented by a single object array.
        /// </returns>
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            var data = this.baseAttribute.GetData(testMethod);

            foreach (var datum in data)
            {
                var autoData = this.autoDataAttribute.GetData(testMethod).ToArray()[0];

                for (var i = 0; i < datum.Length; i++)
                {
                    autoData[i] = datum[i];
                }

                yield return autoData;
            }
        }
    }
}
