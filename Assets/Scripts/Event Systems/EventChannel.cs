using System.Collections.Generic;
using UnityEngine;

public abstract class EventChannel<T> : ScriptableObject
{
    readonly HashSet<EventListener<T>> Observers = new();
    public void Invoke(T value){
        foreach(var observer in Observers){
            observer.Raise(value);
        }
    }
    public void Register(EventListener<T> observer) => Observers.Add(observer);
    public void Deregister(EventListener<T> observer) => Observers.Remove(observer);
}
public readonly struct Empty{}
[CreateAssetMenu(menuName = "Events/EventChannel")]
public class EventChannel : EventChannel<Empty> {}
