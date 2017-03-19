using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager
{
    /*
     * Singleton
     */
    private static EventsManager instance;

    public static EventsManager Instance()
    {
        if (instance == null)
        {
            instance = new EventsManager();
        }

        return instance;
    }

    /*
     * Implementation
     */
    private Dictionary<string, List<Action<GameObject>>> handlers;

    private EventsManager()
    {
        handlers = new Dictionary<string, List<Action<GameObject>>>();
    }

    /// <summary>
    /// Bind an handler to an event so that the handler will be called when the event occurs
    /// </summary>
    /// <param name="eventId">The identifier of the event to bind the handler to</param>
    /// <param name="handler">The handler to call when the event occurs</param>
    public void Subscribe(string eventId, Action<GameObject> handler)
    {
        if (!handlers.ContainsKey(eventId))
        {
            handlers.Add(eventId, new List<Action<GameObject>>());
        }

        handlers[eventId].Add(handler);
    }

    /// <summary>
    /// Unbind an handler from the list of handlers to call when an event occurs
    /// </summary>
    /// <param name="eventId">The identifier of the event to unbind the handler to</param>
    /// <param name="handler">The handler to remove from the list of handlers to call</param>
    public void Unsubscribe(string eventId, Action<GameObject> handler)
    {
        if (handlers.ContainsKey(eventId))
        {
            handlers[eventId].Remove(handler);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="gameObject"></param>
    public void Notify(string eventId, GameObject gameObject)
    {
        foreach (var handler in handlers[eventId])
        {
            handler(gameObject);
        }
    }
}
