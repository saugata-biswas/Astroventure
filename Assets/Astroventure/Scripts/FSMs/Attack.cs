using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : NPCBaseFSM
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<NPCBrain>().StartFiring();
        navMeshAgent.enabled = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var positionToLookAt = new Vector3(targetGmObj.transform.position.x, 0.5f, targetGmObj.gameObject.transform.position.z);
        //var positionToLookAt = targetGmObj.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        NPC.transform.LookAt(positionToLookAt);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<NPCBrain>().StopFiring();
        navMeshAgent.enabled = true;
    }
}
