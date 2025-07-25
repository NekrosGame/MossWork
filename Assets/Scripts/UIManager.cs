using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // �߰�

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI ExitText;


    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartText.gameObject.SetActive(false);
        ExitText.gameObject.SetActive(false);

    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        ExitText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
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