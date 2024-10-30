using UnityEngine;

public class NPCTypeSelector : MonoBehaviour
{
    public enum NPCType
    {
        Traveler,
        Blacksmith
    }

    [SerializeField] private NPCType selectedNPCType; // ���� ��� ������ ���� � ����������
    [SerializeField] private GameObject npcUI; // ����������� ������ NPC �� UI

    private void Start()
    {
        SetActiveNPCType();
    }

    private void SetActiveNPCType()
    {
        if (npcUI == null) return;

        Transform npcTypeTransform = npcUI.transform.Find("NPCType");
        if (npcTypeTransform == null) return;

        foreach (Transform child in npcTypeTransform)
        {
            child.gameObject.SetActive(false); // ��������� ����
        }

        // �������� ������ ��������� ���
        switch (selectedNPCType)
        {
            case NPCType.Traveler:
                npcTypeTransform.Find("Traveler")?.gameObject.SetActive(true);
                break;
            case NPCType.Blacksmith:
                npcTypeTransform.Find("Blacksmith")?.gameObject.SetActive(true);
                break;
        }
    }
}
