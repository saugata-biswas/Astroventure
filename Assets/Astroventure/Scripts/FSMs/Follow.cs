using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : CompanionBaseFSM
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        if (navMeshAgent.enabled)
            navMeshAgent.SetDestination(targetGmObj.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var positionToLookAt = new Vector3(targetGmObj.transform.position.x, 0.5f, targetGmObj.gameObject.transform.position.z);
        //var positionToLookAt = targetGmObj.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        CompanionNPC.transform.LookAt(positionToLookAt);
        //CompanionNPC.transform.Rotate(0.01f, 0.2f, 0.0f);

        if (navMeshAgent.enabled)
            navMeshAgent.SetDestination(targetGmObj.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (navMeshAgent.enabled)
            navMeshAgent.SetDestination(CompanionNPC.transform.position);
    }
}
