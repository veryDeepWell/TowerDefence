using UnityEngine;

public interface IDamageble
{
    int Health { get; set; }

    public void GetDamage(int Damage);

    public void Suicide();
}
