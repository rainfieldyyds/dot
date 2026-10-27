using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller2 : MonoBehaviour
{
    [Header("移动参数")]
    public float moveSpeed = 5f;
    public float jumpForce = 2f;

    [Header("跳跃音效")]
    public AudioClip jumpSFX;
    private AudioSource audioSource;

    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    private float currentHorizontalInput = 0f;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

        // 自动获取或添加 AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // 水平移动
        currentHorizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(currentHorizontalInput * moveSpeed, rb.velocity.y);

        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;

            PlayJumpSound();
        }

        // 翻转角色朝向
        if (currentHorizontalInput > 0)
            spriterenderer.flipX = true;
        else if (currentHorizontalInput < 0)
            spriterenderer.flipX = false;
    }

    private void PlayJumpSound()
    {
        if (jumpSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSFX);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测是否与地面碰撞
        if (collision.gameObject.CompareTag("Untagged"))
        {
            isJumping = false;
        }
    }
}
