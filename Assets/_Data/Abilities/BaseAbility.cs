using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : ShipMonoBehaviour
{
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;

    protected virtual void Update()
    {
        //
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
    }

    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = transform.parent.GetComponent<Abilities>();
        Debug.LogWarning(transform.name + ": LoadAbilities", gameObject);
    }

    
}
