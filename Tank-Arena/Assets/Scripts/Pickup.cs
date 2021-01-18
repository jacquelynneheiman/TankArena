using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Repair, Shield, Speed
    }

    public PickupType pickupType;

    public float amount;
    public float delay;

    public float spinSpeed;
    public float hoverSpeed;

    public float hoverMax;
    public float hoverMin;

    float hoverHeight;
    float hoverRange;

    

    private void Start()
    {
        hoverHeight = (hoverMin + hoverMax) / 2f;
        hoverRange = hoverMax - hoverMin;
    }


    public void Update()
    {
        transform.Rotate(transform.up, spinSpeed * Time.deltaTime);

        Vector3 position = transform.position;
        position.y = transform.up.y * hoverHeight + Mathf.Cos(Time.time * hoverSpeed) * hoverRange;
        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        TankPowerUp tank = other.GetComponent<TankPowerUp>();

        if(tank != null)
        {
            tank.ActivatePowerup(this);
        }

        Destroy(this.gameObject);
        
    }
}
