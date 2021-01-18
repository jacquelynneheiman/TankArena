using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPowerUp : MonoBehaviour
{
    TankData self;
    float speed;
    float timer;

    private void Start()
    {
        self = GetComponent<TankData>();
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                ResetSpeed();
            }
        }
    }

    public void ActivatePowerup(Pickup pickup)
    {
        if(pickup.pickupType == Pickup.PickupType.Repair)
        {
            RepairTank(pickup);
        }
        else if(pickup.pickupType == Pickup.PickupType.Shield)
        {
            ActivateShield(pickup);
        }
        else
        {
            TurboBoost(pickup);
        }
    }

    void RepairTank(Pickup pickup)
    {
        self.health.Repair(pickup.amount);
    }

    void ActivateShield(Pickup pickup)
    {
        self.shield.RestoreShields();
    }

    void TurboBoost(Pickup pickup)
    {
        speed = self.mover.moveSpeed;
        timer = pickup.delay;
        self.mover.SpeedBoost(self.mover.moveSpeed + pickup.amount);
    }

    void ResetSpeed()
    {
        self.mover.SpeedBoost(speed);
    }

    
}
