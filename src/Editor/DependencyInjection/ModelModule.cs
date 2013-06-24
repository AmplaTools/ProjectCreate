using AmplaTools.ProjectCreate.Editor.Models;

using Autofac;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public class ModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            EditorModel editorModel = new EditorModel();
            builder.RegisterInstance(editorModel).ExternallyOwned();
            builder.RegisterType<EditorMenuModel>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}