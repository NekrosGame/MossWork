using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public GameObject rKeyPanel; // R키 패널 (활성/비활성 대상)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            if (rKeyPanel != null)
                rKeyPanel.SetActive(true);
            Debug.Log("퀘스트 Npc 범위에 진입!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // other.gameObject가 파괴된 경우 예외 방지
        if (other == null || other.gameObject == null) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            if (rKeyPanel != null)
                rKeyPanel.SetActive(false);
            Debug.Log("퀘스트 Npc 범위에서 이탈!");
        }
    }
}
