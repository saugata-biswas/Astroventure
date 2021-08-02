using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Astroventure.Controls // namespace for game logic
{
    public class CameraSwitcher : MonoBehaviour, LookControls.IMouseActions
    {
        private LookControls lookControls;
        private bool isFocusPressed = false;

        [SerializeField] private GameObject mainCinemachineCamera;
        [SerializeField] private GameObject aimCamera;
        [SerializeField] private GameObject aimReticle;

        public void OnMouseLook(InputAction.CallbackContext context)
        {
            // Do nothing
        }

        public void OnFocusAim(InputAction.CallbackContext context)
        {
            isFocusPressed = context.ReadValueAsButton();
        }

        /// <summary>
        /// Activates the PlayerControls for this script
        /// </summary>
        private void OnEnable()
        {
            lookControls.Enable();
        }

        /// <summary>
        /// Disables the PlayerControls's for this script
        /// </summary>
        private void OnDisable()
        {
            lookControls.Disable();
        }

        void Awake()
        {
            lookControls = new LookControls();
            lookControls.Mouse.SetCallbacks(this);
        }

        IEnumerator ShowReticle()
        {
            yield return new WaitForSeconds(0.25f);
            aimReticle.SetActive(enabled);
        }

        void Update()
        {
            if (isFocusPressed)
            {
                mainCinemachineCamera.SetActive(false);
                aimCamera.SetActive(true);

                // give some time before the aim camera blends in.
                StartCoroutine(ShowReticle());
            }
            else 
            {
                mainCinemachineCamera.SetActive(true);
                aimCamera.SetActive(false);
                aimReticle.SetActive(false);
            }
        }
    }
}
