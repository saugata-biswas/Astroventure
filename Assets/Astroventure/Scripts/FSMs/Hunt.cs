using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunt : CompanionBaseFSM
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //if (navMeshAgent.enabled && CompanionNPC.GetComponent<CompanionBrain>().TargetEnemyGmObj == null)
        //{
        //    CompanionNPC.GetComponent<CompanionBrain>().StartHunting();
        //}
        if (navMeshAgent.enabled && CompanionNPC.GetComponent<CompanionBrain>().TargetEnemyGmObj != null)
            navMeshAgent.SetDestination(targetGmObj.transform.position);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (navMeshAgent.enabled && CompanionNPC.GetComponent<CompanionBrain>().TargetEnemyGmObj != null)
            navMeshAgent.SetDestination(targetGmObj.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //CompanionNPC.GetComponent<CompanionBrain>().StopHunting();
    }
}
