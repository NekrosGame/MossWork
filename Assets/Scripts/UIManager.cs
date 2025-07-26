using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // �߰�

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI RestartText;
    public TextMeshProUGUI ExitText;
    public TextMeshProUGUI ClickJumpText;

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
    }

    public void SetRestart()
    {
        RestartText.gameObject.SetActive(true);
        ExitText.gameObject.SetActive(true);
        ClickJumpText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    void Update()
    {
        // ExitText�� Ȱ��ȭ�Ǿ� �ְ� EscŰ�� ������ MainScene���� �̵�
        if (ExitText != null && ExitText.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}