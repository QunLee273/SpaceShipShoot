using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : ShipMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 2;
    [SerializeField] protected bool isDead = false;

    protected AudioManager audioManager;

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public int HPMax
    {
        get { return hpMax; }
        set { hpMax = value; }
    }

    protected override void OnEnable()
    {
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();

        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.13f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Add(int add)
    {
        if (this.isDead) return;

        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;

        this.hp -= deduct;
        audioManager.PlaySFX(audioManager.hitClip);
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
