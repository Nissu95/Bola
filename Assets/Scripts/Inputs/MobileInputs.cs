using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputs : AllInputs
{
    public override void UpdateInputs()
    {
        horizontal = Input.acceleration.x;
    }
}