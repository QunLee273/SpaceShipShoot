using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICloseInventory : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
