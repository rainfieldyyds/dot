using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [Header("目标传送点")]
    public Transform targetPoint;

    [Header("是否只允许玩家触发")]
    public bool onlyPlayer = true;

    [Header("传送后的位置偏移")]
    public Vector3 offset;

    [Header("冷却时间（防止来回瞬移）")]
    public float cooldown = 0.3f;

    [Header("传送音效")]
    public AudioClip teleportSFX;
    public AudioSource audioSource;

    private bool canTeleport = true;

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
        if (!canTeleport) return;
        if (onlyPlayer && !collision.CompareTag("Player")) return;

        Teleport(collision.transform);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!canTeleport) return;
        if (onlyPlayer && !collision.CompareTag("Player")) return;

        Teleport(collision.transform);
    }

    void Teleport(Transform target)
    {
        canTeleport = false;

        // 播放音效
        PlayTeleportSound();

        // 传送位置
        target.position = targetPoint.position + offset;

        // 重置冷却
        Invoke(nameof(ResetTeleport), cooldown);
    }

    void ResetTeleport()
    {
        canTeleport = true;
    }

    private void PlayTeleportSound()
    {
        if (teleportSFX != null && audioSource != null)
            audioSource.PlayOneShot(teleportSFX);
    }
}
