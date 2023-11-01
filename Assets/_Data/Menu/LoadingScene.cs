using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] protected Slider progressBar;
    [SerializeField] protected TextMeshProUGUI loadingText;

    protected AsyncOperation operation;

    private float currentValue;
    private float targetValue;

    [SerializeField]
    [Range(0, 1)]
    private float progressAnimationMultiplier = 0.25f;

    protected void Start()
    {
        progressBar.value = currentValue = targetValue = 0;

        var currentScene = SceneManager.GetActiveScene();
        operation = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);

        operation.allowSceneActivation = false;
    }

    protected void Update()
    {
        targetValue = operation.progress / 0.9f;

        currentValue = Mathf.MoveTowards(currentValue, targetValue, progressAnimationMultiplier * Time.deltaTime);
        progressBar.value = currentValue;

        loadingText.text =(currentValue * 100).ToString("F0") + "%";


        if (Mathf.Approximately(currentValue, 1))
        {
            operation.allowSceneActivation = true;
        }
    }
}
