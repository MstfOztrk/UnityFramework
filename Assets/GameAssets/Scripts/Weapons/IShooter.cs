using System;

public interface IShooter
{
    void StartShooting();
    void StopShooting();
    event Action OnShoot;
}
