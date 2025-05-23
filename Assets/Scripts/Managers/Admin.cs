using UnityEngine;

public class Administrator : MonoBehaviour
{
    private SpawnManager SpawnManager;
    private ScoreManager ScoreManager;
    private WaveManager WaveManager;

    private void Awake()
    {
        SpawnManager = GetComponentInChildren<SpawnManager>();
        ScoreManager = GetComponentInChildren<ScoreManager>();
        WaveManager = GetComponentInChildren<WaveManager>();
    }

    public void AddScore(int ScoreToAdd)
    {
        ScoreManager.ScoreInteger(1);
    }

    public int GetEnemyAmount()
    {
        return WaveManager.EnemyAmountDetermine();
    }

    public void ChangeWave(int waveChanger)
    {
        WaveManager.ChangeWave(waveChanger);
    }
}
