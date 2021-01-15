using UnityEngine;
using UnityEngine.UI;

public class TankShields : MonoBehaviour
{
    [Header("Stats")]
    public float currentShield;
    public float maxShields;

    [Header("UI Components")]
    public Image shieldIndicator;


    private void Start()
    {
        currentShield = maxShields;
        UpdateUI();
    }

    public void TakeShieldDamage(TankData tank, float amount)
    {
        float delta = currentShield - amount;

        if (delta <= 0)
        {
            tank.health.TakeDamage(Mathf.Abs(delta));
        }

        currentShield -= amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (shieldIndicator)
        {
            shieldIndicator.fillAmount = currentShield / maxShields;

        }
    }
}
