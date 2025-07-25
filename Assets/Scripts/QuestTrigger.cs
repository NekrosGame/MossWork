using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public GameObject rKeyPanel; // RŰ �г� (Ȱ��/��Ȱ�� ���)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            rKeyPanel.SetActive(true);
            Debug.Log("����Ʈ Npc ������ ����!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            rKeyPanel.SetActive(false);
            Debug.Log("����Ʈ Npc �������� ��Ż!");
        }
    }
}
