using System;
using System.Collections.Concurrent;

namespace EventBusTask.Console
{
    public class EventBus
    {
        private ConcurrentDictionary<string, ConcurrentQueue<Action<object>>> _dict =
            new ConcurrentDictionary<string, ConcurrentQueue<Action<object>>>();

        public void RegisterEvent(string eventName)
        {
            _dict.TryAdd(eventName, new ConcurrentQueue<Action<object>>());
        }

        public void Subscribe(string eventName, Action<object> action)
        {
            if (!_dict.ContainsKey(eventName)) return;
            _dict[eventName].Enqueue(action);
        }

        public void Trigger(string eventName, object o)
        {
            ConcurrentQueue<Action<object>> actions;
            if (!_dict.TryGetValue(eventName, out actions)) return;
            foreach (var action in actions)
            {
                action.Invoke(o);
            }
            
        }
    }
}