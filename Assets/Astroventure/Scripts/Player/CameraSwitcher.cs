using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

namespace Astroventure.Controls // namespace for game logic
{
    public class CameraSwitcher : MonoBehaviour, LookControls.IMouseActions
    {
        private LookControls lookControls;
        private bool isFocusPressed = false;
        private int numOfFocusPressed = 0;
        private bool afterFocusReset = true;

        [SerializeField] private GameObject mainCinemachineCamera;
        [SerializeField] private GameObject aimCamera;
        [SerializeField] private GameObject aimReticle;
        [SerializeField] private SimpleMoveAndAnimationController controller;
        [SerializeField] private GameObject animationRig;


        //[SerializeField] private Transform barrelTransform;
        [SerializeField] private Transform gunTargetTransform;

        public void OnMouseLook(InputAction.CallbackContext context)
        {
            // Do nothing
        }

        public void OnFocusAim(InputAction.CallbackContext context)
        {
            isFocusPressed = context.ReadValueAsButton();
            if (context.performed)
            {
                numOfFocusPressed = numOfFocusPressed + 1;
            }
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
            bool focusNow = (numOfFocusPressed % 2 != 0);

            if (focusNow)
            {
                mainCinemachineCamera.SetActive(false);
                aimCamera.SetActive(true);

                animationRig.GetComponent<Rig>().weight = 1.0f;
                RaycastHit hit;
                if (Physics.Raycast(aimCamera.transform.position, aimCamera.transform.forward, out hit, Mathf.Infinity))
                {
                    gunTargetTransform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                }
                else
                {
                    gunTargetTransform.position = aimCamera.transform.position + aimCamera.transform.forward * controller.MaxBulletTravelDistance;
                }

                if (afterFocusReset)
                {
                    // give some time before the aim camera blends in.
                    StartCoroutine(ShowReticle());
                    afterFocusReset = false;
                }

                if (controller.isMovePressed || controller.isJumpPressed)
                {
                    numOfFocusPressed = 0;
                }
            }
            else 
            {
                mainCinemachineCamera.SetActive(true);
                aimCamera.SetActive(false);
                aimReticle.SetActive(false);
                numOfFocusPressed = 0;
                afterFocusReset = true;
                animationRig.GetComponent<Rig>().weight = 0.0f;
            }
        }
    }
}
