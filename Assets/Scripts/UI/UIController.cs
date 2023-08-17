using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button ffButton;

    [SerializeField] private GameObject pauseMenuPanel;

    private void Start()
    {
        pauseButton.onClick.AddListener(ShowPauseMenu);
        ffButton.onClick.AddListener(FastForward);
    }

    private void FastForward()
    {
        
    }

    private void ShowPauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
    }
}
