
using Autofac;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public class ViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EditorForm>().AsImplementedInterfaces().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}