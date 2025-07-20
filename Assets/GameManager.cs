using UnityEngine;
using Lean.Touch;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private IEventBus eventBus;

    private void OnEnable()
    {
        LeanTouch.OnFingerTap += HandleFingerTap;
    }
    private void HandleFingerTap(LeanFinger finger)
    {
        if (finger.IsOverGui == false)
        {
            print("game start");
            eventBus.Raise(GameEvent.GameStart);
            LeanTouch.OnFingerTap -= HandleFingerTap;
        }
    }
}