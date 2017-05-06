﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMovementOnUnitsDeath : UnitsDeathControlled
{
    private Movement movementScript;

    private void Start()
    {
        initListener();

        movementScript = GetComponent<Movement>();

        movementScript.MovementPaused = true;
    }

    protected override void activate()
    {
        movementScript.MovementPaused = false;
    }

    protected override void deactivate()
    {
        return;
    }
}