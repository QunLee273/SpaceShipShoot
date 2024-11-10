using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveWithKeys : ObjMovement
{
    [Header("Move Key")]
    [SerializeField] protected Transform moveTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
    }

    protected override void FixedUpdate()
    {
        this.GetKeyDirection();
        base.FixedUpdate();
    }

    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": LoadMoveTarget", gameObject);
    }

    protected void GetKeyDirection()
    {
        Vector4 dir = InputManager.Instance.Direction;

        if (dir.z == 1)
        {
            this.targetPosition = moveTarget.position;
            this.targetPosition.z = 0;
        }
    }

}
