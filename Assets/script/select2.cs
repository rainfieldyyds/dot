using System.Collections;
using UnityEngine;

public class VictoryTrigger2 : MonoBehaviour
{
    [Header("玩家控制脚本")]
    public MonoBehaviour playerController;   // 玩家控制脚本（如 PlayerMove）

    [Header("胜利UI")]
    public GameObject winUI;                 // 胜利UI

    [Header("胜利音效")]
    public AudioClip winSFX;
    public AudioSource audioSource;

    private bool triggered = false;

    private void Start()
    {
        // 自动获取或添加 AudioSource
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
                audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;

        if (collision.CompareTag("Player"))
        {
            triggered = true;

            // 禁用玩家控制
            if (playerController != null)
                playerController.enabled = false;

            // 显示胜利UI
            if (winUI != null)
                winUI.SetActive(true);

            // 播放胜利音效
            PlayWinSound();
        }
    }

    private void PlayWinSound()
    {
        if (winSFX != null && audioSource != null)
            audioSource.PlayOneShot(winSFX);
    }
}
