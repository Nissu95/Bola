using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllInputs
{
    protected float horizontal;

    public virtual void UpdateInputs() { }

    public float GetHorizontal()
    {
        return horizontal;
    }
}