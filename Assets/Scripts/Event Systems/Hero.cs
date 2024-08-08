using UnityEngine;

public class Hero : MonoBehaviour
{
    EventBinding<TestEvent> TestEventBinding;
    EventBinding<PlayerEvent> PlayerEventBinding;
    void OnEnable()
    {
        TestEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
        EventBus<TestEvent>.Register(TestEventBinding);

        PlayerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
        EventBus<PlayerEvent>.Register(PlayerEventBinding);
    }
    public void OnDisable()
    {
        EventBus<TestEvent>.Deregister(TestEventBinding);
        EventBus<PlayerEvent>.Deregister(PlayerEventBinding);
    }
     void Awake()
    {
        Debug.Log("init test player events");
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            EventBus<TestEvent>.Raise(new TestEvent());
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            EventBus<PlayerEvent>.Raise(new PlayerEvent
            {
                health = 2,
                mana = 3
            });
        }
    }
    void HandleTestEvent()
    {
        Debug.Log("test event recieved");
    }

    void HandlePlayerEvent(PlayerEvent playerEvent)
    {
        Debug.Log($"palyer event recieved, health : {playerEvent.health} | mana : {playerEvent.mana}");
    }
}
