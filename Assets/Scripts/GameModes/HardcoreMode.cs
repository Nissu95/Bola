using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcoreMode : GameModes
{
    public override void Update()
    {
        Transform cameraTrans = GameManager.singleton.GetCameraTrans();
        float speed = GameManager.singleton.GetCameraSpeed();

        Vector3 position = cameraTrans.position;
        position.y += speed * Time.deltaTime;
        cameraTrans.position = position;
    }
}
