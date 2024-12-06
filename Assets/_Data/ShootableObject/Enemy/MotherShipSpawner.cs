using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;

    [SerializeField] protected float paramIncreaseTime = 60f;
    [SerializeField] protected float elapsedTime = 0f;

    [SerializeField] protected int increaseHp = 10;

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null) Debug.LogError("Only 1 MotherShipSpawner allow to exist");
        MotherShipSpawner.instance = this;
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
            EnemyCtrl enemyCtrl = enemy.GetComponent<EnemyCtrl>();
            if (enemyCtrl != null)
            {
                enemyCtrl.DamageReceiver.HPMax += increaseHp;
            }
        }
    }
}