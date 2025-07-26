using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public GameObject RKeyPanel; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            if (RKeyPanel != null)
                RKeyPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // other.gameObject가 파괴된 경우 예외 방지
        if (other == null || other.gameObject == null) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            if (RKeyPanel != null)
                RKeyPanel.SetActive(false);
        }
    }
}
