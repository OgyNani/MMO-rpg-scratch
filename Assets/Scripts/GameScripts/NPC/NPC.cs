using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] public GameObject dialoguePanel; // ѕанель диалога дл€ этого NPC

    private void Start()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false); // —крываем диалоговый панель при старте
        }
    }

    public void Interact()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true); // ѕоказываем диалог при взаимодействии
        }
        else
        {
            Debug.LogWarning("Dialogue Panel не назначен дл€ NPC.");
        }
    }

    public void HideDialogue()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
