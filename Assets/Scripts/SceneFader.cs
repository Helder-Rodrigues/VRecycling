using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(Fade(1f, 0f));
    }

    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeRoutine(sceneName));
    }

    IEnumerator FadeRoutine(string sceneName)
    {
        yield return StartCoroutine(Fade(0f, 1f));

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = color;

            time += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;
    }
}