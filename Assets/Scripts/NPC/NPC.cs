using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] public GameObject dialoguePanel; // ������ ������� ��� ����� NPC

    private void Start()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false); // �������� ���������� ������ ��� ������
        }
    }

    public void Interact()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true); // ���������� ������ ��� ��������������
        }
        else
        {
            Debug.LogWarning("Dialogue Panel �� �������� ��� NPC.");
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
