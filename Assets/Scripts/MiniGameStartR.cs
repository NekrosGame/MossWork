using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameStartR : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // �� ��ũ��Ʈ�� ����� ������Ʈ(�г�)�� Ȱ��ȭ�Ǿ� ���� ���� ����
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MiniGameScene");
        }
    }
}
