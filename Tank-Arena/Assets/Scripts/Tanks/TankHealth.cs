using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [Header("Stats")]
    public float currentHealth;
    public float maxHealth;

    [Header("UI Components")]
    public Image healthFill;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth < 0)
        {
            Debug.Log("Player is dead");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthFill)
        {
            healthFill.fillAmount = currentHealth / maxHealth; 
        }
    }
}
