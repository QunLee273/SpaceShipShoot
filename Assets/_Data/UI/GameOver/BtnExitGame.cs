using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnExitGame : BaseButton
{
    protected string sceneName = "Menu";
    protected override void OnClick()
    {
        this.LoadMenu();
    }

    protected virtual void LoadMenu()
    {
        SceneManager.LoadScene(this.sceneName);
        Time.timeScale = 1;
    }
}
