using UnityEngine;
using Lean.Touch;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private IEventBus eventBus;
    private bool isGameStarted = false;
    private void OnEnable()
    {
        LeanTouch.OnFingerTap += HandleFingerTap;
    }
    
    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= HandleFingerTap;
    }
    private void HandleFingerTap(LeanFinger finger)
    {
        if (isGameStarted) return;
        if (finger.IsOverGui == false)
        {
            print("game start");
            isGameStarted = true;
            eventBus.Raise(GameEvent.GameStart);

        }
    }
}