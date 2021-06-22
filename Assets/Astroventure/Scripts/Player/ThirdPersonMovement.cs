/**
 * ThirdPersonMovement class
 * Contains all the methods for third person character movement.
 * Implementation is adapted from Brackey's tutorial at
 * https://www.youtube.com/watch?v=4HpC--2iowE
 * https://www.youtube.com/watch?v=_QajrabyTJc
 * https://www.youtube.com/watch?v=p-3S73MaDP8
 * for mouselook with new cinemachine
 * https://www.youtube.com/watch?v=we4CGmkPQ6Q
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace Astroventure.Controls {
    public class ThirdPersonMovement : MonoBehaviour, PlayerControls.IPlayerActions
    {
        [SerializeField] private float moveSpeed;
        private Vector3 moveDirection;

        private CharacterController controller;
        private PlayerControls playerControls;
        private InputAction movement;

        [SerializeField] private float smoothTurnTime = 0.1f;
        private float smoothTurnVelocity;

        private bool jump = false;
        [SerializeField] private float jumpHeight = 0.5f;
        [SerializeField] private float gravity = -9.81f;
        private Vector3 velocity;

        [HideInInspector] public int health = 100;
        [HideInInspector] public int life = 5;
        public TMP_Text playerHealth;
        public TMP_Text playerLife;
        public GameObject SceneMenu;
        public GameObject Inventory;
        public List<string> currentInventory;
        public TMP_Text InventoryText;

        void Awake()
        {
            currentInventory = new List<string>();
            currentInventory.Add("Gun");
            controller = GetComponent<CharacterController>();
            playerControls = new PlayerControls();
            playerControls.Player.SetCallbacks(this);
            moveDirection = Vector3.zero;
            velocity = Vector3.zero;
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var move = context.action.ReadValue<Vector2>();
            moveDirection = new Vector3(move.x, 0, move.y).normalized;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if(context.performed)
                Debug.Log("Shoot!");
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                jump = true;
            }
        }

        void Update()
        {
            bool groundedCC = controller.isGrounded;
            if (moveDirection.magnitude >= 0.1f)
            {
                float turnAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, turnAngle, ref smoothTurnVelocity, smoothTurnTime);
                transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

                Vector3 ccMoveDirection = Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;
                
                controller.Move(ccMoveDirection.normalized * moveSpeed * Time.deltaTime);
                //controller.Move(moveDirection * moveSpeed * Time.deltaTime);
            }
            if (groundedCC && jump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
                jump = false;
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (health <= 0)
            {
                health = 100;
                life -= 1;
            }

            playerHealth.text = health.ToString();
            if (life >= 0)
                playerLife.text = life.ToString();
            else if (life < 0)
            {
                playerLife.text = "You are dead!";
                SceneMenu.SetActive(true);
            }

            if (currentInventory.Count > 0)
            {
                InventoryText.text = "";
                for(int i = 0; i < currentInventory.Count; i++)
                {
                    InventoryText.text += currentInventory[i] + "\n";
                } 
            }

            //if (currentInventory.Count > 0)
            //{
            //    if (Inventory.activeSelf && Input.GetKeyDown(KeyCode.Alpha1))
            //    {

            //    }
            //}
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        public void ShowInventory()
        {
            Inventory.SetActive(true);
        }

        public void CloseInventory()
        {
            Inventory.SetActive(false);
        }
    }
}