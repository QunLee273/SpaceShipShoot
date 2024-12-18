using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : ShipMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] public float shootDelay = 0.5f;
    [SerializeField] protected float shootTimer = 0f;

    [SerializeField] protected bool isShip = false;
    [SerializeField] protected bool isEnemy = false;

    [SerializeField] protected AudioManager audioManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadAudioManager();
    }

    void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected void LoadAudioManager()
    {
        if (this.audioManager != null) return;
        this.audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
        Debug.Log(transform.name + ": LoadAudioManager", gameObject);
    }

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        if (this.isShip)
        {
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
            if (newBullet == null) return;

            newBullet.gameObject.SetActive(true);
            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShooter(transform.parent);

            audioManager.PlaySFX(audioManager.atkClip);
        }

        if (this.isEnemy)
        {
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo, spawnPos, rotation);
            if (newBullet == null) return;

            newBullet.gameObject.SetActive(true);
            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShooter(transform.parent);
        }
    }

    protected abstract bool IsShooting();
}
