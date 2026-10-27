using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartSceneButton : MonoBehaviour
{
    [Header("按钮点击音效")]
    public AudioClip clickSFX;
    public AudioSource audioSource;
    public void RestartScene()
    {
    PlayClickSound();

    Time.timeScale = 1f; 

    RestartAfterSound();
    }


    void RestartAfterSound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
    }

    void PlayClickSound()
    {
        if (clickSFX != null && audioSource != null)
            audioSource.PlayOneShot(clickSFX);
    }
}
