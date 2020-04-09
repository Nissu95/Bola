using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distanceFromTarget;

    void Update()
    {
        Vector3 position = transform.position;
        if (position.y < target.position.y - distanceFromTarget)
        {
            position.y = target.position.y - distanceFromTarget;
            transform.position = position;
        }
    }
}
