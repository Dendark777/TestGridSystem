using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class EventBus
    {
        private Dictionary<Type, List<Action<object>>> eventDictionary = new Dictionary<Type, List<Action<object>>>();
        private Dictionary<Type, List<Action<object>>> eventDictionaryOnce = new Dictionary<Type, List<Action<object>>>();
        
        private static EventBus instance;
        public static EventBus Instance
        {
            get
            {
                instance ??= new EventBus();
                return instance;
            }
        }


        public void Subscribe<T>(Action<object> listener)
        {
            var eventType = typeof(T);
            if (!eventDictionary.ContainsKey(eventType))
            {
                eventDictionary[eventType] = new List<Action<object>>();
            }
            eventDictionary[eventType].Add(listener);
        }
        
        public void SubscribeOnce<T>(Action<object> listener)
        {
            var eventType = typeof(T);
            if (!eventDictionaryOnce.ContainsKey(eventType))
            {
                eventDictionaryOnce[eventType] = new List<Action<object>>();
            }
            eventDictionaryOnce[eventType].Add(listener);
        }

        public void Unsubscribe<T>(Action<object> listener)
        {
            var eventType = typeof(T);
            if (eventDictionary.ContainsKey(eventType))
            {
                eventDictionary[eventType].Remove(listener);
            }
            if (eventDictionaryOnce.ContainsKey(eventType))
            {
                eventDictionaryOnce[eventType].Remove(listener);
            }
        }

        public void Publish<T>(object eventData)
        {
            var eventType = typeof(T);
            if (eventDictionary.ContainsKey(eventType))
            {
                foreach (var listener in eventDictionary[eventType])
                {
                    listener.Invoke(eventData);
                }
            }

            if (!eventDictionaryOnce.ContainsKey(eventType)) return;
            
            var listenersToRemove = new List<Action<object>>();
            foreach (var listener in eventDictionaryOnce[eventType])
            {
                listener.Invoke(eventData);
                listenersToRemove.Add(listener);
            }
            foreach (var listener in listenersToRemove)
            {
                Unsubscribe<T>(listener);
            }
        }
    }
}
