using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcoreMode : GameModes
{
    public override void Start()
    {
        cameraTrans = GameManager.singleton.GetCameraTrans();
        speed = GameManager.singleton.GetCameraSpeed();
    }

    public override void Update()
    {
        Vector3 position = cameraTrans.position;
        position.y += speed * Time.deltaTime;
        cameraTrans.position = position;
    }
}
