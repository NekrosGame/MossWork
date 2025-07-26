using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // 추가

public class UIManager : MonoBehaviour
{
    public static int MaxScore; // MaxScore를 public static으로 변경하여 외부에서 접근 가능하도록 수정
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI RestartText;
    public TextMeshProUGUI ExitText;
    public TextMeshProUGUI ClickJumpText;
    public TextMeshProUGUI MaxScoreText;

    public void Start()
    {
        if (RestartText == null)
        {
            Debug.LogError("RestartText is null");
        }

        if (ScoreText == null)
        {
            Debug.LogError("ScoreText is null");
            return;
        }

        RestartText.gameObject.SetActive(false);
        ExitText.gameObject.SetActive(false);
        ClickJumpText.gameObject.SetActive(false);
        MaxScoreText.gameObject.SetActive(false);

        // 저장된 최고점수 불러오기
        MaxScore = PlayerPrefs.GetInt("MaxScore", 0);
        UpdateMaxScoreText();
    }

    public void SetRestart()
    {
        RestartText.gameObject.SetActive(true);
        ExitText.gameObject.SetActive(true);
        ClickJumpText.gameObject.SetActive(true);
        MaxScoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();

        // 최고점수 갱신
        if (score > MaxScore)
        {
            MaxScore = score;
            PlayerPrefs.SetInt("MaxScore", MaxScore);
            PlayerPrefs.Save();
            UpdateMaxScoreText();
        }
    }

    private void UpdateMaxScoreText()
    {
        if (MaxScoreText != null)
            MaxScoreText.text = $"MaxScore: {MaxScore}";
    }

    void Update()
    {
        // ExitText가 활성화되어 있고 Esc키가 눌리면 MainScene으로 이동
        if (ExitText != null && ExitText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}