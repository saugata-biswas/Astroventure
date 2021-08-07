using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : CompanionBaseFSM
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (navMeshAgent.enabled && CompanionNPC.GetComponent<CompanionBrain>().TargetEnemyGmObj == null)
        {
            CompanionNPC.GetComponent<CompanionBrain>().StartHunting();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CompanionNPC.transform.Rotate(0.01f, 0.4f, 0.0f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CompanionNPC.GetComponent<CompanionBrain>().StopHunting();
    }
}
