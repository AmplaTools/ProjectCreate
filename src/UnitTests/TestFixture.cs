using System;
using System.Diagnostics;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate
{
    /// <summary>
    ///		Base class for TestFixtures with provision for specializing other base classes
    /// </summary>
    /// <remarks>
    ///		UnitTest classes should specialize:
    ///			- OnFixtureSetUp()
    ///			- OnFixtureTearDown()
    ///			- OnSetUp()
    ///			- OnTearDown()
    /// </remarks>
    [TestFixture]
    public abstract class TestFixture
    {
        #region Fields ---------------------------------------------------------------

        #endregion // Fields

        #region Properties -----------------------------------------------------------

        #region Protected and Internal -----------------------------------------------

        /// <summary>
        ///		An exception trapped in the TestFixtureSetup
        /// </summary>
        protected Exception FixtureException { get; private set; }

        #endregion // Protected and Internal

        #endregion // Properties

        #region Methods --------------------------------------------------------------

        #region Public ---------------------------------------------------------------

        /// <summary>
        ///		Procedure that is executed prior to the execution of the first test procedure
        ///		and before the SetUp procedure.
        /// </summary>
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            string typeName = GetType().FullName;
            Debug.Assert(typeName != null);
            Debug.WriteLine(new string('=', typeName.Length));
            Debug.WriteLine("[TestFixture]");
            Debug.WriteLine(typeName);
            Debug.WriteLine(new string('=', typeName.Length));

            try
            {
                InternalFixtureSetUp();
                OnFixtureSetUp();
            }
            catch (IgnoreException)
            {
                throw;
            }
            catch (Exception e)
            {
                FixtureException = e;
            }
        }

        /// <summary>
        ///		Procedure that is executed after the execution of the last test procedure
        ///		and after the TearDown procedure.
        /// </summary>
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            try
            {
                OnFixtureTearDown();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            try
            {
                InternalFixtureTearDown();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        ///		Procedure that is executed prior to each test procedure.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Assert.AreEqual(null, FixtureException, "[TestFixtureSetUp]");

            InternalSetUp();
            OnSetUp();
        }

        /// <summary>
        ///		Procedure that is executed after each test procedure.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            OnTearDown();
            InternalTearDown();
        }

        #endregion // Public

        #region Protected and Internal -----------------------------------------------

        /// <summary>
        ///		FixtureSetup method to override in UnitTests
        /// </summary>
        protected virtual void OnFixtureSetUp()
        {
        }

        /// <summary>
        ///		FixtureTearDown method to override in UnitTests
        /// </summary>
        protected virtual void OnFixtureTearDown()
        {
        }

        /// <summary>
        ///		Setup method to override in UnitTests
        /// </summary>
        protected virtual void OnSetUp()
        {
        }

        /// <summary>
        ///		TearDown method to override in UnitTests
        /// </summary>
        protected virtual void OnTearDown()
        {
        }

        /// <summary>
        ///		FixtureSetup method to override in UnitTests
        /// </summary>
        internal virtual void InternalFixtureSetUp()
        {
        }

        /// <summary>
        ///		FixtureTearDown method to override in UnitTests
        /// </summary>
        internal virtual void InternalFixtureTearDown()
        {
        }

        /// <summary>
        ///		Setup method to override in UnitTests
        /// </summary>
        internal virtual void InternalSetUp()
        {
        }

        /// <summary>
        ///		TearDown method to override in UnitTests
        /// </summary>
        internal virtual void InternalTearDown()
        {
        }

        #endregion // Protected and Internal

        #endregion // Methods
    }
}
