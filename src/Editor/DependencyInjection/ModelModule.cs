using AmplaTools.ProjectCreate.Editor.Models;

using Autofac;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public class ModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ProjectModel projectModel = new ProjectModel();
            builder.RegisterInstance(projectModel).ExternallyOwned();
            builder.RegisterType<EditorMenuModel>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}