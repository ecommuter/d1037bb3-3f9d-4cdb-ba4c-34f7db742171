using System;

namespace Common.UnitTests
{
    public abstract class TestsBase
    {
        #region Private Fields

        public readonly Fixture _fixture;

        #endregion

        #region Constructor

        protected TestsBase()
        {
            _fixture = new Fixture();

            _fixture.Customize(new AutoMoqCustomization());
        }

        #endregion
    }
}
