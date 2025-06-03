using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int currentLevel = 0;
    public int maxLevel = 100;
    
    // Stats
    public float damage = 1;
    public float health = 10;
    public float shotDelay = 1;
    public float shotSpeed = 1;

    public void IAMHERE()
    {
        Debug.Log("IAMHERE");
    }
}
