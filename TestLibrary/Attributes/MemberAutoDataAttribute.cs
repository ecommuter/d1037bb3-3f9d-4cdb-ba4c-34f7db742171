namespace TestLibrary.Attributes
{
    /// <summary>
    /// Member auto data implementation based on InlineAutoDataAttribute and MemberData
    /// </summary>
    /// <seealso cref="Ploeh.AutoFixture.Xunit2.CompositeDataAttribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MemberAutoDataAttribute : AutoCompositeDataAttribute
    {
        /// <summary>
        /// The automatic data attribute
        /// </summary>
        private readonly AutoDataAttribute autoDataAttribute;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberAutoDataAttribute" /> class.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="parameters">The parameters.</param>
        public MemberAutoDataAttribute(string memberName, params object[] parameters)
            : this(new AutoDataAttribute(), memberName, parameters)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberAutoDataAttribute" /> class.
        /// </summary>
        /// <param name="autoDataAttribute">The automatic data attribute.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <param name="parameters">The parameters.</param>
        public MemberAutoDataAttribute(AutoDataAttribute autoDataAttribute, string memberName, params object[] parameters)
            : base((DataAttribute)new MemberDataAttribute(memberName, parameters), (DataAttribute)autoDataAttribute)
        {
            this.autoDataAttribute = autoDataAttribute;
        }

        /// <summary>
        /// Gets the automatic data attribute.
        /// </summary>
        /// <value>
        /// The automatic data attribute.
        /// </value>
        public AutoDataAttribute AutoDataAttribute => this.autoDataAttribute;
    }
}
