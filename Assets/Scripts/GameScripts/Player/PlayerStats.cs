using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public HealthBar health_bar;
    public ManaBar mana_bar;

    //BASE STATS
    private readonly float max_health = 100;
    private readonly float max_mana = 100;
    private readonly float move_speed = 5;
    private readonly float defence = 0;
    private readonly float wisdom = 1;
    private readonly float vitality = 1;
    private readonly float attack = 5;
    private readonly float crit_damage_percent = 10;
    private readonly float crit_chance_percent = 10;

    private float current_health;
    private float current_mana;
    private float damage_take;

    private PlayerSkills playerSkills;

    private void Start()
    {
        playerSkills = GetComponent<PlayerSkills>();
        current_health = max_health;
        current_mana = max_mana;

        health_bar.SetSliderMax(max_health);
        mana_bar.SetSliderMax(max_mana);

        // «апускаем регенерацию с интервалом 1 секунда
        InvokeRepeating(nameof(HealthRegen), 1f, 1f);
        InvokeRepeating(nameof(ManaRegen), 1f, 1f);
    }

    private void Update()
    {
        // ќграничиваем здоровье и ману максимальным значением
        if (current_health > max_health) { current_health = max_health; }
        if (current_mana > max_mana) { current_mana = max_mana; }

        // Ћогика смерти
        if (current_health <= 0) { Die(); }
    }

    public float getMaxHealth() { return max_health; }
    public float getCurrentHealth() { return current_health; }
    public float getMaxMana() { return max_mana; }
    public float getCurrentMana() { return current_mana; }
    public float getSpeed() { return move_speed; }
    public float getDefence() { return defence; }
    public float getWisdom() { return wisdom; }
    public float getVitality() { return vitality; }
    public float getAttack() { return attack; }
    public float getCritDamagePercent() { return crit_damage_percent; }
    public float getCritChancePercent() { return crit_chance_percent; }

    public void TakeDamage(float amount)
    {
        if (playerSkills != null && playerSkills.IsShieldActive())
        {
            return; // No damage taken if shield is active
        }

        float damage_take = Mathf.Max(amount - defence, 0); // Ensure damage is not negative
        current_health -= damage_take;

        health_bar.SetSlider(current_health);
    }

    public void ConsumeMana(float amount)
    {
        current_mana -= amount;
        mana_bar.SetSlider(current_mana);
    }

    public void Heal(float amount)
    {
        current_health += amount;
        health_bar.SetSlider(current_health);
    }

    private void HealthRegen()
    {
        if (current_health < max_health)
        {
            current_health += Mathf.Max(vitality, 0);
            health_bar.SetSlider(current_health);
        }
        else if (current_health > max_health)
        {
            current_health = max_health;
            health_bar.SetSlider(current_health);
        }
    }

    private void ManaRegen()
    {
        if (current_mana < max_mana)
        {
            current_mana += Mathf.Max(wisdom, 0);
            mana_bar.SetSlider(current_mana);
        }
        else if (current_mana > max_mana)
        {
            current_mana = max_mana;
            mana_bar.SetSlider(current_mana);
        }
    }


    private void Die()
    {
        Debug.Log("You died....");
    }
}
