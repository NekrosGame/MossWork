using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 1f;
    public float jumpDuration = 0.8f; // ���� �ö󰬴� ������������� ��ü �ð�

    [SerializeField] private Transform playerImage; // Player ������ ��ġ�� Sprite/Animator ������Ʈ

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 moveInput;
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private Vector3 imageOriginPos;

    private static readonly int IsMove = Animator.StringToHash("IsMove");
    private static readonly int MoveY = Animator.StringToHash("MoveY");
    private static readonly int IsJump = Animator.StringToHash("IsJump");

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        // ���� ������Ʈ���� Animator�� SpriteRenderer ��������
        animator = playerImage.GetComponent<Animator>();
        spriteRenderer = playerImage.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �̵� �Է�
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // �ִϸ��̼� ó��
        animator.SetBool(IsMove, moveInput.x != 0 || moveInput.y != 0);
        animator.SetFloat(MoveY, moveInput.y);

        // �¿� ���� ó�� (�����̵�)
        if (moveInput.x != 0)
            spriteRenderer.flipX = moveInput.x < 0;

        // ���� �Է�
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTimer = 0f;
            imageOriginPos = playerImage.localPosition; // ���� ��ġ ����
            animator.SetTrigger(IsJump);
        }
    }

    void FixedUpdate()
    {
        // �̵� ó��
        Vector2 move = moveInput * moveSpeed;
        rb.velocity = move;

        // ���� ó�� (PlayerImage�� ���� ���)
        if (isJumping)
        {
            jumpTimer += Time.fixedDeltaTime;
            float progress = jumpTimer / jumpDuration;

            float offsetY = Mathf.Sin(progress * Mathf.PI) * jumpHeight;
            Vector3 offset = new Vector3(0f, offsetY, 0f);
            playerImage.localPosition = imageOriginPos + offset;

            if (progress >= 1f)
            {
                isJumping = false;
                playerImage.localPosition = imageOriginPos;
            }
        }
    }
}
