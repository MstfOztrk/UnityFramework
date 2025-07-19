using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EventTest : MonoBehaviour
{
    [Inject] IEventBus eventBus;

    private void OnEnable()
    {
        eventBus.OnEvent(GameEvent.GameLoad).Subscribe(_ => OnLoad()).AddTo(gameObject);
    }

    private void OnLoad()
    {
        print("level loaded");
    }

    [Button]
    public void SendDieEvent()
    {
        eventBus.Raise(GameEvent.PlayerDied);
    }
    
    [Button]
    public void SendGameWonEvent()
    {
        eventBus.Raise(GameEvent.GameWon);
    }
}
