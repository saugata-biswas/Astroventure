// This script is adapted from [iHeartGameDev, https://www.youtube.com/watch?v=bXNFxQpp2qk]
// and [Brakeys, https://www.youtube.com/watch?v=4HpC--2iowE]
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Astroventure.Controls // namespace for game logic
{
    /// <summary>
    /// This class is responsible for simple character movement and animation.
    /// </summary>
    /// <remarks> Look (or Mouse Look) is not implemented by this class. 
    /// That is achieved by CinemachineInputProvider.</remarks>
    public class SimpleMoveAndAnimationController : MonoBehaviour, PlayerControls.IPlayerActions
    {
        private CharacterController controller;
        private PlayerControls playerControls;
        private Animator animator;

        [SerializeField] [Range(2.0f, 10.0f)] private float moveSpeed = 4.0f;
        [SerializeField] [Range(1.0f, 5.0f)] private float runFactor = 2.0f; // run factor is multiplied with moveSpeed to get the run speed

        [SerializeField] [Range(0.001f, 0.2f)] private float smoothTurnTime = 0.1f;
        private float smoothTurnVelocity;

        // variables related to user input
        private Vector3 moveDirection;
        private bool isMovePressed = false;
        private bool isRunPressed = false;
        private bool isJumpPressed = false;

        [SerializeField] public float gravity = -9.8f;
        private float groundedGravity = -0.05f; // gravity to be applied when the character controller is grounded

        private float initialJumpVelocity;  // at the begining of jump, initial velocity along y axis 
        [SerializeField] [Range(0.3f, 1.2f)] private float maxJumpHeight = 0.5f;    // is actually the fraction of the body height the character will jump
        [SerializeField] [Range(0.1f, 4.0f)] private float maxJumpTime = 0.5f;      // from going up to coming down
        private bool isJumping = false;
        private float fallMultiplier = 2.0f;

        // animator related variables
        // for storing optimized getter/setter parameter id
        private int isWalkingHash;
        private int isRunningHash;
        private int isJumpingHash;
        private bool isJumpAnimating = false;

        // a small float number to compare float values
        private const float epsilon = 0.0000001f;

        /// <summary>
        /// Implements PlayerControls.IPlayerActions's OnMovement method.
        /// </summary>
        /// <param name="context">Is a InputAction callback context.</param>
        public void OnMovement(InputAction.CallbackContext context)
        {
            var moveInput = context.action.ReadValue<Vector2>();
            // moveDirection doesn't need to be normalized here. normalization is already done on the InputActions
            moveDirection.x = moveInput.x;
            moveDirection.z = moveInput.y;

            isMovePressed = (Mathf.Abs(moveInput.x - 0) > epsilon) || (Mathf.Abs(moveInput.y - 0) > epsilon);
        }

        /// <summary>
        /// Implements PlayerControls.IPlayerActions's OnRun method.
        /// </summary>
        /// <param name="context">Is a InputAction callback context.</param>
        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                isRunPressed = true;
            }
            else if (context.canceled)
            {
                isRunPressed = false;
            }
        }

        /// <summary>
        /// Implements PlayerControls.IPlayerActions's OnShoot method.
        /// </summary>
        /// <param name="context">Is a InputAction callback context.</param>
        public void OnShoot(InputAction.CallbackContext context)
        {
            //if(context.performed)
            //    Debug.Log("Shoot!");
        }

        /// <summary>
        /// Implements PlayerControls.IPlayerActions's OnJump method.
        /// </summary>
        /// <param name="context">Is a InputAction callback context.</param>
        public void OnJump(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
        }

        /// <summary>
        /// Activates the PlayerControls for this script
        /// </summary>
        private void OnEnable()
        {
            playerControls.Enable();
        }

        /// <summary>
        /// Disables the PlayerControls's for this script
        /// </summary>
        private void OnDisable()
        {
            playerControls.Disable();
        }

        /// <summary>
        /// Handles the gravity working on the character controller.
        /// </summary>
        private void handleGravity()
        {
            bool isFalling = moveDirection.y <= 0.0f || !isJumpPressed;
            //bool isFalling = controller.velocity.y < 0.0f;

            if (controller.isGrounded)  // when the character controller is grounded
            {
                moveDirection.y = groundedGravity;
                animator.SetBool(isJumpingHash, false);

                if (isRunPressed && isJumpAnimating)
                {
                    animator.SetBool(isWalkingHash, false);
                    isJumpAnimating = false;
                }
            }
            else if (isFalling) // when the character controller is falling
            {
                // Velocity Verlet Integration
                float previousYVelocity = moveDirection.y;
                float newYVelocity = moveDirection.y + (gravity * fallMultiplier * Time.deltaTime);
                // clamping is performed to prevent excessive high fallspeed
                float nextYVelocity = Mathf.Max((previousYVelocity + newYVelocity) / 2.0f, -20.0f);
                moveDirection.y = nextYVelocity;
            }
            else // when the character controller has jumped and not yet falling
            {
                // gravity = -9.8f; // not needed
                // Eular Integration
                // moveDirection.y += gravity * Time.deltaTime;

                // Velocity Verlet Integration
                // with velocity Verlet and Eular integration
                float previousYVelocity = moveDirection.y;
                float newYVelocity = moveDirection.y + (gravity * Time.deltaTime);
                float nextYVelocity = (previousYVelocity + newYVelocity) / 2.0f;
                moveDirection.y = nextYVelocity;
            }
        }

        /// <summary>
        /// Handles the jump for the character controller.
        /// </summary>
        /// <remarks>Call handleGravity before handleJump in Update.</remarks>
        void handleJump()
        {
            if (!isJumping && controller.isGrounded && isJumpPressed)
            {
                isJumping = true;
                moveDirection.y = (initialJumpVelocity + 0.0f) / 2.0f; // assuming previous Y velocity is zero
                
                animator.SetBool(isJumpingHash, true);
                isJumpAnimating = true;
            }
            else if (!isJumpPressed && isJumping && controller.isGrounded)
            {
                isJumping = false;
            }
        }

        /// <summary>
        /// Handles the animator component connect to the attached gameObject or its children.
        /// </summary>
        private void handleWalkAndRunAnimation()
        {
            bool isWalking = animator.GetBool(isWalkingHash);
            bool isRunning = animator.GetBool(isRunningHash);

            if (isMovePressed && !isWalking)
            {
                animator.SetBool(isWalkingHash, true);
            }
            else if (!isMovePressed && isWalking)
            {
                animator.SetBool(isWalkingHash, false);
            }

            if ((isMovePressed && isRunPressed) && !isRunning)
            {
                animator.SetBool(isRunningHash, true);
            }
            else if ((!isMovePressed || !isRunPressed) && isRunning)
            {
                animator.SetBool(isRunningHash, false);
            }
        }

        /// <summary>
        /// Initializes the variables related to character controller jump.
        /// </summary>
        void initializeJumpVars()
        {
            isJumping = false;
            float timeToApex = maxJumpTime / 2.0f;
            gravity = (-2.0f * maxJumpHeight) / Mathf.Pow(timeToApex, 2.0f);
            initialJumpVelocity = (2.0f * maxJumpHeight) / timeToApex;
        }

        /// <summary>
        /// Initializes some varaibles before Start or Update is called.
        /// </summary>
        void Awake()
        {
            controller = GetComponent<CharacterController>();
            animator = transform.GetChild(1).GetComponent<Animator>();
            playerControls = new PlayerControls();
            playerControls.Player.SetCallbacks(this);
            
            isWalkingHash = Animator.StringToHash("isWalking");
            isRunningHash = Animator.StringToHash("isRunning");
            isJumpingHash = Animator.StringToHash("isJumping");

            moveDirection = Vector3.zero;
            initializeJumpVars();
        }

        /// <summary>
        /// Handles the character controller movement and animation each frame.
        /// </summary>
        void Update()
        {
            handleWalkAndRunAnimation();

            //if (moveDirection.magnitude >= 0.1f)
            if(isMovePressed)
            {
                // rotate only if the player moves; for rotation, don't consider the y axis values
                float turnAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, turnAngle, ref smoothTurnVelocity, smoothTurnTime);
                transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

                // find out move direction
                Vector3 ccMoveDirection = Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;
                ccMoveDirection = ccMoveDirection.normalized;
                ccMoveDirection.y = moveDirection.y;    // copy the jump parameters along y-axis.

                // perform move on character controller
                if (isRunPressed)
                {
                    controller.Move(ccMoveDirection * moveSpeed * runFactor * Time.deltaTime);
                }
                else
                {
                    controller.Move(ccMoveDirection * moveSpeed * Time.deltaTime);
                }
            }
            else
            {
                Vector3 ccJumpDirection = new Vector3(0.0f, moveDirection.y, 0.0f);
                controller.Move(ccJumpDirection * moveSpeed * Time.deltaTime);
            }

            handleGravity();    // handleGravity should be called before handleJump
            handleJump();
        }
    }

}   // !namespace Astroventure.Controls
