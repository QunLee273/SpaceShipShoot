using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseSetting : BaseButton
{
    public GameObject Setting;

    public GameObject[] Ui;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSetting();
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && this.Setting.activeSelf)
        {
            this.Setting.SetActive(false);
            Time.timeScale = 1;

            foreach (GameObject ui in Ui)
            {
                ui.SetActive(true);
            }
        }
    }

    protected virtual void LoadSetting()
    {
        if (this.Setting != null) return;
        this.Setting = GameObject.Find("UISetting");
        Debug.Log(transform.name + ": LoadSetting", gameObject);

        Ui = GameObject.FindGameObjectsWithTag("UI");
    }
    protected override void OnClick()
    {
        this.Setting.SetActive(false);
        Time.timeScale = 1;

        foreach (GameObject ui in Ui)
        {
            ui.SetActive(true);
        }
    }
}
