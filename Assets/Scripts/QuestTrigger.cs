using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public GameObject rKeyPanel; // RŰ �г� (Ȱ��/��Ȱ�� ���)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            if (rKeyPanel != null)
                rKeyPanel.SetActive(true);
            Debug.Log("����Ʈ Npc ������ ����!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // other.gameObject�� �ı��� ��� ���� ����
        if (other == null || other.gameObject == null) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            if (rKeyPanel != null)
                rKeyPanel.SetActive(false);
            Debug.Log("����Ʈ Npc �������� ��Ż!");
        }
    }
}
