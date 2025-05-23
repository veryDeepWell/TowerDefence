using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int waveNumber = 1;
    private int waveDifficulty = 10;
    
    public int EnemyAmountDetermine()
    {
        int enemyCount = waveNumber * waveDifficulty;

        return enemyCount;
    }

    public void IncreaseSimultaneousEnemyLimit()
    {
        
    }
}
