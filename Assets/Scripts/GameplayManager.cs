using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private bool HasGameFinished;

    [SerializeField] private TMP_Text ScoreText;

    private float Score;
    private float ScoreSpeed;
    private int currentLevel;

    [SerializeField] private List<int> LevelSpeed, LevelMax;

    private void Awake()
    {
        GameManager.Instance.IsInitialized = true;
        HasGameFinished = false;
        Score = 0;
        currentLevel = 0;
        ScoreText.text = ((int)Score).ToString();
        ScoreSpeed = LevelSpeed[currentLevel];
    }

    private void Update()
    {
        if (HasGameFinished) return;
        Score += ScoreSpeed * Time.deltaTime;
        ScoreText.text = ((int)Score).ToString();

        if(Score > LevelMax[Mathf.Clamp(currentLevel, 0, LevelSpeed.Count - 1)])
        {
            currentLevel = Mathf.Clamp(currentLevel + 1, 0, LevelSpeed.Count - 1);
            ScoreSpeed = LevelSpeed[currentLevel];
        }
    }

    public void GameOver()
    {
        HasGameFinished = true;
        GameManager.Instance.CurrentScore = (int)Score;
        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.GoToMainMenu();
    }
}
