using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHp : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 100;

    protected override void FixedUpdate()
    {
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
    }

    protected override void OnChanged(float newValue)
    {
        //Debug.Log("newValue: " + newValue);
    }

    public virtual void SetMaxHp(float maxHP)
    {
        this.maxHP = maxHP;
    }

    public virtual void SetCurrentHp(float currentHP)
    {
        this.currentHP = currentHP;
    }
}
