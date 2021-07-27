using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Astroventure.Controls
{
    public class AnimationAndMovementController : MonoBehaviour, PlayerControls.IPlayerActions
    {
        private CharacterController controller;
        private PlayerControls playerControls;
        private Animator animator;

        [SerializeField] private float moveSpeed;
        [SerializeField] [Range(10.0f, 15.0f)] float rotationFactorPerFrame;
        [SerializeField] [Range(1.0f, 5.0f)] float runFactor;
        private Vector3 moveDirection;
        private Vector3 velocity;
        private bool isMovePressed = false;
        private bool isRunPressed = false;
        private bool isJumpPressed = false;

        [SerializeField] public float gravity = -9.8f;
        float groundedGravity = -0.05f;

        private float initialJumpVelocity;
        [SerializeField] [Range(0.3f, 1.2f)]private float maxJumpHeight;    // is actually the fraction of the body height the character will jump
        [SerializeField] [Range(0.1f, 4.0f)] private float maxJumpTime;
        private bool isJumping = false;
        private float fallMultiplier = 2.0f;


        // for storing optimized getter/setter parameter id
        private int isWalkingHash;
        private int isRunningHash;


        // a small float number to compare float values
        private const float epsilon = 0.0000001f;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var moveInput = context.action.ReadValue<Vector2>();
            // moveDirection doesn't need to be normalized here. normalization is already done on the InputActions
            moveDirection.x = moveInput.x;
            moveDirection.z = moveInput.y;
            //moveDirection = new Vector3(moveInput.x, moveDirection.y, moveInput.y);

            isMovePressed = (Mathf.Abs(moveInput.x - 0) > epsilon) || (Mathf.Abs(moveInput.y - 0) > epsilon);
        }

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

        public void OnShoot(InputAction.CallbackContext context)
        {
            //if(context.performed)
            //    Debug.Log("Shoot!");
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
            //Debug.Log("isJumpPressed: " + isJumpPressed.ToString());
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void handleAnimation()
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

        // this method has been taken from [iHeartGameDev, https://www.youtube.com/watch?v=bXNFxQpp2qk]
        private void handleRotation()
        {
            //Vector3 positionToLookAt = new Vector3(moveDirection.x, 0.0f, moveDirection.z);
            Vector3 positionToLookAt;
            positionToLookAt.x = moveDirection.x;
            positionToLookAt.y = 0.0f;
            positionToLookAt.z = moveDirection.z;

            Quaternion currentRotation = transform.rotation;

            if (isMovePressed)
            {
                Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
            }
        }

        private void handleGravity()
        {
            bool isFalling = moveDirection.y <= 0.0f || !isJumpPressed;

            if (controller.isGrounded)
            {
                moveDirection.y = groundedGravity;
            }
            else if (isFalling)
            {
                float previousYVelocity = moveDirection.y;
                float newYVelocity = moveDirection.y + (gravity * fallMultiplier * Time.deltaTime);
                // clamping is performed to prevent excessive high fallspeed
                float nextYVelocity = Mathf.Max((previousYVelocity + newYVelocity) / 2.0f, -20.0f);
                moveDirection.y = nextYVelocity;
            }
            else
            {
                //gravity = -9.8f; // not needed

                // without velocity Verlet and Eular integration
                //moveDirection.y += gravity * Time.deltaTime;

                // with velocity Verlet and Eular integration
                float previousYVelocity = moveDirection.y;
                float newYVelocity = moveDirection.y + (gravity * Time.deltaTime);
                float nextYVelocity = (previousYVelocity + newYVelocity) / 2.0f;
                moveDirection.y = nextYVelocity;
            }
        }

        void initializeJumpVars()
        {
            isJumping = false;
            float timeToApex = maxJumpTime / 2.0f;
            gravity = (-2.0f * maxJumpHeight) / Mathf.Pow(timeToApex, 2.0f);
            initialJumpVelocity = (2.0f * maxJumpHeight) / timeToApex;

            //Debug.Log("in initializeJumpVars, timeToApex: " + timeToApex.ToString());
            //Debug.Log("in initializeJumpVars, maxJumpTime: " + maxJumpTime.ToString());
            //Debug.Log("in initiallizeJumpVars, maxJumpHeight: " + maxJumpHeight.ToString());
            //Debug.Log("in initializeJumpVars, gravity: " + gravity.ToString());
            //Debug.Log("in initializeJumpVars, initialJumpVelocity: " + initialJumpVelocity.ToString());

        }

        void handleJump()
        {
            if (!isJumping && controller.isGrounded && isJumpPressed)
            {
                isJumping = true;
                moveDirection.y = (initialJumpVelocity + 0.0f)/ 2.0f; // assuming previous Y velocity is zero
                //Debug.Log("Jump initiated, initialJumpVelocity: " + initialJumpVelocity.ToString());
            }
            else if (!isJumpPressed && isJumping && controller.isGrounded)
            {
                isJumping = false;
            }
        }

        void Awake()
        {
            controller = GetComponent<CharacterController>();
            playerControls = new PlayerControls();
            playerControls.Player.SetCallbacks(this);
            animator = transform.GetChild(1).GetComponent<Animator>();

            isWalkingHash = Animator.StringToHash("isWalking");
            isRunningHash = Animator.StringToHash("isRunning");


            moveDirection = Vector3.zero;
            velocity = Vector3.zero;
            initializeJumpVars();
        }

        void Start()
        {

        }

        void Update()
        {
            
            handleRotation();
            handleAnimation();

            if (isRunPressed)
                controller.Move(moveDirection * moveSpeed * runFactor * Time.deltaTime);
            else
                controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            handleGravity();
            handleJump();

            
        }

    }
}   // !namespace Astroventure.Controls
