using UnityEngine;

public interface ISoundManager
{
    public void LoadChapterSounds(ChapterSoundConfig config);
    public void Play(SoundType type);
    public void ClearSounds();
}