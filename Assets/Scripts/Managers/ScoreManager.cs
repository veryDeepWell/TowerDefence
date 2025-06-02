using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text targetText;

    public void ScoreInteger(int scoreAmount)
    {
        scoreText.text = Convert.ToString(Convert.ToInt32(scoreText.text) + scoreAmount);
    }
    
    public void TargetInteger(int targetInt)
    {
        targetText.text = targetInt.ToString();
    }
}
