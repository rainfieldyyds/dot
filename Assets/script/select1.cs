using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour
{
    [Header("玩家控制脚本")]
    public MonoBehaviour playerController;

    [Header("胜利UI")]
    public GameObject winUI;

    [Header("跳转设置")]
    public float delayTime = 2f;
    public string nextSceneName;

    [Header("音效")]
    public AudioClip winSound;
    private AudioSource audioSource;

    private bool triggered = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;

        if (collision.CompareTag("Player"))
        {
            triggered = true;

            if (playerController != null)
                playerController.enabled = false;

            if (winUI != null)
                winUI.SetActive(true);

            PlaySound();

            StartCoroutine(LoadNextScene());
        }
    }

    void PlaySound()
    {
        if (winSound != null)
            audioSource.PlayOneShot(winSound);
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(nextSceneName);
    }
}
