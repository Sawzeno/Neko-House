using UnityEngine;
using UnityEngine.Events;

public abstract class EventListener<T> : MonoBehaviour{
    [SerializeField] EventChannel<T> EventChannel;
    [SerializeField] UnityEvent<T> UnityEvent;

    protected void Awake(){
        EventChannel.Register(this);
    }
    protected void OnDestroy(){
        EventChannel.Deregister(this);
    }
    public void Raise(T value){
        UnityEvent?.Invoke(value);
    }
}
public class EventListener : EventListener<Empty> {}
