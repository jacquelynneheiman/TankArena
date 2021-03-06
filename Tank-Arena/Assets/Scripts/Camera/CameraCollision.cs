﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{

    [HideInInspector] public LayerMask collisionLayer;
    [HideInInspector] public bool isColliding = false;
    [HideInInspector] public Vector3[] adjustedCameraClipPoints;
    [HideInInspector] public Vector3[] desiredCameraClipPoints;

    Camera camera;

    public void Initialize(Camera cam)
    {
        camera = cam;
        adjustedCameraClipPoints = new Vector3[5];
        desiredCameraClipPoints = new Vector3[5];
    }

    public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
    {
        if (!camera)
        {
            return;
        }

        //clear contents of intoArray
        intoArray = new Vector3[5];

        float z = camera.nearClipPlane;
        float x = Mathf.Tan(camera.fieldOfView / 3.41f) * z;
        float y = x / camera.aspect;

        //top left
        intoArray[0] = (atRotation * new Vector3(-x, y, z)) + cameraPosition;

        //top right
        intoArray[1] = (atRotation * new Vector3(x, y, z)) + cameraPosition;

        //bottom left
        intoArray[2] = (atRotation * new Vector3(-x, -y, z)) + cameraPosition;

        //bottom right
        intoArray[3] = (atRotation * new Vector3(x, -y, z)) + cameraPosition;

        intoArray[4] = cameraPosition - camera.transform.forward;

    }

    bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
    {
        for (int i = 0; i < clipPoints.Length; i++)
        {
            Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
            float distance = Vector3.Distance(clipPoints[i], fromPosition);

            if (Physics.Raycast(ray, distance, collisionLayer))
            {
                return true;
            }
        }

        return false;
    }

    public float GetAdjustedDistanceWithRay(Vector3 from)
    {
        float distance = -1f;

        for(int i = 0; i < desiredCameraClipPoints.Length; i++)
        {
            Ray ray = new Ray(from, desiredCameraClipPoints[i] - from);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(distance == -1f)
                {
                    distance = hit.distance;
                }
                else
                {
                    if(hit.distance < distance)
                    {
                        distance = hit.distance;
                    }
                }
            }
        }

        if(distance == -1f)
        {
            return 0;
        }

        return distance;
    }

    public void CheckColliding(Vector3 targetPosition)
    {
        if(CollisionDetectedAtClipPoints(desiredCameraClipPoints, targetPosition))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }


}
