using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : IEventManager
{
    private Dictionary<Type, List<object>> subscribers;

    public EventBus()
    {
        subscribers = new Dictionary<Type, List<object>>();        
    }

    public void Subscribe<T>(IEventSubscriber<T> subscriber) where T : IEvent
    {
        var eventType = typeof(T);

        if (!subscribers.ContainsKey(eventType))
        {
            subscribers[eventType] = new List<object>();
        }

        subscribers[eventType].Add(subscriber);
    }

    public void Unsubscribe<T>(IEventSubscriber<T> subscriber) where T : IEvent
    {
        var eventType = typeof(T);

        if (subscribers.ContainsKey(eventType))
        {
            subscribers[eventType].Remove(subscriber);

            if (subscribers[eventType].Count == 0)
            {
                subscribers.Remove(eventType);
            }
        }
    }

    public void Publish<T>(T eventData) where T : IEvent
    {
        var eventType = typeof(T);

        if (subscribers.ContainsKey(eventType))
        {            
            var subscribersCopy = new List<object>(subscribers[eventType]);

            foreach (var subscriber in subscribersCopy)
            {
                if (subscriber is IEventSubscriber<T> typedSubscriber)
                {
                    typedSubscriber.OnEvent(eventData);
                }
            }
        }
    }

}
