using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : BaseButton
{
    public GameObject Setting;

    public GameObject[] Ui;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSetting();
    }

    protected override void Start()
    {
        base.Start();

        Setting.SetActive(false);
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.Setting.SetActive(true);
            Time.timeScale = 0;

            foreach (GameObject ui in Ui)
            {
                ui.SetActive(false);
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
        this.Setting.SetActive(true);
        Time.timeScale = 0;

        foreach (GameObject ui in Ui)
        {
            ui.SetActive(false);
        }
    }
}
