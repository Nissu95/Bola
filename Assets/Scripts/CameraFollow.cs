using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 position = transform.position;

        position.y = target.position.y;

        transform.position = position;
    }
}
