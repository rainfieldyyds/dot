using UnityEngine;

public class PlayerDeathTrigger : MonoBehaviour
{
    [Header("死亡UI")]
    public GameObject deathUI;

    [Header("死亡音效")]
    public AudioClip deathSFX;
    public AudioSource audioSource;

    private bool isDead = false;

    private void Start()
    {
        if (deathUI != null)
            deathUI.SetActive(false);

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
        if (isDead) return;

        if (collision.CompareTag("Player"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        // 显示死亡UI
        if (deathUI != null)
            deathUI.SetActive(true);

        // 播放死亡音效
        PlayDeathSound();

        // 暂停游戏
        Time.timeScale = 0f;
    }

    private void PlayDeathSound()
    {
        if (deathSFX != null && audioSource != null)
            audioSource.PlayOneShot(deathSFX);
    }
}
