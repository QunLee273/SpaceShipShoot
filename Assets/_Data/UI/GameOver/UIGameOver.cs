using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : ShipMonoBehaviour
{
    [SerializeField] protected GameObject gameOver;
    public GameObject GameOver => gameOver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameOver();
        
    }

    protected virtual void LoadGameOver()
    {
        if (this.gameOver != null) return;
        this.gameOver = GameObject.Find("UIGameOver");
        Debug.Log(transform.name + ": LoadGameOver", gameObject);

        this.gameOver.SetActive(false);
    }
}
