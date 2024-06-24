using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlayAgain : BaseButton
{
    protected string sceneName = "LoadingScene";
    protected override void OnClick()
    {
        this.LoadGame();
    }

    protected virtual void LoadGame()
    {
        SceneManager.LoadScene(this.sceneName);
        Time.timeScale = 1;
    }
}
