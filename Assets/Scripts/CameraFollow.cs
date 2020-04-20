using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameModes gm;

    private void Start()
    {
        switch (GameManager.singleton.GetGameMode())
        {
            case Modes.Normal:
                gm = new NormalMode();
                gm.Start();
                break;
            case Modes.Hardcore:
                gm = new HardcoreMode();
                gm.Start();
                break;
        }
    }

    private void FixedUpdate()
    {
        gm.Update();
    }
}