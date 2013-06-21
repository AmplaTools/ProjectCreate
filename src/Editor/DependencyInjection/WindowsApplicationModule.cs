using Autofac;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public class WindowsApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<WinFormsApplication>().As<IApplication>();
        }
    }
}