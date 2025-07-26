using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 추가

public class ScoreText : MonoBehaviour
{
    public GameObject MiniScore;      // MiniScore 판넬
    public TextMeshProUGUI YourScore; // Text에서 TextMeshProUGUI로 변경
    public Button ExitButton;         // ExitButton 버튼

    void Start()
    {
        // MiniGameScene에서 MainScene으로 돌아왔을 때 호출된다고 가정
        MiniScore.SetActive(true);

        // UIManager의 MaxScore 값을 YourScore에 표시
        YourScore.text = UIManager.MaxScore.ToString();

        // ExitButton 클릭 시 MiniScore 판넬 비활성화
        ExitButton.onClick.AddListener(() => MiniScore.SetActive(false));
    }

}
