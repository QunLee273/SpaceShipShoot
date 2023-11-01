using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjModifyAbtract : ShipMonoBehaviour
{
    [Header("Modify")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.GetComponent<ShootableObjectCtrl>();
        Debug.LogWarning(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }
}
