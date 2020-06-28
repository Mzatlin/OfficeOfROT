using System;
internal interface IHealth
{
    event Action OnDie;
    bool IsDead { get; set; }
    void ProcessDamage();
}