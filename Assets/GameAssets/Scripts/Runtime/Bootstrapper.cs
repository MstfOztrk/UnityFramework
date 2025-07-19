using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private ChapterPoolSO[] allChapters;
    [Inject] private IPoolManager poolManager;

    private async void Start()
    {
        int chapterIdx = GetSelectedChapterIndex();
        var selectedSO = allChapters[chapterIdx];

        await poolManager.InitializeFromChapterSO(selectedSO);

        SceneManager.LoadScene("Game");
    }

    private int GetSelectedChapterIndex()
    {
        // Seçim logic'in burada
        return 0;
    }
}
