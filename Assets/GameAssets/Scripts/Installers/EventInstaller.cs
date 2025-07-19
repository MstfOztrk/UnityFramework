using Zenject;

public class EventInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventBus>().To<EventBus>().AsSingle().NonLazy();
    }
}