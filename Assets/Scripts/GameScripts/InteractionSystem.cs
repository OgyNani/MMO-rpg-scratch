using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactPrompt; // ����� "Press 'F' to interact"
    private bool isPlayerInRange;
    private IInteractable currentInteractable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            isPlayerInRange = true;
            currentInteractable = interactable;
            interactPrompt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable) && interactable == currentInteractable)
        {
            isPlayerInRange = false;

            // ��������� ������, ���� ����� ������ �� NPC
            var npc = currentInteractable as NPC;
            if (npc != null)
            {
                npc.HideDialogue();
            }

            interactPrompt.gameObject.SetActive(false); // �������� ���������
            currentInteractable = null;
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Keyboard.current.fKey.wasPressedThisFrame)
        {
            currentInteractable?.Interact();

            // �������� ��������� ��� �������� �������
            if (currentInteractable is NPC)
            {
                interactPrompt.gameObject.SetActive(false);
            }
        }
    }
}
