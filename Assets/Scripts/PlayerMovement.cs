using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        canMove = true;
    }

    //Moves player in chosen direction
    private void Update()
    {
        if (!canMove)
        {
            moveInput = Vector2.zero;       
            return;
        }
        rb.velocity = moveInput * moveSpeed;
    }

    //Triggers walking/idle animations
    public void Move(InputAction.CallbackContext context)
    {
        if (!canMove)
        {
            return;
        }
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
        if (moveInput.x != 0)
        {
            spriteRenderer.flipX = moveInput.x < 0;
        }

    }
}
