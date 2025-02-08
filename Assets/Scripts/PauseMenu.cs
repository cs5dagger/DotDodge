using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Overlay;

    [SerializeField]
    private GameObject PauseButton;

    [SerializeField]
    private GameObject ResumeButton;

    public void OnPausePressed()
    {
        Time.timeScale = 0;
        Overlay.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void OnResumePressed()
    {
        Time.timeScale = 1; 
        Overlay.SetActive(false);
        PauseButton.SetActive(true);
    }
}
