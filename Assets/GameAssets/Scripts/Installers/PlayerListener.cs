using UnityEngine;
using UniRx;
using Zenject;

public class PlayerListener : MonoBehaviour
{
    [Inject] IEventBus eventBus;

    private CompositeDisposable disposables = new();

    void Start()
    {
        eventBus.OnEvent(GameEvent.PlayerDied)
            .Subscribe(_ => Debug.Log("Player died!"))
            .AddTo(disposables);
    }

    void OnDestroy()
    {
        disposables.Dispose(); 
    }
}
