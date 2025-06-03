using UnityEngine;
using UnityEngine.Serialization;

public class WaveManager : MonoBehaviour
{
    //Debug
    [SerializeField] private bool debug = false;
    
    private int _waveNumber = 1;
    private int _waveDifficulty = 10;
    
    public int EnemyAmountDetermine()
    {
        int enemyCount = _waveNumber * _waveDifficulty;

        if (debug)
        {
            Debug.Log("Starting wave with number: " + _waveNumber + " and difficulty : "+ _waveDifficulty);
        }
        
        return enemyCount;
    }

    public void ChangeWave(int waveChanger)
    {
        _waveDifficulty = _waveDifficulty + waveChanger;
    }

    public void IncreaseSimultaneousEnemyLimit()
    {
        
    }
}
