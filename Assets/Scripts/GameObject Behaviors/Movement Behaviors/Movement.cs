using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected bool movementPaused;

    public bool MovementPaused
    {
        get { return movementPaused; }
        set { movementPaused = value; }
    }
}
