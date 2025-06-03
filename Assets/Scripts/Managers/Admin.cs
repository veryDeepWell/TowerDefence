using UnityEngine;
using UnityEngine.Serialization;

public class Administrator : MonoBehaviour
{
    private SpawnManager _spawnManager;
    private ScoreManager _scoreManager;
    private WaveManager _waveManager;
    private CanvasManager _canvasManager;
    
    public StatsManager statsManager;

    [FormerlySerializedAs("Player")] [SerializeField] private GameObject player;

    private void Awake()
    {
        _spawnManager = GetComponentInChildren<SpawnManager>();
        _scoreManager = GetComponentInChildren<ScoreManager>();
        _waveManager = GetComponentInChildren<WaveManager>();
        _canvasManager = GetComponentInChildren<CanvasManager>();
        statsManager = GetComponentInChildren<StatsManager>();
    }

    private void Start()
    {
        _canvasManager.HidePanel_panelGameOverPanel();
    }

    public void AddScore(int scoreToAdd)
    {
        _scoreManager.ScoreInteger(1);
    }

    public void SetTarget(int targetInt)
    {
        _scoreManager.TargetInteger(targetInt);
    }

    public int GetEnemyAmount()
    {
        return _waveManager.EnemyAmountDetermine();
    }

    public void ChangeWave(int waveChanger)
    {
        _waveManager.ChangeWave(waveChanger);
    }

    public void GameOver()
    {
        _canvasManager.HidePanel_panelMainPanel();
        _canvasManager.ShowPanel_panelGameOverPanel();
        
        _spawnManager.StopAllCoroutines();
    }

    public void IAMHERE()
    {
        Debug.Log("IAMHERE");
    }
}
