using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound/Chapter Sound Config")]
public class ChapterSoundConfig : ScriptableObject
{
    public List<SoundEntry> SoundEntries;
}

