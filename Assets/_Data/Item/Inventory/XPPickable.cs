using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPPickable : ItemPickupable
{
    public int exp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExperienceBar.Instance.currentXP += exp;
        }
    }
}
