using System;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Inject] private IEventBus eventBus;
    [Inject] private GameConfig gameConfig;
    private bool canMove = true;
    private void OnEnable()
    {
        Observable.EveryUpdate().Where(x => canMove).SkipUntil(eventBus.OnEvent(GameEvent.GameStart)).TakeUntil(eventBus.OnEvent(GameEvent.GameEnd)).Subscribe(_ => OnUpdate());
    }

    private void OnUpdate()
    {
        transform.Translate(Vector3.forward * gameConfig.playerSpeed * Time.deltaTime);
    }
}
