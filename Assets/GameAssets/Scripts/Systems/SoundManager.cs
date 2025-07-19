using UnityEngine;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SoundManager : ISoundManager, IDisposable
{
    private readonly AudioSource sfxSource;
    private readonly AudioSource bgmSource;
    private readonly Dictionary<SoundType, AudioClip> clipMap = new();
    private readonly List<AsyncOperationHandle<AudioClip>> handles = new();
    private readonly CompositeDisposable disposables = new();

    public SoundManager(AudioSource sfxSource, AudioSource bgmSource)
    {
        this.sfxSource = sfxSource;
        this.bgmSource = bgmSource;
    }

    public void LoadChapterSounds(ChapterSoundConfig config)
    {
        ClearSounds();

        foreach (var entry in config.SoundEntries)
        {
            var handle = entry.clipReference.LoadAssetAsync<AudioClip>();

            handle.ToObservable()
                .Where(_ => handle.Status == AsyncOperationStatus.Succeeded)
                .Subscribe(_ => clipMap[entry.type] = handle.Result)
                .AddTo(disposables);
        }
    }

    public void PlayLoop(SoundType type)
    {
        if (!clipMap.TryGetValue(type, out var clip)) return;

        sfxSource.clip = clip;
        sfxSource.loop = true;
        sfxSource.Play();
    }

    public void Play(SoundType type)
    {
        if (!clipMap.TryGetValue(type, out var clip)) return;
        sfxSource.PlayOneShot(clip);
    }


    public void ClearSounds()
    {
        foreach (var handle in handles)
        {
            Addressables.Release(handle);
        }

        clipMap.Clear();
        handles.Clear();
        disposables.Clear();
    }

    public void Dispose()
    {
        ClearSounds();
    }
}

public enum SoundType
{
    Hit,
}

[System.Serializable]
public struct SoundEntry
{
    public SoundType type;
    public AssetReferenceT<AudioClip> clipReference;
}
