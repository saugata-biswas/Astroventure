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

        [SerializeField] float initialJumpVelocity;
        float maxJumpHeight;
        float maxJumpTIme;



        // for storing optimized getter/setter parameter id
        private int isWalkingHash;
        private int isRunningHash;


        // a small float number to compare float values
        float epsilon = 0.0000001f;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var moveInput = context.action.ReadValue<Vector2>();
            // moveDirection doesn't need to be normalized here. normalization is already done on the InputActions
            moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

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
            if (context.performed)
            {
                isJumpPressed = true;
            }
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
            Vector3 positionToLookAt = new Vector3(moveDirection.x, 0.0f, moveDirection.z);
            Quaternion currentRotation = transform.rotation;

            if (isMovePressed)
            {
                Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
            }
        }

        private void handleGravity()
        {
            if (controller.isGrounded)
            {
                moveDirection.y = groundedGravity;
            }
            else 
            {
                moveDirection.y += gravity;
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
        }

        void Start()
        {

        }

        void Update()
        {
            handleGravity();

            if (isRunPressed)
                controller.Move(moveDirection.normalized * moveSpeed * runFactor * Time.deltaTime);
            else
                controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

            handleRotation();
            handleAnimation();
        }

    }
}   // !namespace Astroventure.Controls
