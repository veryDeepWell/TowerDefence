using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public TMP_Text TextComponent;

    public void ScoreInteger(int scoreAmount)
    {
        TextComponent.text = Convert.ToString(Convert.ToInt32(TextComponent.text) + scoreAmount);
    }
}
