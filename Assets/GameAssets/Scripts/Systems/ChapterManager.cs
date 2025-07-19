using Zenject;
using UnityEngine;

public interface IChapterManager
{
    public int CurrentChapterIndex { get; }
    public string CurrentChapterName { get; }
}

public class ChapterManager : IInitializable, IChapterManager
{
    private const string chapterKey = "CurrentChapterIndex";
    private int currentIndex;

    public int CurrentChapterIndex => currentIndex;
    public string CurrentChapterName => $"Chapter{currentIndex}";

    public void Initialize()
    {
        currentIndex = PlayerPrefs.GetInt(chapterKey, 0);
    }

    public void SetChapter(int idx)
    {
        currentIndex = idx;
        PlayerPrefs.SetInt(chapterKey, idx);
    }
}
