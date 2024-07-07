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

        public void Unsubscribe<T>(Action<object> listener)
        {
            var eventType = typeof(T);
            if (eventDictionary.ContainsKey(eventType))
            {
                eventDictionary[eventType].Remove(listener);
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
        }
    }
}
