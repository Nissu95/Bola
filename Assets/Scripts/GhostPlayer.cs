using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    [SerializeField] GameObject ghostCameraPrefab;

    Camera mainCamera;
    float screenWidth;
    float screenHeight;
    float rightSidePositionX;
    float leftSidePositionX;
    BallBehaviour ballBehaviour;

    GameObject[] ghostCameras = new GameObject[2];

    void Start()
    {
        ballBehaviour = GetComponent<BallBehaviour>();

        //Finding screen Width
        mainCamera = Camera.main;
        Vector3 screenBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 screenTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

        screenWidth = screenTopRight.x - screenBottomLeft.x;
        screenHeight = screenTopRight.y - screenBottomLeft.y;

        rightSidePositionX = mainCamera.transform.position.x + (screenWidth / 2);
        leftSidePositionX = mainCamera.transform.position.x - (screenWidth / 2);

        ghostCameras[0] = Instantiate(ghostCameraPrefab, mainCamera.transform);
        ghostCameras[1] = Instantiate(ghostCameraPrefab, mainCamera.transform);

        foreach (var item in ghostCameras)
        {
            DestroyImmediate(item.GetComponent<CameraFollow>());
            item.transform.position = mainCamera.transform.position;
        }

        ghostCameras[0].transform.Translate(Vector3.right * screenWidth);
        ghostCameras[1].transform.Translate(Vector3.left * screenWidth);

    }

    visibleType IsVisible()
    {
        if (transform.position.y < mainCamera.transform.position.y - (screenHeight / 2))
            return visibleType.Below;

        if (transform.position.x < screenWidth / 2 && transform.position.x > -screenWidth / 2)
            return visibleType.Visible;

        if (transform.position.x < screenWidth / 2)
            return visibleType.Left;

        return visibleType.Right;
    }

    // Update is called once per frame
    void Update()
    {
        visibleType visible = IsVisible();

        if (visible == visibleType.Below)
            ballBehaviour.PlayerLose();
        else if (visible == visibleType.Right)
            transform.position = new Vector3(leftSidePositionX, transform.position.y, transform.position.z);
        else if (visible == visibleType.Left)
            transform.position = new Vector3(rightSidePositionX, transform.position.y, transform.position.z);
    }

    enum visibleType { Left, Right, Visible, Below };
}
