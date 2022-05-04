using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControls : MonoBehaviour
{
    Animator animator;
    PlayerInputActions playerInputActions;
  
    public PlayerAttackManager attackManager;
    public HealthBarManager healthManager;

    public bool playerActive = false;
    //public bool playeractivated = false;
    public bool playerAlive = true;
    public bool blocking = false;

    //public CSVFileManager csvManager;

    [SerializeField] private bool playerFacingRight;
    private Rigidbody2D spriteBody2D;
    private Vector3 velocityZero = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0.2f;	// How much to smooth out the movement
    public bool isGrounded = true;
    float jumpForce = 600.0f;
    Vector2 newDirectionInput;
    Vector3 lastPosition;

    private void Awake()
    {
        spriteBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInputActions = new PlayerInputActions();

        playerInputActions.Gameplay.Movment.performed += context => newDirectionInput = context.ReadValue<Vector2>();
        playerInputActions.Gameplay.Movment.canceled += context => newDirectionInput = Vector2.zero;
       
        playerInputActions.Gameplay.Jump.performed += context => Jump();
        playerInputActions.Gameplay.Attack.performed += context => attackManager.Attack();
        playerInputActions.Gameplay.Block.performed += context => attackManager.Block();
        playerInputActions.Gameplay.Block.canceled += context => attackManager.EndBlock();

        lastPosition = transform.position;

        //inputManager.Gameplay.SaveFile.performed += context => csvManager.WriteToCSV();
    }

    private void Update()
    {
        if (lastPosition.y < (transform.position.y - 0.1))
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else
        {
            bool currentFallingStatus = animator.GetBool("isFalling");

            if (currentFallingStatus == true)
            {
                animator.SetBool("isFalling", false);
            }
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void MovePlayer()
    {
        if (playerActive && playerAlive && !blocking) {

            if (newDirectionInput.x != 0)
            {
                float movmentSpeed = 28.0f;
                float move;

                move = (newDirectionInput.x * Time.fixedDeltaTime) * movmentSpeed;

                // Move the character by finding the target velocity
                Vector3 targetVelocity = new Vector2(move * 10f, spriteBody2D.velocity.y);
                // And then smoothing it out and applying it to the character
                spriteBody2D.velocity = Vector3.SmoothDamp(spriteBody2D.velocity, targetVelocity, ref velocityZero, m_MovementSmoothing);

                if (newDirectionInput.x < 0 && playerFacingRight)
                {
                    FlipSprite();
                    playerFacingRight = false;
                }
                else if (newDirectionInput.x > 0 && !playerFacingRight)
                {
                    FlipSprite();
                    playerFacingRight = true;
                }
            }

            animator.SetFloat("playerSpeed", Mathf.Abs(newDirectionInput.x));
        }
    }

    private void Jump()
    {
        if (playerActive && playerAlive && !blocking)
        {
            if (isGrounded)
            {
                spriteBody2D.AddForce(new Vector2(0f, jumpForce));
                isGrounded = false;
                animator.SetBool("isJumping", true);
            }
        }
    }
  
    private void FlipSprite()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void DamageReaction(float currentHealth)
    {

        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            playerAlive = false;
        }

        animator.SetTrigger("damaged");
    }

    private void OnEnable()
    {
        playerInputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Gameplay.Disable();
    }   
}