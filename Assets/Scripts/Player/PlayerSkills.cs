using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkills : MonoBehaviour
{
    private PlayerAnimator playerAnimator;
    private bool isShieldActive;

    void Awake()
    {
        // Get reference to PlayerAnimator
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void OnShield(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShieldActive = true;
            playerAnimator.SetShieldActive(true);
        }
        else if (context.canceled)
        {
            isShieldActive = false;
            playerAnimator.SetShieldActive(false);
        }
    }

    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}
