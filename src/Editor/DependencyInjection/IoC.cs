using System;
using AmplaTools.ProjectCreate.Editor.Events;
using Autofac;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public class IoC : IDisposable
    {
        public IoC()
        {
            ContainerBuilder builder = new ContainerBuilder();
            
            builder.RegisterModule<EventsModule>();
            builder.RegisterModule<PresentationModule>();
            builder.RegisterModule<ModelModule>();
            builder.RegisterModule<ViewModule>();
            builder.RegisterModule<WindowsApplicationModule>();

            builder.RegisterInstance(this).ExternallyOwned();

            Container = builder.Build();
        }

        public IContainer Container { get; private set; }

        public IEventAggregator EventAggregator
        {
            get { return Container.Resolve<IEventAggregator>(); }
        }

        public void Dispose()
        {
            if (Container == null) return;
            Container.Dispose();
            Container = null;
        }
    }
}