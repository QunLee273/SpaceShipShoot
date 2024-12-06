using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetting : ShipMonoBehaviour
{
    [Header("UI Setting")]
    [SerializeField] protected GameObject setting;
    public GameObject Setting => setting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSetting();
    }

    protected virtual void LoadSetting()
    {
        if (this.setting != null) return;
        this.setting = GameObject.Find("UISetting");
        Debug.Log(transform.name + ": LoadSetting", gameObject);

        setting.SetActive(false);
    }
}
