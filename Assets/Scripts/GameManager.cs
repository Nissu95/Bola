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

    Transform playerTrans;
    Transform cameraTrans;
    GameObject loseMenu;

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

    public void SetLoseMenu(GameObject _loseMenu)
    {
        loseMenu = _loseMenu;
        loseMenu.SetActive(false);
    }

    public void DisplayLoseMenu()
    {
        loseMenu.SetActive(true);
    }
}
