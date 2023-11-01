using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamReceiver : ShootableObjectDamReceiver
{
    [SerializeField] protected GameObject gameWin;

    [SerializeField] protected GameObject isSpawnner;
    protected override void OnDead()
    {
        base.OnDead();
        this.gameWin.SetActive(true);
        this.isSpawnner.SetActive(false);
    }
}
