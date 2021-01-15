using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    public void SetOffset(Vector3 newOffset)
    {
        offset = newOffset;
    }

    public void LateUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        Vector3 position = transform.position;
        position = target.position - offset;
        transform.position = position;
    }

    void Rotate()
    {

    }






}
