using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbitityWarpFromInput : AbitityWarp
{
    protected override void Update()
    {
        base.Update();
        this.UpdateKeyDirection();
    }

    protected virtual void UpdateKeyDirection()
    {
        this.keyDirection = InputManager.Instance.OnWarping == 1;
    }
}
