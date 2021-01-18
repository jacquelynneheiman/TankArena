using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankMover : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float gunSpeed;

    Quaternion targetRotation;
    Rigidbody rb;
   

    public Quaternion TargetRotation { get { return targetRotation; } }

    private void Start()
    {
        targetRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    public void SpeedBoost(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void Move(float direction)
    {
        Vector3 position = transform.position;
        position += transform.forward * direction * moveSpeed * Time.deltaTime;
        transform.position = position;
    }

    public void Rotate(float direction)
    {
        transform.Rotate(transform.up, rotateSpeed * direction * Time.deltaTime);
        targetRotation = transform.rotation;
    }

    public void RotateGun(TankData tank, float direction)
    {
        
        
        tank.gun.transform.Rotate(transform.up, gunSpeed * direction * Time.deltaTime);
    }

    public void SnapToRotation(TankData data, Vector3 direction)
    {
        data.gun.transform.forward = direction;
    }
}
