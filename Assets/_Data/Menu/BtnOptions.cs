using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnOptions : BaseButton
{
    [SerializeField] protected GameObject uiOption;
    public GameObject UIOption => uiOption;

    protected override void OnClick()
    {
        this.LoadOptions();
    }

    protected virtual void LoadOptions()
    {
        uiOption.SetActive(true);
    }
}
