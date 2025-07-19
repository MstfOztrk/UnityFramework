using System;
using System.Collections.Concurrent;
using UniRx;
using UnityEngine;
public interface IEventBus
{
    public IObservable<Unit> OnEvent(GameEvent e);
    public IObservable<T> OnEvent<T>(GameEvent e);
    public void Raise(GameEvent e);
    public void Raise<T>(GameEvent e, T data);
}