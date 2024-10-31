using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    [SerializeField] protected float paramIncreaseTime = 60f;
    [SerializeField] protected float elapsedTime = 0f;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }

    protected void FixedUpdate()
    {
        UpdateTime();
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);

        return newEnemy;
    }

    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        if (newEnemy == null)
        {
            Debug.LogError("newEnemy is null");
            return;
        }
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHpBar.gameObject.SetActive(true);
    }

    protected void UpdateTime()
    {
        elapsedTime += Time.fixedDeltaTime;
        if (elapsedTime >= paramIncreaseTime)
        {
            IncreaseEnemyParam();
            elapsedTime = 0;
        }
    }

    protected void IncreaseEnemyParam()
    {
        foreach (Transform enemy in holder)
        {
            ShootableObjectCtrl shootableCtrl = enemy.GetComponent<ShootableObjectCtrl>();
            if (shootableCtrl != null)
            {
                shootableCtrl.DamageReceiver.HPMax += 10;
            }

            DamageSender damageSender = enemy.GetComponent<DamageSender>();
            if (damageSender != null)
            {
                damageSender.damage += 1;
            }
        }
    }
}