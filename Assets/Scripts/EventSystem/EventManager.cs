using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class EventManager : MonoBehaviour
    {
        private static EventManager instance;

        public static EventManager get()
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject();
                instance = gameObject.AddComponent<EventManager>();
            }

            return instance;
        }

        private Dictionary<EventListener, HashSet<Type>> listeners;

        public EventManager()
        {
            listeners = new Dictionary<EventListener, HashSet<Type>>();
        }

        public void Subscribe(EventListener listener, HashSet<Type> events)
        {
            listeners.Add(listener, events);
        }

        public void Unsubscribe(EventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Notify(Event e)
        {
            foreach (var listener in listeners)
            {
                if (listener.Value.Contains(e.GetType()))
                {
                    listener.Key.OnNotify(e);
                }
            }
        }
    }
}
