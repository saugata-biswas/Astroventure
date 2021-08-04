using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController animatorWithoutWeapon;
    [SerializeField] private AnimatorOverrideController animatorWithWeapon;
    private Animator currentAnimator;

    public bool weaponAtHand;
    private bool weaponAtHandInPrevFrame;


    private AnimatorOverrideController animatorOverrideController;

    void Start()
    {
        weaponAtHand = false;
        weaponAtHandInPrevFrame = weaponAtHand;
        animatorOverrideController = new AnimatorOverrideController();
        currentAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (weaponAtHand != weaponAtHandInPrevFrame)
        {
            if (weaponAtHand)
            {
                animatorOverrideController = animatorWithWeapon;
                currentAnimator.runtimeAnimatorController = animatorOverrideController;

                // put the transform at ground
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.833f, transform.position.z);
            }
            else
            {
                currentAnimator.runtimeAnimatorController = animatorWithoutWeapon;

                // lift the transform 
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.833f, transform.position.z);
            }
        }
        weaponAtHandInPrevFrame = weaponAtHand;
    }
}
