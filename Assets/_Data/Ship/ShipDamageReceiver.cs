using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{
    [Header("Ship Damage Receiver")]
    [SerializeField] protected ShootableObjectCtrl shootablObjectCtrl;

    [SerializeField] protected GameObject gameOver;
    public GameObject GameOver => gameOver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
        this.LoadGameOver();
    }

    protected virtual void LoadCtrl()
    {
        if (this.shootablObjectCtrl != null) return;
        this.shootablObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected virtual void LoadGameOver()
    {
        if (this.gameOver != null) return;
        this.gameOver = GameObject.Find("UIGameOver");
        Debug.Log(transform.name + ": LoadGameOver", gameObject);
    }

    protected override void OnDead()
    {
        this.shootablObjectCtrl.Despawn.DespawnObject();
        this.ShowGameOver();
    }

    protected virtual void ShowGameOver()
    {
        this.gameOver.SetActive(true);
    }

    public override void Reborn()
    {
        this.hpMax = this.shootablObjectCtrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
