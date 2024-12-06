using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{
    [Header("Ship Damage Receiver")]
    [SerializeField] protected ShootableObjectCtrl shootablObjectCtrl;

    [SerializeField] protected Renderer rendererSprite;
    public Renderer RendererSprite => rendererSprite;

    [SerializeField] protected GameObject gameOver;
    public GameObject GameOver => gameOver;

    [SerializeField] protected float immortalDuration = 1.5f;
    [SerializeField] protected float flashTime = 0.1f;
    [SerializeField] protected bool isImmortal = false;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
        this.LoadGameOver();
        this.LoadRendererSprite();
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

    protected virtual void LoadRendererSprite()
    {
        if (this.rendererSprite != null) return;
        this.rendererSprite = shootablObjectCtrl.Model.GetComponent<Renderer>();
        Debug.Log(transform.name + ": LoadRendererSprite", gameObject);
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

    protected void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Va chạm với: " + other.gameObject.name);
        if (other.transform.parent.CompareTag("Enemy") || other.transform.parent.CompareTag("Junk") && !isImmortal)
        {
            StartCoroutine(ImmortalCoroutine());
            Deduct(5);
        }
    }

    protected IEnumerator ImmortalCoroutine()
    {
        isImmortal = true;
        float timeRun = 0f;

        while (timeRun < immortalDuration)
        {
            rendererSprite.enabled = !rendererSprite.enabled;
            yield return new WaitForSeconds(flashTime); 
            timeRun += flashTime;
        }

        rendererSprite.enabled = true;
        isImmortal = false;
    }
}
