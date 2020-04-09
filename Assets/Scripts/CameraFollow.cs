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
                break;
            case Modes.Hardcore:
                gm = new HardcoreMode();
                break;
        }
    }

    private void FixedUpdate()
    {
        gm.Update();
    }
}