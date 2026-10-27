using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelect : MonoBehaviour
{
    [Header("目标场景名")]
    public string sceneName;

    [Header("点击音效")]
    public AudioClip clickSFX;

    [Header("音效播放源")]
    public AudioSource audioSource;

    [Header("切换延迟")]
    public float delay = 0.15f;

    private bool isLoading = false;

    void OnMouseDown()
    {
        if (isLoading) return;

        if (!string.IsNullOrEmpty(sceneName))
        {
            StartCoroutine(LoadSceneWithSound());
        }
        else
        {
            Debug.LogWarning("未设置目标场景名：" + gameObject.name);
        }
    }

    IEnumerator LoadSceneWithSound()
    {
        isLoading = true;

        if (clickSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSFX);
        }

        yield return new WaitForSecondsRealtime(delay);

        SceneManager.LoadScene(sceneName);
    }
}
