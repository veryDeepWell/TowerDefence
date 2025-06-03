using UnityEngine;

public interface IDamageble
{
    int Health { get; set; }

    public void GetDamage(int damage);

    public void Suicide();
    
    public void AddHealth(int health);
}
