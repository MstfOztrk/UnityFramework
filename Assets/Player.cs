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

    private void Start()
    {
        targetPosition = root.position; 
    }

      private void Update()
    {
        // LeanTouch parmakları al
        if (LeanTouch.Fingers.Count > 0)
        {
            // İlk parmağı al
            LeanFinger finger = LeanTouch.Fingers[0];

            // Parmağın delta hareketini al
            Vector2 touchDelta = finger.ScreenDelta;

            // Sensitivity ile çarpma işlemi
            float movement = touchDelta.x * gameConfig.sensitivity;

            // Yeni hedef pozisyonu hesapla
            targetPosition.x += movement * gameConfig.playerSpeed * Time.deltaTime;

            targetPosition.x = Mathf.Clamp(targetPosition.x, gameConfig.clampMin, gameConfig.clampMax);
        }

        // Root objesini pürüzsüz bir şekilde hareket ettir (damping ile)
        root.position = Vector3.SmoothDamp(root.position, targetPosition, ref currentVelocity, 0.2f);
    }
}
