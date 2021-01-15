using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float destroyDelay;

    public GameObject explosionVFX;
    public AudioClip explosionSFX;

    [HideInInspector]
    public TankData owner;

    Rigidbody rb;
    AudioSource audioSource;
    float damage;

    private void Start()
    {
        damage = owner.damage;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.AddForce(transform.forward * bulletSpeed);

        Destroy(this.gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        TankData otherTank = other.GetComponent<TankData>();

        if(otherTank && otherTank.shield)
        {
            if (otherTank != owner)
            {
                otherTank.shield.TakeShieldDamage(otherTank, damage); 
            }
        }
        else if(otherTank && otherTank.health)
        {
            if (otherTank != owner)
            {
                otherTank.health.TakeDamage(damage); 
            }
        }

        Instantiate(explosionVFX, transform.position, transform.rotation);
        audioSource.clip = explosionSFX;
        audioSource.Play();


        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Destroy(this.gameObject, 1f);
    }
}
