using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Game Config")]
public class GameConfig : ScriptableObject
{
    public float playerSpeed = 5f;      
    public float sensitivity = 1f;     
    public float clampMin = -10f;     
    public float clampMax = 10f;     
}
