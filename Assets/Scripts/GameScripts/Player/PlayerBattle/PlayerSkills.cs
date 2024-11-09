using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkills : MonoBehaviour
{
    private PlayerAnimator playerAnimator;
    private PlayerStats playerStats;
    private bool isShieldActive;

    void Awake()
    {
        // Get references to PlayerAnimator and PlayerStats
        playerAnimator = GetComponent<PlayerAnimator>();
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (isShieldActive)
        {
            // Consume 10 mana per second while the shield is active
            if (playerStats.getCurrentMana() >= 10 * Time.deltaTime)
            {
                playerStats.ConsumeMana(10 * Time.deltaTime);
            }
            else
            {
                // Deactivate shield if not enough mana
                DeactivateShield();
            }
        }
    }

    public void OnShield(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ActivateShield();
        }
        else if (context.canceled)
        {
            DeactivateShield();
        }
    }

    private void ActivateShield()
    {
        if (playerStats.getCurrentMana() >= 10)
        {
            isShieldActive = true;
            playerAnimator.SetShieldActive(true);
        }
    }

    private void DeactivateShield()
    {
        isShieldActive = false;
        playerAnimator.SetShieldActive(false);
    }

    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}
