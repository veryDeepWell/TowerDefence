using UnityEngine;

public class Administrator : MonoBehaviour
{
    private SpawnManager SpawnManager;
    private ScoreManager ScoreManager;
    private WaveManager WaveManager;

    [SerializeField] private GameObject Player;
    
    [SerializeField] private GameObject panelMainPanel;
    [SerializeField] private GameObject panelGameOverPanel;
    
    private void Awake()
    {
        SpawnManager = GetComponentInChildren<SpawnManager>();
        ScoreManager = GetComponentInChildren<ScoreManager>();
        WaveManager = GetComponentInChildren<WaveManager>();
        
        panelMainPanel.SetActive(false);
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

    public void GameOver()
    {
        panelGameOverPanel.SetActive(false);
        panelMainPanel.SetActive(true);
        
        SpawnManager.StopAllCoroutines();
    }
}
