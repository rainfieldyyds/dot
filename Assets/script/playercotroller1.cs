using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // 移动速度
    public float jumpForce = 2f;  // 最大跳跃力度
    public float jumpTime = 0.5f;  // 最大跳跃时间（按空格键的时间限制）

    private Rigidbody2D rb;
    private float jumpStartTime;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 获取左右移动输入
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // 跳跃控制
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)  // 仅在地面上跳跃
        {
            jumpStartTime = Time.time;
            isJumping = true;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            // 计算按住空格的时间
            float jumpTimeHeld = Time.time - jumpStartTime;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // 应用跳跃力度
            if (jumpTimeHeld >= jumpTime)
            {
                isJumping = false;  // 跳跃达到最大时间后停止增加跳跃力度
            }
        }

        // 跳跃释放
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
}
