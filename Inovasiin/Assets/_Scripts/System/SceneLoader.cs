using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : PersistentSingleton<SceneLoader>
{
    [SerializeField] private Slider slider;
    [SerializeField] private CanvasGroup canvasGroup;
    public void LoadScene(string sceneName){
        StartCoroutine(OpenLoading(sceneName));
    }
    IEnumerator OpenLoading(string name){
        slider.value = 0f;
        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;

        // TODO : Enter transition
        yield return new WaitForSecondsRealtime(0.3f);
        float _timer=0;
        AsyncOperation sceneLoaded = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        sceneLoaded.allowSceneActivation = false;
        sceneLoaded.completed += (async) => {
            Time.timeScale = 1f;
            LeanTween.alphaCanvas(canvasGroup, 0f, 0.3f).setIgnoreTimeScale(true);
        };
        while(_timer < 2f){
            slider.value = Mathf.Min(sceneLoaded.progress, _timer/2f);
            _timer += Time.unscaledDeltaTime;
            yield return null;
        }
        sceneLoaded.allowSceneActivation = true;
        
        yield return null;
    }
}