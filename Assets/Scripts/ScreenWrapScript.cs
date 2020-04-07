using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapScript : MonoBehaviour
{
    Renderer[] renderers;
    bool isWrapping = false;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
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

        Camera cam = Camera.main;
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
        foreach (Renderer renderer in renderers)
            if (renderer.isVisible)
                return true;
        return false;
    }
}
