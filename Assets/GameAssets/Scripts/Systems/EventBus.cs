using System;
using System.Collections.Concurrent;
using UniRx;
using UnityEngine;

public enum GameEvent
{
    GameLoad,
    GameStart,
    GameEnd,
    GameWon,
    GameLose,
    PlayerDied,
}

public class EventBus : IEventBus
{

    private readonly ConcurrentDictionary<GameEvent, object> subjects =
        new ConcurrentDictionary<GameEvent, object>();

    public IObservable<Unit> OnEvent(GameEvent e)
    {
        var subj = subjects.GetOrAdd(e, _ => new Subject<Unit>()) as ISubject<Unit>;
        return subj.AsObservable();
    }

    public IObservable<T> OnEvent<T>(GameEvent e)
    {
        var subj = subjects.GetOrAdd(e, _ => new Subject<T>()) as ISubject<T>;
        return subj.AsObservable();
    }

    public void Raise(GameEvent e)
    {
        if (subjects.TryGetValue(e, out var obj) && obj is ISubject<Unit> s)
        {
            s.OnNext(Unit.Default);
        }
    }

    public void Raise<T>(GameEvent e, T data)
    {
        if (subjects.TryGetValue(e, out var obj) && obj is ISubject<T> s)
        {
            s.OnNext(data);
        }
    }

    private void OnDisable()
    {
        foreach (var obj in subjects.Values)
        {
            if (obj is IDisposable d)
            {
                d.Dispose();
            }
        }
        subjects.Clear();
    }
}
