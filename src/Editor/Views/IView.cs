
using AmplaTools.ProjectCreate.Editor.Events;

namespace AmplaTools.ProjectCreate.Editor.Views
{
    public interface IView
    {
        void SetEventPublisher(IEventPublisher eventPublisher);
    }
}