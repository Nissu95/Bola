using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputs : AllInputs
{
    public override void UpdateInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
}
