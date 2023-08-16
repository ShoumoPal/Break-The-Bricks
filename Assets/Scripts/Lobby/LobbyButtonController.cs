using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyButtonController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button volumeButton;
    [SerializeField] private GameObject levelSelectionPanel;
    [SerializeField] private GameObject volumePanel;
    private bool isActive;

    private void Start()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
        volumeButton.onClick.AddListener(ShowSlider);
        isActive = true;
    }

    private void ShowSlider()
    {
        SoundManager.Instance.PlayFX(SoundType.ButtonClick);
        volumePanel.SetActive(isActive);

        if (isActive)
            isActive = false;
        else
            isActive = true;
    }

    private void Quit()
    {
        SoundManager.Instance.PlayFX(SoundType.ButtonClick);
        Application.Quit();
    }

    private void Play()
    {
        SoundManager.Instance.PlayFX(SoundType.ButtonClick);
        levelSelectionPanel.SetActive(true);
    }


}
