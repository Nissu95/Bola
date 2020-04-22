using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapScript : MonoBehaviour
{
    Plane[] planes;
    Camera cam;
    Collider thisCollider;
    bool isWrapping = false;

    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        thisCollider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        ScreenWrap();
    }

    void ScreenWrap()
    {
        bool isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrapping = false;
            return;
        }

        if (isWrapping)
            return;

        
        Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
        Vector3 newPos = transform.position;

        if (!isWrapping && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPos.x = -newPos.x;
            isWrapping = true;
        }

        transform.position = newPos;
    }

    bool CheckRenderers()
    {
        if (GeometryUtility.TestPlanesAABB(planes, thisCollider.bounds))
            return true;
        return false;
    }
}
