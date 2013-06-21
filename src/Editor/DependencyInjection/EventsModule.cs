using System.Windows.Forms;
using AmplaTools.ProjectCreate.Editor.Events;

using Autofac;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            EventAggregator.Config config = new EventAggregator.Config
            {
                OnMessageNotPublishedBecauseZeroListeners = delegate(object o)
                {
                    string message = string.Format("{0} was not handled", o);
                    MessageBox.Show(message, @"EventAggregator - Not Handled");
                }
                ,
                SupportMessageInheritance = true
            };
            EventAggregator eventAggregator = new EventAggregator(config);

            builder.RegisterInstance(eventAggregator).As<IEventAggregator>().ExternallyOwned();
            base.Load(builder);
        }
    }
}