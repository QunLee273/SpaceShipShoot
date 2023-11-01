using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : ShipMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    [SerializeField] protected PlayerAbility playerAbility;
    public PlayerAbility PlayerAbility => playerAbility;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
        this.LoadPlayerAbility();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.LogWarning(transform.name + ": LoadPlayerPickup", gameObject);
    }

    protected virtual void LoadPlayerAbility()
    {
        if (this.playerAbility != null) return;
        this.playerAbility = transform.GetComponentInChildren<PlayerAbility>();
        Debug.LogWarning(transform.name + ": LoadplayerAbility", gameObject);
    }
}
