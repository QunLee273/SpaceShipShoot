﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigidbody();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.4f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.LogWarning(transform.name + " LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;

        if (itemCode == ItemCode.Experience)
        {
            itemPickupable.Picked();

            // Kiểm tra xem ExperienceBar.Instance có tồn tại hay không
            if (ExperienceBar.Instance != null)
            {
                int xpGained = 25; // giá trị XP nhặt được
                ExperienceBar.Instance.currentXP += xpGained;

                // Cập nhật thanh XP
                ExperienceBar.Instance.XPShowing();
            }
        }
        else
        {
            this.inventory.AddItem(itemInventory);
            itemPickupable.Picked();
        }
    }
}
