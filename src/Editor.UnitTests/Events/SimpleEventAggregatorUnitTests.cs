using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Editor.Events
{
    [TestFixture]
    public class SimpleEventAggregatorUnitTests : TestFixture
    {
        private EventAggregator eventAggregator;
        private TestListener testListener;

        protected override void OnSetUp()
        {
            base.OnSetUp();

            eventAggregator = new EventAggregator();

            testListener = new TestListener();

            eventAggregator.AddListener(testListener);
        }

        protected override void OnTearDown()
        {
            base.OnTearDown();
            eventAggregator = null;
        }

        [Test]
        public void TestMessagesCalled()
        {
            eventAggregator.SendMessage(new TestMessage());
            Assert.That(testListener.Handled, Is.True);
        }

        [Test]
        public void TestMessagesCalledNoArgument()
        {
            eventAggregator.SendMessage<TestMessage>();
            Assert.That(testListener.Handled, Is.True);
        }

        [Test]
        public void TestMessagesCalledWithNullMessage()
        {
            eventAggregator.SendMessage<TestMessage>(null);
            Assert.That(testListener.Handled, Is.True);
        }

        [Test]
        public void TestMessagesCalledWithObjectType()
        {
            eventAggregator.SendMessage<object>(new TestMessage());
            Assert.That(testListener.Handled, Is.True);
        }

        [Test]
        public void TestMessagesCalledWithDifferentType()
        {
            eventAggregator.SendMessage<int>(5);
            Assert.That(testListener.Handled, Is.False);
        }

        public class TestMessage 
        {
        }

  
        public class TestListener : IListener<TestMessage>
        {
            public int Count { get; private set; }

            public bool Handled
            {
                get { return Count > 0; }
            }

            public void Handle(TestMessage message)
            {
                Count++;
            }

            public void Reset()
            {
                Count = 0;
            }
        }

 
    }


}