using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //Debug
    [SerializeField] private bool DEBUG = false;
    
    private int waveNumber = 1;
    private int waveDifficulty = 10;
    
    public int EnemyAmountDetermine()
    {
        int enemyCount = waveNumber * waveDifficulty;

        if (DEBUG)
        {
            Debug.Log("Starting wave with number: " + waveNumber + " and difficulty : "+ waveDifficulty);
        }
        
        return enemyCount;
    }

    public void ChangeWave(int waveChanger)
    {
        waveDifficulty = waveDifficulty + waveChanger;
    }

    public void IncreaseSimultaneousEnemyLimit()
    {
        
    }
}
