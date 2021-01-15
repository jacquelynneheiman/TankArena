using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [Header("Stats")]
    public float fireRate;

    [Header("Components")]
    public Bullet bulletPrefab;
    public Transform[] bulletSpawns;

    float timer = 0f;

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Shoot(TankData tank)
    {
        if (timer <= 0)
        {
            for (int i = 0; i < bulletSpawns.Length; i++)
            {
                Bullet bullet = Instantiate<Bullet>(bulletPrefab, bulletSpawns[i].position, bulletSpawns[i].rotation);
                bullet.owner = tank;
                timer = fireRate;
            } 
        }
    }
}
