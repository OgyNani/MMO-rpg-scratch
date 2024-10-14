using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerAnimator playerAnimator;

    void Start()
    {
        string selectedCharacter = CharacterSelection.selectedCharacter;
        int selectedSkinID = CharacterSelection.selectedSkinID;

        if (selectedCharacter == "Mage")
        {
            Mage mage = new Mage();
            Skin selectedSkin = mage.GetSkinByID(selectedSkinID);
            playerAnimator.SetCharacterAnimations(selectedSkin);
        }
        else if (selectedCharacter == "Dummy")
        {
            Dummy dummy = new Dummy();
            Skin selectedSkin = dummy.GetSkinByID(selectedSkinID);
            playerAnimator.SetCharacterAnimations(selectedSkin);
        }
    }
}
