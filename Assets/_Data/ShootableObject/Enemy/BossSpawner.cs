using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    private static BossSpawner instance;
    public static BossSpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (BossSpawner.instance != null) Debug.LogError("Only 1 BossSpawner allow to exist");
        BossSpawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newBoss = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newBoss);

        return newBoss;
    }

    protected virtual void AddHPBar2Obj(Transform newBoss)
    {
        if (newBoss == null)
        {
            Debug.LogError("newBoss is null");
            return;
        }
        ShootableObjectCtrl newEnemyCtrl = newBoss.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newBoss.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newBoss);

        newHpBar.gameObject.SetActive(true);
    }
}
