using UnityEngine;

public class Administrator : MonoBehaviour
{
    private SpawnManager SpawnManager;
    private ScoreManager ScoreManager;

    private void Awake()
    {
        SpawnManager = GetComponentInChildren<SpawnManager>();
        ScoreManager = GetComponentInChildren<ScoreManager>();
    }

    public void AddScore(int ScoreToAdd)
    {
        ScoreManager.ScoreInteger(1);
    }
}
