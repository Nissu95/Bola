using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMode : GameModes
{
    public override void Update(Transform cameraTrans, Transform target, float distanceFromTarget)
    {
        Vector3 position = cameraTrans.position;
        if (position.y < target.position.y - distanceFromTarget)
        {
            position.y = target.position.y - distanceFromTarget;
            cameraTrans.position = position;
        }
    }
}
