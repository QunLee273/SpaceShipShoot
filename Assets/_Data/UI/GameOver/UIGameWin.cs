using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameWin : ShipMonoBehaviour
{
    [SerializeField] protected GameObject gameWin;
    public GameObject GameWin => gameWin;

    public GameObject[] Ui;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameOver();
    }

    protected virtual void Update()
    {
        if (this.gameWin.activeSelf)
        {
            foreach (GameObject ui in Ui)
            {
                ui.SetActive(false);
            }
        }
    }

    protected virtual void LoadGameOver()
    {
        if (this.gameWin != null) return;
        this.gameWin = GameObject.Find("UIGameOver");
        Debug.Log(transform.name + ": LoadGameOver", gameObject);

        this.gameWin.SetActive(false);

        Ui = GameObject.FindGameObjectsWithTag("UI");
    }
}
