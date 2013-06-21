namespace AmplaTools.ProjectCreate.Editor.Events
{
    public interface IPublisher<in TMessage> 
    {
        void Publish(TMessage message);
    }
}