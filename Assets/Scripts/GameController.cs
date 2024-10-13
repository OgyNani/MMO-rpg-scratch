using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerAnimator playerAnimator;

    void Start()
    {
        Mage mage = new Mage();
        Skin selectedSkin = mage.GetSkinByID(1);
        playerAnimator.SetCharacterAnimations(selectedSkin);
    }

}
