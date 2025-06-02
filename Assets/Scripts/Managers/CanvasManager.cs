using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOverPanel;
    [SerializeField] private GameObject panelMainPanel;

    public void HidePanel_panelGameOverPanel()
    {
        panelGameOverPanel.SetActive(false);
    }
    
    public void ShowPanel_panelGameOverPanel()
    {
        panelGameOverPanel.SetActive(true);
    }
    
    public void HidePanel_panelMainPanel()
    {
        panelMainPanel.SetActive(false);
    }
    
    public void ShowPanel_panelMainPanel()
    {
        panelMainPanel.SetActive(true);
    }
}
