using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameStartR : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // 이 스크립트가 연결된 오브젝트(패널)가 활성화되어 있을 때만 동작
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MiniGameScene");
        }
    }
}
