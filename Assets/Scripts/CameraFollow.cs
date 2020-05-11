using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameModes newGM = new GameModes();

    GameModes gm;
    Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
        ResetGameMode();

        /*switch (GameManager.singleton.GetGameMode())
        {
            case Modes.Normal:
                gm = new NormalMode();
                gm.Start();
                break;
            case Modes.Hardcore:
                gm = new HardcoreMode();
                gm.Start();
                break;
        }*/
    }

    private void FixedUpdate()
    {
        gm.Update();
    }

    public void ResetCamera()
    {
        transform.position = initialPos;
    }

    public void SetGameMode()
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

    public void ResetGameMode()
    {
        if (gm != null)
            gm.Delete();

        gm = newGM;
    }
}