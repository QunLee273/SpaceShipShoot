using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPPickable : ItemPickupable
{
    private static XPPickable instance;
    public static XPPickable Instance => instance;

    public int exp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExperienceBar.Instance.currentXP += exp;
        }
    }
}
