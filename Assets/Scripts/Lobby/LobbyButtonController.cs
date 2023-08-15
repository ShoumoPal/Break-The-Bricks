using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyButtonController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject levelSelectionPanel;

    private void Start()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void Play()
    {
        levelSelectionPanel.SetActive(true);
    }
}
