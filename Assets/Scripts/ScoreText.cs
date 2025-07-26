using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // �߰�

public class ScoreText : MonoBehaviour
{
    public GameObject MiniScore;      // MiniScore �ǳ�
    public TextMeshProUGUI YourScore; // Text���� TextMeshProUGUI�� ����
    public Button ExitButton;         // ExitButton ��ư

    void Start()
    {
        // MiniGameScene���� MainScene���� ���ƿ��� �� ȣ��ȴٰ� ����
        MiniScore.SetActive(true);

        // UIManager�� MaxScore ���� YourScore�� ǥ��
        YourScore.text = UIManager.MaxScore.ToString();

        // ExitButton Ŭ�� �� MiniScore �ǳ� ��Ȱ��ȭ
        ExitButton.onClick.AddListener(() => MiniScore.SetActive(false));
    }

}
