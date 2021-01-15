using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public TankData data;

    float forwardDirection;
    float rotateDirection;

    bool hasPlayedStartSound;
    bool hasPlayedEndSound;

    private void Update()
    {

        forwardDirection = Input.GetAxis("Vertical");
        rotateDirection = Input.GetAxis("Horizontal");
        

        if(Input.GetKey(KeyCode.UpArrow))
        {
            data.mover.SnapToRotation(data, data.transform.right);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            data.mover.RotateGun(data, -1f);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            data.mover.SnapToRotation(data, -data.transform.right);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            data.mover.RotateGun(data, 1f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            data.shooter.Shoot(data);
        }

        data.mover.Rotate(rotateDirection);
    }

    private void FixedUpdate()
    {
        data.mover.Move(forwardDirection);
    }
}
