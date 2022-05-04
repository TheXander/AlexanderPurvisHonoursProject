using UnityEngine;

public class SceneBasedPlayerControls : MonoBehaviour
{
    // for navagating the city  
    public LevelLoader levelLoader;
    public LevelLoader.Levels newDestination = LevelLoader.Levels.City;
    public bool locationSet = false;
    float movmentSpeed = 22.0f;
    Animator animator;
    PlayerInputActions playerInputActions;
   
    [SerializeField] private bool playerFacingRight;
    private Rigidbody2D spriteBody2D;
    private Vector3 velocityZero = Vector3.zero;
    [Range(0, 1.0f)] [SerializeField] private float m_MovementSmoothing = 0.3f;	// How much to smooth out the movement
    Vector2 newDirectionInput;
   
    public RomeoData romeoData;
    public CamPlayerTracking trackingCam;
    public bool movmentLocked = false;

    // dialog / event bools
    public bool eventReady = false;
    public bool confirmingEvent = false;
    public bool eventConfirmed = false;
    bool eventActivated = false;

   
    public PlayerProgress playerProgress;
    public GameObject invitation;

    private void Awake()
    {
        spriteBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInputActions = new PlayerInputActions();
   
        playerInputActions.Gameplay.Movment.performed += context => newDirectionInput = context.ReadValue<Vector2>();
        playerInputActions.Gameplay.Movment.canceled += context => newDirectionInput = Vector2.zero;
             
        // for navagating the city  
        playerInputActions.Gameplay.EnterDoor.performed += context => EnterDoor();
        // interactions
        playerInputActions.Gameplay.Interact.performed += context => StartEvent();
        playerInputActions.Gameplay.Interact.canceled += context => StopEvent();

        if (romeoData.previousLocation == LevelLoader.Levels.CardGame ||
            romeoData.previousLocation == LevelLoader.Levels.Combat)
        {
            transform.position = romeoData.previousPlayerCoordinates;
            trackingCam.trackingActive = true;
        }
    }

    private void FixedUpdate()
    {
        if (!movmentLocked)
        {
            MovePlayer();
        }
    }// Created by ALexander Purvis copyright Alexander Purvis

    private void Update()
    {
        if (playerProgress.levelOneEventsComplete >= 3 && !playerProgress.julietsReady)
        {
            playerProgress.julietsReady = true;
        }

        if (playerProgress.julietsReady && !playerProgress.invitedToJuliets)
        {
            StopPlayer();
            invitation.SetActive(true);
            playerProgress.invitedToJuliets = true;
        }


        if (newDirectionInput.y > 0.95)
        {
            EnterDoor();
        }
      
        if (eventConfirmed && !eventActivated)
        {          
            switch (romeoData.currentEvent)
            {                
                case RomeoData.Events.CardGame:
                    if (locationSet)
                    {
                        romeoData.previousPlayerCoordinates = transform.position;
                        levelLoader.LoadLevel(newDestination);
                    }
                    break;
                case RomeoData.Events.Combat:                 
                    if (locationSet)
                    {       
                        romeoData.previousPlayerCoordinates = transform.position;
                        levelLoader.LoadLevel(newDestination);
                    }
                    break;
                case RomeoData.Events.Dialog:
                    StartDialog();
                    break;
                default:
                    break;
            }
            eventActivated = true;
        }
    }

    private void MovePlayer()
    {
       if (newDirectionInput.x != 0)
       {      
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

    private void FlipSprite()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void EnterDoor()
    {
        if (locationSet)
        {
            levelLoader.LoadLevel(newDestination);
        }       
    }

    void StartEvent()
    {
        if (!movmentLocked)
        {
            eventReady = true;
        }
    }

    void StopEvent()
    {
        
            eventReady = false;
        
    }


    public void StartDialog()
    {
        print("Dialog Started!");
        movmentLocked = true;
    }

    public void EndDialog()
    {
        print("Dialog Ended!");
        movmentLocked = false;
    }

   
    public void TurnPlayerLeft()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        playerFacingRight = false;
    }


    public void TurnPlayerRight()
    {
        if (transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);           
        }
        playerFacingRight = true;
    }


    private void OnEnable()
    {
        playerInputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Gameplay.Disable();
    }

    public void StopPlayer()
    {      
        spriteBody2D.velocity = new Vector3(0, 0, 0);
        animator.SetFloat("playerSpeed", 0.0f);
        movmentLocked = true;
        animator.SetTrigger("SetAsIdle");
    }

    public void StartPlayer()
    {
       
        movmentLocked = false;
    }
}
