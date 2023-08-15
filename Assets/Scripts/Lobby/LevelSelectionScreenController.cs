using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionScreenController : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject levelSelectionPanel;

    private void Start()
    {
        backButton.onClick.AddListener(GoBack);
    }

    private void GoBack()
    {
        levelSelectionPanel.SetActive(false);
    }
}
