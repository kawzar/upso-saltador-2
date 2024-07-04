using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    public bool IsPlaying { get; private set; }
    public int Score { get; private set; }

    public int HighScore { get; private set; }

    private const string HIGHSCORE_KEY = "highscore";

    private void Awake()
    {
        Instance = this;
        IsPlaying = true;
        HighScore = PlayerPrefs.GetInt(HIGHSCORE_KEY);
        UIMananger.Instance.UpdateHighScoreText(HighScore.ToString());
    }

    public void Perder()
    {
        AudioManager.Instance.PlaySound(AudioClipEnum.GameOver);
        UIMananger.Instance.FadeInGameOver();
        IsPlaying = false;
    }

    

    public void JugarDeNuevo()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int score)
    {
        this.Score += score;

        if(Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(HIGHSCORE_KEY, HighScore);
            UIMananger.Instance.UpdateHighScoreText(HighScore.ToString());
        }

        UIMananger.Instance.UpdateScoreText(Score.ToString());
    }
}
