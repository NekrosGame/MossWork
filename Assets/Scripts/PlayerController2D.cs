using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 1f;
    public float jumpDuration = 0.3f; // ���� �ö󰬴� ������������� ��ü �ð�

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 moveInput;

    private bool isJumping = false;
    private Vector3 jumpStartPos;
    private float jumpTimer;

    private static readonly int IsMove = Animator.StringToHash("IsMove");
    private static readonly int MoveY = Animator.StringToHash("MoveY");
    private static readonly int IsJump = Animator.StringToHash("IsJump");

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �̵� �Է�
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // �ִϸ��̼� ó��
        animator.SetBool(IsMove, moveInput.x != 0 || moveInput.y != 0);
        animator.SetFloat(MoveY, moveInput.y);

        if (moveInput.x != 0)
            spriteRenderer.flipX = moveInput.x < 0;

        // ���� �Է�
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpStartPos = transform.position;
            jumpTimer = 0f;
            animator.SetTrigger(IsJump);
        }
    }

    void FixedUpdate()
    {
        // �̵� ó��
        Vector2 move = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        rb.velocity = move;

        // ���� �ִϸ��̼� ó��
        if (isJumping)
        {
            jumpTimer += Time.fixedDeltaTime;
            float progress = jumpTimer / jumpDuration;

            // �ε巯�� ���Ʒ� ���� � (sine ���)
            float offsetY = Mathf.Sin(progress * Mathf.PI) * jumpHeight;
            transform.position = new Vector3(transform.position.x, jumpStartPos.y + offsetY, transform.position.z);

            if (progress >= 1f)
            {
                // ���� �Ϸ� �� ��ġ ����
                isJumping = false;
                transform.position = new Vector3(transform.position.x, jumpStartPos.y, transform.position.z);
            }
        }
    }
}
