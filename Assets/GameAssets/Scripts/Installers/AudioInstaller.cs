using UnityEngine;
using Zenject;
public class AudioInstaller : MonoInstaller
{
    private AudioSource sfxSource;

    public override void InstallBindings()
    {
        sfxSource = GetComponent<AudioSource>();
        Container.Bind<AudioSource>().FromInstance(sfxSource);
        Container.Bind<ISoundManager>().To<SoundManager>().AsSingle();
    }
}
