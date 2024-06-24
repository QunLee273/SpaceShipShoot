using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WornHole : ShipMonoBehaviour
{
    protected string sceneName = "Galaxy_1";

    protected virtual void OnMouseDown()
    {
        this.LoadGalaxy();
    }

    protected virtual void LoadGalaxy()
    {
        SceneManager.LoadScene(this.sceneName);
    }
}
