using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcoreMode : GameModes
{
    Timer timer = new Timer();

    public HardcoreMode()
    {
        cameraTrans = GameManager.singleton.GetCameraTrans();
        speed = GameManager.singleton.GetCameraSpeed();
    }

    /*public override void Start()
    {
        cameraTrans = GameManager.singleton.GetCameraTrans();
        speed = GameManager.singleton.GetCameraSpeed();
    }*/

    public override void Update()
    {
        timer.Count();
        Vector3 position = cameraTrans.position;
        position.y += speed * Time.deltaTime * timer.GetTime();
        cameraTrans.position = position;
    }

    public override void Delete()
    {
        base.Delete();
    }
}
