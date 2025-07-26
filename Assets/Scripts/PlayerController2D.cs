using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 1f;
    public float jumpDuration = 0.8f; // 위로 올라갔다 내려오기까지의 전체 시간

    [SerializeField] private Transform playerImage; // Player 하위에 위치한 Sprite/Animator 오브젝트

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

        // 하위 오브젝트에서 Animator와 SpriteRenderer 가져오기
        animator = playerImage.GetComponent<Animator>();
        spriteRenderer = playerImage.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 이동 입력
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // 애니메이션 처리
        animator.SetBool(IsMove, moveInput.x != 0 || moveInput.y != 0);
        animator.SetFloat(MoveY, moveInput.y);

        // 좌우 반전 처리 (왼쪽이동)
        if (moveInput.x != 0)
            spriteRenderer.flipX = moveInput.x < 0;

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTimer = 0f;
            imageOriginPos = playerImage.localPosition; // 로컬 위치 저장
            animator.SetTrigger(IsJump);
        }
    }

    void FixedUpdate()
    {
        // 이동 처리
        Vector2 move = moveInput * moveSpeed;
        rb.velocity = move;

        // 점프 처리 (PlayerImage만 위로 띄움)
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
