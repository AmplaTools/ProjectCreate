using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Editor.Events
{
    [TestFixture]
    public class EventAggregatorUnitTests : TestFixture
    {
        private EventAggregator eventAggregator;
        private Level1Listener level1Listener;
        private Level2Listener level2Listener;
        private InterfaceListener interfaceListener;

        protected override void OnSetUp()
        {
            base.OnSetUp();

            eventAggregator = new EventAggregator(new EventAggregator.Config{SupportMessageInheritance = true});
            level1Listener = new Level1Listener();
            level2Listener = new Level2Listener();
            interfaceListener = new InterfaceListener();

            eventAggregator.AddListener(level1Listener);
            eventAggregator.AddListener(level2Listener);
            eventAggregator.AddListener(interfaceListener);
        }

        protected override void OnTearDown()
        {
            base.OnTearDown();
            eventAggregator = null;
        }

        private void CheckListeners(bool interfaceHandled, bool level1Handled, bool level2Handled)
        {
            const string format = "Message Handled by Interface: {0} Level1: {1} Level2:{2}";
            string expected = string.Format(format, interfaceHandled, level1Handled, level2Handled);
            string actual = string.Format(format, interfaceListener.Handled, level1Listener.Handled, level2Listener.Handled);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void BaseMessagesCalled()
        {
            eventAggregator.SendMessage(new Level1Message());
            CheckListeners(true, true, false);
        }

        [Test]
        public void TestMessagesCalled()
        {
            eventAggregator.SendMessage(new Level2Message());

            CheckListeners(true, true, true);
        }

        [Test]
        public void SendUsingBase()
        {
            eventAggregator.SendMessage<Level1Message>(new Level2Message());

            CheckListeners(true, true, true);
        }

        [Test]
        public void SendUsingObject()
        {
            eventAggregator.SendMessage<object>(new Level2Message());
            CheckListeners(true, true, true);
        }

        [Test]
        public void SendUsingIMessage()
        {
            eventAggregator.SendMessage<IMessage>(new Level2Message());
            CheckListeners(true, true, true);
        }

        public interface IMessage
        {
        }

        public class Level1Message : IMessage
        {
        }

        public class Level2Message : Level1Message
        {
        }

        public class Level1Listener : IListener<Level1Message>
        {
            public int Count { get; private set; }

            public bool Handled
            {
                get { return Count > 0; }
            }

            public void Handle(Level1Message message)
            {
                Count++;
            }

            public void Reset()
            {
                Count = 0;
            }
        }

        public class Level2Listener : IListener<Level2Message>
        {
            public int Count { get; private set; }

            public bool Handled
            {
                get { return Count > 0; }
            }

            public void Handle(Level2Message message)
            {
                Count++;
            }

            public void Reset()
            {
                Count = 0;
            }
        }

        public class InterfaceListener : IListener<IMessage>
        {
            public int Count { get; private set; }

            public bool Handled
            {
                get { return Count > 0; }
            }

            public void Handle(IMessage message)
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