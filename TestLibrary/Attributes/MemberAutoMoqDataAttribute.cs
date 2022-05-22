namespace TestLibrary.Attributes
{
    /// <summary>
    /// The member auto moq data attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MemberAutoMoqDataAttribute : MemberAutoDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberAutoMoqDataAttribute"/> class.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="parameters">The parameters.</param>
        public MemberAutoMoqDataAttribute(string memberName, params object[] parameters)
            : base(new AutoMoqDataAttribute(), memberName, parameters)
        {
        }
    }
}
