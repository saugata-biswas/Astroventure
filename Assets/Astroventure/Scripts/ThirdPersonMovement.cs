using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Astroventure.Controls {
    public class ThirdPersonMovement : MonoBehaviour, PlayerControls.IPlayerActions
    {
        [SerializeField]
        private float moveSpeed;
        private float move;

        private PlayerControls playerControls;
        private InputAction movement;


        void Awake()
        {
            playerControls = new PlayerControls();
            playerControls.Player.SetCallbacks(this);
            moveSpeed = 10.0f;
            move = 0.0f;
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var move2d = context.action.ReadValue<Vector2>();
            Debug.Log(move2d.ToString());
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if(context.performed)
                Debug.Log("Shoot!");
        }


        void Update()
        {

        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }


    }
}