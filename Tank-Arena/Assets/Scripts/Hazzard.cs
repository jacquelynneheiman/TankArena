using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TankData tank = other.GetComponent<TankData>();

        if(tank != null)
        {
            Destroy(tank.gameObject);
        }
    }
}
