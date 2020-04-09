﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    [SerializeField] Modes modes;
    [SerializeField] string playerTag;
    [SerializeField] float distanceFromTarget;

    Transform playerTrans;
    Transform cameraTrans;

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
        //playerTrans = GameObject.FindGameObjectWithTag(playerTag).GetComponentInChildren<GetGroundChecker>().GetTransform();

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
}
