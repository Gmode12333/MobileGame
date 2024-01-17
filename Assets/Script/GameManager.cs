using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : GlobalReference<GameManager>
{
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject NewHighScore;
    public GameObject GameUI;
    public GameObject PauseButton;
    public GameObject InGameScore;

    public GameObject Player;

    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI InGameScoreText;
    public TextMeshProUGUI GameOverScoreText;

    public int Score;
    public int CurrentBubbleHealth = 1;
    public int CurrentBubbleCount;
    public int CurrentBuffCount;

    public int GunLevel;
    public float FireRate;
    public float DropRate;
    public bool isGameOver;
    public bool BubbleUpgraded;
    [SerializeField] float nextBubbleUpgradetime;
    private void Awake()
    {
        Time.timeScale = 0;
        HighScoreText.text = GetPlayerHighScore().ToString();
        SoundManager.Instance.PlayMusic("Game");
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        isGameOver = false;
        NewHighScore.SetActive(false);
        GameUI.SetActive(false);
        PauseButton.SetActive(true);
        InGameScore.SetActive(true);
    }
    public void AddScore()
    {
        Score++;
        InGameScoreText.text = Score.ToString();
    }
    public void SetBubbleHealth()
    {
        CurrentBubbleHealth += 1;
        BubbleUpgraded = true;
    }
    public void GameOver()
    {
        SoundManager.Instance.PlaySound("GameOver");
        isGameOver = true;
        PauseButton.SetActive(false);
        InGameScore.SetActive(false);
        GameOverMenu.SetActive(true);
        GameOverScoreText.text = Score.ToString();
        int temp = GetPlayerHighScore();
        if(Score > temp)
        {
            NewHighScore.SetActive(true);
            SavePlayerHighScore();
        }
        Time.timeScale = 0;
    }
    public void InscreaseDropRate()
    {
        DropRate -= 0.1f;
    }
    public void SavePlayerHighScore()
    {
        PlayerPrefs.SetInt("HighScore", Score);
    }
    public int GetPlayerHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    public void ReStartGame()
    {
        SetDefault();
    }
    public void SetDefault()
    {
        Player.transform.position = new Vector2(0f, -3.6f);
        HighScoreText.text = GetPlayerHighScore().ToString();
        Bubble.BubbleCount = 0;
        Buff.count = 0;
        GunLevel = 1;
        CurrentBubbleHealth = 1;
        FireRate = 1f;
        DropRate = 1f;
        Score = 0;
        InGameScoreText.text = Score.ToString();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        CurrentBubbleCount = Bubble.BubbleCount;
        CurrentBuffCount = Buff.count;
        if (FireRate < 0.1f)
        {
            GunLevel++;
            FireRate = 1f;
        }
        if(BubbleUpgraded)
        {
            int temp = Score;
            if(Score != temp)
            {
                BubbleUpgraded = false;
            }
        }
        if (nextBubbleUpgradetime < Time.time)
        {
            GameManager.Instance.SetBubbleHealth();
            GameManager.Instance.InscreaseDropRate();
            nextBubbleUpgradetime = Time.time + 25f;
        }
    }
}
