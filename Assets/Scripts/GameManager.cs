using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    [SerializeField] Modes modes;
    [SerializeField] string playerTag;
    [SerializeField] float distanceFromTarget;
    [SerializeField] float cameraSpeed;

    //.....................................................................
    //Menus 
    [SerializeField] GameObject loseMenu;

    //.....................................................................

    Transform playerTrans;
    Transform cameraTrans;
    BallBehaviour ballBehaviour;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;

        GetGroundChecker groundChecker = FindObjectOfType<GetGroundChecker>();
        if (groundChecker)
            playerTrans = groundChecker.GetTransform();

        cameraTrans = Camera.main.transform;
        ballBehaviour = FindObjectOfType<BallBehaviour>();
        loseMenu.SetActive(false);
    }

    public Modes GetGameMode()
    {
        return modes;
    }

    public Transform GetPlayerTrans()
    {
        return playerTrans;
    }

    public Transform GetCameraTrans()
    {
        return cameraTrans;
    }

    public float GetDistanceFromTarget()
    {
        return distanceFromTarget;
    }

    public float GetCameraSpeed()
    {
        return cameraSpeed;
    }

    //.....................................................................
    //Menus 
    public void DisplayLoseMenu()
    {
        loseMenu.SetActive(true);
    }
    //.....................................................................
    //Buttons

    public void RetryButton()
    {
        FindObjectOfType<CameraFollow>().ResetCamera();
        ballBehaviour.ResetPlayer();
        FindObjectOfType<PlatformManager>().ResetPlatforms();
        loseMenu.SetActive(false);
    }
    //.....................................................................
}
