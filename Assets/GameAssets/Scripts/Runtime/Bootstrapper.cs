using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private ChapterPoolSO[] allChapters;
    [SerializeField] private ChapterSoundConfig[] allSoundConfigs;

    [Inject] private IPoolManager poolManager;
    [Inject] private ISoundManager soundManager;

    private async void Start()
    {
        int chapterIdx = GetSelectedChapterIndex();
        var selectedPoolSO = allChapters[chapterIdx];
        var selectedSoundSO = allSoundConfigs[chapterIdx];

        soundManager.LoadChapterSounds(selectedSoundSO);
        await poolManager.InitializeFromChapterSO(selectedPoolSO);

        SceneManager.LoadScene("Game");
    }

    private int GetSelectedChapterIndex()
    {
        // Seçim logic'in burada
        return 0;
    }

}