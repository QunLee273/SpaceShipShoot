using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStart : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
