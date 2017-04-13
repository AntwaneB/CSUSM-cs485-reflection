using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnBtnEvent : ButtonControlled
{
    protected override void activate()
    {
        this.gameObject.SetActive(false);
    }

    protected override void deactivate()
    {
        this.gameObject.SetActive(true);
    }
}
