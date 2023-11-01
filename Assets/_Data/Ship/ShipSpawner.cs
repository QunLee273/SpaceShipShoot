using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : Spawner
{
    private static ShipSpawner instance;
    public static ShipSpawner Instance => instance;

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;

    public GameObject ship;

    protected override void Awake()
    {
        base.Awake();
        if (ShipSpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        ShipSpawner.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSO();
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/Ship/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadSO " + resPath, gameObject);
    }
}
