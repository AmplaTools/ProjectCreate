
using AmplaTools.ProjectCreate.Editor.Presenters;
using AmplaTools.ProjectCreate.Editor.Views;
using Autofac;
using NUnit.Framework;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    [TestFixture]
    public class IoCUnitTests : TestFixture
    {
        [Test]
        public void EventAggregator()
        {
            IoC ioc = new IoC();
            Assert.That(ioc.EventAggregator, Is.Not.Null);
        }

        [Test]
        public void ResolveIApplication()
        {
            IoC ioc = new IoC();
            IApplication application = ioc.Container.Resolve<IApplication>();
            Assert.That(application, Is.Not.Null);
            application.Dispose();
        }

        [Test]
        public void ResolveView()
        {
            IoC ioc = new IoC();
            IEditorView  view = ioc.Container.Resolve<IEditorView>();
            Assert.That(view, Is.Not.Null);

            IEditorMenuView menuView = ioc.Container.Resolve<IEditorMenuView>();
            Assert.That(menuView, Is.Not.Null);
        }

        [Test]
        public void ResolvePresenters()
        {
            IoC ioc = new IoC();
            IMainPresenter presenter = ioc.Container.Resolve<IMainPresenter>();
            Assert.That(presenter, Is.Not.Null);
            Assert.That(presenter.MainView, Is.TypeOf<EditorForm>());

            Assert.That(ioc.Container.Resolve<IMainPresenter>(), Is.TypeOf<EditorPresenter>());
            Assert.That(ioc.Container.Resolve<EditorMenuPresenter>(), Is.Not.Null);
        }

    }
}