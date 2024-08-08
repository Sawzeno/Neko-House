using System.Collections.Generic;
using UnityEngine;

public static class EventBus<T> where T : IEvent{
    static readonly HashSet<IEventBinding<T>> Bindings = new HashSet<IEventBinding<T>>();
    public static void Register(EventBinding<T> binding) => Bindings.Add(binding);
    public static void Deregister(EventBinding<T> binding) => Bindings.Remove(binding);
    public static void Raise(T @event){
        foreach( var binding in Bindings){
            binding.OnEvent.Invoke(@event);
            binding.OnEventNoArgs.Invoke();
        }
    }

    public static void clear(){
        Debug.Log($"Clearing {typeof(T).Name} bindings");
        Bindings.Clear();
    }
}
