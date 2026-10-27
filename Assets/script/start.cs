using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [Header("切换音效")]
    public AudioClip clickSFX;

    [Header("音效播放源")]
    public AudioSource audioSource;

    [Header("切换延迟")]
    public float delay = 0.2f;

    // 跳转到指定场景
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;

        if (clickSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSFX);
        }

        StartCoroutine(LoadSceneDelay(sceneName));
    }

    IEnumerator LoadSceneDelay(string sceneName)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }
}

