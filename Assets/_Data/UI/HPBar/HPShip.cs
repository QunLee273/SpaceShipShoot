using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPShip : ShipMonoBehaviour
{
    [Header("HP Ship")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHp sliderHp;
    

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
    }

    protected virtual void LoadSliderHp()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponent<SliderHp>();
        Debug.LogWarning(transform.name + ": LoadSliderHp", gameObject);
    }

    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;

        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float maxHp = this.shootableObjectCtrl.DamageReceiver.HPMax;

        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(maxHp);
    }
}
