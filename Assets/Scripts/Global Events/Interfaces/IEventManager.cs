public interface IEventManager 
{
    public void Subscribe<T>(IEventSubscriber<T> subscriber) where T : IEvent;
    public void Unsubscribe<T>(IEventSubscriber<T> subscriber) where T : IEvent;
    public void Publish<T>(T eventData) where T : IEvent;
}

