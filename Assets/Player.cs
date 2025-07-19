using UnityEngine;

using Lean.Touch;
using System.Collections.Generic;
using Zenject;  // LeanTouch namespace'i

public class Player : MonoBehaviour
{
    [Inject] private GameConfig gameConfig;
    public Transform root;
    private Vector3 targetPosition;
    private Vector3 currentVelocity;
    private bool isTouching = false;

    private void Start()
    {
        targetPosition = root.position;
    }

    private void Update()
    {
        LeanFinger activeFinger = null;

        for (int i = 0; i < LeanTouch.Fingers.Count; i++)
        {
            var finger = LeanTouch.Fingers[i];
            if (finger.IsActive && !finger.StartedOverGui)
            {
                activeFinger = finger;
                break;
            }
        }

        float moveDelta = 0f;
        if (activeFinger.ScreenDelta != Vector2.zero)
        {
            moveDelta = activeFinger.ScreenDelta.x * gameConfig.sensitivity * gameConfig.playerSpeed * Time.deltaTime;
            Vector3 newPosition = root.position;
            newPosition.x += moveDelta;
            newPosition.x = Mathf.Clamp(newPosition.x, gameConfig.clampMin, gameConfig.clampMax);
            root.position = Vector3.Lerp(root.position, newPosition, Time.deltaTime * 10f);
        }

    }
}
