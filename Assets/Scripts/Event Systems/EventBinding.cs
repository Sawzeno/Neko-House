using System;
internal interface IEventBinding<T>
{
    public Action<T> OnEvent { get; set; }
    public Action OnEventNoArgs { get; set; }
}

public class EventBinding<T> : IEventBinding<T> where T : IEvent
{
    Action<T> OnEvent = _ => { };
    Action OnEventNoArgs = () => { };

    Action<T> IEventBinding<T>.OnEvent
    {
        get => OnEvent;
        set => OnEvent = value;
    }
    Action IEventBinding<T>.OnEventNoArgs
    {
        get => OnEventNoArgs;
        set => OnEventNoArgs = value;
    }
    public EventBinding(Action<T> onEvent) => OnEvent = onEvent;
    public EventBinding(Action onEventNoArgs) => OnEventNoArgs = onEventNoArgs;

    public void Add(Action onEventNoArgs) => OnEventNoArgs += onEventNoArgs;
    public void Remove(Action onEventNoArgs) => OnEventNoArgs -= onEventNoArgs;
    public void Add(Action<T> onEvent) => OnEvent += onEvent;
    public void Remove(Action<T> onEvent) => OnEvent -= onEvent;
}