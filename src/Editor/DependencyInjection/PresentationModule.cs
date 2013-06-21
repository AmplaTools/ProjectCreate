using AmplaTools.ProjectCreate.Editor.Presenters;
using Autofac;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public class PresentationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EditorPresenter>().As<IMainPresenter>().InstancePerLifetimeScope();
            builder.RegisterType<EditorMenuPresenter>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}