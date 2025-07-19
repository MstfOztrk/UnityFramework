using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class LevelHandler : MonoBehaviour
{
    [Inject] private ILevelManager levelManager;
    [Inject] private IEventBus eventBus;
 
    private int currentIndex;
    private const string LEVEL_INDEX_KEY = "CurrentLevelIndex";

    private void OnEnable()
    {
        currentIndex = PlayerPrefs.GetInt(LEVEL_INDEX_KEY, 0);

        levelManager.CurrentLevel
            .Where(l => l != null)
            .Subscribe(delegate
            {
                eventBus.Raise(GameEvent.GameLoad);
            })
            .AddTo(this);

        eventBus.OnEvent(GameEvent.GameWon).Subscribe(_=>LoadNextLevel());

        LoadCurrentLevel();
    }

    private void OnDestroy()
    {
        levelManager.UnloadLevel();
    }

    private void LoadCurrentLevel()
    {
        string levelName = "Level"+currentIndex;
        Debug.Log($"Loading: {levelName}");
        levelManager.LoadLevelRequest.OnNext(levelName);
    }

    public void LoadNextLevel()
    {
        currentIndex++;
        PlayerPrefs.SetInt(LEVEL_INDEX_KEY, currentIndex);
        PlayerPrefs.Save();
        LoadCurrentLevel();
    }

    public void ResetLevelProgress()
    {
        currentIndex = 0;
        PlayerPrefs.DeleteKey(LEVEL_INDEX_KEY);
        LoadCurrentLevel();
    }

    public string GetCurrentLevelName()
    {
        return $"Level{currentIndex}";
    }

    public int GetCurrentLevelIndex()
    {
        return currentIndex;
    }
}
