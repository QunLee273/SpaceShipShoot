using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ObjMovement
{
    [Header("Follow Target")]
    [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.GetTargetPosition();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }
}
