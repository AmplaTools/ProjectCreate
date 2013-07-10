
using AmplaTools.ProjectCreate.Editor.Events;
using AmplaTools.ProjectCreate.Editor.Views;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Editor.Presenters
{
    public class Presenter<TView, TModel> : IPresenter
        where TView : IView
    {
        public Presenter(TView view, TModel model, IEventAggregator eventAggregator)
        {
            ArgumentCheck.IsNotNull(view);
            ArgumentCheck.IsNotNull(eventAggregator);
            ArgumentCheck.IsNotNull(model);

            View = view;
            Model = model;

            View.SetEventPublisher(eventAggregator);
            eventAggregator.AddListener(this);
            EventAggregator = eventAggregator;
        }
        
        public TView View { get; private set; }

        public TModel Model { get; protected set; }

        public IEventAggregator EventAggregator { get; private set; }
    }

}