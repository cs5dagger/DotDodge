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

    [SerializeField]
    private GameObject ExitOverlay;

    public void OnPausePressed()
    {
        Time.timeScale = 0;
        this.Overlay.SetActive(true);
        this.PauseButton.SetActive(false);
    }

    public void OnResumePressed()
    {
        Time.timeScale = 1; 
        this.Overlay.SetActive(false);
        this.PauseButton.SetActive(true);
    }

    public void OnExitPressed()
    {
        ExitOverlay.SetActive(true);
    }

    public void OnConfirmExit() 
    {
        Application.Quit();
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    public void OnCancel()
    {
        ExitOverlay.SetActive(false);
    }
}
