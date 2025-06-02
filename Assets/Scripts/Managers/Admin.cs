using UnityEngine;

public class Administrator : MonoBehaviour
{
    private SpawnManager SpawnManager;
    private ScoreManager ScoreManager;
    private WaveManager WaveManager;
    private CanvasManager CanvasManager;

    [SerializeField] private GameObject Player;

    private void Awake()
    {
        SpawnManager = GetComponentInChildren<SpawnManager>();
        ScoreManager = GetComponentInChildren<ScoreManager>();
        WaveManager = GetComponentInChildren<WaveManager>();
        CanvasManager = GetComponentInChildren<CanvasManager>();
    }

    private void Start()
    {
        CanvasManager.HidePanel_panelGameOverPanel();
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
        CanvasManager.HidePanel_panelMainPanel();
        CanvasManager.ShowPanel_panelGameOverPanel();
        
        SpawnManager.StopAllCoroutines();
    }
}
