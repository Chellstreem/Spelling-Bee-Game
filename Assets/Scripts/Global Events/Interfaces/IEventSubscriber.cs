public interface IEventSubscriber<T> where T : IEvent
{
    void OnEvent(T eventData);
}