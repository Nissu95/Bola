﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMode : GameModes
{
    public NormalMode()
    {
        cameraTrans = GameManager.singleton.GetCameraTrans();
        target = GameManager.singleton.GetPlayerTrans();
        distanceFromTarget = GameManager.singleton.GetDistanceFromTarget();
    }

    /*public override void Start()
    {
        cameraTrans = GameManager.singleton.GetCameraTrans();
        target = GameManager.singleton.GetPlayerTrans();
        distanceFromTarget = GameManager.singleton.GetDistanceFromTarget();
    }*/

    public override void Update()
    {
        Vector3 position = cameraTrans.position;
        if (position.y < target.position.y - distanceFromTarget)
        {
            position.y = target.position.y - distanceFromTarget;
            cameraTrans.position = position;
        }
    }

    public override void Delete()
    {
        base.Delete();
    }
}
