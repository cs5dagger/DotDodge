using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ScoreText;
    
    [SerializeField]
    private TMP_Text NewBestText;
    
    [SerializeField]
    private TMP_Text HighScoreText;

    private void Awake()
    {
        HighScoreText.text = GameManager.Instance.HighScore.ToString();

        if(!GameManager.Instance.IsInitialized)
        {
            ScoreText.gameObject.SetActive(false);
            NewBestText.gameObject.SetActive(false); 
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    [SerializeField] private float AnimationTime;
    [SerializeField] private AnimationCurve SpeedCurve;

    /// <summary>
    /// Display and update score
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        ScoreText.text = tempScore.ToString();

        int currScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;

        if(highScore < currScore)
        {
            NewBestText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currScore;
        }
        else
        {
            NewBestText.gameObject.SetActive(false);
        }

        HighScoreText.text = GameManager.Instance.HighScore.ToString();
        float speed = 1 / AnimationTime;
        float timeElapsed = 0f;

        /// Play score animation
        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;

            tempScore = (int)(SpeedCurve.Evaluate(timeElapsed) * currScore);
            ScoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currScore;
        ScoreText.text = tempScore.ToString();
    }

    [SerializeField] private AudioClip ClickClip;

    /// <summary>
    /// Play sound and change scene to play
    /// </summary>
    public void ClickedPlay()
    {
        SoundManager.instance.PlaySound(ClickClip);
        GameManager.Instance.GoToGamePlay();
    }


}
