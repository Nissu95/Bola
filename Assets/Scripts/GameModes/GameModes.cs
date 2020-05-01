using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modes { Normal, Hardcore}

public class GameModes
{
    protected Transform cameraTrans;
    protected Transform target;
    protected float distanceFromTarget;
    protected float speed;

    public virtual void Start() { }
    public virtual void Update() { } 
}
